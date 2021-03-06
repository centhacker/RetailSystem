USE [RetailSystem]
GO
/****** Object:  Table [dbo].[AccountTransaction]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountTransaction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NULL,
	[Debit] [nvarchar](max) NULL,
	[Credit] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Total] [nvarchar](max) NULL,
	[CurrentTransaction] [nvarchar](max) NULL,
	[TransactionType] [nvarchar](max) NULL,
	[FiscalYearId] [int] NULL,
	[eDate] [date] NULL,
	[WareHouseId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_AccountTransaction] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AllowancesPaid]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllowancesPaid](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[AllowancePaid] [nvarchar](max) NULL,
	[AllowanceTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_AllowancesPaid] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BalanceSheet]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalanceSheet](
	[ACCOUNTID] [nvarchar](50) NULL,
	[ACCOUNTNAME] [nvarchar](50) NULL,
	[ACCOUNTTOTAL] [float] NULL,
	[TYPE] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bank]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bank](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Branch] [nvarchar](max) NULL,
	[BranchCode] [nvarchar](max) NULL,
	[TelephoneNumber] [nvarchar](max) NULL,
	[EmailAddress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BankAccount]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BankAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BankId] [int] NULL,
	[AccountNumber] [nvarchar](max) NULL,
	[AccountTitle] [nvarchar](max) NULL,
	[AccountHolderId] [nvarchar](max) NULL,
	[OpeningBalance] [nvarchar](max) NULL,
	[Balance] [nvarchar](max) NULL,
	[BeginDate] [nvarchar](max) NULL,
	[WareHouseId] [int] NULL,
	[AccountType] [nvarchar](max) NULL,
 CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashAccount]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashAccount](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CashAccountName] [nvarchar](max) NULL,
	[WareHouseId] [int] NULL,
	[OpeningBalance] [nvarchar](max) NULL,
	[BeginDate] [nvarchar](max) NULL,
	[AccountType] [nvarchar](max) NULL,
	[ClientId] [int] NULL,
	[VendorId] [int] NULL,
 CONSTRAINT [PK_CashAccount] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CashTransaction]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CashTransaction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CashAccountId] [int] NULL,
	[Debit] [nvarchar](max) NULL,
	[Credit] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Total] [nvarchar](max) NULL,
	[TransactionId] [int] NULL,
	[OrderId] [int] NULL,
	[TransactionType] [nvarchar](max) NULL,
	[FiscalYearId] [int] NULL,
	[eDate] [date] NULL,
	[WareHouseId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_CashTransaction] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChartOfAccounts]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChartOfAccounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[num] [nvarchar](50) NULL,
	[name] [nvarchar](max) NULL,
	[type] [nvarchar](50) NULL,
	[e_date] [date] NULL,
 CONSTRAINT [PK_CharOfAccounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Clients]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ClientTypeId] [int] NULL,
	[Name] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[EmailAddress] [nvarchar](max) NULL,
	[Address1] [nvarchar](max) NULL,
	[Address2] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[isVendor] [bit] NULL,
	[eDate] [date] NULL,
	[WareHouseId] [int] NULL,
	[NIC] [nvarchar](max) NULL,
	[GrantorName] [nvarchar](max) NULL,
	[GrantorNIC] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ClientTypes]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_ClientTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefaultBankAccounts]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefaultBankAccounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseDefaultAccountId] [int] NULL,
	[SalesDefaultAccountId] [int] NULL,
	[WareHouseId] [int] NULL,
 CONSTRAINT [PK_DefaultAccounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefaultCashAccounts]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefaultCashAccounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DefaultPurchaseAccountId] [int] NULL,
	[DefaultSalesAccountId] [int] NULL,
	[WareHouseId] [int] NULL,
 CONSTRAINT [PK_DefaultCashAccounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DefaultFiscalYear]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DefaultFiscalYear](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DefaultfiscalYear] [int] NULL,
 CONSTRAINT [PK_DefaultFiscalYear] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DesignationId] [int] NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[HomePhone] [nvarchar](max) NULL,
	[CellNo] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[EmergencyContactNo] [nvarchar](max) NULL,
	[WarehouseId] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FiscalYear]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiscalYear](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fiscalFrom] [date] NULL,
	[fiscalTo] [date] NULL,
 CONSTRAINT [PK_FiscalYear] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOD]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_HOD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IncomeStatement]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IncomeStatement](
	[Type] [nvarchar](50) NULL,
	[AccountId] [nvarchar](50) NULL,
	[AccountName] [nvarchar](50) NULL,
	[value] [float] NULL,
	[NetProfit] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NULL,
	[WareHouseId] [int] NULL,
	[Cost] [nvarchar](max) NULL,
	[Quantity] [nvarchar](max) NULL,
	[FiscalYearId] [int] NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InventoryBalance]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryBalance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[WarehouseId] [int] NULL,
	[ProductsId] [int] NULL,
	[PurchaseUnits] [nvarchar](max) NULL,
	[PurchaseUnitsCost] [nvarchar](max) NULL,
	[PurchaseTotal] [nvarchar](max) NULL,
	[SaleUnits] [nvarchar](max) NULL,
	[SaleUnitsCost] [nvarchar](max) NULL,
	[SaleTotal] [nvarchar](max) NULL,
	[BalanceUnits] [nvarchar](max) NULL,
	[BalanceUnitsCost] [nvarchar](max) NULL,
	[BalanceTotal] [nvarchar](max) NULL,
 CONSTRAINT [PK_InventoryBalance] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[OrderId] [int] NULL,
	[VendorId] [int] NULL,
	[CustomerId] [int] NULL,
 CONSTRAINT [PK_OrderInvoice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoiceItems]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[InvoicedetailId] [int] NULL,
	[ProductId] [int] NULL,
	[ProductCost] [nchar](10) NULL,
 CONSTRAINT [PK_InvoiceItems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[InvoicePayment]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoicePayment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceId] [int] NULL,
	[Payment] [nvarchar](max) NULL,
	[Total] [nvarchar](max) NULL,
	[Remaining] [nvarchar](max) NULL,
 CONSTRAINT [PK_InvoicePayment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceType] [nvarchar](max) NULL,
	[InvoiceTotal] [nvarchar](max) NULL,
	[InvoiceDate] [nvarchar](max) NULL,
	[FiscalYeadId] [int] NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Journal]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[acc_id] [int] NULL,
	[amount] [float] NULL,
	[des] [nvarchar](max) NULL,
	[type] [nvarchar](max) NULL,
	[e_date] [date] NULL,
	[WarehouseId] [int] NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ledgers]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ledgers](
	[type] [nvarchar](50) NOT NULL,
	[e_date] [date] NULL,
 CONSTRAINT [PK_Ledgers] PRIMARY KEY CLUSTERED 
(
	[type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Permission] [nvarchar](max) NULL,
	[Menu] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderLine]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductId] [int] NULL,
	[SalePrice] [nvarchar](max) NULL,
	[units] [nvarchar](max) NULL,
	[totalProductCost] [nvarchar](max) NULL,
	[eDate] [date] NULL,
 CONSTRAINT [PK_OrderLine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](max) NULL,
	[OrderName] [nvarchar](max) NULL,
	[OrderDescription] [nvarchar](max) NULL,
	[OrderDate] [date] NULL,
	[deliveryDate] [date] NULL,
	[TotalCost] [nvarchar](max) NULL,
	[OrderType] [nvarchar](max) NULL,
	[WareHouseId] [int] NULL,
	[ClientId] [int] NULL,
	[VendorId] [int] NULL,
	[FiscalYearId] [int] NULL,
	[eDate] [date] NULL,
	[Installments] [nvarchar](max) NULL,
	[InstallmentDueDate] [nvarchar](max) NULL,
	[ModeOfPayment] [nvarchar](max) NULL,
	[GrantorName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OwnerEquity]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OwnerEquity](
	[OldCapital] [float] NULL,
	[newcapital] [float] NULL,
	[netincome] [float] NULL,
	[ow] [float] NULL,
	[finalcapital] [float] NULL,
	[fromDate] [date] NULL,
	[toDate] [date] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaidSalary]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaidSalary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[SalaryId] [int] NULL,
	[MonthPaid] [nvarchar](max) NULL,
	[Paid] [nvarchar](max) NULL,
	[DatePaid] [date] NULL,
 CONSTRAINT [PK_PaidSalary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ClientId] [int] NULL,
	[VendorId] [int] NULL,
	[OrderId] [int] NULL,
	[TransactionId] [int] NULL,
	[TotalCost] [nvarchar](max) NULL,
	[Paid] [nvarchar](max) NULL,
	[PaymentType] [nvarchar](max) NULL,
	[PaymentState] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentBankContainer]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentBankContainer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentId] [int] NULL,
	[BankId] [int] NULL,
	[AmountRemaining] [nvarchar](max) NULL,
 CONSTRAINT [PK_PaymentBankContainer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentLine]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentLine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentId] [int] NULL,
	[PaidAmount] [nvarchar](max) NULL,
	[RemainingAmount] [nvarchar](max) NULL,
	[BankId] [int] NULL,
	[Date] [date] NULL,
	[CumulativeAmount] [nvarchar](max) NULL,
	[ModeOfPayment] [nvarchar](50) NULL,
	[Cheque] [nvarchar](max) NULL,
 CONSTRAINT [PK_PaymentLine] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payroll]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payroll](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [int] NULL,
	[SalaryId] [int] NULL,
	[DateOfPay] [nvarchar](max) NULL,
 CONSTRAINT [PK_Payroll] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PayrollDetails]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PayrollDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[LastMonthPaid] [nvarchar](max) NULL,
 CONSTRAINT [PK_PayrollDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Permissions]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permissions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[Permission] [nvarchar](max) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Postings]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Postings](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[acc_id] [int] NULL,
	[acc_num] [nvarchar](50) NULL,
	[type] [nvarchar](max) NULL,
	[amount] [float] NULL,
	[e_date] [date] NULL,
 CONSTRAINT [PK_Postings] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[tag1] [nvarchar](max) NULL,
	[tag2] [nvarchar](max) NULL,
	[tag3] [nvarchar](max) NULL,
	[costPrice] [nvarchar](max) NULL,
	[salePrice] [nvarchar](max) NULL,
	[Manufacturer] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[VendorId] [int] NULL,
	[FiscalYearId] [int] NULL,
	[eDate] [date] NULL,
	[WareHouseId] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salary]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [nvarchar](max) NULL,
	[DesignationId] [nvarchar](max) NULL,
 CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleTypes]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleTypes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_SaleTypes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDetails] [nvarchar](max) NULL,
	[TransactionType] [nvarchar](max) NULL,
	[OrderId] [int] NULL,
	[ClientId] [int] NULL,
	[VendorId] [int] NULL,
	[FiscalYearId] [int] NULL,
	[eDate] [date] NULL,
 CONSTRAINT [PK_TransactionDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionDetail]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionDetail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionId] [int] NULL,
	[ProductId] [int] NULL,
	[FromWareHouseId] [int] NULL,
	[ToWareHouseId] [int] NULL,
	[TransactionQuantity] [nvarchar](max) NULL,
	[TransactionCost] [nvarchar](max) NULL,
	[TotalCost] [nvarchar](max) NULL,
	[eDate] [date] NULL,
 CONSTRAINT [PK_TransactionDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[WareHouseId] [int] NULL,
	[OrderId] [int] NULL,
	[CostPrice] [nvarchar](max) NULL,
	[SalePrice] [nvarchar](max) NULL,
	[units] [nvarchar](max) NULL,
	[TransactionType] [nvarchar](max) NULL,
	[ClientID] [nvarchar](max) NULL,
	[VendorID] [nvarchar](max) NULL,
	[date] [date] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransactionType]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionType] [nvarchar](max) NULL,
	[ActionType] [nvarchar](max) NULL,
 CONSTRAINT [PK_TransactionType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrialBalance]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrialBalance](
	[AccountId] [nvarchar](50) NULL,
	[AccountName] [nvarchar](max) NULL,
	[Debit] [float] NULL,
	[Credit] [float] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[cellNo] [nvarchar](max) NULL,
	[phoneNo] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[emailId] [nvarchar](max) NULL,
	[CNIC] [nvarchar](max) NULL,
	[eDate] [date] NULL,
 CONSTRAINT [PK_UserDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRolesContainer]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRolesContainer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[RolesId] [int] NULL,
 CONSTRAINT [PK_UserRolesContainer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[Approved] [nvarchar](50) NULL,
	[eDate] [date] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserToEmployee]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserToEmployee](
	[id] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserToEmployee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserWareHouseContainer]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserWareHouseContainer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[WareHouseId] [int] NULL,
 CONSTRAINT [PK_UserWareHouseContainer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[WareHouseId] [int] NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WareHouse]    Script Date: 10/19/2014 4:24:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WareHouse](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[openedDate] [date] NULL,
 CONSTRAINT [PK_WareHouse] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AccountTransaction] ON 

INSERT [dbo].[AccountTransaction] ([id], [AccountId], [Debit], [Credit], [Description], [Total], [CurrentTransaction], [TransactionType], [FiscalYearId], [eDate], [WareHouseId], [UserId]) VALUES (1, 1, N'0', N'999999', N'Opened Account [-] Opening Balance [999999]', N'999999', N'0', N'Credit', 4, CAST(0xEC380B00 AS Date), NULL, NULL)
INSERT [dbo].[AccountTransaction] ([id], [AccountId], [Debit], [Credit], [Description], [Total], [CurrentTransaction], [TransactionType], [FiscalYearId], [eDate], [WareHouseId], [UserId]) VALUES (2, 1, N'2000', N'0', N'Payment Of Order Id[7] Paid, Amount [2000]', N'997999', N'18', N'Debit', 4, CAST(0xE7380B00 AS Date), NULL, NULL)
SET IDENTITY_INSERT [dbo].[AccountTransaction] OFF
SET IDENTITY_INSERT [dbo].[Bank] ON 

INSERT [dbo].[Bank] ([id], [Name], [Branch], [BranchCode], [TelephoneNumber], [EmailAddress]) VALUES (1, N'hbl', N'-', N'-', N'-', N'-')
SET IDENTITY_INSERT [dbo].[Bank] OFF
SET IDENTITY_INSERT [dbo].[BankAccount] ON 

INSERT [dbo].[BankAccount] ([id], [BankId], [AccountNumber], [AccountTitle], [AccountHolderId], [OpeningBalance], [Balance], [BeginDate], [WareHouseId], [AccountType]) VALUES (1, 1, N'981*8191651919', N'-', N'-', N'999999', N'997999', N'08/24/2014', 6, NULL)
SET IDENTITY_INSERT [dbo].[BankAccount] OFF
SET IDENTITY_INSERT [dbo].[CashAccount] ON 

INSERT [dbo].[CashAccount] ([id], [CashAccountName], [WareHouseId], [OpeningBalance], [BeginDate], [AccountType], [ClientId], [VendorId]) VALUES (29, N'htc', 6, N'0', N'8/23/2014', N'Vendor', -1, 15)
INSERT [dbo].[CashAccount] ([id], [CashAccountName], [WareHouseId], [OpeningBalance], [BeginDate], [AccountType], [ClientId], [VendorId]) VALUES (30, N'nokia', 6, N'0', N'8/23/2014', N'Vendor', -1, 16)
INSERT [dbo].[CashAccount] ([id], [CashAccountName], [WareHouseId], [OpeningBalance], [BeginDate], [AccountType], [ClientId], [VendorId]) VALUES (31, N'hamza', 6, N'0', N'8/23/2014 7:15:19 PM', N'Client', 8, -1)
INSERT [dbo].[CashAccount] ([id], [CashAccountName], [WareHouseId], [OpeningBalance], [BeginDate], [AccountType], [ClientId], [VendorId]) VALUES (32, N'zafar', 6, N'0', N'8/23/2014 7:15:31 PM', N'Client', 9, -1)
INSERT [dbo].[CashAccount] ([id], [CashAccountName], [WareHouseId], [OpeningBalance], [BeginDate], [AccountType], [ClientId], [VendorId]) VALUES (33, N'personal sale account', 6, N'99999999999', N'08/24/2014', N'Personal', -1, -1)
INSERT [dbo].[CashAccount] ([id], [CashAccountName], [WareHouseId], [OpeningBalance], [BeginDate], [AccountType], [ClientId], [VendorId]) VALUES (34, N'personal purchase account', 6, N'99999999999', N'08/24/2014', N'Personal', -1, -1)
SET IDENTITY_INSERT [dbo].[CashAccount] OFF
SET IDENTITY_INSERT [dbo].[CashTransaction] ON 

INSERT [dbo].[CashTransaction] ([id], [CashAccountId], [Debit], [Credit], [Description], [Total], [TransactionId], [OrderId], [TransactionType], [FiscalYearId], [eDate], [WareHouseId], [UserId]) VALUES (29, 29, N'0', N'0', N'Opened Client Account[htc]', N'0', -1, -1, N'Credit', 4, CAST(0xEB380B00 AS Date), 6, 8)
INSERT [dbo].[CashTransaction] ([id], [CashAccountId], [Debit], [Credit], [Description], [Total], [TransactionId], [OrderId], [TransactionType], [FiscalYearId], [eDate], [WareHouseId], [UserId]) VALUES (30, 30, N'0', N'0', N'Opened Client Account[nokia]', N'0', -1, -1, N'Credit', 4, CAST(0xEB380B00 AS Date), 6, 8)
INSERT [dbo].[CashTransaction] ([id], [CashAccountId], [Debit], [Credit], [Description], [Total], [TransactionId], [OrderId], [TransactionType], [FiscalYearId], [eDate], [WareHouseId], [UserId]) VALUES (31, 31, N'0', N'0', N'Opened Client Account[hamza]', N'0', -1, -1, N'Credit', 4, CAST(0xEB380B00 AS Date), 6, 8)
INSERT [dbo].[CashTransaction] ([id], [CashAccountId], [Debit], [Credit], [Description], [Total], [TransactionId], [OrderId], [TransactionType], [FiscalYearId], [eDate], [WareHouseId], [UserId]) VALUES (32, 32, N'0', N'0', N'Opened Client Account[zafar]', N'0', -1, -1, N'Credit', 4, CAST(0xEB380B00 AS Date), 6, 8)
INSERT [dbo].[CashTransaction] ([id], [CashAccountId], [Debit], [Credit], [Description], [Total], [TransactionId], [OrderId], [TransactionType], [FiscalYearId], [eDate], [WareHouseId], [UserId]) VALUES (33, 33, N'0', N'99999999999', N'Opened Account', N'99999999999', -1, -1, N'Credit', 4, CAST(0xEC380B00 AS Date), 6, 8)
INSERT [dbo].[CashTransaction] ([id], [CashAccountId], [Debit], [Credit], [Description], [Total], [TransactionId], [OrderId], [TransactionType], [FiscalYearId], [eDate], [WareHouseId], [UserId]) VALUES (34, 34, N'0', N'99999999999', N'Opened Account', N'99999999999', -1, -1, N'Credit', 4, CAST(0xEC380B00 AS Date), 6, 8)
SET IDENTITY_INSERT [dbo].[CashTransaction] OFF
SET IDENTITY_INSERT [dbo].[Clients] ON 

INSERT [dbo].[Clients] ([id], [ClientTypeId], [Name], [phone], [EmailAddress], [Address1], [Address2], [City], [isVendor], [eDate], [WareHouseId], [NIC], [GrantorName], [GrantorNIC]) VALUES (8, 5, N'hamza', N'-', N'-', N'-', N'-', N'-', 0, CAST(0xEB380B00 AS Date), 6, NULL, NULL, NULL)
INSERT [dbo].[Clients] ([id], [ClientTypeId], [Name], [phone], [EmailAddress], [Address1], [Address2], [City], [isVendor], [eDate], [WareHouseId], [NIC], [GrantorName], [GrantorNIC]) VALUES (9, 5, N'zafar', N'=', N'=', N'=', N'=', N'=', 0, CAST(0xEB380B00 AS Date), 6, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clients] OFF
SET IDENTITY_INSERT [dbo].[ClientTypes] ON 

INSERT [dbo].[ClientTypes] ([id], [Name]) VALUES (5, N'walk in customer')
SET IDENTITY_INSERT [dbo].[ClientTypes] OFF
SET IDENTITY_INSERT [dbo].[DefaultBankAccounts] ON 

INSERT [dbo].[DefaultBankAccounts] ([id], [PurchaseDefaultAccountId], [SalesDefaultAccountId], [WareHouseId]) VALUES (1, 1, 1, 6)
SET IDENTITY_INSERT [dbo].[DefaultBankAccounts] OFF
SET IDENTITY_INSERT [dbo].[DefaultCashAccounts] ON 

INSERT [dbo].[DefaultCashAccounts] ([id], [DefaultPurchaseAccountId], [DefaultSalesAccountId], [WareHouseId]) VALUES (2, 34, 33, 6)
SET IDENTITY_INSERT [dbo].[DefaultCashAccounts] OFF
SET IDENTITY_INSERT [dbo].[DefaultFiscalYear] ON 

INSERT [dbo].[DefaultFiscalYear] ([id], [DefaultfiscalYear]) VALUES (4, 4)
SET IDENTITY_INSERT [dbo].[DefaultFiscalYear] OFF
SET IDENTITY_INSERT [dbo].[FiscalYear] ON 

INSERT [dbo].[FiscalYear] ([id], [fiscalFrom], [fiscalTo]) VALUES (4, CAST(0x01380B00 AS Date), CAST(0x6D390B00 AS Date))
SET IDENTITY_INSERT [dbo].[FiscalYear] OFF
SET IDENTITY_INSERT [dbo].[Inventory] ON 

INSERT [dbo].[Inventory] ([id], [ProductId], [WareHouseId], [Cost], [Quantity], [FiscalYearId], [date]) VALUES (7, 12, 6, N'5000', N'40', 1, CAST(0x02380B00 AS Date))
INSERT [dbo].[Inventory] ([id], [ProductId], [WareHouseId], [Cost], [Quantity], [FiscalYearId], [date]) VALUES (8, 13, 6, N'5000', N'30', 1, CAST(0xDF380B00 AS Date))
SET IDENTITY_INSERT [dbo].[Inventory] OFF
SET IDENTITY_INSERT [dbo].[InventoryBalance] ON 

INSERT [dbo].[InventoryBalance] ([id], [Date], [WarehouseId], [ProductsId], [PurchaseUnits], [PurchaseUnitsCost], [PurchaseTotal], [SaleUnits], [SaleUnitsCost], [SaleTotal], [BalanceUnits], [BalanceUnitsCost], [BalanceTotal]) VALUES (16, CAST(0xDF380B00 AS Date), 6, 12, N'30', N'5000', N'150000', NULL, NULL, NULL, N'30', N'5000', N'150000')
INSERT [dbo].[InventoryBalance] ([id], [Date], [WarehouseId], [ProductsId], [PurchaseUnits], [PurchaseUnitsCost], [PurchaseTotal], [SaleUnits], [SaleUnitsCost], [SaleTotal], [BalanceUnits], [BalanceUnitsCost], [BalanceTotal]) VALUES (17, CAST(0xDF380B00 AS Date), 6, 13, N'30', N'5000', N'150000', NULL, NULL, NULL, N'30', N'5000', N'150000')
INSERT [dbo].[InventoryBalance] ([id], [Date], [WarehouseId], [ProductsId], [PurchaseUnits], [PurchaseUnitsCost], [PurchaseTotal], [SaleUnits], [SaleUnitsCost], [SaleTotal], [BalanceUnits], [BalanceUnitsCost], [BalanceTotal]) VALUES (18, CAST(0x02380B00 AS Date), 6, 12, N'10', N'5000', N'50000', NULL, NULL, NULL, N'40', N'5000', N'200000')
SET IDENTITY_INSERT [dbo].[InventoryBalance] OFF
SET IDENTITY_INSERT [dbo].[Journal] ON 

INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (73, 5001, 999999, N'Opened Bank Account with name[-] ', N'Credit', CAST(0xEC380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (74, 1001, 999999, N'Opened Bank Account with name[-] ', N'Debit', CAST(0xEC380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (75, 1003, 150000, N'Purchased Inventory [30] ', N'Debit', CAST(0xDF380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (76, 1001, 150000, N'Purchased Inventory [30] ', N'Credit', CAST(0xDF380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (77, 1003, 150000, N'Purchased Inventory [30] ', N'Debit', CAST(0xDF380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (78, 1001, 150000, N'Purchased Inventory [30] ', N'Credit', CAST(0xDF380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (79, 1003, 50000, N'Purchased Inventory [10] ', N'Debit', CAST(0x02380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (80, 1001, 50000, N'Purchased Inventory [10] ', N'Credit', CAST(0x02380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (81, 1003, 80000, N'Order Of Inventory for Vendor of Product Id [12] units [10] ', N'Debit', CAST(0x02380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (82, 2001, 80000, N'Order Of Inventory for Vendor of Product Id [12] units [10] ', N'Credit', CAST(0x02380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (83, 1003, 2000, N'Payment Recieved of Order id [7]', N'Debit', CAST(0xE7380B00 AS Date), NULL)
INSERT [dbo].[Journal] ([id], [acc_id], [amount], [des], [type], [e_date], [WarehouseId]) VALUES (84, 2001, 2000, N'Payment Recieved of Order id [7]', N'Credit', CAST(0xE7380B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Journal] OFF
SET IDENTITY_INSERT [dbo].[OrderLine] ON 

INSERT [dbo].[OrderLine] ([id], [OrderId], [ProductId], [SalePrice], [units], [totalProductCost], [eDate]) VALUES (12, 7, 12, N'5000', N'10', N'80000', CAST(0xEC380B00 AS Date))
SET IDENTITY_INSERT [dbo].[OrderLine] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([id], [OrderNo], [OrderName], [OrderDescription], [OrderDate], [deliveryDate], [TotalCost], [OrderType], [WareHouseId], [ClientId], [VendorId], [FiscalYearId], [eDate], [Installments], [InstallmentDueDate], [ModeOfPayment], [GrantorName]) VALUES (7, N'0001', N'purchase orders', N'-', CAST(0x02380B00 AS Date), CAST(0x02380B00 AS Date), N'80000', N'Order To Vendor', 6, -1, 15, 4, CAST(0xEC380B00 AS Date), N'8', N'2014-01-02', N'Cash', N'abc')
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([id], [ClientId], [VendorId], [OrderId], [TransactionId], [TotalCost], [Paid], [PaymentType], [PaymentState]) VALUES (7, -1, 15, 7, 18, N'80000', N'2000', N'Partial', N'NotPaid')
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[PaymentLine] ON 

INSERT [dbo].[PaymentLine] ([id], [PaymentId], [PaidAmount], [RemainingAmount], [BankId], [Date], [CumulativeAmount], [ModeOfPayment], [Cheque]) VALUES (1, 7, N'2000', N'78000', 1, CAST(0xE7380B00 AS Date), N'2000', N'Cheque', N'9898989898989898')
SET IDENTITY_INSERT [dbo].[PaymentLine] OFF
SET IDENTITY_INSERT [dbo].[Permissions] ON 

INSERT [dbo].[Permissions] ([id], [RoleID], [Permission]) VALUES (5, 5, N'33')
SET IDENTITY_INSERT [dbo].[Permissions] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([id], [ProductCode], [Name], [tag1], [tag2], [tag3], [costPrice], [salePrice], [Manufacturer], [Description], [VendorId], [FiscalYearId], [eDate], [WareHouseId]) VALUES (12, N'00001', N'htc mobile', N'-', N'-', NULL, N'5000', N'8000', N'-', N'-', 15, 0, CAST(0xEC380B00 AS Date), 6)
INSERT [dbo].[Products] ([id], [ProductCode], [Name], [tag1], [tag2], [tag3], [costPrice], [salePrice], [Manufacturer], [Description], [VendorId], [FiscalYearId], [eDate], [WareHouseId]) VALUES (13, N'00002', N'nokia mobile', N'-', N'-', NULL, N'5000', N'9000', N'-', N'-', 16, 0, CAST(0xEC380B00 AS Date), 6)
SET IDENTITY_INSERT [dbo].[Products] OFF
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id], [RoleName]) VALUES (5, N'admin')
SET IDENTITY_INSERT [dbo].[Roles] OFF
SET IDENTITY_INSERT [dbo].[Transactions] ON 

INSERT [dbo].[Transactions] ([id], [ProductID], [WareHouseId], [OrderId], [CostPrice], [SalePrice], [units], [TransactionType], [ClientID], [VendorID], [date], [UserId]) VALUES (16, 12, 6, -1, N'5000', NULL, N'30', N'Addition', N'-1', N'15', CAST(0xDF380B00 AS Date), NULL)
INSERT [dbo].[Transactions] ([id], [ProductID], [WareHouseId], [OrderId], [CostPrice], [SalePrice], [units], [TransactionType], [ClientID], [VendorID], [date], [UserId]) VALUES (17, 13, 6, -1, N'5000', NULL, N'30', N'Addition', N'-1', N'16', CAST(0xDF380B00 AS Date), NULL)
INSERT [dbo].[Transactions] ([id], [ProductID], [WareHouseId], [OrderId], [CostPrice], [SalePrice], [units], [TransactionType], [ClientID], [VendorID], [date], [UserId]) VALUES (18, 12, 6, 7, N'5000', N'8000', N'10', N'Addition', N'-1', N'15', CAST(0x02380B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Transactions] OFF
SET IDENTITY_INSERT [dbo].[UserRolesContainer] ON 

INSERT [dbo].[UserRolesContainer] ([id], [userId], [RolesId]) VALUES (7, 8, 5)
INSERT [dbo].[UserRolesContainer] ([id], [userId], [RolesId]) VALUES (8, 9, 5)
SET IDENTITY_INSERT [dbo].[UserRolesContainer] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [name], [password], [Approved], [eDate]) VALUES (8, N'admin', N'admin', N'1', CAST(0x01380B00 AS Date))
INSERT [dbo].[Users] ([id], [name], [password], [Approved], [eDate]) VALUES (9, N'admin1', N'admin', N'1', CAST(0x00000000 AS Date))
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserWareHouseContainer] ON 

INSERT [dbo].[UserWareHouseContainer] ([id], [UserId], [WareHouseId]) VALUES (6, 8, 6)
INSERT [dbo].[UserWareHouseContainer] ([id], [UserId], [WareHouseId]) VALUES (7, 9, 7)
SET IDENTITY_INSERT [dbo].[UserWareHouseContainer] OFF
SET IDENTITY_INSERT [dbo].[Vendor] ON 

INSERT [dbo].[Vendor] ([id], [name], [Address], [phone], [WareHouseId]) VALUES (15, N'htc', N'-', N'-', 6)
INSERT [dbo].[Vendor] ([id], [name], [Address], [phone], [WareHouseId]) VALUES (16, N'nokia', N'0', N'0', 6)
SET IDENTITY_INSERT [dbo].[Vendor] OFF
SET IDENTITY_INSERT [dbo].[WareHouse] ON 

INSERT [dbo].[WareHouse] ([id], [Name], [Address], [Phone], [Description], [openedDate]) VALUES (6, N'gulshan', N'-', N'-', N'-', CAST(0xEB380B00 AS Date))
INSERT [dbo].[WareHouse] ([id], [Name], [Address], [Phone], [Description], [openedDate]) VALUES (7, N'johar', N'-', N'-', N'-', CAST(0xEB380B00 AS Date))
SET IDENTITY_INSERT [dbo].[WareHouse] OFF
ALTER TABLE [dbo].[AccountTransaction] ADD  CONSTRAINT [DF_AccountTransaction_date]  DEFAULT (getdate()) FOR [eDate]
GO
ALTER TABLE [dbo].[ChartOfAccounts] ADD  CONSTRAINT [DF_CharOfAccounts_e_date]  DEFAULT (getdate()) FOR [e_date]
GO
ALTER TABLE [dbo].[Journal] ADD  CONSTRAINT [DF_Journal_e_date]  DEFAULT (getdate()) FOR [e_date]
GO
ALTER TABLE [dbo].[Ledgers] ADD  CONSTRAINT [DF_Ledgers_e_date]  DEFAULT (getdate()) FOR [e_date]
GO
ALTER TABLE [dbo].[OrderLine] ADD  CONSTRAINT [DF_OrderLine_eDate]  DEFAULT (getdate()) FOR [eDate]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_eDate]  DEFAULT (getdate()) FOR [eDate]
GO
ALTER TABLE [dbo].[Postings] ADD  CONSTRAINT [DF_Postings_e_date]  DEFAULT (getdate()) FOR [e_date]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_eDate]  DEFAULT (getdate()) FOR [eDate]
GO
ALTER TABLE [dbo].[Transaction] ADD  CONSTRAINT [DF_TransactionDetails_eDate]  DEFAULT (getdate()) FOR [eDate]
GO
ALTER TABLE [dbo].[TransactionDetail] ADD  CONSTRAINT [DF_TransactionDetail_eDate]  DEFAULT (getdate()) FOR [eDate]
GO
ALTER TABLE [dbo].[Transactions] ADD  CONSTRAINT [DF_Transactions_date]  DEFAULT (getdate()) FOR [date]
GO
ALTER TABLE [dbo].[UserDetails] ADD  CONSTRAINT [DF_UserDetails_eDate]  DEFAULT (getdate()) FOR [eDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_eDate]  DEFAULT (getdate()) FOR [eDate]
GO
ALTER TABLE [dbo].[AccountTransaction]  WITH NOCHECK ADD  CONSTRAINT [FK_AccountTransaction_BankAccount] FOREIGN KEY([AccountId])
REFERENCES [dbo].[BankAccount] ([id])
GO
ALTER TABLE [dbo].[AccountTransaction] CHECK CONSTRAINT [FK_AccountTransaction_BankAccount]
GO
ALTER TABLE [dbo].[BankAccount]  WITH NOCHECK ADD  CONSTRAINT [FK_BankAccount_Bank] FOREIGN KEY([BankId])
REFERENCES [dbo].[Bank] ([id])
GO
ALTER TABLE [dbo].[BankAccount] CHECK CONSTRAINT [FK_BankAccount_Bank]
GO
ALTER TABLE [dbo].[CashTransaction]  WITH NOCHECK ADD  CONSTRAINT [FK_CashTransaction_CashAccount] FOREIGN KEY([CashAccountId])
REFERENCES [dbo].[CashAccount] ([id])
GO
ALTER TABLE [dbo].[CashTransaction] CHECK CONSTRAINT [FK_CashTransaction_CashAccount]
GO
ALTER TABLE [dbo].[ChartOfAccounts]  WITH NOCHECK ADD  CONSTRAINT [FK_CharOfAccounts_Ledgers] FOREIGN KEY([type])
REFERENCES [dbo].[Ledgers] ([type])
GO
ALTER TABLE [dbo].[ChartOfAccounts] CHECK CONSTRAINT [FK_CharOfAccounts_Ledgers]
GO
ALTER TABLE [dbo].[Clients]  WITH NOCHECK ADD  CONSTRAINT [FK_Clients_ClientTypes] FOREIGN KEY([ClientTypeId])
REFERENCES [dbo].[ClientTypes] ([id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_Clients_ClientTypes]
GO
ALTER TABLE [dbo].[HOD]  WITH NOCHECK ADD  CONSTRAINT [FK_HOD_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[HOD] CHECK CONSTRAINT [FK_HOD_Department]
GO
ALTER TABLE [dbo].[HOD]  WITH NOCHECK ADD  CONSTRAINT [FK_HOD_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([id])
GO
ALTER TABLE [dbo].[HOD] CHECK CONSTRAINT [FK_HOD_Employees]
GO
ALTER TABLE [dbo].[Inventory]  WITH NOCHECK ADD  CONSTRAINT [FK_Inventory_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Products]
GO
ALTER TABLE [dbo].[Inventory]  WITH NOCHECK ADD  CONSTRAINT [FK_Inventory_WareHouse] FOREIGN KEY([WareHouseId])
REFERENCES [dbo].[WareHouse] ([id])
GO
ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_WareHouse]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH NOCHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([id])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices]
GO
ALTER TABLE [dbo].[InvoiceItems]  WITH NOCHECK ADD  CONSTRAINT [FK_InvoiceItems_InvoiceDetails] FOREIGN KEY([InvoicedetailId])
REFERENCES [dbo].[InvoiceDetails] ([id])
GO
ALTER TABLE [dbo].[InvoiceItems] CHECK CONSTRAINT [FK_InvoiceItems_InvoiceDetails]
GO
ALTER TABLE [dbo].[InvoicePayment]  WITH NOCHECK ADD  CONSTRAINT [FK_InvoicePayment_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([id])
GO
ALTER TABLE [dbo].[InvoicePayment] CHECK CONSTRAINT [FK_InvoicePayment_Invoices]
GO
ALTER TABLE [dbo].[OrderLine]  WITH NOCHECK ADD  CONSTRAINT [FK_OrderLine_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[OrderLine] CHECK CONSTRAINT [FK_OrderLine_Products]
GO
ALTER TABLE [dbo].[PaidSalary]  WITH NOCHECK ADD  CONSTRAINT [FK_PaidSalary_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([id])
GO
ALTER TABLE [dbo].[PaidSalary] CHECK CONSTRAINT [FK_PaidSalary_Employees]
GO
ALTER TABLE [dbo].[Payroll]  WITH NOCHECK ADD  CONSTRAINT [FK_Payroll_Salary] FOREIGN KEY([SalaryId])
REFERENCES [dbo].[Salary] ([id])
GO
ALTER TABLE [dbo].[Payroll] CHECK CONSTRAINT [FK_Payroll_Salary]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_TransactionDetail_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([id])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_Products]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_TransactionDetail_Transaction] FOREIGN KEY([TransactionId])
REFERENCES [dbo].[Transaction] ([id])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_Transaction]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_TransactionDetail_WareHouse] FOREIGN KEY([FromWareHouseId])
REFERENCES [dbo].[WareHouse] ([id])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_WareHouse]
GO
ALTER TABLE [dbo].[TransactionDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_TransactionDetail_WareHouse1] FOREIGN KEY([ToWareHouseId])
REFERENCES [dbo].[WareHouse] ([id])
GO
ALTER TABLE [dbo].[TransactionDetail] CHECK CONSTRAINT [FK_TransactionDetail_WareHouse1]
GO
ALTER TABLE [dbo].[UserDetails]  WITH NOCHECK ADD  CONSTRAINT [FK_UserDetails_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_UserDetails_Users]
GO
ALTER TABLE [dbo].[UserRolesContainer]  WITH NOCHECK ADD  CONSTRAINT [FK_UserRolesContainer_Roles] FOREIGN KEY([RolesId])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[UserRolesContainer] CHECK CONSTRAINT [FK_UserRolesContainer_Roles]
GO
ALTER TABLE [dbo].[UserRolesContainer]  WITH NOCHECK ADD  CONSTRAINT [FK_UserRolesContainer_Users] FOREIGN KEY([userId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserRolesContainer] CHECK CONSTRAINT [FK_UserRolesContainer_Users]
GO
ALTER TABLE [dbo].[UserWareHouseContainer]  WITH NOCHECK ADD  CONSTRAINT [FK_UserWareHouseContainer_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[UserWareHouseContainer] CHECK CONSTRAINT [FK_UserWareHouseContainer_Users]
GO
ALTER TABLE [dbo].[UserWareHouseContainer]  WITH NOCHECK ADD  CONSTRAINT [FK_UserWareHouseContainer_WareHouse] FOREIGN KEY([WareHouseId])
REFERENCES [dbo].[WareHouse] ([id])
GO
ALTER TABLE [dbo].[UserWareHouseContainer] CHECK CONSTRAINT [FK_UserWareHouseContainer_WareHouse]
GO
