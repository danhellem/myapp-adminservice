﻿CREATE TABLE [dbo].[Groups]
(
	[Id] INT NOT NULL PRIMARY KEY , 
    [Type] NVARCHAR(128) NOT NULL, 
    [Name] NVARCHAR(128) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1
)
