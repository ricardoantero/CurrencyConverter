-- CREATE DATABASE
CREATE DATABASE dbAPICurrencyConverter
GO

USE [dbAPICurrencyConverter]
GO

-- CREATE TABLE USERS
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](8) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO


-- CREATE TABLE CURRIENCIES
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Currency] [nvarchar](30) NOT NULL,
	[CurrencyCode] [nvarchar](8) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Currencies] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO


-- CREATE TABLE TRANSACTIONS
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsersId] [int] NOT NULL,
	[CurrenciesId] [int] NOT NULL,
	[OriginCurrency] [nvarchar](8) NOT NULL,
	[DestinationCurrency] [nvarchar](8) NOT NULL,
	[OriginValue] [decimal](18, 6) NOT NULL,
	[DestinationValue] [decimal](18, 6) NOT NULL,
	[ConversionRate] [decimal](18, 6) NOT NULL,
	[ConversionDate] [datetime2](7) NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Transactions] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Currencies_CurrenciesId] FOREIGN KEY([CurrenciesId])
REFERENCES [dbo].[Currencies] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Currencies_CurrenciesId]
GO

ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_Users_UsersId] FOREIGN KEY([UsersId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_Users_UsersId]
GO


--DATA

-- INSERT TABLE USERS
INSERT INTO [dbo].[Users] VALUES('Ricardo Antero', 'ricardo.antero@dev.com.br', '123456',GETDATE(),1)

-- INSERT TABLE CURRENCIES
INSERT INTO [dbo].[Currencies] VALUES('Euro', 'EUR', GETDATE(), 1)

--INSERT TABLE TRANSACTIONS
INSERT INTO [dbo].[Transactions] VALUES(1,1,'EUR', 'BRL', 2, 12, 6, GETDATE(), GETDATE(), 1)