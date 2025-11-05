using SchoolManagement.Core.Features.User.Queries.Results;
using SchoolManagement.Domain.Entities.Identity;

namespace SchoolManagement.Core.Mapping.User
{
    public partial class ApplicationUserProfile
    {
        public void GetUsersPaginationMapping()
        {
            CreateMap<UserApplication, GetUserPaginationResponse>();
            //.ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email));
        }
    }
}
