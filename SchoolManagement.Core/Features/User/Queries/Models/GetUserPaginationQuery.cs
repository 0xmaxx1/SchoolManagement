using MediatR;
using SchoolManagement.Core.Features.User.Queries.Results;
using SchoolManagement.Core.Wrappers;

namespace SchoolManagement.Core.Features.User.Queries.Models
{
    public class GetUserPaginationQuery : IRequest<PaginatedResult<GetUserPaginationResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
