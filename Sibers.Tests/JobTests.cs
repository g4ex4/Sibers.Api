using Shouldly;
using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.DAL.Enums;
using Sibers.DAL.Models;
using Sibers.Tests.Common;

namespace Sibers.Tests
{
    public class JobTests : TestCommandBase
    {
        [Fact]
        public async Task CreateJob()
        {
            var request = new CreateJobDto()
            {
                Name = "XUnitJob",
                Comment = "XUnitComment",
                JobStatus = JobStatus.ToDo,
                Priority  = 0,
                ProjectId = 1
            };

            var response = TestHelper<Response>.MakeRequest(
                _client, "POST", "api/Job/Create", request);

            Assert.Equal(200, response.StatusCode);
            Assert.Matches($"{nameof(Job)} created with Id",
                response.Message);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task GetAllJobs()
        {
            var response = TestHelper<List<JobVM>>.MakeRequest(
                _client, "GET", "api/Job/GetAllJobs");

            response.ShouldBeOfType<List<JobVM>>();
        }

        [Fact]
        public async Task GetJobDetailesById()
        {
            var request = new ModifyByIdDto() { Id = 1 };

            var response = TestHelper<JobVM>.MakeRequest(
                _client, "GET", "api/Job/GetJobDetailesById", request);

            response.ShouldBeOfType<JobVM>();
            response.ShouldNotBeNull();
        }

        [Fact]
        public async Task EditJobById()
        {
            var request = new JobData()
            {
                Id = 1,
                Name = "EDITED",
                Comment = "AFTERXUNIT",
                Priority = 10,
                AuthorizerId = 0,
                PerformerId = 4,
                ProjectId = 2,
                JobStatus = JobStatus.InProgress,
            };

            var response = TestHelper<JobData>.MakeRequest(
                _client, "PUT", "api/Job/EditJobById", request);

            response.ShouldBeOfType<JobData>();
            response.ShouldNotBeNull();
        }

        [Fact]
        public async Task SetStatusToJobByName()
        {
            var request = new SetStatusDto()
            {
                Name = "Job - GTEX Project",
                Status = JobStatus.Done
            };

            var response = TestHelper<JobData>.MakeRequest(
                _client, "PUT", "api/Job/SetStatusToJobByName", queryParameters: request);

            response.ShouldBeOfType<JobData>();
            response.JobStatus.ShouldBe(JobStatus.Done);
        }

        [Fact]
        public async Task SetStatusToJobById()
        {
            var request = new SetStatusDto()
            {
                Id = 1,
                Status = JobStatus.InProgress
            };

            var response = TestHelper<JobData>.MakeRequest(
                _client, "PUT", "api/Job/SetStatusToJobById", queryParameters: request);

            response.ShouldBeOfType<JobData>();
            response.JobStatus.ShouldBe(JobStatus.InProgress);
        }

        [Fact]
        public async Task SearchJobs()
        {
            var request = new SearchJobDto()
            {
                Name = "Job - Sibers Project"
            };

            var response = TestHelper<List<JobVM>>.MakeRequest(
                _client, "GET", "api/Job/SearchJobs", queryParameters: request);

            response.ShouldBeOfType<List<JobVM>>();
        }

        [Fact]
        public async Task DeleteJobById()
        {
            var request = new ModifyByIdDto() { Id = 2 };

            var response = TestHelper<Response>.MakeRequest(
                _client, "DELETE", "api/Job/DeleteJobById", queryParameters: request);

            Assert.Equal(200, response.StatusCode);
            Assert.Equal($"Job with Id = {request.Id} deleted successfully", response.Message);
            Assert.True(response.IsSuccess);
        }

        [Fact]
        public async Task DeleteJobByName()
        {
            var request = new ModifyByNameDto() { Name = "Job - Sibers Project" };
            var response = TestHelper<Response>.MakeRequest(
                _client, "DELETE", "api/Job/DeleteJobByName", queryParameters: request);

            Assert.Equal(200, response.StatusCode);
            Assert.Matches($"Job with name = {request.Name} deleted successfully", response.Message);
            Assert.True(response.IsSuccess);
        }
    }

    class SetStatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public JobStatus Status { get; set; }
    }
}
