using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Core.Bases;

namespace SchoolManagement.WebApi.Base
{
    [ApiController]
    public class AppControllerBase : ControllerBase
    {

        private IMediator? mediator;
        protected IMediator _mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();


        public ObjectResult NewResult<T>(Response<T> response)
        {
            return HandleResponse(response);

        }

        private static ObjectResult HandleResponse<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return new OkObjectResult(response);

                case System.Net.HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);

                case System.Net.HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);

                case System.Net.HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);

                case System.Net.HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);

                case System.Net.HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);

            }
        }
    }
}
