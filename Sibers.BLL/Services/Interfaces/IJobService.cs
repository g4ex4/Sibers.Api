using Sibers.BLL.Common.Responses;
using Sibers.BLL.DTO.JobDto_s;

namespace Sibers.BLL.Services.Interfaces
{
    public interface IJobService : IService
    {
        public Task<Response> CreateJob(CreateJobDto data);
        public Task<List<JobData>> GetAllJobs();
        public Task<JobVM> GetJobDetailesById(long id);
        public Task<JobVM> EditJobById(JobVM data);
        public Task<Response> DeleteJobById(long id);
        public Task<List<JobVM>> SearchJobs(SearchJobDto searchparams);

    }
}
