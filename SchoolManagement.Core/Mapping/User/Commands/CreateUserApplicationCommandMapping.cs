using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Domain.Entities.Identity;

namespace SchoolManagement.Core.Mapping.User
{
    public partial class ApplicationUserProfile
    {

        public void AddTheMappingForUser()
        {
            CreateMap<AddUserCommand, UserApplication>();

            // public string FullName { get; set; }
            //public string UserName { get; set; }
            //public string Email { get; set; }
            ////public string Paswword { get; set; }
            //public string? Address { get; set; }
            //public string? Country { get; set; }
            //public string? PhoneNumber { get; set; }
            //public string Password { get; set; }
            //public string ConfirmPassword { get; set; }


        }

    }
}
