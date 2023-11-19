using Shouldly;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.DAL.Models;
using Sibers.Tests.Common;
using System.Text.RegularExpressions;

namespace Sibers.Tests
{
    public class ProjectTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProject()
        {
            var request = new CreateProjectDto()
            {
                Name = "XUnitTest",
                CustomerName = "Sibers",
                PerformerName = "GTEXCorp",
                EndDate = DateTime.Now.AddDays(14),
                Priority = 1,
                ProjectManagerId = null
            };

            var response = TestHelper<Response>.MakeRequest(
                _client, "POST", "api/Project/Create", request);
            var stringResponse = $"{nameof(Project)} created with Id =";
            var regex = new Regex(stringResponse);

            Assert.Equal(200, response.StatusCode);
            Assert.Matches(regex, response.Message);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task GetAllProjects()
        {
            var response = TestHelper<List<ProjectVM>>.MakeRequest(
                _client, "GET", "api/Project/GetAllProjects");

            response.ShouldBeOfType<List<ProjectVM>>();
        }

        [Fact]
        public async Task GetProjectDetailesById()
        {
            var request = new ModifyByIdDto() { Id = 1 };

            var response = TestHelper<ProjectVM>.MakeRequest(
                _client, "GET", "api/Project/GetProjectDetailesById", request);

            response.ShouldBeOfType<ProjectVM>();
            response.ShouldNotBeNull();
        }

        [Fact]
        public async Task SearchProjects()
        {
            var request = new SearchProjectDto()
            {
                Name = "FreeProject"
            };

            var response = TestHelper<List<ProjectVM>>.MakeRequest(
                _client, "GET", "api/Project/SearchProject", queryParameters: request);

            response.ShouldBeOfType<List<ProjectVM>>();
            response.Count.ShouldBe(1);
        }

        [Fact]
        public async Task EditProjectById()
        {
            var request = new EditProjectDto()
            {
                Id = 1,
                ProjectManagerId = 2,
                Name = "EDITED",
                CustomerName = "after",
                PerformerName = "XUNITtest",
                EndDate = DateTime.Now.AddDays(14),
                Priority = 10
            };

            var response = TestHelper<ProjectData>.MakeRequest(
                _client, "PUT", "api/Project/EditProjectById", request);

            response.ShouldBeOfType<ProjectData>();
            response.ShouldNotBeNull();
        }

        [Fact]
        public async Task DeleteProjectById()
        {
            var request = new ModifyByIdDto() { Id = 2 };

            var response = TestHelper<Response>.MakeRequest(
                _client, "DELETE", "api/Project/DeleteProjectById", queryParameters: request);

            Assert.Equal(200, response.StatusCode);
            Assert.Equal($"Project with Id = {request.Id} deleted successfully", response.Message);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task DeleteProjectByName()
        {
            var request = new ModifyByNameDto() { Name = "FreeProject" };
            var response = TestHelper<Response>.MakeRequest(
                _client, "DELETE", "api/project/DeleteProjectByName", queryParameters: request);

            Assert.Equal(200, response.StatusCode);
            Assert.Matches($"Project with name = {request.Name} deleted successfully", response.Message);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task DeleteEmployeeFromProjectById()
        {
            var request = new ModifyEmployeeByIdsDto() { EmployeeId = 4, ProjectId = 1};

            var response = TestHelper<Response>.MakeRequest(
                _client, "DELETE", "api/Project/DeleteEmployeeFromProjectById", queryParameters: request);

            Assert.Equal(200, response.StatusCode);
            Assert.Equal($"Employee deleted successfully", response.Message);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task PutEmployeeToProject()
        {
            var request = new ModifyEmployeeByIdsDto()
            {
                EmployeeId = 4,
                ProjectId = 2
            };

            var response = TestHelper<ProjectVM>.MakeRequest(
                _client, "PUT", "api/Project/PutEmployeeToProject", queryParameters: request);

            response.Employees.ShouldSatisfyAllConditions(x => x.FirstOrDefault(e => e.Id == 4));
        }
    }
    
    class ModifyEmployeeByIdsDto
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
    }
}
