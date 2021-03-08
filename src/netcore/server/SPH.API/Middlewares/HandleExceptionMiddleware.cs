using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using WeLott.Model.Abstractions.Responses;
using WeLott.Shared.Exceptions;

namespace SPH.Api.Middlewares
{
    public class HandleExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<HandleExceptionMiddleware> logger;

        public HandleExceptionMiddleware(RequestDelegate next, ILogger<HandleExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                logger.LogError(ex, ex.Message);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            BaseResponseModel responseModel = new BaseResponseModel(System.Net.HttpStatusCode.InternalServerError, ex.Message);

            if (ex is NotFoundException)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            else if (ex is BadRequestException)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            else if (ex is UnauthorizedAccessException)
            {
                responseModel.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            }
            else responseModel.StatusCode = System.Net.HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            if (responseModel.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
            else context.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(responseModel));
        }
    }
}
