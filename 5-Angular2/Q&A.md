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
#### 3--Why my observable data from http.get() not be render to page, as well as with a error "uncaught(In promise)..."? refer to [Demo](http://plnkr.co/edit/hJ40JWN6nJpSvr8Ph0y9)
    A: Because this is asynchronous. we need to add "?" behind the property in the html when call this property in double braces in order to support delay rendering.
#### 4--When get data from third resouse url in http, notice the '/' whether to exist or not in the end of url, if set '/' uncorrectly, maybe caurse the cross origin error. ex. 'http://swapi.co/api/films/1`/`' in the [Demo](http://plnkr.co/edit/hJ40JWN6nJpSvr8Ph0y9)  