using Sibers.DAL.Common;
using Sibers.DAL.Models;

namespace Sibers.DAL.RelationModels
{
    public class ProjectEmployee : IBaseEntity
    {
        public Project Project { get; set; }
        public long ProjectId { get; set; }
        public Employee Employee { get; set; }
        public long EmployeeId { get; set; }
    }
}
