#### [With As](http://www.cnblogs.com/CareySon/archive/2011/12/12/2284740.html)
  * non-recursive
  ```sql
    with 
    cr as 
    ( 
        select CountryRegionCode from person.CountryRegion where Name like 'C%' 
    ) 
    select * from person.StateProvince where CountryRegionCode in (select * from cr) 
  ```
  ```sql
    with 
    cte1 as 
    ( 
        select * from table1 where name like 'abc%' 
    ), 
    cte2 as 
    ( 
        select * from table2 where id > 20 
    ), 
    cte3 as 
    ( 
        select * from table3 where price < 100 
    ) 
    select a.* from cte1 a, cte2 b, cte3 c where a.id = b.id and a.id = c.id 
  ```
  * [recursive](https://www.cnblogs.com/wenyang-rio/p/3722868.html)
    * 如果已知当前用户ID我要想知道他的上级领导有哪些，可编写sql语句如下
      ```sql
        WITH    Emp
                  AS ( SELECT   ID ,
                                EName ,
                                ParentGUID
                       FROM     dbo.Employee
                       WHERE    ID = '5C8214EC-258B-4C44-9F31-206E499F0285'
                       UNION ALL  
                       SELECT   d.ID ,
                               d.EName ,
                               d.ParentGUID
                      FROM     Emp
                               INNER JOIN dbo.Employee d ON d.ID = Emp.ParentGUID
                    )
           SELECT ID,EName
           FROM    Emp
      ```
    * 相反，如果已知当前用户ID，怎么获取他的下级呢，编写sql语句如下
      ```sql
        WITH    Emp
              AS ( SELECT   ID ,
                            EName ,
                            ParentGUID
                   FROM     dbo.Employee
                   WHERE    ID = '0CD19311-2CA1-4120-9554-11BFD8219AF9'
                   UNION ALL  
                   SELECT   d.ID ,
                            d.EName ,
                           d.ParentGUID
                  FROM     Emp
                           INNER JOIN dbo.Employee d ON d.ParentGUID = Emp.ID
                )
       SELECT ID,EName
       FROM    Emp
      ```

#### [With As Notice](http://www.cnblogs.com/fygh/archive/2011/08/31/2160266.html)
  * CET sql must follow after CET closely
  * In sentence of "CTE_query_definition", it is not allowed that there is as below
    * （1）COMPUTE 或COMPUTE BY
    * （2）ORDER BY（除非指定了TOP 子句）
    * （3）INTO
    * （4）带有查询提示的OPTION 子句
    * （5）FOR XML
    * （6）FOR BROWSE
