using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Features.Department.Query.Models;
using SchoolManagement.Domain.AppRoute;
using SchoolManagement.WebApi.Base;

namespace SchoolManagement.WebApi.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartments([FromQuery] DepartmentByIdQuery req)
        {

            var response = await _mediator.Send(req);
            return NewResult(response);
        }


    }
}
