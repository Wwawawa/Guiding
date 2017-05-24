# Guiding
#### 1-- [Enterprise Library Configuration Console Extension](https://github.com/Wwawawa/Guiding/blob/master/1-EnterpriseLibraryConfExtension.md)
#### 2-- [SSIS DTEXEC](https://github.com/Wwawawa/Guiding/blob/master/2-SSIS-DTEXEC.md)
#### 3-- [for xml path('')](https://github.com/Wwawawa/Guiding/blob/master/3-ForXmlPath.md)
#### 4-- [CSS](https://github.com/Wwawawa/Guiding/blob/master/4-CSS.md)
#### Cross origin
```sh
  jsonp
  CORS
```
#### Authentication inherit
```sh
  <location path="." inheritInChildApplications="true">
```

#### Useful site:
* [Plunker](https://plnkr.co/)
* [identityserver](https://identityserver.github.io/)
* [slideshare](https://www.slideshare.net/)
#### Sharing Course:
* [Mosh Sharing](https://www.youtube.com/channel/UCWv7vMbMWH4-V0ZXdmDpPBA)
* [Kudvenkat Sharing](https://www.youtube.com/user/kudvenkat/featured)
* [Joudeh Sharing](http://bitoftech.net/archive/)
#### Get Max Id Lamada:
```sh
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
