﻿CREATE TABLE [dbo].[Estatus]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[Descripcion] VARCHAR(15) NOT NULL,
	CONSTRAINT [PK_Estatus] PRIMARY KEY CLUSTERED ([Id] ASC)
)
