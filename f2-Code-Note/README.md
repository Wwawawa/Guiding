#### Cross origin
```sh
  jsonp
  CORS
```
  * Cross origin requests are only supported for HTTP but it's not cross-domain
    * you are loading the model using either file:// or C:/, which stays true to the error message as they are not http://. So you can either install a webserver in your local PC or upload the model somewhere else and use jsonp and change the url to http://example.com/path/to/model.
    * on windows edit the properties of the chrome shortcut and add the switch to the end of the "target" path, e.g.
    ```sh    
      C:\ ... \Application\chrome.exe --allow-file-access-from-files
    ```
#### Authentication inherit
```sh
  <location path="." inheritInChildApplications="true">
```
#### Get Max Id Lamada:
```js
  let newArray=[{id: 1},{id: 2}];
  const maxId=Math.max.apply(null, this.newArray.map(s=>s.id));
```
#### How to simulate a abversable and asynchrony
```js
  searchSessions(searchTerm:string)
  {
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
#### [Object Function Extension](https://github.com/Wwawawa/iac-aspnet/tree/master/6-WS-Federation/EmbeddedSTS/ChangeEmbeddedSTSForAddOutputCliamsDynamically)
* we can add extension methods for a object, as below approach:
  * Can add extention methods for variable which is declared using same type as below
```cs    
    public void IEnumerableTest(IEnumerable<string> testp)
    {
        var test1 = testp.test();
    }
        
        ......
    internal static class myExtensions
    {
        public static string test(this IEnumerable<string> a)
        {
            return "";
        }
    }
```
```cs
    public void Test(string testp)
    {
        var test1 = testp.test();
    }
        
        ......
    internal static class myExtensions
    {
        public static string test(this string a)
        {
            return "";
        }
    }
```



