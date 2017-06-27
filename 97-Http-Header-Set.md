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
        this.Response.Cache.AppendCacheExtension("no-store");
    }
```
