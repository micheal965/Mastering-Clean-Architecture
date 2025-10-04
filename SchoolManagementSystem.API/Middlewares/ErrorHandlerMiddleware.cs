using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Core.APIBases;
using System.Net;
using System.Text.Json;

namespace SchoolManagementSystem.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = APIResponse<string>.Failure(default, default);
                //TODO:: cover all validation errors
                switch (error)
                {
                    case UnauthorizedAccessException e:
                        // custom application error
                        HandleResponseModelMessage<APIResponse<string>>(responseModel, e.Message, (int)HttpStatusCode.Unauthorized);
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case ValidationException e:
                        // custom validation error
                        HandleResponseModelMessage<APIResponse<string>>(responseModel, e.Message, (int)HttpStatusCode.UnprocessableEntity);
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;

                    case KeyNotFoundException e:
                        // not found error
                        HandleResponseModelMessage<APIResponse<string>>(responseModel, e.Message, (int)HttpStatusCode.NotFound);
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case DbUpdateException e:
                        // can't update error      
                        HandleResponseModelMessage<APIResponse<string>>(responseModel, e.Message, (int)HttpStatusCode.BadRequest);
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case Exception e:
                        string Message = e.Message + e.InnerException == null ? "" : "\n" + e.InnerException.Message;
                        HandleResponseModelMessage<APIResponse<string>>(responseModel, Message, (int)HttpStatusCode.InternalServerError);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                    default:
                        // unhandled error
                        HandleResponseModelMessage<APIResponse<string>>(responseModel, "Unhandled Error occurs", (int)HttpStatusCode.InternalServerError);
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }

        }
        private void HandleResponseModelMessage<T>(APIResponse<string> responseModel, string errMsg, int statusCode, T? data = default)
        {
            responseModel.ErrorMessage = errMsg;
            responseModel.StatusCode = statusCode;
        }
    }

}
