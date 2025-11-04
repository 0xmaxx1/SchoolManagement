using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Features.Student.Commands.Models;
using SchoolManagement.Core.Features.Student.Queries.Models;
using SchoolManagement.Domain.AppRoute;
using SchoolManagement.WebApi.Base;

namespace SchoolManagement.WebApi.Controllers
{
    [ApiController]
    public class StudentController : AppControllerBase
    {


        [HttpGet(Router.StudentRouting.List)]
        public async Task<ActionResult> GetStudentList()
        {
            var response = await _mediator.Send(new GetStudentListQuery());
            return NewResult(response);

        }

        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<ActionResult> GetStudentListPaginated([FromQuery] GetStudentPaginatedListQuery paramsQuery)
        {
            var response = await _mediator.Send(paramsQuery);

            return NewResult(response);

        }

        [HttpGet(Router.StudentRouting.GetById)] // GET /Student/2
        public async Task<ActionResult> GetStudent([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetStudentByIdQuery(id));
            return NewResult(response);

        }

        [HttpPost(Router.StudentRouting.Create)]
        public async Task<ActionResult> CreateStudent([FromBody] AddStudentCommand entity)
        {
            var response = await _mediator.Send(entity);
            return NewResult(response);
        }

        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<ActionResult> UpdateStudent([FromBody] EditStudentCommand entity)
        {
            var response = await _mediator.Send(entity);
            return NewResult(response);
        }


        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<ActionResult> UpdateStudent([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(response);
        }


    }
}
