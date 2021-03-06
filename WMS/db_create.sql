USE [wms_db]
GO
/****** Object:  Table [dbo].[Releases]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Releases](
	[release_id] [varchar](250) NOT NULL,
	[trip] [varchar](250) NOT NULL,
	[released_on] [datetime] NOT NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_Releases] PRIMARY KEY CLUSTERED 
(
	[release_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReleaseOrders]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReleaseOrders](
	[order_id] [varchar](250) NOT NULL,
	[client] [varchar](100) NOT NULL,
	[reference] [varchar](1000) NOT NULL,
	[reference_date] [datetime] NOT NULL,
	[order_date] [datetime] NOT NULL,
	[recipient] [varchar](1000) NOT NULL,
	[status] [varchar](50) NOT NULL,
	[scheduled_release_date] [date] NULL,
	[actual_release_date] [date] NULL,
 CONSTRAINT [PK_ReleaseOrders] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReleaseTrips]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReleaseTrips](
	[trip_id] [varchar](250) NOT NULL,
	[status] [varchar](50) NULL,
	[authorized_receiver] [varchar](50) NULL,
	[receiving_date] [date] NULL,
 CONSTRAINT [PK_ReleaseTrips] PRIMARY KEY CLUSTERED 
(
	[trip_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TMenu]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TMenu](
	[menu_id] [varchar](50) NOT NULL,
	[menu_current] [int] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Locations](
	[location_id] [varchar](250) NOT NULL,
	[description] [varchar](1000) NOT NULL,
	[type] [varchar](250) NOT NULL,
	[status] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[location_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Putaways]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Putaways](
	[putaway_id] [varchar](250) NOT NULL,
	[container] [varchar](250) NOT NULL,
	[encoded_on] [datetime] NOT NULL,
	[completed_on] [datetime] NULL,
 CONSTRAINT [PK_Putaways] PRIMARY KEY CLUSTERED 
(
	[putaway_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Products]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Products](
	[product_id] [varchar](250) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[pcs_per_case] [int] NOT NULL,
	[category] [varchar](500) NULL,
	[pc_barcode] [varchar](200) NULL,
	[case_barcode] [varchar](200) NULL,
	[default_owner] [varchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductClassification]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductClassification](
	[product] [varchar](250) NOT NULL,
	[classification] [varchar](250) NOT NULL,
	[value] [varchar](250) NULL,
 CONSTRAINT [PK_ProductClassification] PRIMARY KEY CLUSTERED 
(
	[product] ASC,
	[classification] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Picklists]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Picklists](
	[picklist_id] [varchar](250) NOT NULL,
	[status] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Picklists] PRIMARY KEY CLUSTERED 
(
	[picklist_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhysicalCounts]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhysicalCounts](
	[phcount_id] [varchar](250) NOT NULL,
	[created_by] [varchar](250) NULL,
	[created_on] [varchar](250) NULL,
	[finished_on] [varchar](250) NULL,
	[device_handler] [varchar](250) NULL,
	[cycle] [decimal](18, 0) NULL,
	[cycle_year] [int] NULL,
	[counted_by] [varchar](250) NULL,
 CONSTRAINT [PK_PhysicalCounts] PRIMARY KEY CLUSTERED 
(
	[phcount_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationLedger]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationLedger](
	[location] [varchar](250) NOT NULL,
	[transaction_datetime] [datetime] NOT NULL,
	[transaction_type] [varchar](250) NOT NULL,
	[transaction_name] [varchar](250) NOT NULL,
	[transaction_id] [varchar](250) NOT NULL,
 CONSTRAINT [PK_LocationLedger] PRIMARY KEY CLUSTERED 
(
	[location] ASC,
	[transaction_datetime] ASC,
	[transaction_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ForResolutions]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ForResolutions](
	[trans_source] [varchar](250) NOT NULL,
	[trans_id] [varchar](250) NOT NULL,
	[detected_on] [datetime] NOT NULL,
	[product] [varchar](250) NOT NULL,
	[uom] [varchar](250) NOT NULL,
	[lot_no] [varchar](250) NOT NULL,
	[expiry] [date] NOT NULL,
	[location] [varchar](250) NOT NULL,
	[variance_type] [varchar](50) NOT NULL,
	[variance_qty] [int] NOT NULL,
	[status] [varchar](50) NOT NULL,
	[line] [int] NOT NULL,
 CONSTRAINT [PK_ForResolutions] PRIMARY KEY CLUSTERED 
(
	[trans_source] ASC,
	[trans_id] ASC,
	[line] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employees](
	[employee_id] [varchar](250) NOT NULL,
	[name] [varchar](250) NOT NULL,
	[position] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Containers]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Containers](
	[container_id] [varchar](250) NOT NULL,
	[type] [varchar](250) NOT NULL,
	[description] [varchar](250) NULL,
	[status] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Containers] PRIMARY KEY CLUSTERED 
(
	[container_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BadStockDeclarations]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BadStockDeclarations](
	[declaration_id] [varchar](250) NOT NULL,
	[declared_by] [varchar](50) NULL,
	[declared_on] [date] NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_BadStockDeclarations] PRIMARY KEY CLUSTERED 
(
	[declaration_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BadStockDeclarationDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BadStockDeclarationDetails](
	[declaration] [varchar](250) NOT NULL,
	[line] [int] NOT NULL,
	[product] [varchar](250) NOT NULL,
	[uom] [varchar](250) NOT NULL,
	[lot_no] [varchar](250) NOT NULL,
	[expiry] [date] NOT NULL,
	[location] [varchar](250) NOT NULL,
	[qty] [int] NOT NULL,
	[reason] [varchar](1000) NOT NULL,
	[bad_stock_storage] [varchar](250) NULL,
 CONSTRAINT [PK_BadStockDeclarationDetails] PRIMARY KEY CLUSTERED 
(
	[declaration] ASC,
	[line] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Issuances]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Issuances](
	[issuance_id] [varchar](250) NOT NULL,
	[issued_to] [varchar](1000) NOT NULL,
	[issued_on] [datetime] NOT NULL,
	[issued_by] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Issuances] PRIMARY KEY CLUSTERED 
(
	[issuance_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhysicalCountDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhysicalCountDetails](
	[phcount] [varchar](250) NOT NULL,
	[location] [varchar](250) NOT NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_PhysicalCountDetails] PRIMARY KEY CLUSTERED 
(
	[phcount] ASC,
	[location] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PicklistDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PicklistDetails](
	[picklist] [varchar](250) NOT NULL,
	[order_id] [varchar](250) NOT NULL,
	[product] [varchar](250) NOT NULL,
	[uom] [varchar](50) NOT NULL,
	[lot_no] [varchar](50) NOT NULL,
	[expiry] [date] NOT NULL,
	[location] [varchar](50) NOT NULL,
	[qty] [int] NOT NULL,
	[line] [int] NOT NULL,
 CONSTRAINT [PK_PicklistDetails] PRIMARY KEY CLUSTERED 
(
	[picklist] ASC,
	[line] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PutawayDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PutawayDetails](
	[putaway] [varchar](250) NOT NULL,
	[product] [varchar](250) NOT NULL,
	[uom] [varchar](50) NOT NULL,
	[lot_no] [varchar](50) NOT NULL,
	[expiry] [date] NOT NULL,
	[location] [varchar](250) NOT NULL,
	[expected_qty] [int] NOT NULL,
	[actual_qty] [int] NULL,
 CONSTRAINT [PK_PutawayDetails] PRIMARY KEY CLUSTERED 
(
	[putaway] ASC,
	[product] ASC,
	[uom] ASC,
	[lot_no] ASC,
	[expiry] ASC,
	[location] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProductUOMs]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProductUOMs](
	[product] [varchar](250) NOT NULL,
	[uom] [varchar](250) NOT NULL,
	[qty] [decimal](18, 0) NOT NULL,
	[barcode] [varchar](250) NULL,
 CONSTRAINT [PK_ProductUOMs] PRIMARY KEY CLUSTERED 
(
	[product] ASC,
	[uom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LocationProductsLedger]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocationProductsLedger](
	[location] [varchar](250) NOT NULL,
	[product] [varchar](250) NOT NULL,
	[qty] [int] NOT NULL,
	[uom] [varchar](50) NOT NULL,
	[lot_no] [varchar](50) NOT NULL,
	[expiry] [date] NOT NULL,
	[reserved_qty] [int] NULL,
	[available_qty]  AS ([qty]-[reserved_qty]),
	[to_be_picked_qty] [int] NULL,
 CONSTRAINT [PK_LocationProductsLedger] PRIMARY KEY CLUSTERED 
(
	[location] ASC,
	[product] ASC,
	[uom] ASC,
	[lot_no] ASC,
	[expiry] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Receipts]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Receipts](
	[receipt_id] [varchar](250) NOT NULL,
	[received_from] [varchar](1000) NOT NULL,
	[received_on] [datetime] NOT NULL,
	[received_by] [varchar](250) NOT NULL,
	[encoded_on] [datetime] NOT NULL,
 CONSTRAINT [PK_Receipts] PRIMARY KEY CLUSTERED 
(
	[receipt_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Resolutions]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Resolutions](
	[trans_source] [varchar](250) NOT NULL,
	[trans_id] [varchar](250) NOT NULL,
	[line] [int] NOT NULL,
	[explanation_no] [int] NOT NULL,
	[explanation] [varchar](2000) NOT NULL,
	[charge_to] [varchar](50) NULL,
	[qty_resolved] [int] NOT NULL,
	[resolved_by] [varchar](250) NULL,
	[resolved_on] [datetime] NULL,
 CONSTRAINT [PK_Resolutions] PRIMARY KEY CLUSTERED 
(
	[trans_source] ASC,
	[trans_id] ASC,
	[line] ASC,
	[explanation_no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReleaseTripDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReleaseTripDetails](
	[trip] [varchar](250) NOT NULL,
	[order_id] [varchar](250) NOT NULL,
	[drop_sequence] [int] NULL,
 CONSTRAINT [PK_ReleaseTripDetails] PRIMARY KEY CLUSTERED 
(
	[trip] ASC,
	[order_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReleaseOrderDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReleaseOrderDetails](
	[release_order] [varchar](250) NOT NULL,
	[product] [varchar](250) NOT NULL,
	[uom] [varchar](50) NOT NULL,
	[qty] [int] NULL,
 CONSTRAINT [PK_ReleaseOrderDetails] PRIMARY KEY CLUSTERED 
(
	[release_order] ASC,
	[product] ASC,
	[uom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReleaseDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReleaseDetails](
	[release] [varchar](250) NOT NULL,
	[order_id] [varchar](250) NOT NULL,
	[drop_sequence] [int] NOT NULL,
	[status] [varchar](250) NOT NULL,
 CONSTRAINT [PK_ReleaseDetails] PRIMARY KEY CLUSTERED 
(
	[release] ASC,
	[order_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReleaseDetailItems]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReleaseDetailItems](
	[release] [varchar](250) NOT NULL,
	[order_id] [varchar](250) NOT NULL,
	[product] [varchar](250) NOT NULL,
	[expiry] [datetime] NOT NULL,
	[lot_no] [varchar](250) NOT NULL,
	[order_qty] [int] NOT NULL,
	[uom] [varchar](250) NOT NULL,
	[scanned_qty] [int] NOT NULL,
	[line] [int] NOT NULL,
	[scanned_on] [datetime] NULL,
 CONSTRAINT [PK_ReleaseDetailItems] PRIMARY KEY CLUSTERED 
(
	[release] ASC,
	[order_id] ASC,
	[line] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ReceiptDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReceiptDetails](
	[receipt] [varchar](250) NOT NULL,
	[line] [int] NOT NULL,
	[product] [varchar](250) NOT NULL,
	[qty] [int] NOT NULL,
	[uom] [varchar](50) NOT NULL,
	[lot_no] [varchar](50) NOT NULL,
	[expiry] [date] NOT NULL,
	[remarks] [varchar](250) NULL,
 CONSTRAINT [PK_ReceiptDetails] PRIMARY KEY CLUSTERED 
(
	[receipt] ASC,
	[line] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhysicalCountDetailItems]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhysicalCountDetailItems](
	[phcount] [varchar](250) NOT NULL,
	[location] [varchar](250) NOT NULL,
	[line] [int] NOT NULL,
	[product] [varchar](250) NOT NULL,
	[uom] [varchar](50) NULL,
	[lot_no] [varchar](250) NULL,
	[expiry] [date] NULL,
	[expected_qty] [int] NULL,
	[actual_qty] [int] NULL,
	[variance] [int] NULL,
	[shortage]  AS (case when [expected_qty]>[actual_qty] then [expected_qty]-[actual_qty] else (0) end),
	[overage]  AS (case when [actual_qty]>[expected_qty] then [actual_qty]-[expected_qty] else (0) end),
 CONSTRAINT [PK_PhysicalCountDetailItems] PRIMARY KEY CLUSTERED 
(
	[phcount] ASC,
	[location] ASC,
	[line] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IssuanceDetails]    Script Date: 08/05/2018 17:13:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IssuanceDetails](
	[issuance] [varchar](250) NOT NULL,
	[product] [varchar](250) NOT NULL,
	[qty] [int] NOT NULL,
	[expiry] [date] NOT NULL,
	[lot_no] [varchar](250) NOT NULL,
 CONSTRAINT [PK_IssuanceDetails] PRIMARY KEY CLUSTERED 
(
	[issuance] ASC,
	[product] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_ReleaseOrders_status]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[ReleaseOrders] ADD  CONSTRAINT [DF_ReleaseOrders_status]  DEFAULT ('FOR STOCK CHECKING') FOR [status]
GO
/****** Object:  Default [DF_LocationProductsLedger_reserved_qty]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[LocationProductsLedger] ADD  CONSTRAINT [DF_LocationProductsLedger_reserved_qty]  DEFAULT ((0)) FOR [reserved_qty]
GO
/****** Object:  Default [DF_LocationProductsLedger_to_be_picked_qty]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[LocationProductsLedger] ADD  CONSTRAINT [DF_LocationProductsLedger_to_be_picked_qty]  DEFAULT ((0)) FOR [to_be_picked_qty]
GO
/****** Object:  Check [CK_LocationProductsLedger]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[LocationProductsLedger]  WITH CHECK ADD  CONSTRAINT [CK_LocationProductsLedger] CHECK  (([qty]>=(0)))
GO
ALTER TABLE [dbo].[LocationProductsLedger] CHECK CONSTRAINT [CK_LocationProductsLedger]
GO
/****** Object:  ForeignKey [FK_BadStockDeclarationDetails_BadStockDeclarations]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[BadStockDeclarationDetails]  WITH CHECK ADD  CONSTRAINT [FK_BadStockDeclarationDetails_BadStockDeclarations] FOREIGN KEY([declaration])
REFERENCES [dbo].[BadStockDeclarations] ([declaration_id])
GO
ALTER TABLE [dbo].[BadStockDeclarationDetails] CHECK CONSTRAINT [FK_BadStockDeclarationDetails_BadStockDeclarations]
GO
/****** Object:  ForeignKey [FK_Issuances_Employees]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[Issuances]  WITH CHECK ADD  CONSTRAINT [FK_Issuances_Employees] FOREIGN KEY([issued_by])
REFERENCES [dbo].[Employees] ([employee_id])
GO
ALTER TABLE [dbo].[Issuances] CHECK CONSTRAINT [FK_Issuances_Employees]
GO
/****** Object:  ForeignKey [FK_PhysicalCountDetails_PhysicalCounts]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[PhysicalCountDetails]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalCountDetails_PhysicalCounts] FOREIGN KEY([phcount])
REFERENCES [dbo].[PhysicalCounts] ([phcount_id])
GO
ALTER TABLE [dbo].[PhysicalCountDetails] CHECK CONSTRAINT [FK_PhysicalCountDetails_PhysicalCounts]
GO
/****** Object:  ForeignKey [FK_PicklistDetails_Picklists]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[PicklistDetails]  WITH CHECK ADD  CONSTRAINT [FK_PicklistDetails_Picklists] FOREIGN KEY([picklist])
REFERENCES [dbo].[Picklists] ([picklist_id])
GO
ALTER TABLE [dbo].[PicklistDetails] CHECK CONSTRAINT [FK_PicklistDetails_Picklists]
GO
/****** Object:  ForeignKey [FK_PutawayDetails_Putaways]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[PutawayDetails]  WITH CHECK ADD  CONSTRAINT [FK_PutawayDetails_Putaways] FOREIGN KEY([putaway])
REFERENCES [dbo].[Putaways] ([putaway_id])
GO
ALTER TABLE [dbo].[PutawayDetails] CHECK CONSTRAINT [FK_PutawayDetails_Putaways]
GO
/****** Object:  ForeignKey [FK_ProductUOMs_Products]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[ProductUOMs]  WITH CHECK ADD  CONSTRAINT [FK_ProductUOMs_Products] FOREIGN KEY([product])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[ProductUOMs] CHECK CONSTRAINT [FK_ProductUOMs_Products]
GO
/****** Object:  ForeignKey [FK_LocationProductsLedger_Products]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[LocationProductsLedger]  WITH CHECK ADD  CONSTRAINT [FK_LocationProductsLedger_Products] FOREIGN KEY([product])
REFERENCES [dbo].[Products] ([product_id])
GO
ALTER TABLE [dbo].[LocationProductsLedger] CHECK CONSTRAINT [FK_LocationProductsLedger_Products]
GO
/****** Object:  ForeignKey [FK_Receipts_Employees]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[Receipts]  WITH CHECK ADD  CONSTRAINT [FK_Receipts_Employees] FOREIGN KEY([received_by])
REFERENCES [dbo].[Employees] ([employee_id])
GO
ALTER TABLE [dbo].[Receipts] CHECK CONSTRAINT [FK_Receipts_Employees]
GO
/****** Object:  ForeignKey [FK_Resolutions_ForResolutions]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[Resolutions]  WITH CHECK ADD  CONSTRAINT [FK_Resolutions_ForResolutions] FOREIGN KEY([trans_source], [trans_id], [line])
REFERENCES [dbo].[ForResolutions] ([trans_source], [trans_id], [line])
GO
ALTER TABLE [dbo].[Resolutions] CHECK CONSTRAINT [FK_Resolutions_ForResolutions]
GO
/****** Object:  ForeignKey [FK_ReleaseTripDetails_ReleaseTrips]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[ReleaseTripDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReleaseTripDetails_ReleaseTrips] FOREIGN KEY([trip])
REFERENCES [dbo].[ReleaseTrips] ([trip_id])
GO
ALTER TABLE [dbo].[ReleaseTripDetails] CHECK CONSTRAINT [FK_ReleaseTripDetails_ReleaseTrips]
GO
/****** Object:  ForeignKey [FK_ReleaseOrderDetails_ReleaseOrders]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[ReleaseOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReleaseOrderDetails_ReleaseOrders] FOREIGN KEY([release_order])
REFERENCES [dbo].[ReleaseOrders] ([order_id])
GO
ALTER TABLE [dbo].[ReleaseOrderDetails] CHECK CONSTRAINT [FK_ReleaseOrderDetails_ReleaseOrders]
GO
/****** Object:  ForeignKey [FK_ReleaseDetails_Releases]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[ReleaseDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReleaseDetails_Releases] FOREIGN KEY([release])
REFERENCES [dbo].[Releases] ([release_id])
GO
ALTER TABLE [dbo].[ReleaseDetails] CHECK CONSTRAINT [FK_ReleaseDetails_Releases]
GO
/****** Object:  ForeignKey [FK_ReleaseDetailItems_ReleaseDetails]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[ReleaseDetailItems]  WITH CHECK ADD  CONSTRAINT [FK_ReleaseDetailItems_ReleaseDetails] FOREIGN KEY([release], [order_id])
REFERENCES [dbo].[ReleaseDetails] ([release], [order_id])
GO
ALTER TABLE [dbo].[ReleaseDetailItems] CHECK CONSTRAINT [FK_ReleaseDetailItems_ReleaseDetails]
GO
/****** Object:  ForeignKey [FK_ReceiptDetails_Products]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[ReceiptDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptDetails_Products] FOREIGN KEY([product])
REFERENCES [dbo].[Products] ([product_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ReceiptDetails] CHECK CONSTRAINT [FK_ReceiptDetails_Products]
GO
/****** Object:  ForeignKey [FK_ReceiptDetails_Receipts]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[ReceiptDetails]  WITH CHECK ADD  CONSTRAINT [FK_ReceiptDetails_Receipts] FOREIGN KEY([receipt])
REFERENCES [dbo].[Receipts] ([receipt_id])
GO
ALTER TABLE [dbo].[ReceiptDetails] CHECK CONSTRAINT [FK_ReceiptDetails_Receipts]
GO
/****** Object:  ForeignKey [FK_PhysicalCountDetailItems_PhysicalCountDetails]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[PhysicalCountDetailItems]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalCountDetailItems_PhysicalCountDetails] FOREIGN KEY([phcount], [location])
REFERENCES [dbo].[PhysicalCountDetails] ([phcount], [location])
GO
ALTER TABLE [dbo].[PhysicalCountDetailItems] CHECK CONSTRAINT [FK_PhysicalCountDetailItems_PhysicalCountDetails]
GO
/****** Object:  ForeignKey [FK_IssuanceDetails_Issuances]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[IssuanceDetails]  WITH CHECK ADD  CONSTRAINT [FK_IssuanceDetails_Issuances] FOREIGN KEY([issuance])
REFERENCES [dbo].[Issuances] ([issuance_id])
GO
ALTER TABLE [dbo].[IssuanceDetails] CHECK CONSTRAINT [FK_IssuanceDetails_Issuances]
GO
/****** Object:  ForeignKey [FK_IssuanceDetails_Products]    Script Date: 08/05/2018 17:13:54 ******/
ALTER TABLE [dbo].[IssuanceDetails]  WITH CHECK ADD  CONSTRAINT [FK_IssuanceDetails_Products] FOREIGN KEY([product])
REFERENCES [dbo].[Products] ([product_id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[IssuanceDetails] CHECK CONSTRAINT [FK_IssuanceDetails_Products]
GO
