#### 1--[Microsoft Ajax Minifier](http://ajaxmin.codeplex.com/documentation)
* [Offical using tip for MSBuild task](http://ajaxmin.codeplex.com/wikipage?title=AjaxMinTask)
* Using in a project as-is
  * Download **AjaxMinifier.exe** file into **Tools\JSMin\ajaxminifier** which located the root directory of solution(this directory has solution project) 
  * open the project edit mode
  ```th
  right click project-> unload project->edit xx.csproj
  ```
  * add below config
  ```xml
    <Target Name="MinifyFiles" AfterTargets="AfterBuild">
      <Message Text="Proceed to minify files" Importance="High" />
      <Exec Command="..\Tools\JSMin\ajaxminifier -js -minify:false -clobber:true -xml &quot;$(ProjectDir)JSMin\js.xml&quot;">
      </Exec>
      <Exec Command="..\Tools\JSMin\ajaxminifier -css -comments:all -clobber:true -xml &quot;$(ProjectDir)JSMin\css.xml&quot;">
      </Exec>
      <ItemGroup>
        <CopyAfterBuildJs Include="$(ProjectDir)app\libs\ManageMyRecords*.js" />
        <CopyAfterBuildCss Include="$(ProjectDir)app\css\ManageMyRecords*.css" />
      </ItemGroup>
      <Message Text="Copy minified files" Importance="High" />
      <Copy SourceFiles="@(CopyAfterBuildJs)" DestinationFolder="$(WebProjectOutputDir)\app\libs" />
      <Copy SourceFiles="@(CopyAfterBuildCss)" DestinationFolder="$(WebProjectOutputDir)\app\css" />
    </Target>
  ```
