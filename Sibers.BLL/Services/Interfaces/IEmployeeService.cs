using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.EmployeeDto_s;

namespace Sibers.BLL.Services.Interfaces
{
    public interface IEmployeeService : IService
    {
        Task<Response> CreateEmployee(CreateEmployeeDto dto);
        Task<EmployeeData[]> GetAllEmployees();
        Task<EmployeeData> EditEmployeeById(EmployeeData data);
        Task<Response> DeleteEmployeeById(long id);
        Task<EmployeeVM> GetEmployeeDetailesById(long employeeId);

    }
}
