using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Student.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
