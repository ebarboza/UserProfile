UserProfile
===========

Api mvc to login user 

-------------------------
Developed with:

Visual Studio.Net MVC4 and 
SQL Server 2012

-----------------------

Instructions 

1. Create the database with the following script

    USE [UserProfile]
    GO
    /****** Object:  Table [dbo].[Token]    Script Date: 01/07/2013 07:16:56 a.m. ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    SET ANSI_PADDING ON
    GO
    CREATE TABLE [dbo].[Token](
      [IdUsuario] [int] NOT NULL,
    	[IdToken] [varchar](50) NOT NULL,
    	[Date] [datetime] NOT NULL,
     CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED 
    (
    	[IdUsuario] ASC,
    	[IdToken] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    
    GO
    SET ANSI_PADDING OFF
    GO
    /****** Object:  Table [dbo].[Users]    Script Date: 01/07/2013 07:16:56 a.m. ******/
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
    SET ANSI_PADDING ON
    GO
    CREATE TABLE [dbo].[Users](
    	[Id] [int] IDENTITY(1,1) NOT NULL,
    	[FirstName] [varchar](50) NULL,
    	[MiddleName] [varchar](50) NULL,
    	[LastName] [varchar](50) NULL,
    	[UserName] [varchar](20) NOT NULL,
    	[Password] [varchar](20) NOT NULL,
    	[Email] [varchar](50) NULL,
    	[Address] [varchar](100) NULL,
    	[Phone] [varchar](15) NULL,
     CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
    (
    	[Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
    
    GO
    SET ANSI_PADDING OFF
    GO
    
2. Add a new user in the table [Users]
3. Connect the key switch "UsersProfilesConnectionString" to the database in the configuration file
4. Run to application

 
