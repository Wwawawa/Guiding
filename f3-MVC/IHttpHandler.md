[IHttpHandler Introduction](http://blog.csdn.net/liu_111111/article/details/8439835)
* [ashx introduction](http://www.cnblogs.com/lgx5/p/5629028.html)
* angular call ashx can by directive which set the ashx path into 'src' property of element.
```js
  test.directive('test', [function () {
      return {
          restrict: 'A',
          replace: false,
          link: function (scope, elem, attr) {
              var src = '/test.ashx?param1=test';
              elem.attr('src', src);
          }
      }
  }]);

```
* A demo for load picture dynamically
  * Using [WebClient](http://www.cnblogs.com/hfliyi/archive/2012/08/21/2649892.html) to call special picture path
  * Using [NetworkCredential](http://www.cnblogs.com/Hawk-Hong/p/4293651.html) to transform the authentication
  * [ignore the SSL authentication](http://www.cnblogs.com/duanh/p/5781839.html)
  ```cs
      <%@ WebHandler Language="C#" Class="test.ImageRouteHandler" %>

      using System;
      using System.Collections.Generic;
      using System.Configuration;
      using System.Globalization;
      using System.Linq;
      using System.Net;
      using System.Net.Security;
      using System.Web;

      namespace test
      {

          public class ImageRouteHandler : IHttpHandler
          {
              public bool IsReusable
              {
                  get
                  {
                      return false;
                  }
              }

              public void ProcessRequest(HttpContext context)
              {
                  if (context == null)
                  {
                      return;
                  }

                  object url = context.Request.QueryString["URL"];

                  MyWebClient downloadedData = new MyWebClient();
                  byte[] bytes = null;

                  try
                  {
                      string strURL = context.Request.QueryString["URL"];

                      string strFilename = strURL.Substring(strURL.LastIndexOf("/"), strURL.Length - strURL.LastIndexOf("/")).Replace("/", string.Empty);

                      // Check if the picture was read previouly
                      bytes = (byte[])HttpContext.Current.Cache[strURL];

                      // change the following in the web.config
                      string domain = ConfigurationManager.AppSettings["Doamin"].ToString();
                      string username = ConfigurationManager.AppSettings["User"].ToString();
                      string password = ConfigurationManager.AppSettings["Password"].ToString();
                      NetworkCredential cred = new NetworkCredential(username, password, domain);

                      // if null is because the picture isn't in the cache
                      if (bytes == null)
                      {
                          downloadedData.Credentials = cred;

                          // Change SSL checks so that all checks pass
                          ServicePointManager.ServerCertificateValidationCallback =
                              new RemoteCertificateValidationCallback(
                                  delegate
                                  {
                                      return true;
                                  });

                          bytes = downloadedData.DownloadData(strURL);

                          if (bytes.Length > 0)
                          {
                              HttpContext.Current.Cache.Add(strURL, bytes, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1, 0, 0, 0), System.Web.Caching.CacheItemPriority.Default, null);
                          }
                          else
                          {
                              context.Response.Redirect(ConfigurationManager.AppSettings["error"].ToString());
                              return;
                          }
                      }

                      // Send response
                      context.Response.Clear();
                      context.Response.ClearContent();
                      context.Response.ClearHeaders();
                      context.Response.AddHeader("Content-Length", bytes.Length.ToString(CultureInfo.InvariantCulture));
                      context.Response.ContentType = "image/jpeg";
                      context.Response.AddHeader("Content-Disposition", "inline; filename=" + strFilename);

                      context.Response.Cache.SetCacheability(HttpCacheability.ServerAndPrivate);
                      context.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                      context.Response.Cache.SetNoTransforms();
                      context.Response.Cache.SetETag("SPContentWrapperEtag");
                      context.Response.Cache.SetMaxAge(new TimeSpan(365, 0, 0, 0));
                      context.Response.Cache.SetExpires(System.DateTime.Now.AddYears(1));
                      context.Response.OutputStream.Write(bytes, 0, bytes.Length);
                      context.Response.Flush();
                  }
                  catch (Exception)
                  {
                      context.Response.Redirect(ConfigurationManager.AppSettings["error"].ToString());
                  }
                  finally
                  {
                      downloadedData.Dispose();
                      bytes = null;
                  }
              }
          }

          public class MyWebClient : WebClient
          {
              public MyWebClient()
              {
              }

              protected override WebRequest GetWebRequest(Uri address)
              {
                  WebRequest w = base.GetWebRequest(address);
                  w.Timeout = 20000;
                  return w;
              }
          }    
      }
  ```
