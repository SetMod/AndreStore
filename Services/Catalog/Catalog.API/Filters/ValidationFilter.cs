using Catalog.API.Validators.ValidationError;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .ToDictionary(keyValue => keyValue.Key, keyValue => keyValue.Value.Errors
                    .Select(x => x.ErrorMessage)).ToArray();
                var errorrResponse = new ErrorResponse();
                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel()
                        {
                            FildName = error.Key,
                            Message = subError
                        };

                        errorrResponse.Errors.Add(errorModel);
                    }
                }

                context.Result = new BadRequestObjectResult(errorrResponse);
            }
            
            await next();
        }
    }
}
