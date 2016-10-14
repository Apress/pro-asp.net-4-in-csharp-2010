USE master
GO
if exists (select * from sysdatabases where name='SiteMap')
		drop database SiteMap
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE SiteMap
  ON PRIMARY (NAME = N''SiteMap'', FILENAME = N''' + @device_directory + N'sitemap.mdf'')
  LOG ON (NAME = N''SiteMap_log'',  FILENAME = N''' + @device_directory + N'sitemap.ldf'')')
go

exec sp_dboption 'SiteMap','trunc. log on chkpt.','true'
exec sp_dboption 'SiteMap','select into/bulkcopy','true'
GO

set quoted_identifier on
GO

/* Set DATEFORMAT so that the date strings are interpreted correctly regardless of
   the default DATEFORMAT on the server.
*/
SET DATEFORMAT mdy
GO



-- Add a USE statement for your database here.
USE SiteMap
GO

-- Table structure for table 'SiteMap'
IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'SiteMap')) DROP TABLE [SiteMap]
GO
CREATE TABLE [SiteMap] (
[ID] int IDENTITY NOT NULL,
[Url] varchar(100),
[Title] varchar(100) NOT NULL,
[Description] varchar(250),
[ParentID] int,
[OrdinalPosition] int DEFAULT 0)
GO

CREATE UNIQUE CLUSTERED INDEX PK_SiteMap ON [SiteMap] (ID)
GO


-- Dumping data for table 'SiteMap'
--

-- Enable identity insert
SET IDENTITY_INSERT [SiteMap] ON
GO

INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(1, '~/default.aspx', 'Home', 'Home', NULL)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(2, '~/Products.aspx', 'Products', 'Our Products', 1)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(5, '~/Hardware.aspx', 'Hardware', 'Hardware Choices', 2)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(6, '~/Software.aspx', 'Software', 'Software Choices', 2)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(7, '~/Services.aspx', 'Services', 'Services We Offer', 1)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(8, '~/Training.aspx', 'Training', 'Training Classes', 7)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(9, '~/Consulting.aspx', 'Consulting', 'Consulting Services', 7)
GO
INSERT INTO [SiteMap] ([ID], [Url], [Title], [Description], [ParentID])
VALUES(10, '~/Support.aspx', 'Support', 'Support Plans', 7)
GO


IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'GetSiteMap') AND (xtype = 'P')) DROP PROCEDURE [GetSiteMap]
GO
CREATE PROCEDURE GetSiteMap AS
SELECT * FROM SiteMap ORDER BY ParentID, OrdinalPosition, Title
GO

