using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sibers.BLL.Common.Exceptions;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.DAL.Interfaces;
using Sibers.DAL.Models;

namespace Sibers.BLL.Services.Implementation
{
    public class JobService : IJobService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public JobService(IMapper mapper, IUnitOfWork uow)
            => (_mapper, _uow) = (mapper, uow);
        public async Task<Response> CreateJob(CreateJobDto data)
        {
            var project = await _uow.GetRepository<Project>().FirstOrDefaultAsync(x => x.Id == data.ProjectId);
            if (project == null) throw new NotFoundException(nameof(project), data.ProjectId);
            var performer = await _uow.GetRepository<Employee>().FirstOrDefaultAsync(x => x.Id == data.PerformerId);

            Job newJob = new Job()
            {
                Name = data.Name,
                Priority = data.Priority,
                Comment = data.Comment,
                JobStatus = data.JobStatus,
                PerformerId = performer?.Id,
                ProjectId = project.Id,
                AuthorizerId = data.AuthorizerId
            };
            await _uow.GetRepository<Job>().AddAsync(newJob);
            await _uow.SaveChangesAsync();
            return new Response(200, $"{nameof(Job)} created with Id = {newJob.Id}", true);
        }

        public async Task<Response> DeleteJobById(long id)
        {
            var job = await _uow.GetRepository<Job>().FirstOrDefaultAsync(x => x.Id == id);
            if (job == null) throw new NotFoundException(nameof(job), id);
            _uow.GetRepository<Job>().Delete(job);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Project with Id = {id} deleted successfully", true);
        }

        public async Task<JobVM> EditJobById(JobVM data)
        {
            var job = await _uow.GetRepository<Job>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == data.Id);

            if (job == null) throw new NotFoundException(nameof(Job), data.Id);

            job = _mapper.Map<Job>(data);
            _uow.GetRepository<Job>().Update(job);
            await _uow.SaveChangesAsync();
            return _mapper.Map<JobVM>(job);
        }

        public async Task<List<JobData>> GetAllJobs()
        {
            var jobs = await _uow.GetRepository<Job>().GetAll()
                .ProjectTo<JobData>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return jobs;
        }

        public async Task<JobVM> GetJobDetailesById(long jobId)
        {
            var job = await _uow.GetRepository<Job>()
                .Include(p => p.Authorizer)
                .Include(p => p.Performer)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(x => x.Id == jobId);
            if (job == null) throw new NotFoundException(nameof(Job), jobId);

            return _mapper.Map<JobVM>(job);
        }

        public async Task<List<JobVM>> SearchJobs(SearchJobDto searchParams)
        {
            var jobs = _uow.GetRepository<Job>().GetAll()
                .Include(p => p.Authorizer)
                .Include(p => p.Performer)
                .Include(p => p.Project)
                .AsEnumerable();

            var result = _mapper.Map<List<JobVM>>(jobs);

            if (!result.Any()) return new List<JobVM> { };

            if (!string.IsNullOrEmpty(searchParams.Name))
                result = result.FindAll(x => x.Name == searchParams.Name);

            if (!string.IsNullOrEmpty(searchParams.Comment))
                result = result.FindAll(x => x.Comment == searchParams.Comment);

            if (searchParams.Priority != null)
                result = result.FindAll(x => x.Priority == searchParams.Priority);

            if (((int)searchParams.JobStatus) != null)
                result = result.FindAll(x => ((int)x.JobStatus) == ((int)searchParams.JobStatus));

            if (searchParams.AuthorizerId != null)
                result = result.FindAll(x => x.AuthorizerId == searchParams.AuthorizerId);

            if (searchParams.PerformerId != null)
                result = result.FindAll(x => x.Id == searchParams.PerformerId);

            if (searchParams.ProjectId != null)
                result = result.FindAll(x => x.ProjectId == searchParams.ProjectId);

            return result;
        }
    }
}
