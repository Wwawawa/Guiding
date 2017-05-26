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
