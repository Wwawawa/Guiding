#### Creating and Communicating Between Components
* 1--[Communicating with Child Components](https://plnkr.co/edit/NPY5og89qxa1jhWuOHtw)
* 2--[Communicating with Parent Components](https://plnkr.co/edit/Rm0nL9uMgGPUO3j7EH0F)
* 3--[Using Template Variables To Interact With Child Components](https://plnkr.co/edit/iOJ6d1tsUra0qbNYX54P)
* 4--[Styling Components And Navigation Showing](https://plnkr.co/edit/zIOcnEtO4Hx4u59AqoGx?p=info)
#### Exploring the New Template Syntax
* 5--[Repeating Data with ngFor](https://plnkr.co/edit/UoJWGBKmwsHuI4HvooIl)
* 6--[Handling Null Values with the Safe-Navigation Operator](https://plnkr.co/edit/K8JTinIjcw0u7FiuZpMM)
* 7--[Hiding and Showing Content with ngIf](https://plnkr.co/edit/LXnlULhj6nBPO7yifo7A)
* 8--[Hiding Content with the [Hidden] Binding](https://plnkr.co/edit/4Ui7kEHOp3fPLkcYaG6B)
* 9--[Hiding and Showing Content with ngSwitch](https://plnkr.co/edit/Vilb8799fzOC7pVsA5pR)
* 10--[Adding Style with ngClass](https://plnkr.co/edit/8jCI9tJjcnE013mmsHi4)
* 11--[Adding Style with ngStyle](https://plnkr.co/edit/6DWm5DAlIKXLjxY2HwhN?p=info)
#### Creating Reusable Services
* [Creating a Service And Inject Third Library](https://plnkr.co/edit/3cGfzHAKmt6DYZtJl8DK)
#### Routing and Navigating Pages
* [Creating a Route and avoid conflict when the similar router appearing](http://plnkr.co/edit/uxm1kj8A8DIXQQg4VPQf)
* [Accessing Route Parameters](http://plnkr.co/edit/7MJZc2FuP4wlzo88098n)
* [Linking to Routes](http://plnkr.co/edit/kGFJkbKPElB2tjBddyJh)
* [Navigating from Code](http://plnkr.co/edit/o40fPMINvax9bORdvy6H)
* [Guarding Against Route Activation](http://plnkr.co/edit/Ckuj11eAQUQQiG88Vz02)
* [Guarding Against Route De-Activation](http://plnkr.co/edit/Jl1BTwuClfbAydwgJqbp)
* [Observable And Simulate Asynchrony And Pre-Loading avioding the page partially load before data loading using resolve route](http://plnkr.co/edit/42W34uedJsxSnO4GfuCR)
* [Styling Active Links](http://plnkr.co/edit/yF5qkZWdPp6WzlArxtfX)
* [Multiple module - Lazily Loading Feature Modules](https://plnkr.co/edit/MkLLiAJWkHYjjJ58SYA8)
* [Barrels - Organizing Your Exports](https://plnkr.co/edit/C0aY1Hlqb5JwqCIhFAho)
#### Collecting Data with Forms and Validation
* [Using Models for Type Safety - interface not known in plunker](http://plnkr.co/edit/vDWIzoZrYW6JrU1q1IAa)
* [Creating a Template-based Form](http://plnkr.co/edit/oIVnAkszqOGwDyYTm7WF)
* [Validating a Template-based Form](http://plnkr.co/edit/1VqzHIqrHY4QY1QL3Uko)
* [Creating a Reactive Form ](http://plnkr.co/edit/LFob432TyAjwdEoc4Qo7)
* [Validating a Reactive Form And Multiple Validating](http://plnkr.co/edit/SUUG6w0QUJqU3cGtFrd0)
* [Adding a Custom Validator](http://plnkr.co/edit/FeYhmKgjR7nFoR0Op5xa)
#### Reusing Components with Content Projection
* [Using Content Projection](http://plnkr.co/edit/Zwe0OOwAQdXvHFn6k2jO)
* [Multiple Slot Content Projection](http://plnkr.co/edit/ski3P20beoPdlO2ZwQ0C)
#### Manipulating Data With Pipes
* [Using the Lower Case Pipe](http://plnkr.co/edit/pkKZAyBSD4VZoabcCo8G)
* [Using the Date Pipe](http://plnkr.co/edit/5tJ636Obmt77bro2b7WW)
* [Creating Custom Pipes](http://plnkr.co/edit/S7guOz5qx5xbzJHd3iHb)
* [Use the ngOnChanges lifecycle hook](http://plnkr.co/edit/EDPFB6N8k0XQRFMM448w)
* [Filter a list of movies by their rating](http://plnkr.co/edit/QVA3vMEgSQJ8XoUR7ElK)
* [Sort a list of movies by their rating](http://plnkr.co/edit/W8MhzGXjrphkra0DCOCg)
#### Understanding Dependency Injection
* [Use Opaque Token & @Inject (shorthand use the third-party's all methods and avoiding the conflict of the named)](http://plnkr.co/edit/pMDVwbUkjVR7qUUcvlp8)
* [Use the useExisting Provider(shorthand using the existing service to a new service which has not built-in)](http://plnkr.co/edit/PTojTPcFreI5IX27Edyv)
#### Creating Directives and Advanced Components
* [Creating a Directive](http://plnkr.co/edit/tEDReQReECfkysJCD0fC)
* [Navigation Search](http://plnkr.co/edit/F54Q88J571Abck92fE35)
   * Wrapping the jQuery And  Add Modal 
   * Collapsable 
   * Directive 
   * customize the id for a component template(.ex Modal)
   * simulate the returning observable
    ```js
          var emitter=new EventEmitter(true);
          setTimeout(function() {
            emitter.emit(results);
          }, 100);
          return emitter;
    ```
* [resolving issues about component not be loaded if change router parameters And Hide the modal](http://plnkr.co/edit/2mSJYTmnHecz0h5HUau5)
* [Using the @ViewChild Decorator to hide the mode](http://plnkr.co/edit/b1L5jEuMsNHOYf0LB6Al)
#### Customer validators
* [Customer a validator](http://plnkr.co/edit/A3hJUkP88mDZRDxF3ajQ)
  * Add the validator into NG_VALIDATORS list which include all the validators in angular(NOTICE：add the multi property avoiding the override the NG_VALIDATORS) 
  * FormGroup.Root which is used to get the parent node of current node
  * "#locationGroup="ngModelGroup"": add locationGroup attribute into the specifical html
#### Communicating with the Server using HTTP, Observables, and Rx
* [Massaging Requested Data with Map](http://plnkr.co/edit/ODS0GhIb2Rb5OdXaegLo)
* [Making an HTTP Request](http://plnkr.co/edit/hJ40JWN6nJpSvr8Ph0y9)
  * using '?' to call asynchronous data in html 
  * notice the '/' when call third-party data url
* [refresh data from resolve service when call again](http://plnkr.co/edit/krHtnnzSZunZEZpIPZH9)
* [Http using Querystring Parameters](http://plnkr.co/edit/UkKTiWo6MHKbAaSlAIoq)
#### To Production([Deployment](https://angular.io/docs/ts/latest/guide/deployment.html#!#sts=Optimize%20for%20production))
* [TSLint](https://palantir.github.io/tslint/)
  * TSLint orders: You can see it in the code which has incorrect typical format, move cover to your code which has incorrect typical format, you can see the orders detected this error, you can disable it in your 'tslint.json' config file.
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
