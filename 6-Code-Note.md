#### Cross origin
```sh
  jsonp
  CORS
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
#### Tuple
* C# 4.0中增加的一个新特性，元组Tuple，它是一种固定成员的泛型集合:

* Demo
```cs
// Create a 7-tuple.
var population = new Tuple<string, int, int, int, int, int, int>( "New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278); 

//Display the first and last elements.
Console.WriteLine("Population of {0} in 2000: {1:N0}",population.Item1, population.Item7);
```

* 用法非常简单方便，普通的方式我们可能需要这样：
```cs
public class A{ 
 public int ID{get;set;} 
 public string Name{get;set;}
}
A a=new A(){ID=1001,Name='CodeL'};
Console.WriteLine(a.Name);
```
* 而使用Tuple我们只需要这样：
```cs
Tuple<int,string> a=new Tuple<int,string>(1001,'CodeL');
Console.WriteLine(a.Item2);//Item1 代表第一个，Item2代表第二个
```
* Notice
```th
这样我们就可以不用为了 一些简单的结构或对象而去新建一个类了。
注意的是tuple最多支持8个成员，注意第8个成员很特殊，如果有8个成员，第8个必须是嵌套的tuple类型。
列如：Tuple<string, int, int, int, int, int, int, Tuple<int, int, int>>  红色部分是第8个。
第8个元素使用方法：对象.Rest.Item1，对象.Rest.Item2
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



