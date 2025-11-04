using SchoolManagement.Core.Features.Department.Query.Result;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Core.Mapping.Department
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentByIdMapping()
        {
            CreateMap<Departments, GetDepartmentByIdResponse>()

              .ForMember(dest => dest.ManagerName,
              options => options.MapFrom(src => src.Instructor.GetLocalized
              (src.Instructor.ENameAr ?? string.Empty, src.Instructor.ENameEn)))

              .ForMember(dest => dest.Name,
              options => options.MapFrom(src => src.GetLocalized
              (src.NameAr ?? string.Empty, src.Name)))

            .ForMember(dest => dest.SubjectList, options => options.MapFrom(src => src.Subjects))
            .ForMember(dest => dest.InstructorList, options => options.MapFrom(src => src.Instructors));
            //.ForMember(dest => dest.StudentList, options => options.MapFrom(src => src.Students));



            // Subjects, SubjectResponse
            CreateMap<Subjects, SubjectResponse>()
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.GetLocalized(src.NameAr ?? string.Empty, src.Name)));

            // Instructors, InstructorResponse
            CreateMap<Instructors, InstructorResponse>()
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.GetLocalized(src.ENameAr ?? string.Empty, src.ENameEn)));
            // Students, StudentResponse


            //CreateMap<Students, StudentResponse>()
            //    .ForMember(dest => dest.Name, options => options.MapFrom(src => src.GetLocalized(src.NameAr ?? string.Empty, src.Name)));

        }

    }
}
