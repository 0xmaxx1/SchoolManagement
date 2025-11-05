using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Bases;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Domain.Entities.Identity;

namespace SchoolManagement.Core.Features.User.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>

    {
        private readonly IStringLocalizer<SharedResources.SharedResources> _localizer;
        private readonly IMapper _mapper;
        private readonly UserManager<UserApplication> _manager;

        public UserCommandHandler(IStringLocalizer<SharedResources.SharedResources> localizer
            , IMapper mapper,
            UserManager<UserApplication> manager
            )
        {
            this._localizer = localizer;
            this._mapper = mapper;
            this._manager = manager;
        }


        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            // if email is exist

            var user = await _manager.FindByEmailAsync(request.Email);

            if (user is not null)
            {
                return BadRequest<string>(_localizer[SharedResources.SharedResourcesKeys.EmailIsExist]);
            }

            var userByName = await _manager.FindByNameAsync(request.UserName);

            if (userByName is not null)
            {
                return BadRequest<string>(_localizer[SharedResources.SharedResourcesKeys.UserNameIsExist]);

            }

            //Mapping 
            var userMapped = _mapper.Map<UserApplication>(request);




            var createdResult = await _manager.CreateAsync(userMapped, request.Password);


            if (!createdResult.Succeeded)
            {

                var errorDescription = createdResult.Errors.Select(e => $"{e.Code} : {e.Description}").ToList();



                return BadRequest<string>(_localizer[SharedResources.SharedResourcesKeys.FailedToAddUser]);
            }




            return Created<string>();

        }
    }
}
