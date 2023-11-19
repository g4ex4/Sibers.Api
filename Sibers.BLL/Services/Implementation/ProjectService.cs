using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sibers.BLL.Common.Exceptions;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.DAL.Interfaces;
using Sibers.DAL.Models;
using Sibers.DAL.RelationModels;

namespace Sibers.BLL.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork uow, IMapper mapper)
            => (_uow, _mapper) = (uow, mapper);
        public async Task<Response> CreateProject(CreateProjectDto dto)
        {
            var existedProject = _uow.GetRepository<Project>()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == dto.Name.ToLower()).Result;
            if (existedProject != null) throw new ExistException(nameof(Project), dto.Name);

            Project newProject = _mapper.Map<Project>(dto);
            var projectManager = 
                await _uow.GetRepository<Employee>()
                .Include(x => x.ManagedProjects)
                .FirstOrDefaultAsync(x => x.Id == dto.ProjectManagerId);
            newProject.StartDate = DateTime.Now;
            newProject.ProjectManagerId = projectManager?.Id;

            await _uow.GetRepository<Project>().AddAsync(newProject);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Project created with Id = {newProject.Id}", true);
        }

        public async Task<Response> DeleteProjectById(long projectId)
        {
            var project = await _uow.GetRepository<Project>()
                .FirstOrDefaultAsync(x => x.Id == projectId);
            if (project == null) throw new NotFoundException(nameof(project), projectId);
            _uow.GetRepository<Project>().Delete(project);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Project with Id = {projectId} deleted successfully", true);
        }

        public async Task<Response> DeleteProjectByName(string name)
        {
            var project = await _uow.GetRepository<Project>()
                .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            if (project == null) throw new NotFoundException(nameof(project), name);
            _uow.GetRepository<Project>().Delete(project);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Project with name = {name} deleted successfully", true);
        }

        public async Task<Response> DeleteEmployeeFromProjectById(long employeeId , long projectId)
        {
            var project = await _uow.GetRepository<ProjectEmployee>()
                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.ProjectId == projectId);
            if (project == null) throw new NotFoundException(nameof(Project), employeeId);
            _uow.GetRepository<ProjectEmployee>().Delete(project);
            await _uow.SaveChangesAsync();
            return new Response(200, "Employee deleted successfully", true);
        }

        public async Task<ProjectData> EditProjectById(EditProjectDto dto)
        {
            var origEntity = _uow.GetRepository<Project>().AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.Id).Result;
            if (origEntity == null) throw new NotFoundException(nameof(Project), dto.Id);

            var projectManager = _uow.GetRepository<Employee>()
                .FirstOrDefaultAsync(x => x.Id == dto.ProjectManagerId).Result;

            origEntity = _mapper.Map<Project>(dto);
            origEntity.ProjectManagerId = projectManager?.Id;

            _uow.GetRepository<Project>().Update(origEntity);
            await _uow.SaveChangesAsync();
            return _mapper.Map<ProjectData>(origEntity);
        }

        public async Task<List<ProjectVM>> GetProjects()
        {
            var projects = await _uow.GetRepository<Project>().GetAll()
                .ProjectTo<ProjectVM>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return projects;
        }

        public async Task<ProjectVM> GetProjectDetailesById(long projectId)
        {
            var project = await _uow.GetRepository<Project>()
                .Include(p => p.Jobs)
                .Include(p => p.Employees)
                .Include(p => p.ProjectManager)
                .FirstOrDefaultAsync(x => x.Id == projectId);
            if (project == null) throw new NotFoundException(nameof(Project), projectId);

            return _mapper.Map<ProjectVM>(project);
        }
        public async Task<List<ProjectVM>> SearchProjects(SearchProjectDto searchParams)
        {
            var projects = _uow.GetRepository<Project>().GetAll()
                .Include(p => p.ProjectManager)
                .Include(p => p.Jobs)
                .Include(p => p.Employees)
                .AsEnumerable();

            if (!projects.Any()) return new List<ProjectVM> { };

            var result = _mapper.Map<List<ProjectVM>>(projects);

            if (!string.IsNullOrEmpty(searchParams.Name))
                result = result.FindAll(x => x.Name.ToLower() == searchParams.Name.ToLower());

            if(!string.IsNullOrEmpty(searchParams.CustomerName))
                result = result.FindAll(x => x.CustomerName.ToLower() == searchParams.CustomerName.ToLower());

            if (!string.IsNullOrEmpty(searchParams.PerformerName))
                result = result.FindAll(x => x.PerformerName.ToLower() == searchParams.PerformerName.ToLower());

            if (searchParams.Priority != null)
                result = result.FindAll(x => x.Priority == searchParams.Priority);

            if (searchParams.StartDate != null)
                result = result.FindAll(x => x.StartDate == searchParams.StartDate);

            if (searchParams.EndDate != null)
                result = result.FindAll(x => x.EndDate == searchParams.EndDate);

            if (searchParams.ProjectManagerId != null)
                result = result.FindAll(x => x.ProjectManagerId == searchParams.ProjectManagerId);

            if (searchParams.ProjectId != null)
                result = result.FindAll(x => x.Id == searchParams.ProjectId);

            if (searchParams.EmployeeId != null)
                result = result.FindAll(x => x.Employees.FirstOrDefault(e => e.Id == searchParams.EmployeeId) != null);

            return result;


        }

        public async Task<ProjectVM> PutEmployeeToProject(long employeeId, long projectId)
        {
            var employee = await _uow.GetRepository<Employee>()
                .FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee == null) throw new NotFoundException(nameof(employee), employeeId);

            var project = await _uow.GetRepository<Project>()
                .FirstOrDefaultAsync(x => x.Id == projectId);
            if (project == null) throw new NotFoundException(nameof(project), projectId);

            ProjectEmployee projectEmployee = new ProjectEmployee()
            {
                EmployeeId = employeeId,
                ProjectId = projectId,
                Employee = employee,
                Project = project
            };

            await _uow.GetRepository<ProjectEmployee>().AddAsync(projectEmployee);
            await _uow.SaveChangesAsync();

            var projectData = await _uow.GetRepository<Project>()
                .Include(p => p.Employees)
                .Include(p => p.ProjectManager)
                .FirstOrDefaultAsync(x => x.Id == projectId
                && x.Employees.FirstOrDefault(e => e.Id == employeeId) != null);

            return _mapper.Map<ProjectVM>(projectData);

        }
    }
}
