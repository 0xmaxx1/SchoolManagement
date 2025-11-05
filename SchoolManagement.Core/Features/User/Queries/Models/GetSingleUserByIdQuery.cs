using MediatR;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.User.Queries.Results;

namespace SchoolManagement.Core.Features.User.Queries.Models
{
    public class GetSingleUserByIdQuery : IRequest<Response<GetSingleUserByIdResponse>>
    {
        public GetSingleUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
