using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Sibers.BLL.Common.Exceptions;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.BLL.Services.Interfaces;
using Sibers.DAL.Interfaces;
using Sibers.DAL.Models;

namespace Sibers.BLL.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWork uow, IMapper mapper)
            => (_uow, _mapper) = (uow, mapper);
        public async Task<Response> CreateEmployee(CreateEmployeeDto dto)
        {
            dto.UserId = new Random().Next(100, 1000);
            Employee newEmployee = _mapper.Map<Employee>(dto);
            await _uow.GetRepository<Employee>().AddAsync(newEmployee);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Created employee with Id = {newEmployee.Id}", true);

        }

        public async Task<Response> DeleteEmployeeById(long id)
        {
            var employee = await _uow.GetRepository<Employee>().FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null) throw new NotFoundException(nameof(employee), id);
            _uow.GetRepository<Employee>().Delete(employee);
            await _uow.SaveChangesAsync();
            return new Response(200, $"Employee with Id = {id} deleted successfully", true);
        }

        public async Task<List<EmployeeData>> GetAllEmployees()
        {
            return await _uow.GetRepository<Employee>().GetAll()
                .ProjectTo<EmployeeData>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<EmployeeVM> GetEmployeeDetailesById(long employeeId)
        {
            var employee = await _uow.GetRepository<Employee>()
                .Include(e => e.ManagedProjects)
                .Include(e => e.Projects)
                .Include(e => e.PerformingJobs)
                .Include(e => e.AuthorizedJobs)
                .FirstOrDefaultAsync(x => x.Id == employeeId);
            if (employee == null) throw new NotFoundException(nameof(Employee), employeeId);

            return _mapper.Map<EmployeeVM>(employee);                
        }

        public async Task<EmployeeData> EditEmployeeById(EmployeeData data)
        {
            var employee = await _uow.GetRepository<Employee>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == data.Id);
            
            if (employee == null) throw new NotFoundException(nameof(Employee), data.Id);

            data.UserId = employee.Id;
            employee = _mapper.Map<Employee>(data);
            _uow.GetRepository<Employee>().Update(employee);
            await _uow.SaveChangesAsync();
            return _mapper.Map<EmployeeData>(employee);
        }
    }
}
