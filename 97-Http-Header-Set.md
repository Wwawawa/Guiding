* [HTTP Documentation](https://developer.mozilla.org/en-US/docs/Web/HTTP)
* Cache-Control header value set, by adding below config into web.config
```xml
<system.webServer>
  <httpProtocol>
          <customHeaders>
              <add name="Cache-Control" value="no-store" />
          </customHeaders>
  </httpProtocol>
  ....
```
* As upon method, we can add other header values like
```xml
<system.webServer>
  <httpProtocol>
          <customHeaders>         
              <add name="Expires" value="-1" />
              <add name="Pragma" value="no-cache" />
          </customHeaders>
  </httpProtocol>
  ....

```
* Set Headers in the global.asax
```cs
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        // set no-store to cache-control
        this.Response.Cache.AppendCacheExtension("no-store");
        //avoid Iframe attacking
        this.Response.Headers["X-FRAME-OPTIONS"] = "SAMEORIGIN";
    }    
```
* Introduction
>>>The correct minimum set of headers that works across all mentioned clients (and proxies):
```th
        Cache-Control: no-cache, no-store, must-revalidate
        Pragma: no-cache
        Expires: 0
```
  
>>>The [Cache-Control](https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.9) is per the HTTP 1.1 spec for clients and proxies (and implicitly required by some clients next to **Expires**). The [Pragma](http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.32) is per the HTTP 1.0 spec for prehistoric clients. The [Expires](http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.21) is per the HTTP 1.0 and 1.1 spec for clients and proxies. In HTTP 1.1, the **Cache-Control** takes precedence over **Expires**, so it's after all for HTTP 1.0 proxies only.

>>>If you don't care about IE6 and its broken caching when serving pages over HTTPS with only **no-store**, then you could omit **Cache-Control: no-cache**.
  ```th
          Cache-Control: no-store, must-revalidate
          Pragma: no-cache
          Expires: 0
  ```
>>>If you don't care about IE6 nor HTTP 1.0 clients (HTTP 1.1 was introduced 1997), then you could omit  **Pragma**
```th
        Cache-Control: no-store, must-revalidate
        Expires: 0
```
>>>If you don't care about HTTP 1.0 proxies either, then you could omit **Expires**.
```th
        Cache-Control: no-store, must-revalidate
```
>>>On the other hand, if the server auto-includes a valid Date header, then you could theoretically omit **Cache-Control** too and rely on **Expires** only.
```th
        Date: Wed, 24 Aug 2016 18:32:02 GMT
        Expires: 0
```
>>>But that may fail if e.g. the enduser manipulates the operating system date and the client software is relying on it.

>>>Other **Cache-Control** parameters such as **max-age** are irrelevant if the abovementioned **Cache-Control** parameters are specified. The [Last-Modified](http://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html#sec14.29) header as included in most other answers here is only interesting if you **actually want** to cache the request, so you don't need to specify it at all.

* How to set it?
>>>Using PHP:
  ```php
          header("Cache-Control: no-cache, no-store, must-revalidate"); // HTTP 1.1.
          header("Pragma: no-cache"); // HTTP 1.0.
          header("Expires: 0"); // Proxies.
  ```
>>>Using Java Servlet, or Node.js:
```js
          response.setHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
          response.setHeader("Pragma", "no-cache"); // HTTP 1.0.
          response.setHeader("Expires", "0"); // Proxies.
```
>>>Using ASP.NET-MVC
```cs
          Response.Cache.SetCacheability(HttpCacheability.NoCache);  // HTTP 1.1.
          Response.Cache.AppendCacheExtension("no-store, must-revalidate");
          Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
          Response.AppendHeader("Expires", "0"); // Proxies.
```
>>>Using ASP.NET:
```cs
          Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
          Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
          Response.AppendHeader("Expires", "0"); // Proxies.
```
>>>Using ASP:
```cs
          Response.addHeader "Cache-Control", "no-cache, no-store, must-revalidate" ' HTTP 1.1.
          Response.addHeader "Pragma", "no-cache" ' HTTP 1.0.
          Response.addHeader "Expires", "0" ' Proxies.
```
>>>Using Ruby on Rails, or Python on Flask:
```ruby
          response.headers["Cache-Control"] = "no-cache, no-store, must-revalidate" # HTTP 1.1.
          response.headers["Pragma"] = "no-cache" # HTTP 1.0.
          response.headers["Expires"] = "0" # Proxies.
```
>>>Using Google Go:
```cs
          responseWriter.Header().Set("Cache-Control", "no-cache, no-store, must-revalidate") // HTTP 1.1.
          responseWriter.Header().Set("Pragma", "no-cache") // HTTP 1.0.
          responseWriter.Header().Set("Expires", "0") // Proxies.
```
>>>Using Apache .htaccess file:
```htaccess
          <IfModule mod_headers.c>
              Header set Cache-Control "no-cache, no-store, must-revalidate"
              Header set Pragma "no-cache"
              Header set Expires 0
          </IfModule>
```
>>>Using HTML4:
```html
          <meta http-equiv="Cache-Control" content="no-cache, no-store, must-revalidate" />
          <meta http-equiv="Pragma" content="no-cache" />
          <meta http-equiv="Expires" content="0" />
```
>>>Using Python/Pyramid:
```Python
          def my_api_call(context, request):

          # disable caching
          request.response.headerlist.extend(
              (
                  ('Cache-Control', 'no-cache, no-store, must-revalidate'),
                  ('Pragma', 'no-cache'),
                  ('Expires', '0')
              )
          )
```
* HTML meta tags vs HTTP response headers
>Important to know is that when a HTML page is served over a HTTP connection, and a header is present in both the HTTP response headers and the HTML **meta http-equiv>** tags, then the one specified in the HTTP response header will get precedence over the HTML meta tag. The HTML meta tag will only be used when the page is viewed from local disk file system via a **file://** URL. See also [W3 HTML spec chapter 5.2.2.](http://www.w3.org/TR/html4/charset.html#h-5.2.2) Take care with this when you don't specify them programmatically, because the webserver can namely include some default values.

>Generally, you'd better just not specify the HTML meta tags to avoid confusion by starters, and rely on hard HTTP response headers. Moreover, specifically those **meta http-equiv>** tags are [invalid](http://validator.w3.org/) in HTML5. Only the **http-equiv** values listed in [HTML5 specification](http://dev.w3.org/html5/spec-preview/the-meta-element.html#attr-meta-http-equiv) are allowed.
* Verifying the actual HTTP response headers
>To verify the one and other, you can see/debug them in HTTP traffic monitor of webbrowser's developer toolset. You can get there by pressing F12 in Chrome/Firefox23+/IE9+, and then opening the "Network" or "Net" tab panel, and then clicking the HTTP request of interest to uncover all detail about the HTTP request and response.The [screenshot](https://i.stack.imgur.com/fSnXH.png) is from Chrome
* I want to set those headers on file downloads too
>First of all, this question and answer is targeted on "web pages" (HTML pages), not "file downloads" (PDF, zip, Excel, etc). You'd better have them cached and make use of some file version identifier somewhere in URI path or querystring to force a redownload on a changed file. When applying those no-cache headers on file downloads anyway, then beware of the IE7/8 bug when serving a file download over HTTPS instead of HTTP. For detail, see [IE cannot download foo.jsf. IE was not able to open this internet site. The requested site is either unavailable or cannot be found](https://stackoverflow.com/q/5034454).
