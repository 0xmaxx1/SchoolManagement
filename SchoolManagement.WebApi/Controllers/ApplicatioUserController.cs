using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Features.User.Commands.Models;
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





    }
}
