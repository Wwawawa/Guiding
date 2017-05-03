* 1. IF there is a dtsconfig file in root of project(or you selected path), your package use the value of this config file default, unless you remove it, the package would use the value of configuration you configure in your batch.
* 2. If cannot find configuration file, the package will load itself db

.bat file with configuration
```sh
  "C:\Program Files (x86)\Microsoft SQL Server\110\DTS\Binn\DTEXEC.exe" /F "C:\Users\zhenhui.sun.DS\Desktop\Zhenhui\DevelopmentGuide\My SSIS Package Deploy Demo\package.dtsx" /conf "C:\Users\zhenhui.sun.DS\Desktop\Zhenhui\DevelopmentGuide\My SSIS Package Deploy Demo\final.dtsConfig"
```
.bat file no configuration

```sh
  "C:\Program Files (x86)\Microsoft SQL Server\110\DTS\Binn\DTEXEC.exe" /F "C:\Users\zhenhui.sun.DS\Desktop\Zhenhui\DevelopmentGuide\My SSIS Package Deploy Demo\package.dtsx"
```

