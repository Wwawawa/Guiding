#### HandleErrorAttribute: we actually only deploy below code in web.config, not have to set "defaultRedirect" property if you don't need to custom specially, because it will default redirect the page located in "/Views/Shared/Error.cshtml".
#### If exception occur in a try catch, the exception filter will not be invoke, because the exception has been catch.
```xml
  <customErrors mode="On">
  </customErrors>
```

* [HandleErrorAttribute Introduction](http://shiyousan.com/post/635838881238204198)
    * [IExceptionFilter for CustomExceptionAttribute](http://shiyousan.com/post/635833789557065314)
    * [FilterConfig](http://shiyousan.com/post/635835285087587126)
* How to handle HTTP 404,403 .etc error:
  * not include 401,the HandleErrorAttribute cannot handle this error, but it often cause logon page showing
    * solution 1: custom HandlerrorAttribute to handle this error.
    * solution 2: custom authorizeAttribute to can explose this error:
    ```cs
        public class BetterAuthorizeAttribute : AuthorizeAttribute
        {
          protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
          {
            throw new NotAuthorizedHttpException(Roles);
          }
        }

        public class NotAuthorizedHttpException : HttpException
        {
          public NotAuthorizedHttpException(string missingRoles)
            : base(401, string.Format("You do not have the required role(s) '{0}'.", string.Join(", ", missingRoles)))
          {
          }
        }
    ```
    
  * Since HandleErrorAttribute filter can only handle 500 error, so we need to custom error view for other errors except 500.
  * Demo [Video](https://www.youtube.com/watch?v=nNEjXCSnw6w) and [Slide](http://csharp-video-tutorials.blogspot.com.ar/2013/08/part-72-handleerror-attribute-in-mvc.html)
  * Step to deployment:
    * Step 1: Add "ErrorController" to controllers folder. Copy and paste the following code.
    ```cs
        public class ErrorController : Controller
        {
            public ActionResult NotFound()
            {
                return View();
            }
        }
    ```
    
    * Step 2: Right click on "Shared" folder and add "NotFound.cshtml" view. Copy and paste the following code.
    ```html
        <h2>Please check the URL. The page you are looking for cannot be found</h2>
    ```
    
    * Step 3: Change "customErrors" element in web.config as shown below.
    ```xml
        <customErrors mode="On">
          <error statusCode="404" redirect="~/Error/NotFound"/>
        </customErrors> 
    ```
    
    
    
