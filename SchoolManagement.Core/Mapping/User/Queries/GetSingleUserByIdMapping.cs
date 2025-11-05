using SchoolManagement.Core.Features.User.Queries.Results;
using SchoolManagement.Domain.Entities.Identity;

namespace SchoolManagement.Core.Mapping.User
{
    public partial class ApplicationUserProfile
    {
        public void GetSingleUserByIdMapping()
        {
            CreateMap<UserApplication, GetSingleUserByIdResponse>();

        }

    }
}
