
USE [bestilvasketid_dk]
GO
/****** Object:  Table [dbo].[address]    Script Date: 24-10-2019 11:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[address](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[streetname] [nvarchar](50) NULL,
	[housenumber] [int] NULL,
	[floor] [nchar](10) NULL,
	[door] [nchar](10) NULL,
	[zipcode] [int] NULL,
	[city] [nvarchar](50) NULL,
 CONSTRAINT [PK_address] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 24-10-2019 11:08:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_fk] [int] NOT NULL,
	[canEditMachine] [bit] NULL,
	[canChangeDuration] [bit] NULL,
	[canChangeOpeningHours] [bit] NULL,
	[canDeleteEndUsers] [bit] NULL,
	[canDeleteAdmins] [bit] NULL,
	[canChangeShowID] [bit] NULL,
	[canChangeScheduleLimit] [bit] NULL,
	[isMaster] [bit] NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[adminlaundry]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adminlaundry](
	[admin_fk] [int] NULL,
	[laundry_fk] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[laundry]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[laundry](
	[id] [int] IDENTITY(1000,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[pin] [int] NULL,
	[showID_fk] [int] NULL,
	[openHours] [datetime] NULL,
	[closeHours] [datetime] NULL,
	[scheduleLimit] [int] NULL,
	[defaultDuration] [int] NULL,
	[timestamp_fk] [int] NULL,
	[address_fk] [int] NULL,
 CONSTRAINT [PK_laundry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[machine]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[machine](
	[id] [int] IDENTITY(10000,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](200) NULL,
	[status_fk] [int] NULL,
	[duration] [int] NULL,
	[timestamp_fk] [int] NULL,
	[laundry_fk] [int] NULL,
 CONSTRAINT [PK_machine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[machinestatus]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[machinestatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_machinestatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[resident]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[resident](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_fk] [int] NULL,
	[address_fk] [int] NULL,
	[timestamp_fk] [int] NULL,
 CONSTRAINT [PK_enduser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[schedules]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schedules](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[time] [datetime] NULL,
	[status_fk] [int] NULL,
	[user_fk] [int] NULL,
	[timestamp_fk] [int] NULL,
	[machine_fk] [int] NULL,
 CONSTRAINT [PK_schedules] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[schedulestatus]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schedulestatus](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_schedulestatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[showid]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[showid](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[showID] [nvarchar](50) NULL,
 CONSTRAINT [PK_showid] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[timestamp]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[timestamp](
	[id] [int] IDENTITY(1000000,1) NOT NULL,
	[created] [datetime] NULL,
	[deleted] [datetime] NULL,
	[changed] [datetime] NULL,
 CONSTRAINT [PK_timestamp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 24-10-2019 11:08:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[phone] [nchar](10) NULL,
	[name] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[lastlogin] [datetime] NULL,
	[timestamp_fk] [int] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[admin]  WITH CHECK ADD  CONSTRAINT [FK_admin_user] FOREIGN KEY([user_fk])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[admin] CHECK CONSTRAINT [FK_admin_user]
GO
ALTER TABLE [dbo].[adminlaundry]  WITH CHECK ADD  CONSTRAINT [FK_adminlaundry_admin] FOREIGN KEY([admin_fk])
REFERENCES [dbo].[admin] ([id])
GO
ALTER TABLE [dbo].[adminlaundry] CHECK CONSTRAINT [FK_adminlaundry_admin]
GO
ALTER TABLE [dbo].[adminlaundry]  WITH CHECK ADD  CONSTRAINT [FK_adminlaundry_laundry] FOREIGN KEY([laundry_fk])
REFERENCES [dbo].[laundry] ([id])
GO
ALTER TABLE [dbo].[adminlaundry] CHECK CONSTRAINT [FK_adminlaundry_laundry]
GO
ALTER TABLE [dbo].[laundry]  WITH CHECK ADD  CONSTRAINT [FK_laundry_address] FOREIGN KEY([address_fk])
REFERENCES [dbo].[address] ([id])
GO
ALTER TABLE [dbo].[laundry] CHECK CONSTRAINT [FK_laundry_address]
GO
ALTER TABLE [dbo].[laundry]  WITH CHECK ADD  CONSTRAINT [FK_laundry_showid] FOREIGN KEY([showID_fk])
REFERENCES [dbo].[showid] ([id])
GO
ALTER TABLE [dbo].[laundry] CHECK CONSTRAINT [FK_laundry_showid]
GO
ALTER TABLE [dbo].[laundry]  WITH CHECK ADD  CONSTRAINT [FK_laundry_timestamp] FOREIGN KEY([timestamp_fk])
REFERENCES [dbo].[timestamp] ([id])
GO
ALTER TABLE [dbo].[laundry] CHECK CONSTRAINT [FK_laundry_timestamp]
GO
ALTER TABLE [dbo].[machine]  WITH CHECK ADD  CONSTRAINT [FK_machine_laundry] FOREIGN KEY([laundry_fk])
REFERENCES [dbo].[laundry] ([id])
GO
ALTER TABLE [dbo].[machine] CHECK CONSTRAINT [FK_machine_laundry]
GO
ALTER TABLE [dbo].[machine]  WITH CHECK ADD  CONSTRAINT [FK_machine_machinestatus] FOREIGN KEY([status_fk])
REFERENCES [dbo].[machinestatus] ([id])
GO
ALTER TABLE [dbo].[machine] CHECK CONSTRAINT [FK_machine_machinestatus]
GO
ALTER TABLE [dbo].[machine]  WITH CHECK ADD  CONSTRAINT [FK_machine_timestamp] FOREIGN KEY([timestamp_fk])
REFERENCES [dbo].[timestamp] ([id])
GO
ALTER TABLE [dbo].[machine] CHECK CONSTRAINT [FK_machine_timestamp]
GO
ALTER TABLE [dbo].[resident]  WITH CHECK ADD  CONSTRAINT [FK_enduser_address] FOREIGN KEY([address_fk])
REFERENCES [dbo].[address] ([id])
GO
ALTER TABLE [dbo].[resident] CHECK CONSTRAINT [FK_enduser_address]
GO
ALTER TABLE [dbo].[resident]  WITH CHECK ADD  CONSTRAINT [FK_enduser_enduser] FOREIGN KEY([user_fk])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[resident] CHECK CONSTRAINT [FK_enduser_enduser]
GO
ALTER TABLE [dbo].[resident]  WITH CHECK ADD  CONSTRAINT [FK_enduser_timestamp] FOREIGN KEY([timestamp_fk])
REFERENCES [dbo].[timestamp] ([id])
GO
ALTER TABLE [dbo].[resident] CHECK CONSTRAINT [FK_enduser_timestamp]
GO
ALTER TABLE [dbo].[schedules]  WITH CHECK ADD  CONSTRAINT [FK_schedules_enduser] FOREIGN KEY([user_fk])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[schedules] CHECK CONSTRAINT [FK_schedules_enduser]
GO
ALTER TABLE [dbo].[schedules]  WITH CHECK ADD  CONSTRAINT [FK_schedules_machine] FOREIGN KEY([machine_fk])
REFERENCES [dbo].[machine] ([id])
GO
ALTER TABLE [dbo].[schedules] CHECK CONSTRAINT [FK_schedules_machine]
GO
ALTER TABLE [dbo].[schedules]  WITH CHECK ADD  CONSTRAINT [FK_schedules_schedulestatus] FOREIGN KEY([status_fk])
REFERENCES [dbo].[schedulestatus] ([id])
GO
ALTER TABLE [dbo].[schedules] CHECK CONSTRAINT [FK_schedules_schedulestatus]
GO
ALTER TABLE [dbo].[schedules]  WITH CHECK ADD  CONSTRAINT [FK_schedules_timestamp] FOREIGN KEY([timestamp_fk])
REFERENCES [dbo].[timestamp] ([id])
GO
ALTER TABLE [dbo].[schedules] CHECK CONSTRAINT [FK_schedules_timestamp]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_timestamp] FOREIGN KEY([timestamp_fk])
REFERENCES [dbo].[timestamp] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_timestamp]
GO
USE [master]
GO
ALTER DATABASE [dbbestilvasketid.dk] SET  READ_WRITE 
GO
