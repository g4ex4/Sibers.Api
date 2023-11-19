using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sibers.BLL.Common.Exceptions;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.DAL.Enums;
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
        public async Task<Response> CreateJob(CreateJobDto dto)
        {
            var project = await _uow.GetRepository<Project>().FirstOrDefaultAsync(x => x.Id == dto.ProjectId);
            if (project == null) throw new NotFoundException(nameof(project), dto.ProjectId);

            var existedJob = _uow.GetRepository<Job>()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == dto.Name.ToLower()).Result;
            if (existedJob != null) throw new ExistException(nameof(Job), dto.Name);

            var performer = await _uow.GetRepository<Employee>().FirstOrDefaultAsync(x => x.Id == dto.PerformerId);

            Job job = _mapper.Map<Job>(dto);
            job.PerformerId = performer?.Id;

            await _uow.GetRepository<Job>().AddAsync(job);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Job created with Id = {job.Id}", true);
        }

        public async Task<Response> DeleteJobById(long id)
        {
            var job = await _uow.GetRepository<Job>().FirstOrDefaultAsync(x => x.Id == id);
            if (job == null) throw new NotFoundException(nameof(job), id);
            _uow.GetRepository<Job>().Delete(job);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Job with Id = {id} deleted successfully", true);
        }

        public async Task<Response> DeleteJobByName(string name)
        {
            var job = await _uow.GetRepository<Job>()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            if (job == null) throw new NotFoundException(nameof(job), name);
            _uow.GetRepository<Job>().Delete(job);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Job with name = {name} deleted successfully", true);
        }

        public async Task<JobData> EditJobById(JobData dto)
        {
            var job = await _uow.GetRepository<Job>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (job == null) throw new NotFoundException(nameof(Job), dto.Id);

            var project = await _uow.GetRepository<Project>()
                .FirstOrDefaultAsync(x => x.Id == dto.ProjectId);
            if (project == null) throw new NotFoundException(nameof(Project), dto.ProjectId);

            var performer = await _uow.GetRepository<Employee>().FirstOrDefaultAsync(x => x.Id == dto.PerformerId);
            if (performer == null) throw new NotFoundException(nameof(Employee), dto.PerformerId);
            dto.AuthorizerId = job.AuthorizerId;

            job = _mapper.Map<Job>(dto);
            _uow.GetRepository<Job>().Update(job);
            await _uow.SaveChangesAsync();
            return _mapper.Map<JobData>(job);
        }

        public async Task<List<JobVM>> GetAllJobs()
        {
            var jobs = await _uow.GetRepository<Job>().GetAll()
                .Include(p => p.Authorizer)
                .Include(p => p.Performer)
                .Include(p => p.Project)
                .ProjectTo<JobVM>(_mapper.ConfigurationProvider)
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
                result = result.FindAll(x => x.Name.ToLower() == searchParams.Name.ToLower());

            if (!string.IsNullOrEmpty(searchParams.Comment))
                result = result.FindAll(x => x.Comment.ToLower() == searchParams.Comment.ToLower());

            if (searchParams.Priority != null)
                result = result.FindAll(x => x.Priority == searchParams.Priority);

            if (searchParams.JobStatus != null)
                result = result.FindAll(x => ((int)x.JobStatus) == ((int)searchParams.JobStatus));

            if (searchParams.AuthorizerId != null)
                result = result.FindAll(x => x.AuthorizerId == searchParams.AuthorizerId);

            if (searchParams.PerformerId != null)
                result = result.FindAll(x => x.Id == searchParams.PerformerId);

            if (searchParams.ProjectId != null)
                result = result.FindAll(x => x.ProjectId == searchParams.ProjectId);

            return result;
        }

        public async Task<JobData> SetStatusToJobById(long id, JobStatus status)
        {
            var job = await _uow.GetRepository<Job>()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (job == null) throw new NotFoundException(nameof(Job), id);

            job.JobStatus = status;
            _uow.GetRepository<Job>().Update(job);
            await _uow.SaveChangesAsync();
            return _mapper.Map<JobData>(job);
        }

        public async Task<JobData> SetStatusToJobByName(string name, JobStatus status)
        {
            var job = await _uow.GetRepository<Job>()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (job == null) throw new NotFoundException(nameof(Job), name);

            job.JobStatus = status;
            _uow.GetRepository<Job>().Update(job);
            await _uow.SaveChangesAsync();
            return _mapper.Map<JobData>(job);
        }
    }
}
