### Structure
1. tsconfig.json: compile ts into js configuration
2. systemjs.config.js: package path configuration
3. styles.css: global css file
4. package.json: dependence package configuration
5. index.html: page entry html(included package reference)
6. main.ts: bootstrap module
7. app.module.ts: module file. which is used to register component, service, router.etc, in other words, all blocks are registered in a module(of caurse can have muiltiple module), as-is this file. it is bootstraped by main.ts
8. app.component.ts: which can be renamed any name, this is first componnet which is all component entry and router bootstrap by '<router-outlet></router-outlet>'
9. routes.ts: optional, build this file if need to router, it is bootstrap by app.component.ts(<router-outlet></router-outlet>).

### Block
#### module

* muiltiple module, now only learning about relation with each other by router, child module not need to bootstrap in main.ts, it can be registered in router of parent module. reference [Multiple module - Lazily Loading Feature Modules](https://plnkr.co/edit/MkLLiAJWkHYjjJ58SYA8) 

#### Component
* comunicating with each other
```js
  @input() //with child component
  @Output() //with parent component
```
* can add style
* component reusing(ng-content)
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

