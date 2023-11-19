using Shouldly;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.EmployeeDto_s;
using Sibers.Tests.Common;

namespace Sibers.Tests
{
    public class EmployeeTests : TestCommandBase
    {
        [Fact]
        public async Task CreateEmployee()
        {
            var request = new CreateEmployeeDto()
            {
                FirstName = "XUnitName",
                MiddleName = "XUNITMIDDLENAME",
                LastName = "LastNameOfXunitTEst",
                Email = "XUNIT@SIBERS.COM"
            };

            var response = TestHelper<Response>.MakeRequest(
                _client, "POST", "api/Employee/Create", bodyParameters: request);

            Assert.Equal(200, response.StatusCode);
            Assert.Matches($"Created employee with Id = ", response.Message);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task GetAllEmployee()
        {
            var response = TestHelper<List<EmployeeData>>.MakeRequest(
                _client, "GET", "api/Employee/GetAll");

            response.ShouldBeOfType<List<EmployeeData>>();
        }

        [Fact]
        public async Task GetEmployeeDetailesById()
        {
            var request = new ModifyByIdDto() { Id = 1 };

            var response = TestHelper<EmployeeVM>.MakeRequest(
                _client, "GET", "api/Employee/GetEmployeeDetailesById", request);

            response.ShouldBeOfType<EmployeeVM>();
        }

        [Fact]
        public async Task EditEmployeeById()
        {
            var request = new EmployeeData()
            {
                Id = 5,
                FirstName = "Edited",
                MiddleName = "After",
                LastName = "XunitTest",
                Email = "XXX@gmail.com",
            };

            var response = TestHelper<EmployeeVM>.MakeRequest(
                _client, "PUT", "api/Employee/EditEmployeeById", request);

            response.ShouldBeOfType<EmployeeVM>();
            response.ShouldNotBeNull();
        }

        [Fact]
        public async Task DeleteEmployeeById()
        {
            var request = new ModifyByIdDto() { Id = 5 };

            var response = TestHelper<Response>.MakeRequest(
                _client, "DELETE", "api/Employee/DeleteEmployeeById", queryParameters: request);

            Assert.Equal(200, response.StatusCode);
            Assert.Equal($"Employee with Id = {request.Id} deleted successfully", response.Message);
            Assert.True(response.IsSuccess);
        }
    }
}
