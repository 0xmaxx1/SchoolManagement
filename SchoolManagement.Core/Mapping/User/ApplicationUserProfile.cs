using AutoMapper;

namespace SchoolManagement.Core.Mapping.User
{
    public partial class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            AddTheMappingForUser();
            GetUsersPaginationMapping();
            GetSingleUserByIdMapping();
        }
    }
}
