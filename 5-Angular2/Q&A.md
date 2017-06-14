#### 1--Why @Input() transform variables have below ways:
```js
    @Input('modal-trigger') modalID:string
    @Input adress:string
```
    A: "-" is not allowed in the angular 2 as a variable, so we need to alias this use "@Input('modal-trigger') modalID:string". means use mainID alias the 'modal-trigger' to restore the value of 'modal-trigger'

#### 2--Why @Input() transform variables have below ways in the html:
```js
    [adress]="event.sessions"
    title="Found Sessions"
```
    A: With [] means there is a property from component class left right the "=", .ex the 'event.session' the event is a property of the component.
    and without [] means there is a string left right the "=", is not a property, .ex 'Found Sessions' which is only transform a piece of string "Found Sessions" to @Input title
#### 3--Why my observable data from http.get() not be render to page, as well as with a error "uncaught(In promise)..."? ex. "{{movie?.title}}" in the [Demo](http://plnkr.co/edit/hJ40JWN6nJpSvr8Ph0y9)
    A: Because this is asynchronous. we need to add "?" behind the property in the html when call this property in double braces in order to support delay rendering.
#### 4--When get data from third resouse url in http, notice the '/' whether to exist or not in the end of url, if set '/' uncorrectly, maybe caurse the cross origin error. ex. "/" in the end of http://swapi.co/api/films/1/  in the [Demo](http://plnkr.co/edit/hJ40JWN6nJpSvr8Ph0y9)
#### 5--Resolve service need to transform the router parameters when need the router parameters, ex. 
```js
    resolve(router:ActivatedRouteSnapshot){
        return this.eventService.getEvent(router.params['id']);
    }
```
#### 6-- OpaqueToken has been replaced by InjectionToken, see [angular/angular@d169c24](https://github.com/angular/angular/commit/d169c2434e3b5cd5991e38ffd8904e0919f11788)
#### 7-- For vs code editor, remove all .js files and .js.map files in order to clean the directory, we can add below configuration into vsCode setting(file->Preferences->settings:USER SETTINGS section right the view window):
```json
    "files.exclude": {
        "app/**/*.js":true,
        "app/**/*.map":true
    }
```
