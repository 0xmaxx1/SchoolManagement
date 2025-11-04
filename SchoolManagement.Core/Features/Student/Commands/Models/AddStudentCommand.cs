using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Student.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}



