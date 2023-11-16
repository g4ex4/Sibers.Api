using AutoMapper;
using Sibers.BLL.Common.Mappings;
using Sibers.BLL.DTO.EmployeeDto_s;
using System.ComponentModel.DataAnnotations;

namespace Sibers.WebAPI.Models.DTO_s
{
    public class RegisterDto : IMapWith<CreateEmployeeDto>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [MinLength(6)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPasseord { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeDto, RegisterDto>()
                .ForMember(e => e.FirstName,
                    opt => opt.MapFrom(e => e.FirstName))
                .ForMember(e => e.LastName,
                    opt => opt.MapFrom(e => e.LastName))
                .ForMember(e => e.MiddleName,
                    opt => opt.MapFrom(e => e.MiddleName))
                .ForMember(e => e.Email,
                    opt => opt.MapFrom(e => e.Email))
                .ReverseMap();
        }
    }
}
