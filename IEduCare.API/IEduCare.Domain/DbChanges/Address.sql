/*
   03 March 202112:09:47
   User: 
   Server: SOFTWARE\MSSQLSERVER2017
   Database: iEduCareDb
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Address
	(
	Id uniqueidentifier NOT NULL,
	Line1 nvarchar(128) NOT NULL,
	Line2 nvarchar(128) NOT NULL,
	Line3 nvarchar(128) NULL,
	City nvarchar(128) NOT NULL,
	CreateDate datetime NOT NULL,
	CreatedBy nvarchar(450) NOT NULL,
	UpdateDate datetime NULL,
	IsDeleted bit NOT NULL,
	StatusId uniqueidentifier NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Address ADD CONSTRAINT
	PK_Address PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Address SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Address', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Address', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Address', 'Object', 'CONTROL') as Contr_Per 