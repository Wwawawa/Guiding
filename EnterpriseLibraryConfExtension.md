It does. You may add Enterprise Library 6 into your project via [Nuget](https://www.nuget.org/packages/EnterpriseLibrary.Logging/) 
Here is the sample application.

You may find more details in [Logging Application Block](http://msdn.microsoft.com/en-us/library/dn440731(v=pandp.60).aspx)

To use [Enterprise Library Configuration Console Extension](http://msdn.microsoft.com/en-us/library/dn440731(v=pandp.60).aspx)

To install the extension into the Visual Studio 2013 you may follow the workaround steps below.

download Microsoft.Practices.EnterpriseLibrary.ConfigConsoleV6.vsix from the [link](http://download.microsoft.com/download/B/B/4/BB4234FA-F238-4BDE-8A63-FFB6B2D81761/Microsoft.Practices.EnterpriseLibrary.ConfigConsoleV6.vsix)

A VSIX file is a zip file that uses the Open Packaging Convention. You can rename the .VSIX extension to .ZIP and use any zip browser (including the Windows File Explorer) to browse its contents.
      
extract the file into a folder
locate the file called extension.vsixmanifest in the folder
open the file with notepad.exe
locate
      
 ```sh     
  <SupportedProducts>
    <VisualStudio Version="11.0">
      <Edition>Ultimate</Edition>
      <Edition>Premium</Edition>
      <Edition>Pro</Edition>
    </VisualStudio>
  </SupportedProducts>
```
and replace it with the part below

```sh
  <SupportedProducts>
    <VisualStudio Version="11.0">
      <Edition>Ultimate</Edition>
      <Edition>Premium</Edition>
      <Edition>Pro</Edition>
    </VisualStudio>
    <VisualStudio Version="12.0"> <!-- VS2013 -->
      <Edition>Ultimate</Edition>
      <Edition>Premium</Edition>
      <Edition>Pro</Edition>
    </VisualStudio>
    <VisualStudio Version="14.0"> <!-- VS2015 -->
      <Edition>Ultimate</Edition>
      <Edition>Premium</Edition>
      <Edition>Pro</Edition>
    </VisualStudio>
  </SupportedProducts>
```
save the file and exit
compress folder as a ZIP file again
rename the extension to VSIX
double click on it.
