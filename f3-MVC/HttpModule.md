
* [Add IHttpModule by config](http://www.cnblogs.com/zengen/articles/1184731.html)
  ```xml
    <httpModules>
      <add name="MyHttpModule" type="WebApplication1.MyHttpModule,WebApplication1"/>
    </httpModules>
  ```
* [DynamicModuleUtility](http://www.cnblogs.com/TomXu/p/3756846.html)
  * [Demo](https://github.com/Wwawawa/Thinktecture.IdentityModel/blob/master/source/EmbeddedSts/EmbeddedStsConfiguration.cs)
    * we need below code to make sure HttpModule to be registered by DynamicModuleUtility pre applicaiton start:
    ```cs
        [assembly: PreApplicationStartMethod(typeof(Thinktecture.IdentityModel.EmbeddedSts.EmbeddedStsConfiguration), "Start")]
     ```   

    * we can add below code into **AssemblyInfo.cs** to replace upon code to deploy same function
    ```cs
        [assembly: PreApplicationStartMethod(typeof(Thinktecture.IdentityModel.EmbeddedSts.EmbeddedStsConfiguration), "Start")]
    ```
