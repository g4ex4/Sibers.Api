using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Sibers.BLL.DTO.EmployeeDto_s
{
    public class CreateEmployeeDto : IMapWith<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [JsonIgnore]
        public long? UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
        }
    }
}
