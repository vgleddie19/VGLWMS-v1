USE [wms_db]
GO

/****** Object:  Table [dbo].[BinProductLedger]    Script Date: 03/18/2019 16:29:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BinProductLedger]') AND type in (N'U'))
DROP TABLE [dbo].[BinProductLedger]
GO

USE [wms_db]
GO

/****** Object:  Table [dbo].[BinProductLedger]    Script Date: 03/18/2019 16:29:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BinProductLedger](
	[Location] [nvarchar](150) NOT NULL,
	[product] [nvarchar](150) NULL,
	[uom] [nvarchar](50) NULL,
	[lot_no] [nvarchar](50) NULL,
	[expiry] [datetime] NULL,
	[actualqty] [int] NULL,
	[min_qty] [int] NULL,
	[max_qty] [int] NULL,
	[qty_to_replenished] [int] NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_BinProductLedger] PRIMARY KEY CLUSTERED 
(
	[Location] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


