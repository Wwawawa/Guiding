使用自连接、for xml path('')和stuff合并显示多行数据到一行中
```sh
3. --注  	
4. --1、计算列可以不用包含在聚合函数中而直接显示，如下面语句的val。  	
5. --2、for xml path('') 应该应用于语句的最后面，继而生成xml。  	
6. --3、for xml path('root')中的path参数是生成的xml最顶级节点。  	
7. --4、字段名或是别名将成为xml的子节点，对于没有列名(字段+'')或是没有别名的字段将直接显示。如[value] +','则是用,分隔的数据(aa,bb,)。  	
8. --5、对于合并多行数据显示为一行数据时使用自连。  	
9.   	
10. --生成测试表并插入测试数据  	
11. create table tb(id int, value varchar(10))  	
12. insert into tb values(1, 'aa')  	
13. insert into tb values(1, 'bb')  	
14. insert into tb values(2, 'aaa')  	
15. insert into tb values(2, 'bbb')  	
16. insert into tb values(2, 'ccc')  	
17. go  	
18.   	
19. --第一种显示  	
20. select id, [val]=(  	
21. select [value] +',' from tb as b where b.id = a.id for xml path('')) from tb as a  	
22. --第一种显示结果  	
23. --1 aa,bb,  	
24. --1 aa,bb,  	
25. --2 aaa,bbb,ccc,  	
26. --2 aaa,bbb,ccc,  	
27. --2 aaa,bbb,ccc,  	
28.   	
29.   	
30. --第二种显示  	
31. select id, [val]=(  	
32. select [value] +',' from tb as b where b.id = a.id for xml path('')) from tb as a  	
33. group by id  	
34. --第二种显示结果  	
35. --1 aa,bb,  	
36. --2 aaa,bbb,ccc,  	
37.   	
38.   	
39. --第三种显示  	
40. select id, [val]=stuff((  	
41. select ','+[value] from tb as b where b.id = a.id for xml path('')),1,1,'') from tb as a  	
42. group by id  	
43. --第三种显示结果  	
44. --1 aa,bb  	
45. --2 aaa,bbb,ccc  	
46.   	
47.   	
48. --典型应用  	
49. --AMD_GiftNew中获取所有的管理员ID  	
50. --select adminIds = stuff((select ','+cast(UserId as varchar) from MM_Users where RoleId = 1 and flag =0 for xml path('')),1,1,'')  	
51. --典型应用显示结果  	
52. --3,27  	
53. You just need to use the right options with FOR XML. Here's one approach that avoids encoding:	
	
USE tempdb;	
GO	
	
CREATE TABLE dbo.x(y NVARCHAR(255));	
	
INSERT dbo.x SELECT 'Sports & Recreation'	
   UNION ALL SELECT 'x >= y'	
   UNION ALL SELECT 'blat'	
   UNION ALL SELECT '<hooah>';	
	
-- bad:	
SELECT STUFF((SELECT ',' + y	
 FROM dbo.x FOR XML PATH('')), 1, 1, '');	
	
-- good:	
SELECT STUFF((SELECT ',' + y	
 FROM dbo.x FOR XML PATH, TYPE).value('.[1]',	
 'nvarchar(max)'), 1, 1, '');	
	
 GO	
 DROP TABLE dbo.x;	
```
