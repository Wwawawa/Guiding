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
