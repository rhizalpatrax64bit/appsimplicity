IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CUSTOMERS_SP_SELECT]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1) 
	BEGIN		
		DROP PROCEDURE [dbo].[CUSTOMERS_SP_SELECT]
	END
EXEC dbo.sp_executesql @statement = N'

-- ----------------------------------------------------------------------------------------------------------------      
--                  Proyecto : ActiveRecordTests.vbproj
--             Base de Datos : Dummy
--       Tablas Involucradas : Customers
--                  Objetivo : Obtener un registro de la tabla Customers
--             Observaciones : ESTE PROCEDIMIENTO FUE GENERADO POR UNA HERRAMIENTA DE GENERACIÓN DE CÓDIGO
--
--              Generado por : INVERCAP\JPITALUA
--       Fecha de generación : 21/09/2009 11:57:38 a.m.        
-- ----------------------------------------------------------------------------------------------------------------     
CREATE PROCEDURE [dbo].[CUSTOMERS_SP_SELECT]
           @Id AS INT
AS
BEGIN
	
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
        SET NOCOUNT ON

        SELECT
           [Customers].[Id] AS [Customers.Id]
          ,[Customers].[Name] AS [Customers.Name]
          ,[Customers].[Address] AS [Customers.Address]
          ,[Customers].[Phone] AS [Customers.Phone]
          ,[Customers].[BirthOn] AS [Customers.BirthOn]
          ,[Customers].[AnnualIncoming] AS [Customers.AnnualIncoming]
          ,[Customers].[Active] AS [Customers.Active]
          ,[Customers].[Average] AS [Customers.Average]
          ,[Customers].[UserType_Id] AS [Customers.UserType_Id]
        
        FROM Customers 
        WHERE
        Id = @Id        

END


'
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CUSTOMERS_SP_INSERT]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1) 
	BEGIN		
		DROP PROCEDURE [dbo].[CUSTOMERS_SP_INSERT]
	END
EXEC dbo.sp_executesql @statement = N'

-- ----------------------------------------------------------------------------------------------------------------      
--                  Proyecto : ActiveRecordTests.vbproj
--             Base de Datos : Dummy
--       Tablas Involucradas : Customers
--                  Objetivo : Insertar un registro en la tabla Customers
--             Observaciones : ESTE PROCEDIMIENTO FUE GENERADO POR UNA HERRAMIENTA DE GENERACIÓN DE CÓDIGO
--
--              Generado por : INVERCAP\JPITALUA
--       Fecha de generación : 21/09/2009 11:57:38 a.m.        
-- ----------------------------------------------------------------------------------------------------------------     
CREATE PROCEDURE [dbo].[CUSTOMERS_SP_INSERT]
           @Name AS VARCHAR(50)
          ,@Address AS TEXT
          ,@Phone AS VARCHAR(20)
          ,@BirthOn AS SMALLDATETIME
          ,@AnnualIncoming AS MONEY
          ,@Active AS BIT
          ,@Average AS FLOAT
          ,@UserType_Id AS INT

AS
BEGIN
	
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
        SET NOCOUNT ON

        INSERT INTO [dbo].[Customers] (
           Name
          ,Address
          ,Phone
          ,BirthOn
          ,AnnualIncoming
          ,Active
          ,Average
          ,UserType_Id

        )		
        VALUES (
           @Name
          ,@Address
          ,@Phone
          ,@BirthOn
          ,@AnnualIncoming
          ,@Active
          ,@Average
          ,@UserType_Id

        )

        SELECT @@IDENTITY

END

'

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CUSTOMERS_SP_UPDATE]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1) 
	BEGIN		
		DROP PROCEDURE [dbo].[CUSTOMERS_SP_UPDATE]
	END
EXEC dbo.sp_executesql @statement = N'

-- ----------------------------------------------------------------------------------------------------------------      
--                  Proyecto : ActiveRecordTests.vbproj
--             Base de Datos : Dummy
--       Tablas Involucradas : Customers
--                  Objetivo : Actualizar un registro en la tabla Customers
--             Observaciones : ESTE PROCEDIMIENTO FUE GENERADO POR UNA HERRAMIENTA DE GENERACIÓN DE CÓDIGO
--
--              Generado por : INVERCAP\JPITALUA
--       Fecha de generación : 21/09/2009 11:57:38 a.m.        
-- ----------------------------------------------------------------------------------------------------------------     
CREATE PROCEDURE [dbo].[CUSTOMERS_SP_UPDATE]
           @Id AS INT
          ,@Name AS VARCHAR(50)
          ,@Address AS TEXT
          ,@Phone AS VARCHAR(20)
          ,@BirthOn AS SMALLDATETIME
          ,@AnnualIncoming AS MONEY
          ,@Active AS BIT
          ,@Average AS FLOAT
          ,@UserType_Id AS INT

AS
BEGIN
	
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
        SET NOCOUNT ON

        UPDATE Customers 
          SET
           Name = @Name
          ,Address = @Address
          ,Phone = @Phone
          ,BirthOn = @BirthOn
          ,AnnualIncoming = @AnnualIncoming
          ,Active = @Active
          ,Average = @Average
          ,UserType_Id = @UserType_Id
          
        WHERE
        Id = @Id        

        SELECT @@ROWCOUNT

END


'
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CUSTOMERS_SP_DELETE]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1) 
	BEGIN		
		DROP PROCEDURE [dbo].[CUSTOMERS_SP_DELETE]
	END
EXEC dbo.sp_executesql @statement = N'

-- ----------------------------------------------------------------------------------------------------------------      
--                  Proyecto : ActiveRecordTests.vbproj
--             Base de Datos : Dummy
--       Tablas Involucradas : Customers
--                  Objetivo : Eliminar un registro de la tabla Customers
--             Observaciones : ESTE PROCEDIMIENTO FUE GENERADO POR UNA HERRAMIENTA DE GENERACIÓN DE CÓDIGO
--
--              Generado por : INVERCAP\JPITALUA
--       Fecha de generación : 21/09/2009 11:57:38 a.m.        
-- ----------------------------------------------------------------------------------------------------------------     
CREATE PROCEDURE [dbo].[CUSTOMERS_SP_DELETE]
           @Id AS INT
AS
BEGIN
	
        SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED 
        SET NOCOUNT ON

        DELETE FROM Customers 
        WHERE
           Id = @Id        

        SELECT @@ROWCOUNT

END


'
