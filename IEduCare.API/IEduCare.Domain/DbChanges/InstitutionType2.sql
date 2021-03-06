/*
   03 March 202112:17:23
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
ALTER TABLE dbo.InstitutionType
	DROP CONSTRAINT DF_InstitutionType_Id
GO
CREATE TABLE dbo.Tmp_InstitutionType
	(
	Id uniqueidentifier NOT NULL ROWGUIDCOL,
	Name nvarchar(50) NOT NULL,
	Code nvarchar(20) NOT NULL,
	Description nvarchar(150) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_InstitutionType SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_InstitutionType ADD CONSTRAINT
	DF_InstitutionType_Id DEFAULT (newid()) FOR Id
GO
IF EXISTS(SELECT * FROM dbo.InstitutionType)
	 EXEC('INSERT INTO dbo.Tmp_InstitutionType (Id, Name, Code, Description)
		SELECT Id, Name, Code, CONVERT(nvarchar(150), Description) FROM dbo.InstitutionType WITH (HOLDLOCK TABLOCKX)')
GO
ALTER TABLE dbo.Institution
	DROP CONSTRAINT FK_Institution_InstitutionType
GO
DROP TABLE dbo.InstitutionType
GO
EXECUTE sp_rename N'dbo.Tmp_InstitutionType', N'InstitutionType', 'OBJECT' 
GO
ALTER TABLE dbo.InstitutionType ADD CONSTRAINT
	PK_InstitutionType PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.InstitutionType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.InstitutionType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.InstitutionType', 'Object', 'CONTROL') as Contr_Per BEGIN TRANSACTION
GO
ALTER TABLE dbo.Institution ADD CONSTRAINT
	FK_Institution_InstitutionType FOREIGN KEY
	(
	InstitutionTypeId
	) REFERENCES dbo.InstitutionType
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Institution SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Institution', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Institution', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Institution', 'Object', 'CONTROL') as Contr_Per 