using AutoMapper;

namespace SchoolManagement.Core.Mapping.Department
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentByIdMapping();
        }
    }
}
