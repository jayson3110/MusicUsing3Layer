USE [MusicSystem]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 4/1/2022 1:02:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[album_id] [int] NULL,
	[album_Title] [nvarchar](250) NULL,
	[album_Year] [nvarchar](250) NULL,
	[album_Producer] [nvarchar](250) NULL,
	[song_Title] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 4/1/2022 1:02:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artist](
	[Artist_id] [int] NULL,
	[Artist_Name] [nvarchar](250) NOT NULL,
	[Artist_Country] [nvarchar](250) NULL,
	[Artist_DateOfBrith] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Artist_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Songs]    Script Date: 4/1/2022 1:02:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[song_id] [int] NULL,
	[song_Title] [nvarchar](250) NOT NULL,
	[song_Year] [nvarchar](250) NULL,
	[song_Genre] [nvarchar](250) NULL,
	[Artist_Name] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[song_Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Albums]  WITH CHECK ADD FOREIGN KEY([song_Title])
REFERENCES [dbo].[Songs] ([song_Title])
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD FOREIGN KEY([Artist_Name])
REFERENCES [dbo].[Artist] ([Artist_Name])
GO
/****** Object:  StoredProcedure [dbo].[DELETEAlbum]    Script Date: 4/1/2022 1:02:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DELETEAlbum] @album_id int
as
DELETE FROM Albums WHERE album_id = @album_id;
GO
/****** Object:  StoredProcedure [dbo].[GetAlbums]    Script Date: 4/1/2022 1:02:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAlbums]
AS
select * from Albums 
GO;
GO
/****** Object:  StoredProcedure [dbo].[PostAlbum]    Script Date: 4/1/2022 1:02:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PostAlbum] @album_id int, @album_Title nvarchar(250), 
@album_Year nvarchar(250), @album_Producer nvarchar(250), @song_Title nvarchar(250)
AS
insert into Albums values (@album_id, @album_Title , @album_Year ,@album_Producer ,@song_Title)
GO
/****** Object:  StoredProcedure [dbo].[PUTAlbum]    Script Date: 4/1/2022 1:02:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PUTAlbum] @album_id int, @album_Title nvarchar(250), 
@album_Year nvarchar(250), @album_Producer nvarchar(250), @song_Title nvarchar(250)
as
UPDATE Albums
SET album_Title = @album_Title, album_Year = @album_Year, album_Producer = @album_Producer, song_Title = @song_Title
WHERE album_id = @album_id;
GO
