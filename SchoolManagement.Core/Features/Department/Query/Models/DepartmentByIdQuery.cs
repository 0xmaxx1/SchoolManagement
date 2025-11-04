using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.Department.Query.Result;

namespace SchoolManagement.Core.Features.Department.Query.Models
{
    public class DepartmentByIdQuery : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int StudentPageIndex { get; set; }
        public int StudentPageSize { get; set; }
    }
}
