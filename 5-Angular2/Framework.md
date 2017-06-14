### Structure(ex. [ng2-fundamentals](https://github.com/Wwawawa/angular2-fundamentals-JIT/tree/master/ng2-fundamentals))
1. tsconfig.json: compile ts into js configuration
2. [systemjs.config.js]((https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/systemjs.config.js)): package path configuration
3. styles.css: global css file
4. package.json: dependence package configuration
5. [index.html](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/index.html): page entry html(included package reference)
   * Load the main.ts
     * Loading from systemjs.config.js  
        ```js
              <script>        
                System.import('app').catch(function(err){console.error(err); });       
              </script>
              // for this, we must add the config into [systemjs.config.js]:
                packages: {
                    app: {
                      main: './main.js',
                      defaultExtension: 'js'
                    },
                    ....
        ```
      * Loading directly
      ```js
         <script>
            System.import('main.js').catch(function(err){ console.error(err); });//notice the main.js path
         </script>
      ```
6. [main.ts](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/main.ts): bootstrap module
7. [app.module.ts](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/app.module.ts): module file. which is used to register component, service, router.etc, in other words, all blocks are registered in a module(of caurse can have muiltiple module), as-is this file. it is bootstraped by main.ts
8. [app.component.ts](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/events/events-app.component.ts): which can be renamed any name, this is top componnet which is all component entry and router bootstrap by '<router-outlet></router-outlet>', it will be added into bootstrap node of app.module.ts(ex. [bootstrap: [EventsAppComponent]](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/app.module.ts))
9. [routes.ts](https://github.com/Wwawawa/angular2-fundamentals-JIT/blob/master/ng2-fundamentals/app/route.ts): optional, build this file if need to router, it is bootstrap by app.component.ts(<router-outlet></router-outlet>).

### Block
#### module

* muiltiple module, now only learning about relation with each other by router, child module not need to bootstrap in main.ts, it can be registered in router of parent module. reference [Multiple module - Lazily Loading Feature Modules](https://plnkr.co/edit/MkLLiAJWkHYjjJ58SYA8) 

#### Component
* comunicating with each other
  * @input() //with child component
    * @input() can use function like below, details refer to [upvote style changing](https://github.com/Wwawawa/angular2-fundamentals-Completing/blob/master/ng2-fundamentals/app/events/event-detail/upvote.component.ts)
      ```js
          @Input() set voted(val){
            this.iconColor = val ? 'red' : 'white'
          }
      ```
  * @Output() //with parent component

* can add style
* component reusing(ng-content)
* customize the component template ID
* Get a component method: @ViewChild/@ViewChildren/@ContentChild/@ContentChildren and others
#### Service

#### Router

#### Directive

#### Form
* Template-based Form
* Reactive Form

#### Pipe(data format)
* filter
* sort
* format
#### DI(dependence injection)

