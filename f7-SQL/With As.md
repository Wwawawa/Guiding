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
    * Create Table
    ```sql
       CREATE TABLE [dbo].[Employee](
         [ID] [uniqueidentifier] NOT NULL,--用户ID
         [EnterpriseCode] [uniqueidentifier] NOT NULL,--企业标识
         [ParentGUID] [uniqueidentifier] NOT NULL,--上级ID
         [ECode] [nvarchar](50) NOT NULL,--员工编号
         [EName] [nvarchar](200) NOT NULL--员工名称
           CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
          (
              [ID] ASC
         )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
         ) ON [PRIMARY]

         GO
    ```
    ```sql
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'5b82d74d-c5c7-4cbb-af28-0518bdc257d9', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'00000000-0000-0000-0000-000000000000', N'SG0012', N'张志军')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'0cd19311-2ca1-4120-9554-11bfd8219af9', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'5b82d74d-c5c7-4cbb-af28-0518bdc257d9', N'KP10035', N'杜高扬')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'dd994fda-1703-4616-af1b-165164df710e', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'5b82d74d-c5c7-4cbb-af28-0518bdc257d9', N'SG0005', N'赵宾 ')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'ef7c0c60-2545-4c5a-baa6-1a0eec3557b3', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'5b82d74d-c5c7-4cbb-af28-0518bdc257d9', N'KP10029', N'屠玉韵')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'557c113a-786a-4dbc-9eb6-1aa80cfd9e68', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'5b82d74d-c5c7-4cbb-af28-0518bdc257d9', N'0119', N'陈佳楠')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'80012614-b153-4bc6-b5da-0db244cccf9b', N'SG0001', N'张忠荣')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'5c8214ec-258b-4c44-9f31-206e499f0285', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0cd19311-2ca1-4120-9554-11bfd8219af9', N'0129', N'孙跃光')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'df5d082c-baa3-4315-b234-209b50c37e7a', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0cd19311-2ca1-4120-9554-11bfd8219af9', N'0109', N'姚宇')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'5d68e6c2-6e7e-4608-8cd2-234557fcacef', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0cd19311-2ca1-4120-9554-11bfd8219af9', N'KP10040', N'贺雅柔')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'9627fdcf-affa-424b-b1ca-24538b101986', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0cd19311-2ca1-4120-9554-11bfd8219af9', N'0120', N'简婧晖')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'6eccd0ec-11ad-45e3-98b6-2457cf61da2e', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'dd994fda-1703-4616-af1b-165164df710e', N'KP10027', N'苗英叡')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'1416b56c-d54a-41eb-83c2-25573cb25f4b', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'dd994fda-1703-4616-af1b-165164df710e', N'KP10013', N'柴天元')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'868030db-7f25-4bc0-8ff7-259759426250', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'dd994fda-1703-4616-af1b-165164df710e', N'0114', N'师萱倩')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'a81a9114-b7c9-41b6-818e-2a418e3dd14d', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'dd994fda-1703-4616-af1b-165164df710e', N'0125', N'张怀宝')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'166fa95a-0425-40e3-8cb9-2a4c97ca4cc6', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'ef7c0c60-2545-4c5a-baa6-1a0eec3557b3', N'KP10025', N'邵乐家')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'6e94aa52-700a-4415-bb8a-34345605e13d', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'ef7c0c60-2545-4c5a-baa6-1a0eec3557b3', N'SG0011', N'李恒钓')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'c5e537d4-0994-43e2-a1ab-3f736b4e22d3', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'ef7c0c60-2545-4c5a-baa6-1a0eec3557b3', N'KP10015', N'龚高朗')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'61f79eaf-db86-425e-a61c-4228265eec28', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'ef7c0c60-2545-4c5a-baa6-1a0eec3557b3', N'KP10038', N'卜婉慧')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'34c26725-3726-4c45-90c0-440c91ef34b8', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'ef7c0c60-2545-4c5a-baa6-1a0eec3557b3', N'0105', N'苏晓会')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'3d09264c-5a0d-46fd-b924-443585ad61bc', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'557c113a-786a-4dbc-9eb6-1aa80cfd9e68', N'KP10026', N'夏成龙')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'30b558f3-be74-4127-b91f-444e858ef9ff', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'557c113a-786a-4dbc-9eb6-1aa80cfd9e68', N'KP10004', N'马乐意')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'4b1d5979-1ef7-4927-9b6b-44f151d2d803', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'557c113a-786a-4dbc-9eb6-1aa80cfd9e68', N'0110', N'刘文强')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'0107', N'徐连翔')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'ee09d65c-8780-4736-b636-4d9335bfdd80', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'KP10028', N'银嘉树')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'94e3071a-6b00-4f53-9dd0-4fe0fc9bef51', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'0126', N'赵硕')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'123580a5-25c7-4315-b75b-584e86fe945e', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'KP10018', N'刁意智')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'119d1cd2-c8af-4a7e-a1be-5eed11011e09', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'KP10033', N'金季同')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'c7da19df-a45b-4441-9c0e-5f216f5b1950', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'KP10006', N'乌奇逸')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'07912b56-dd54-44f2-b251-61d1e0537c7f', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'0112', N'汪素萍')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'bc9ac28d-010b-45bc-b10b-63998c97c058', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'KP10014', N'古承颜')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'df2d222f-e009-4fa9-b0e4-63c81f4c9976', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'c5b58ce6-96b7-496d-bceb-1e7c659badbd', N'0106', N'郝晓妍')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'34569802-4a83-4851-86cb-678b254850ba', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10031', N'朱自怡')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'a4129729-a96f-44e1-908e-6a2c4e7ba5fa', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'0128', N'姚林蜀')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'd37c7008-c98d-4374-b153-6cc93e1a39ce', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'0102', N'刘倩')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'0122', N'刘广斗')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'c8cf644a-af3f-427b-b7f8-6dc79170259e', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10034', N'房文栋')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'e28d744e-c22f-4fce-9155-6f79d8b426dc', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'SG0013', N'赵斌 ')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'a28b560a-6069-48b8-bb0c-718154b35d42', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'0117', N'刘好')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'38998b88-0425-466c-9197-73a731bed720', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10003', N'巴元良')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'c2de93d0-44d9-4fff-b4aa-74872f315df6', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'0115', N'续非')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'2159a71e-c7d5-4a6d-8719-7971834a6a17', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'0104', N'庄泽雨')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'c439c6bf-45fe-4274-9a89-7a650d9500ba', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'SG0010', N'张亚春')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'd85ba73e-9095-4f1d-b58d-7c02a5396bea', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10011', N'卜飞羽')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'ddf77f91-23fd-48b9-b114-7ef96b6af839', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'SG0002', N'张仲礼')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'b462147f-b47f-46b8-86f4-8042911d25aa', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'0103', N'毛婧')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'194b51e7-285f-4e3b-b723-8b2a568030e1', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10022', N'颉高懿')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'f02647c7-e8c7-4f7b-b007-8dd86e679f27', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10010', N'樊振国')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'fcd56ee6-6658-4337-bda4-98b0e2c5bced', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10016', N'柳德运')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'a949e892-f1a8-4cfc-8aa7-98cfb33a8607', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'SG0006', N'赵芳 ')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'6c20a6f8-f629-4d09-9c66-99c8ec19b9ee', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10036', N'聂思博')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'16b69138-c66a-4ff4-b770-9a239f51403a', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'KP10008', N'蔺力强')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'fde7c22c-b6e9-43e5-93c0-a0f548a8fe28', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'SG0003', N'张宗敏')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'a4c474a4-d885-4ecd-970e-a131abd459fc', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'bdc8cbdc-3511-41dc-899c-4b61969ff65c', N'0118', N'刘晋杰')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'309b57d7-8db3-4f06-bd2d-a33cdae8a2b2', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10005', N'闻成龙')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'f9ee4009-aa1f-4382-be0c-a40ebe77d91f', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10020', N'干新霁')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'ee7f3171-e7e7-468a-9a97-a47367fa62f9', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10032', N'邝和泽')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'54c86d68-4d75-42d4-8687-aa60148408b0', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'0127', N'张莉')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'7d7c0c91-b4d2-45b0-820e-ab36303976d7', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10017', N'攀弘毅')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'513f792c-4e49-4d5b-8d27-acff8c39cf3c', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10002', N'邸英武')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'f8e70a5b-075b-4485-a56c-af7e1e3caffe', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10001', N'乔泰和')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'cf1ebf4f-eeda-4681-91f5-c24864b791ab', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10019', N'言意致')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'7c8d67fc-9f69-4fb9-a6df-c9ad7a24dd8b', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10012', N'沿成礼')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'f7a2bd1d-e7ed-418b-8366-ca749d2a4f71', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10009', N'查泰宁')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'14291e5f-0ab7-433a-88b7-ccd860658e38', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10024', N'国和悦')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'dd0bde40-5f56-48de-992b-ce92689421b9', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'KP10023', N'房嘉佑')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'66ee973d-c1ca-4ad8-9a57-d0acdd26d901', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'0e2ead0b-4f6a-42e6-b954-6cf141fd025f', N'SG0007', N'赵锋 ')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'fee614d1-29ca-4392-9339-d128b7568adc', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'0121', N'吴健会')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'92a0438c-03e2-4570-9322-d1372be54001', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'KP10039', N'殷霞文')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'cc63d7ef-1a72-4ad9-921a-d1e898147faa', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'0108', N'童禾')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'0ed98987-240b-4c86-9f48-d26d3402536c', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'0123', N'杨轶')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'3e8ce818-43e4-486e-8bc6-da63899b9df9', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'KP10007', N'历浩言')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'99d3f991-3000-4720-bc9f-df2714b8ce79', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'KP10021', N'冶星文')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'908c3232-a15a-49f2-a4fa-e21e2ebe29be', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'SG0004', N'赵标 ')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'b0ad74df-71e2-480c-9cf0-e9f036ac42c4', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'0116', N'姚添慧')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'd85e67ea-e03c-472c-a249-eee76ff36524', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'0111', N'叶楠楠')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'7bde57d9-da29-4474-8820-ef3b9b2fa8e7', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'KP10037', N'范夏岚')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'e28b7754-d943-4129-a8c4-ef60dfbe28e2', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'SG0014', N'赵春风')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'd4929e92-d34f-4223-b609-f1b6b7ff5a07', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'0124', N'姚静')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'9a150666-fac1-4ba1-bc63-f2bf3f0055f1', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'SG0008', N'赵福涛')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'1fd9eec8-998b-4808-b963-f8bf3b7052b3', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'0113', N'黄爱辉')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'7ba375aa-756b-4065-aa9a-fb3029c9b208', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'KP10030', N'古信厚')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'48ce3cc3-cfc2-4cf2-92d3-fbf87e0200c0', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'b462147f-b47f-46b8-86f4-8042911d25aa', N'SG0009', N'张雷 ')
        GO
        INSERT [dbo].[Employee] ([ID], [EnterpriseCode], [ParentGUID], [ECode], [EName]) VALUES (N'0bca35ad-91b7-46f5-83b0-ffcdfdfe8d50', N'06bc0b1c-25b8-4d62-a1d6-ac7be1becf56', N'557c113a-786a-4dbc-9eb6-1aa80cfd9e68', N'0101', N'杨硕')
        GO
    ```
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
