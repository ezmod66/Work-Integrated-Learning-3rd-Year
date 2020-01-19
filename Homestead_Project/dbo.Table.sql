CREATE TABLE [dbo].[Documents]
(
	[doc_ID] INT NOT NULL PRIMARY KEY, 
    [doc_name] VARCHAR(225) NOT NULL, 
    [doc_binary] BINARY(225) NOT NULL
)
