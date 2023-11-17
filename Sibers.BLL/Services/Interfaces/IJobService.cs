using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.JobDto_s;
using Sibers.DAL.Enums;

namespace Sibers.BLL.Services.Interfaces
{
    public interface IJobService : IService
    {
        public Task<Response> CreateJob(CreateJobDto data);
        public Task<List<JobVM>> GetAllJobs();
        public Task<JobVM> GetJobDetailesById(long id);
        public Task<JobData> EditJobById(JobData data);
        public Task<Response> DeleteJobById(long id);
        public Task<List<JobVM>> SearchJobs(SearchJobDto searchparams);
        public Task<JobData> SetStatusToJob(long id, JobStatus status);

    }
}
