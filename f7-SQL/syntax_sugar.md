* 1- query data with count rows in sql
  ```sql
    select top 5 *,count(1) over() as totalCount from [table]
  ```
* 2- Merge into with return value
```sql
      MERGE INTO @TargetTable AS T           
      USING @SourceTable AS S                
         ON T.ID = S.ID                      
      WHEN MATCHED         
         THEN UPDATE SET T.DSPT = S.DSPT  
      WHEN NOT MATCHED BY TARGET   
         THEN INSERT VALUES(S.ID,S.DSPT)
      WHEN NOT MATCHED BY SOURCE            
         THEN DELETE
      OUTPUT $ACTION AS [ACTION],
         Deleted.ID AS 'Deleted ID',
         Deleted.DSPT AS 'Deleted Description',
         Inserted.ID AS 'Inserted ID',
         Inserted.DSPT AS 'Inserted Description'
      INTO @Log;
```

```Sql
      MERGE INTO @TargetTable AS T           
      USING @SourceTable AS S                
         ON T.ID = S.ID                      
      WHEN MATCHED         
         THEN UPDATE SET T.DSPT = S.DSPT  
      WHEN NOT MATCHED BY TARGET   
         THEN INSERT VALUES(S.ID,S.DSPT)
      WHEN NOT MATCHED BY SOURCE            
         THEN DELETE
      OUTPUT $action as ACTION_NAME, inserted.*, SYSDATETIME();
      INTO @Log;
```
