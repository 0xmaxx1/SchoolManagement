using AutoMapper;
using SchoolManagement.Core.Features.Student.Commands.Models;
using SchoolManagement.Core.Features.Student.Queries.Results;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Core.Mapping.Student
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Students, GetStudentListResponse>()
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.GetLocalized(src.NameAr, src.Name)));

            CreateMap<Students, GetSignleStudentResponse>()
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.GetLocalized(src.NameAr, src.Name)));


            CreateMap<AddStudentCommand, Students>();

            CreateMap<EditStudentCommand, Students>();



        }

    }
}
