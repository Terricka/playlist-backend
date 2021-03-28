CREATE TABLE [app].[Playlist] (
    [Id] [int] NOT NULL IDENTITY(1,1),
    [Title] nvarchar(200) NOT NULL,
    [Genre] nvarchar(200) NOT NULL,
    [Description] nvarchar(1000) NOT NULL,
    [CreatedDate] [datetime] NOT NULL,
    [ModifiedDate] [datetime] NOT NULL,

    PRIMARY KEY CLUSTERED
    ( [Id] ASC) WITH (PAD_INDEX = OFF, 
    STATISTICS_NORECOMPUTE = OFF, 
    IGNORE_DUP_KEY = OFF, 
    ALLOW_ROW_LOCKS = ON, 
    ALLOW_PAGE_LOCKS = ON) ON (PRIMARY)
) ON [PRIMARY]

GO