IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'IIS APPPOOL\.Net v4.5') 
BEGIN     
CREATE LOGIN [IIS APPPOOL\.Net v4.5]        
FROM WINDOWS WITH DEFAULT_DATABASE= [master],        
DEFAULT_LANGUAGE= [us_english] 
END 
GO 

CREATE USER [Russbucks1User]    
FOR LOGIN [IIS APPPOOL\.Net v4.5] 
GO 
EXEC sp_addrolemember 'db_owner', 'Russbucks1User' 
GO
