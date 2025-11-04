using MediatR;
using SchoolManagement.Core.Features.Student.Queries.Results;
using SchoolManagement.Core.Wrappers;
using SchoolManagement.Domain.Helpers.Enums;

namespace SchoolManagement.Core.Features.Student.Queries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {


        public GetStudentPaginatedListQuery()
        {

        }

        public GetStudentPaginatedListQuery(StudentOrderingEnum orderBy, int pageIndex = 0, int pageSize = 0, string? search = null)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderBy = orderBy;
            Search = search;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }


    }
}
