 A single page contact management web application using C#, MVC, Angular.js, Bootstrap, and SQL Server. features incude 
 pagination, calendar, responsive design, data validation, search function and log function.

 
 A simple sql database ( including a few stored procedules) is required to run this application. sql script for creating the table is as below:
  
 CREATE TABLE [dbo].[Contacts](
                        [Id] [int] IDENTITY(1,1) NOT NULL,
                        [FirstName] [nvarchar](50) NOT NULL,
                        [LastName] [nvarchar](50) NOT NULL,
                        [Email] [nvarchar](50) NOT NULL,
                        [Phone] [nvarchar](50) NULL,
                        [BirthDate] [nvarchar](12) NULL,
                        [ProfilePictureUrl] [varchar](200) NULL,
                        [isFamily] [bit] NULL,
                        [isFriend] [bit] NULL,
                        [isColleague] [bit] NULL,
                        [isAssociate] [bit] NULL,
                        [Comments] [nvarchar](max) NULL,
                        CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
 
