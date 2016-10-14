USE master
GO
if exists (select * from sysdatabases where name='CustomProfiles')
		drop database CustomProfiles
go

DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(filename, 1, CHARINDEX(N'master.mdf', LOWER(filename)) - 1)
FROM master.dbo.sysaltfiles WHERE dbid = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE CustomProfiles
  ON PRIMARY (NAME = N''CustomProfiles'', FILENAME = N''' + @device_directory + N'CustomProfiles.mdf'')
  LOG ON (NAME = N''CustomProfiles_log'',  FILENAME = N''' + @device_directory + N'CustomProfiles.ldf'')')
go

exec sp_dboption 'CustomProfiles','trunc. log on chkpt.','true'
exec sp_dboption 'CustomProfiles','select into/bulkcopy','true'
GO

set quoted_identifier on
GO

/* Set DATEFORMAT so that the date strings are interpreted correctly regardless of
   the default DATEFORMAT on the server.
*/
SET DATEFORMAT mdy
GO




-- Add a USE statement for your database here.
USE CustomProfiles
GO

-- Table structure for table 'Users'
IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'Users')) DROP TABLE [Users]
GO
CREATE TABLE [Users] (
[ID] int IDENTITY NOT NULL,
[UserName] varchar(50) NOT NULL,
[AddressName] varchar(50),
[AddressStreet] varchar(50),
[AddressCity] varchar(50),
[AddressState] varchar(50),
[AddressZipCode] varchar(50),
[AddressCountry] varchar(50))
GO

CREATE UNIQUE NONCLUSTERED INDEX IX_Users ON [Users] (UserName)
GO

CREATE UNIQUE CLUSTERED INDEX PK_Users ON [Users] (ID)
GO


-- Dumping data for table 'Users'
--

-- Enable identity insert
SET IDENTITY_INSERT [Users] ON
GO



IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'Users_Delete') AND (xtype = 'P')) DROP PROCEDURE [Users_Delete]
GO
CREATE PROCEDURE [Users_Delete]	(@UserName varchar(50)) AS DELETE Users WHERE 	( UserName	 = @UserName)
GO

IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'Users_GetByUserName') AND (xtype = 'P')) DROP PROCEDURE [Users_GetByUserName]
GO
CREATE PROCEDURE Users_GetByUserName (@UserName varchar(50))
 AS SELECT * FROM Users WHERE UserName = @UserName
GO

IF EXISTS (SELECT * FROM sysobjects WHERE (name = 'Users_Update') AND (xtype = 'P')) DROP PROCEDURE [Users_Update]
GO
CREATE PROCEDURE [Users_Update]	(
 @UserName 	[varchar](50),	 @AddressName 	[varchar](50),	 @AddressStreet 	[varchar](50),	 @AddressCity 	[varchar](50),	 @AddressState 	[varchar](50),	 @AddressZipCode 	[varchar](50),	 @AddressCountry 	[varchar](50)) 
AS 
DECLARE @Match int
SELECT @Match = COUNT(*) FROM Users    WHERE  UserName = @UserName   
 IF (@Match = 0)    INSERT INTO Users	 (	 [UserName],	 [AddressName],	 [AddressStreet],	 [AddressCity],	 [AddressState],	 [AddressZipCode],	 [AddressCountry])  VALUES 	(	 @UserName,	 @AddressName,	 @AddressStreet,	 @AddressCity,	 @AddressState,	 @AddressZipCode,	 @AddressCountry)    IF (@Match = 1) UPDATE Users SET  	 [UserName]	 = @UserName,	 [AddressName]	 = @AddressName,	 [AddressStreet]	 = @AddressStreet,	 [AddressCity]	 = @AddressCity,	 [AddressState]	 = @AddressState,	 [AddressZipCode]	 = @AddressZipCode,	 [AddressCountry]	 = @AddressCountry WHERE 	( UserName	 = @UserName)
GO

