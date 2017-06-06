#### To Production([Deployment](https://angular.io/docs/ts/latest/guide/deployment.html#!#sts=Optimize%20for%20production))
* [TSLint](https://palantir.github.io/tslint/)
  * TSLint orders: You can see it in the code which has incorrect typical format, move cover to your code which has incorrect typical format, you can see the orders detected this error, you can disable it in your 'tslint.json' config file.
  * check all files: 
  ```js
   tslint "app/**/*.ts"
  ```
  * fix all incorrect format:
  ```js
   tslint "app/**/*.ts" --fix
  ```
* [Turning your rxjs requests](http://plnkr.co/edit/UkKTiWo6MHKbAaSlAIoq?p=info)
  * Turn into upon url, you can find the 'rxjs.extensions.ts' file, you can add your required rxjs libraries in this file.
  * This tip shows you can add your specified rxjs library(ex. import { Observable } from `'rxjs/Observable'`) in your component/service... instead of add all the rxjs libary using `rxjs/rx`(ex. import { Observable } from `'rxjs/rx'`) in order to reduce the times of request, transform size, end up improve loading performance.
  * For the 'rxjs.extensions.ts' file, you need to 'import './rxjs-extensions';'in the 'app.module.ts' file
  * This extension only include all library under the 'add' file in the rxjs, you can refer to that in the 'node_modules'
* [enable production mode](https://github.com/Wwawawa/angular2-fundamentals-Completing/blob/master/ng2-fundamentals/app/main.ts)
* [AHEAD-OF-TIME COMPILATION](https://angular.io/docs/ts/latest/cookbook/aot-compiler.html)
  ```sh
  Ahead-of-time (AOT) vs just-in-time (JIT)
  There is actually only one Angular compiler. The difference between AOT and JIT is a matter of timing and tooling. With AOT, the compiler runs once at build time using one set of libraries; with JIT it runs every time for every user at runtime using a different set of libraries.
  JIT is the standard development approach shown throughout the documentation.
  AOT doesn't have to specifically exclude your not required filed like test files .etc, AOT will walk through the code and figure out which file need to be included in our production build.
  AOT only compile the code file relative app.module.ts from main.ts, cannot deal with the config files, source control files.
  ```
  * install compiler: 'npm install @angular/compiler-cli @angular/platform-server'
  * [tsconfig-aot.json](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/tsconfig-aot.json): It's own tsconfig, compared with [JIT tsconfig.json](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/tsconfig.json).
  * [main.ts](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/app/main-aot.ts): which is different with [JIT compiler main.ts](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/main.ts)
  * [Index.html](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/index.html): which is different with [JIT compiler index.html](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/index.html)
  * AOT No-No's:
    * templateUrl/styleUrl not use full path: should use relative path, [Demo For AOT](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/app/events/create-event.component.ts), compared with [Demo for JIT](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/events/create-event.component.ts), styleUrl like this ,please refer to upvote.component.ts
    * shouldn't declare var for globals: [Toast/jQuery For AOT](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/app/app.module.ts),[Toast/jQuery For JIT](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/app.module.ts)
    * form.controls.controlName:[Demo For AOT](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/app/events/create-event.component.html),[Demo for JIT](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/events/create-event.component.html)
    * control.errors?.someError: [Demo for AOT](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/app/user/profile.component.html),[Demo for JIT](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/user/profile.component.html)
    * Calling method with the right signature: [ngOnChanges for AOT](),[ngOnChanges for JIT](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/events/event-detail/session-list.component.ts)
    * Shouldn't use default exports
    * Functions in providers, routes or declarations of a module
    * Any field used in a template, including Inputs, must be public: [Demo for AOT](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/app/nav/nav.component.ts),[Demo for JIT](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/nav/navbar.component.ts)    
    * ngModel variables cannot be create default:ngModel variables need to create the corresponding items in the component in the aot compiler.[ex. username variable for AOT](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/app/user/login.component.ts),but in the JIT, it doesn't have to create, [ex.username variable for JIT](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/user/login.component.ts)
  * Compiling the application by calling ngc: 'node_modules/.bin/ngc -p tsconfig-aot.json'(windows call '"node_modules/.bin/ngc" -p tsconfig-aot.json').  As well you can create a script for this in your package.json file in order to you can run with something like 'npm run aot'
  * If run successfully, AOT will produce a directory named 'aot', which has all files about aot like module factories and component factories .etc, after that, we will bundle it up with Rollup.
* [Tree Shaking](https://angular.io/docs/ts/latest/cookbook/aot-compiler.html#!#tree-shaking) and Bundling with [Rollup](https://angular.io/docs/ts/latest/cookbook/aot-compiler.html#!#rollup)
  * Rollup doesn't support code splitting, means lazy loaded modules don't work [splitting module for AOT](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/app/routes.ts)--[splitting module for JIT](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/route.ts)
  * install Rollup and all relatived dependences: 'npm install rollup rollup-plugin-node-resolve rollup-plugin-commonjs rollup-plugin-uglify --save-dev'
  * create [rollup.config.js](https://github.com/Wwawawa/angular2-fundamental-exercise/blob/master/chapter17%20Production%20AOT/rollup.config.js)
  * bundle with Rollup: 'node_modules/.bin/rollup -c rollup-config.js'(windows call "node_modules/.bin/rollup"  -c rollup-config.js). As well you can create a script for this in your package.json file to make it easier. after that, we produce a destination folder 'dist' you configured in rollup.config.js
* To production now: copy index.html and build.js and any other files that are referenced by the index.html file.
* [Webpack](https://angular.io/docs/ts/latest/guide/webpack.html) and [Webpack github](https://webpack.github.io/) and [Webpack documentation](https://webpack.js.org/)
  * Webpack support code splitting, means lazy loaded modules can work.
  * [Angular-Cli](https://angular.io/docs/ts/latest/cli-quickstart.html) often use Webpack, please refer to the [document](https://github.com/angular/angular-cli/wiki)
  * Turn into cli project: below refer to [ng-fundamentals-cli](https://github.com/Wwawawa/ng2-fundamentals-cli)
     * Create a blank cli project 
     * copy the app file code into src/app directory
     * align the package.json file
     * align the src/index.html
     * align the src/polyfills.ts
     * align the proxy.conf.json
  * Cli to production just as to WebPack: call below commend line
  ```js
     npm run start:prod
  ```
  * Webpack would not download all the library in the initial, only get the specifical library which you load it, that is mean the library will not load until you render the align application.For solve this problem to add below code into app.module.ts: [demo](https://github.com/Wwawawa/ng2-fundamentals-cli/blob/master/src/app/app.module.ts)
     ```js
     import { PreloadAllModules } from '@angular/router';
     RouterModule.forRoot(appRoutes, {preloadingStrategy: PreloadAllModules})
     ```
  * Cli is able to use AOT
