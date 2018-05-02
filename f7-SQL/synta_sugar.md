* 1- query data with count rows in sql
  ```sql
    select top 5 *,count(1) over() as totalCount from [table]
  ```
