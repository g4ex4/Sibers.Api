using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Sibers.BLL.DTO.EmployeeDto_s
{
    public class EmployeeData
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }
        public long? UserId { get; set; }
    }
}
