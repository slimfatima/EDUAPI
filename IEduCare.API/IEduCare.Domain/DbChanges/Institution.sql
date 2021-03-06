/*
   03 March 202112:05:56
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
CREATE TABLE dbo.Institution
	(
	Id uniqueidentifier NOT NULL ROWGUIDCOL,
	LogoPath nvarchar(125) NOT NULL,
	Name nvarchar(255) NOT NULL,
	AddressId uniqueidentifier NOT NULL,
	InstitutionTypeId uniqueidentifier NOT NULL,
	InstitutionEmail nvarchar(125) NOT NULL,
	PrincipalName nvarchar(150) NOT NULL,
	PrincipalPhoneNumber nvarchar(30) NOT NULL,
	DefaultAdminId nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Institution ADD CONSTRAINT
	DF_Institution_Id DEFAULT (newid()) FOR Id
GO
ALTER TABLE dbo.Institution ADD CONSTRAINT
	PK_Institution PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Institution SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Institution', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Institution', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Institution', 'Object', 'CONTROL') as Contr_Per 