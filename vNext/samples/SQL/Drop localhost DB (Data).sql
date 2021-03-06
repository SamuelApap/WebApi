-- GENERATED BY DatabaseCreator.cs
-- Copyright: Josh Comley, 2013
-- 04/05/2016 23:50:37
-- Also used in 'Start new project.linq'

USE [master]

-- Create data database
IF db_id('Microsoft.AspNetCore.OData.App.Data') IS NOT NULL
BEGIN
	ALTER DATABASE [Microsoft.AspNetCore.OData.App.Data] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE [Microsoft.AspNetCore.OData.App.Data]
END

-- Create standard login
DECLARE @spidstr varchar(8000)
IF EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'roadsteadsLogin')
BEGIN
	SET @spidstr = NULL
	SELECT @spidstr=coalesce(@spidstr,'' )+'kill '+convert(varchar, session_id)+ '; '
	FROM sys.dm_exec_sessions WHERE login_name = 'roadsteadsLogin'
	IF LEN(@spidstr) > 0
	BEGIN
		EXEC(@spidstr)
	END

	ALTER LOGIN [roadsteadsLogin] DISABLE;
	DROP LOGIN [roadsteadsLogin]
END

-- Create migrations login
IF EXISTS 
    (SELECT name  
     FROM master.sys.server_principals
     WHERE name = 'morselsLogin')
BEGIN
	SET @spidstr = NULL
	SELECT @spidstr=coalesce(@spidstr,'' )+'kill '+convert(varchar, session_id)+ '; '
	FROM sys.dm_exec_sessions WHERE login_name = 'morselsLogin'

	IF LEN(@spidstr) > 0
	BEGIN
		EXEC(@spidstr)
	END

	DROP LOGIN [morselsLogin]
END
