
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.User.Queries.Models;
using SchoolManagement.Core.Features.User.Queries.Results;
using SchoolManagement.Core.Wrappers;
using SchoolManagement.Core.Wrappers.Extentions;
using SchoolManagement.Domain.Entities.Identity;

namespace SchoolManagement.Core.Features.User.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
        IRequestHandler<GetUserPaginationQuery, PaginatedResult<GetUserPaginationResponse>>,
        IRequestHandler<GetSingleUserByIdQuery, Response<GetSingleUserByIdResponse>>
    {
        private readonly IStringLocalizer<SharedResources.SharedResources> _localizer;
        private readonly IMapper _mapper
            ;
        private readonly UserManager<UserApplication> _userManager;

        public UserQueryHandler(IStringLocalizer<SharedResources.SharedResources> localizer,
            IMapper mapper,
            UserManager<UserApplication> userManager)
        {
            _localizer = localizer;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<PaginatedResult<GetUserPaginationResponse>> Handle(GetUserPaginationQuery request, CancellationToken cancellationToken)
        {

            var users = _userManager.Users.AsQueryable();

            // mapping 
            var paginatedList = await _mapper.ProjectTo<GetUserPaginationResponse>(users)
                                             .ToPaginatedResult(request.PageNumber, request.PageSize);
            // 

            if (paginatedList.Data!.Any())
            {

                var paginationResponse = PaginatedResult<GetUserPaginationResponse>.Success(paginatedList.Data!, paginatedList.PageSize, paginatedList.PageIndex, paginatedList.TotalCount);

                paginationResponse.Meta = new { Count = paginatedList.Data!.Count() };

                return paginationResponse;
            }
            else
            {
                PaginatedResult<GetUserPaginationResponse>.Failed();
                return paginatedList;
            }


        }

        public async Task<Response<GetSingleUserByIdResponse>> Handle(GetSingleUserByIdQuery request, CancellationToken cancellationToken)
        {
            // Check if Id is Exist 

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
            //var user = _userManager.FindByIdAsync(request.Id.ToString());
            if (user is null)
            {
                return NotFound<GetSingleUserByIdResponse>(_localizer[SharedResources.SharedResourcesKeys.NotFound]);
            }

            var userMapped = _mapper.Map<GetSingleUserByIdResponse>(user);

            return Success(userMapped);
        }
    }
}
