WebAPi filter using is from System.Web.Http.Filters, not from System.Web.Mvc.Filters:
陨石坑之webapi使用filter
   首先为什么说这是一个坑，是因为我们在webapi中使用filter的时候也许会先百度一下，好吧，挖坑的来了，我看了好几篇文章写的是使用System.Web.Mvc.Filters.ActionFilterAttribute。

然后开始痛苦的调试，发现这个过滤器永远调不进来(windows azure mobile services除外)。then.... 还是Google吧 ！

   痛苦后才懂，原来不是这么一回事，ActionFilterAttribute 有2个不同的版本，一个在System.Web.Mvc空间下，另外一个则在System.Web.Http.Filters命名空间下。他们有何区别？

The System.Web.Http one is for Web API; the System.Web.Mvc one is for previous MVC versions.

You can see from the source that the Web API version has several differences.

好吧，原来System.Web.Mvc.Filters.ActionFilterAttribute是给mvc用的，我们要用System.Web.Http.Filters下的，知道这样了 就开始了改写过程....，运行调试，发现异常！！！

先看下异常代码：
public class FilterConfig
  {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
          filters.Add(new HandleErrorAttribute());
          filters.Add(new PushFilter());
      }
  }
 

“System.InvalidOperationException”类型的异常在 System.Web.Mvc.dll 中发生，但未在用户代码中进行处理

其他信息: 给定的筛选器实例必须实现以下一个或多个筛选器接口: System.Web.Mvc.IAuthorizationFilter、System.Web.Mvc.IActionFilter、System.Web.Mvc.IResultFilter、System.Web.Mvc.IExceptionFilter、System.Web.Mvc.Filters.IAuthenticationFilter。
这是为何呢。。。 明明就是这个过滤器，为什么还是会有异常？ 原来问题在FilterConfig 这个类里面，这个类只是对MVC配置起效。（汗！！！！！！）,我们加过滤器的代码要加入到webapi的配置而非mvc的配置，so 代码要这么写。

复制代码
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "push.api.v1",
                routeTemplate: "v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

           config.Filters.Add(new PushFilter());
        }
    }
复制代码
运行调试，ok，success!
