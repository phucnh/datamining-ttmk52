SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CourseCertificate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CourseCertificate](
	[CertificateId] [int] NOT NULL,
	[CertificateName] [nvarchar](50) NULL,
 CONSTRAINT [PK_CourseCertificate] PRIMARY KEY CLUSTERED 
(
	[CertificateId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassTime]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassTime](
	[ClassTimeId] [int] NOT NULL,
	[TimeName] [nvarchar](50) NULL,
	[Note] [nvarchar](1024) NULL,
 CONSTRAINT [PK_ClassTime] PRIMARY KEY CLUSTERED 
(
	[ClassTimeId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TeacherDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TeacherDetails](
	[TeacherId] [int] NOT NULL,
	[TeacherName] [nvarchar](50) NULL,
	[TeacherCertificate] [int] NULL,
	[Note] [nvarchar](1024) NULL,
 CONSTRAINT [PK_TeacherDetails] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OccupationType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OccupationType](
	[OccupationTypeId] [int] NOT NULL,
	[OccupationName] [nvarchar](50) NULL,
	[Note] [nvarchar](1024) NULL,
 CONSTRAINT [PK_OccupationType] PRIMARY KEY CLUSTERED 
(
	[OccupationTypeId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CourseGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CourseGroup](
	[CourseGroupId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Note] [nvarchar](1024) NULL,
 CONSTRAINT [PK_CourseGroup] PRIMARY KEY CLUSTERED 
(
	[CourseGroupId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CourseDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CourseDetails](
	[CourseId] [int] NOT NULL,
	[CourseName] [nvarchar](50) NULL,
	[CourseCertificate] [int] NULL,
	[CourseFee] [float] NULL,
	[CourseGroup] [int] NULL,
 CONSTRAINT [PK_CourseDetails] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassDetails](
	[ClassId] [int] NOT NULL,
	[ClassName] [nvarchar](50) NULL,
	[ClassTime] [int] NULL,
	[CourseId] [int] NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_ClassDetails] PRIMARY KEY CLUSTERED 
(
	[ClassId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClassArrangement]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ClassArrangement](
	[CustomerId] [int] NOT NULL,
	[ClassId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ClassArrangement] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[ClassId] ASC,
	[CreateDate] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerDetails]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerDetails](
	[CustomerId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Birthday] [nvarchar](50) NULL,
	[OccupationTypeId] [int] NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CourseDetails_CourseCertificate]') AND parent_object_id = OBJECT_ID(N'[dbo].[CourseDetails]'))
ALTER TABLE [dbo].[CourseDetails]  WITH CHECK ADD  CONSTRAINT [FK_CourseDetails_CourseCertificate] FOREIGN KEY([CourseCertificate])
REFERENCES [dbo].[CourseCertificate] ([CertificateId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CourseDetails_CourseGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[CourseDetails]'))
ALTER TABLE [dbo].[CourseDetails]  WITH CHECK ADD  CONSTRAINT [FK_CourseDetails_CourseGroup] FOREIGN KEY([CourseGroup])
REFERENCES [dbo].[CourseGroup] ([CourseGroupId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassDetails_ClassTime]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassDetails]'))
ALTER TABLE [dbo].[ClassDetails]  WITH CHECK ADD  CONSTRAINT [FK_ClassDetails_ClassTime] FOREIGN KEY([ClassTime])
REFERENCES [dbo].[ClassTime] ([ClassTimeId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassDetails_CourseDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassDetails]'))
ALTER TABLE [dbo].[ClassDetails]  WITH CHECK ADD  CONSTRAINT [FK_ClassDetails_CourseDetails] FOREIGN KEY([CourseId])
REFERENCES [dbo].[CourseDetails] ([CourseId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassDetails_TeacherDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassDetails]'))
ALTER TABLE [dbo].[ClassDetails]  WITH CHECK ADD  CONSTRAINT [FK_ClassDetails_TeacherDetails] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[TeacherDetails] ([TeacherId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassArrangement_ClassDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassArrangement]'))
ALTER TABLE [dbo].[ClassArrangement]  WITH CHECK ADD  CONSTRAINT [FK_ClassArrangement_ClassDetails] FOREIGN KEY([ClassId])
REFERENCES [dbo].[ClassDetails] ([ClassId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ClassArrangement_CustomerDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[ClassArrangement]'))
ALTER TABLE [dbo].[ClassArrangement]  WITH CHECK ADD  CONSTRAINT [FK_ClassArrangement_CustomerDetails] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[CustomerDetails] ([CustomerId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerDetails_OccupationType]') AND parent_object_id = OBJECT_ID(N'[dbo].[CustomerDetails]'))
ALTER TABLE [dbo].[CustomerDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetails_OccupationType] FOREIGN KEY([OccupationTypeId])
REFERENCES [dbo].[OccupationType] ([OccupationTypeId])
