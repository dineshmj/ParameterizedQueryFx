USE [Tkgs_Corp]
GO

/****** Object:  Table [dbo].[PQ_ClassRoom]    Script Date: 26-01-2017 00:07:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PQ_ClassRoom](
	[class_room_id] [int] NOT NULL,
	[grade_number] [int] NOT NULL,
	[class_division] [nvarchar](2) NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PQ_Student]    Script Date: 26-01-2017 00:08:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PQ_Student](
	[student_id] [int] NOT NULL,
	[salute_text] [nvarchar](10) NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[birth_date] [datetime] NOT NULL,
	[class_room_id] [int] NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PQ_Teacher]    Script Date: 26-01-2017 00:09:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PQ_Teacher](
	[teacher_id] [int] NOT NULL,
	[salute_text] [nvarchar](10) NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[birth_date] [datetime] NOT NULL
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PQ_ClassTeacherInfo]    Script Date: 26-01-2017 00:08:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PQ_ClassTeacherInfo](
	[class_room_id] [int] NOT NULL,
	[teacher_id] [int] NOT NULL
) ON [PRIMARY]

GO
