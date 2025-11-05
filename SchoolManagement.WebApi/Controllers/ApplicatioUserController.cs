using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Features.User.Commands.Models;
using SchoolManagement.Core.Features.User.Queries.Models;
using SchoolManagement.Domain.AppRoute;
using SchoolManagement.WebApi.Base;

namespace SchoolManagement.WebApi.Controllers
{
    [ApiController]
    public class ApplicatioUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicatioUserRouting.Create)]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand req)
        {
            var response = await _mediator.Send(req);
            return NewResult(response);
        }

        [HttpGet(Router.ApplicatioUserRouting.List)]
        public async Task<IActionResult> PaginatedUser([FromQuery] GetUserPaginationQuery req)
        {
            var response = await _mediator.Send(req);
            return NewResult(response);
        }


        [HttpGet(Router.ApplicatioUserRouting.GetById)]
        public async Task<IActionResult> SpecificUser([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetSingleUserByIdQuery(id));
            return NewResult(response);
        }

    }
}
