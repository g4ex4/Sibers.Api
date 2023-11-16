using Sibers.BLL.DTO.JobDto_s;
using Sibers.BLL.DTO.ProjectDto_s;
using Sibers.WebAPI.Models;

namespace Sibers.WebAPI.Common.Helpers
{
    public static class FilterByRole
    {
        public static List<ProjectVM> FilterProjects(List<ProjectVM> projects, long? roleId, long? userId)
        {
            switch (roleId)
            {
                case 1:
                    return projects.FindAll(x => x.Employees.Any())
                        .FindAll(x => x.Employees.FirstOrDefault(x => x.UserId == userId) != null);
                case 2:
                    return projects.FindAll(x => x.ProjectManager?.UserId == userId);

            }
            return projects;
        }

        //public static List<JobVM> FilterJobs(List<JobVM> jobs, long? roleId, long? userId)
        //{
        //    switch (roleId)
        //    {
        //        case 1:
        //            return jobs.FindAll(x => x.Performer.UserId == userId);
        //        case 2:
        //            return jobs.FindAll(x => x.Project.ProjectManagerId == userId);

        //    }
        //    return jobs;
        //}
    }
}
