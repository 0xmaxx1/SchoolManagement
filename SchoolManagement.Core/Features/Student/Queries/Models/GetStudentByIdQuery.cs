
using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Student.Queries.Results;

namespace SchoolManagement.Core.Features.Student.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetSignleStudentResponse>>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
