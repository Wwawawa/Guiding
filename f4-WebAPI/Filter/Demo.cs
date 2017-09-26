[AttributeUsage(AttributeTargets.All)]
public sealed class CustomerAuthorizationFilterAttribute : AuthorizationFilterAttribute
{
    public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
    {
        HttpResponseMessage _HttpResponseMessage;

        var queryString = actionContext.Request.GetQueryNameValuePairs();

        _HttpResponseMessage = actionContext.Request.CreateResponse(HttpStatusCode.InternalServerError, "Not authorized");
        _HttpResponseMessage.ReasonPhrase = "Exception";
        _HttpResponseMessage.Headers.CacheControl = new CacheControlHeaderValue()
        {
            Public = true,
            MaxAge = new TimeSpan(0, 0, 0, 5)
        };
        actionContext.Response = _HttpResponseMessage;

    }
}
[AttributeUsage(AttributeTargets.All)]
public sealed class CustomerActionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
    {
    }
}
[AttributeUsage(AttributeTargets.All)]
public sealed class CustomerExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(System.Web.Http.Controllers.HttpActionContext actionContext)
    {
    }
}
