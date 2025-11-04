
using MediatR;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.Core.Features.Student.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
