using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using WeLott.Model.Abstractions.Responses;

namespace SPH.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string errorMessage = "Unspecified error.";

                var modelState = context.ModelState;
                if (modelState != null && modelState.Count > 0 && modelState.Any(m => m.Value?.Errors?.Count > 0))
                    errorMessage = modelState.Select(m => m.Value?.Errors?.FirstOrDefault()?.ErrorMessage).FirstOrDefault(m => !string.IsNullOrEmpty(m));

                context.Result = new OkObjectResult(new BadRequestResponseModel(errorMessage));
            }
        }
    }
}
