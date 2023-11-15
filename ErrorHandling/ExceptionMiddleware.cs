using System.Net;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;


    public ExceptionMiddleware(RequestDelegate next)
    {

        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {

            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        // return context.Response.WriteAsync(new ErrorDetails()
        // {
        //     statuscode = context.Response.StatusCode,
        //     message = exception.Message //"Internal Server Error from the custom middleware."
        // }.ToString());
        // JsonConvert.SerializeObject(
        context.Response.StatusCode = 400;
        var error = new ErrorDetails();
        if (exception.Source == "Core Microsoft SqlClient Data Provider")
        {
            error.StatusCode = context.Response.StatusCode;
            error.Message = "Database Not Found.";

        }
        else
        {
            error.StatusCode = context.Response.StatusCode;
            error.Message = exception.Message; //"Internal Server Error from the custom middleware."

        }
        return context.Response.WriteAsJsonAsync(error);
    }
}