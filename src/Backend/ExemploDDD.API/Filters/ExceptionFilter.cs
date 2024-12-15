using ExemploDDD.Communication.Response;
using ExemploDDD.Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExemploDDD.API.Filters;
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ExemploDDDException exemploException)
            HandleProjectException(exemploException, context);
        else
            ThrowUnknowException(context);
    }

    private static void HandleProjectException(ExemploDDDException exception , ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)exception.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(exception.GetErrorMessages()));
    }

    private static void ThrowUnknowException(ExceptionContext context)
    {
        if (context.Exception is ErrorOnValidationException)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson("Unknown error"));
        }
    }
}

