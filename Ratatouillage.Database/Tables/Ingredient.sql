CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,

	CONSTRAINT PK_Ingredient PRIMARY KEY([Id])
)
