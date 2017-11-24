#### [Access Remote Server DB](https://msdn.microsoft.com/zh-cn/library/ms188313(v=sql.90).aspx)
  * [Linked Server](https://docs.microsoft.com/zh-cn/sql/relational-databases/linked-servers/create-linked-servers-sql-server-database-engine)
  * [sp_addlinkedserver and sp_addlinkedsrvlogin](https://msdn.microsoft.com/zh-cn/library/ms189811(v=sql.90).aspx)
    * Create Connection(only windows identity, details refer to [here](https://msdn.microsoft.com/zh-cn/library/ms189811(v=sql.90).aspx))
    ```sql
      EXEC sp_addlinkedserver   
      @server='DBVIP', 
      @srvproduct='',
      @provider='SQLNCLI'
      @datasrc='serversrc'
    ```
    * Exec Query 
    ```sql
      SELECT count(1) FROM DBVIP.[dababaseName].[dbo].[tableName]
    ```
    
    * Close Connetion
    ```sql
      Exec sp_droplinkedsrvlogin DBVIP,Null
      Exec sp_dropserver DBVIP  
    ```    
  * [Ad hoc distributed queries option](https://msdn.microsoft.com/zh-cn/library/ms187569(v=sql.90).aspx)(refer to [Set Advanced Options](https://msdn.microsoft.com/zh-cn/library/ms189631(v=sql.90).aspx))
    * Set Options  
      ```sql
      EXEC sp_configure 'show advanced options', 1; 
      RECONFIGURE; 
      EXEC sp_configure 'Ad Hoc Distributed Queries', 1 
      RECONFIGURE;  	
      ```
    * Exec Query
    ```sql
      select * from openrowset('SQLOLEDB', 'Server=serverName;Trusted_Connection=yes','SELECT count(1) FROM [dababaseName].[dbo].[tableName]') 
    ```
    * Remove Options
      ```sql
      EXEC sp_configure 'Ad Hoc Distributed Queries', 0 
      RECONFIGURE; 
      EXEC sp_configure 'show advanced options', 0; 
      RECONFIGURE; 
      ```
    
      
      
