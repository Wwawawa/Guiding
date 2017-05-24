#### Get Max Id Lamada:
```js
  let newArray=[{id: 1},{id: 2}];
  const maxId=Math.max.apply(null, this.newArray.map(s=>s.id));
```
#### How to simulate a abversable and asynchrony
```js
  searchSessions(searchTerm:string){
          var term=searchTerm.toLocaleLowerCase();
          var results=[]
          events.forEach(event=>{
                var macthSession=event.sessions.filter(session=>
                  session.name.toLocaleLowerCase().indexOf(term)>-1);
                macthSession=macthSession.map((session:any)=>{
                  session.eventId=event.id;
                  return session;
                })
                results=results.concat(macthSession);
          })
          var emitter=new EventEmitter(true);//simulate the observable
          setTimeout(function() {  
            emitter.emit(results);
          }, 100); //simulate the asynchrony
          return emitter;
        } 
```

