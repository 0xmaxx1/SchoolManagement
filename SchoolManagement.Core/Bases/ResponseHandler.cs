namespace SchoolManagement.Core.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {

        }



        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully"
            };

        }

        public Response<T> Success<T>(T entity, object? meta = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Successfully",
                Meta = meta,
                Data = entity,
            };
        }

        public Response<T> Unauthorized<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = message == null ? "Bad Request" : message
            };
        }

        public Response<T> NotFound<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message,
            };
        }

        public Response<T> Created<T>(/*T entity,*/ object? meta = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created Successfully",
                Meta = meta,
                //Data = entity,
            };
        }

        public Response<T> Updated<T>(/*T entity,*/ object? meta = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Updated Successfully",
                Meta = meta,
                //Data = entity,
            };
        }


        public Response<T> BadRequest<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = message == null ? "Bad Request" : message,
            };
        }


        public Response<T> UnProccessableEntity<T>(string? message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? "Unprocessable Entity" : message,
            };
        }




    }
}
