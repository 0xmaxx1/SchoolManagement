using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Student.Queries.Results;

namespace SchoolManagement.Core.Features.Student.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<IEnumerable<GetStudentListResponse>>>
    {
    }
}
