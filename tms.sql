USE [master]
GO
/****** Object:  Database [tms_db]    Script Date: 04/10/2019 16:44:40 ******/
CREATE DATABASE [tms_db] ON  PRIMARY 
( NAME = N'tms_db', FILENAME = N'D:\CoreDatabase\tms_db.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'tms_db_log', FILENAME = N'D:\CoreDatabase\tms_db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [tms_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [tms_db] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [tms_db] SET ANSI_NULLS OFF
GO
ALTER DATABASE [tms_db] SET ANSI_PADDING OFF
GO
ALTER DATABASE [tms_db] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [tms_db] SET ARITHABORT OFF
GO
ALTER DATABASE [tms_db] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [tms_db] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [tms_db] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [tms_db] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [tms_db] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [tms_db] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [tms_db] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [tms_db] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [tms_db] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [tms_db] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [tms_db] SET  DISABLE_BROKER
GO
ALTER DATABASE [tms_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [tms_db] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [tms_db] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [tms_db] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [tms_db] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [tms_db] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [tms_db] SET  READ_WRITE
GO
ALTER DATABASE [tms_db] SET RECOVERY SIMPLE
GO
ALTER DATABASE [tms_db] SET  MULTI_USER
GO
ALTER DATABASE [tms_db] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [tms_db] SET DB_CHAINING OFF
GO
USE [tms_db]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 04/10/2019 16:44:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[vehicle_id] [nvarchar](250) NOT NULL,
	[type] [nvarchar](250) NULL,
	[plate_no] [nvarchar](250) NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[vehicle_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'CDP09', N'Sedan', NULL)
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'CDT10', N'Truck', NULL)
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'CDT11', N'Truck', NULL)
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'DGT29', N'Truck', NULL)
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'DGT30', N'Truck', NULL)
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'DGT36', N'Truck', NULL)
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'DGT37', N'Truck', NULL)
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'DGT39', N'Truck', NULL)
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'TRUCK A', N'Sedan     ', N'ABC-123   ')
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'TRUCK B', N'Truck     ', N'ABC-111   ')
INSERT [dbo].[Vehicles] ([vehicle_id], [type], [plate_no]) VALUES (N'TRUCK C', N'Truck     ', N'ABC-121   ')
/****** Object:  Table [dbo].[VehicleBlocking]    Script Date: 04/10/2019 16:44:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleBlocking](
	[vehicle] [nvarchar](250) NOT NULL,
	[date] [datetime] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VehicleBlocking] PRIMARY KEY CLUSTERED 
(
	[vehicle] ASC,
	[date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[VehicleBlocking] ([vehicle], [date], [name]) VALUES (N'ALL', CAST(0x0000A98F00000000 AS DateTime), N'NO WORK')
INSERT [dbo].[VehicleBlocking] ([vehicle], [date], [name]) VALUES (N'TRUCK C', CAST(0x0000A98F00000000 AS DateTime), N'R & M')
/****** Object:  UserDefinedFunction [dbo].[udf_SplitVariable]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[udf_SplitVariable]
(
    @List varchar(8000),
    @SplitOn varchar(5) = ','
)

RETURNS @RtnValue TABLE
(
    Id INT IDENTITY(1,1),
    Value VARCHAR(8000)
)

AS
BEGIN

--Account for ticks
SET @List = (REPLACE(@List, '''', ''))

--Account for 'emptynull'
IF LTRIM(RTRIM(@List)) = 'emptynull'
BEGIN
    SET @List = ''
END

--Loop through all of the items in the string and add records for each item
WHILE (CHARINDEX(@SplitOn,@List)>0)
BEGIN

    INSERT INTO @RtnValue (value)
    SELECT Value = LTRIM(RTRIM(SUBSTRING(@List, 1, CHARINDEX(@SplitOn, @List)-1)))  

    SET @List = SUBSTRING(@List, CHARINDEX(@SplitOn,@List) + LEN(@SplitOn), LEN(@List))

END

INSERT INTO @RtnValue (Value)
SELECT Value = LTRIM(RTRIM(@List))

RETURN

END
GO
/****** Object:  UserDefinedFunction [dbo].[UDF_CreateAlphanumericSortValue]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[UDF_CreateAlphanumericSortValue]
(
	@ItemToSort varchar(50)
)
RETURNS varchar(100)
AS
	--==========================================================================================
	-- This function takes an alphanumeric string and encodes it so that it can be properly sorted
	--    against other alphanumeric strings
	-- The encoding will insert a two digit string before each numeric portion of the item to sort
	--    The two digits represent the number of digits in the numeric portion that it will precede (zero-padded)
	-- The encoding will also account for leading zeros in each numeric portion by adding a two digit
	--    string at the end of the item to sort, for each numeric portion.  Those two digits will
	--    represent the number of leading zeros in the numeric portion (zero-padded)
	-- Examples:
	-- ABC1 =     ABC011 00
	-- ABC1ABC1 = ABC011ABC011 00
	-- ABC12    = ABC0212 00
	-- ABC012   = ABC0212 01
	--==========================================================================================
BEGIN
	declare @WorkingItem varchar(50) = @ItemToSort
	declare @DigitCount int = 0
	declare @LeadingZeroCount int = 0
	declare @CurrentNumber varchar(50) = ''
	declare @Leftmost varchar(1) = ''
	declare @LeadingZeroString varchar(50) = ''

	--==========================================================================================
	-- With 50 character input, the worst case output should be 100 characters
	--==========================================================================================
	declare @SortValue varchar(100) = ''	

	--==========================================================================================
	-- We will work thru the input string one character at a time
	--==========================================================================================
	while (len(@WorkingItem) > 0)
	begin
		select @Leftmost = left(@WorkingItem, 1)

		--==========================================================================================
		-- Is the first character a number?
		--==========================================================================================
		if (isnumeric(@Leftmost) = 1)
		begin
			while (isnumeric(@Leftmost) = 1)
			begin
				--==========================================================================================
				-- Parse out all of the consecutive digits to get the current number
				--==========================================================================================
				if (@Leftmost = '0' and @DigitCount = 0)
				begin
					--==========================================================================================
					-- Leading zero -- just count how many we have in this set of digits
					--    We'll add the string for it to the end of our output below
					--==========================================================================================
					select @LeadingZeroCount = @LeadingZeroCount + 1
				end
				else
				begin
					--==========================================================================================
					-- Not a leading zero, so increment the digit count, and remember the current number value
					--==========================================================================================
					select @DigitCount = @DigitCount + 1
					select @CurrentNumber = @CurrentNumber + @Leftmost
				end

				--==========================================================================================
				-- Trim off the character we just checked, get the next character to check and continue the inner loop
				--==========================================================================================
				select @WorkingItem = substring(@WorkingItem, 2, 50)
				select @Leftmost = left(@WorkingItem, 1)
			end -- while (isnumeric(@Leftmost) = 1)

			--==========================================================================================
			-- We now have the current number from our input string
			--    Add the current number's leading zero string to the entire leading zero string
			--==========================================================================================
			if (@LeadingZeroCount < 10)
				select @LeadingZeroString = @LeadingZeroString + '0' + cast(@LeadingZeroCount as varchar)
			else
				select @LeadingZeroString = @LeadingZeroString + cast(@LeadingZeroCount as varchar)

			--==========================================================================================
			-- Add the current number's sort code, along with the current number, to the returned sort value
			--==========================================================================================
			if (@DigitCount < 10)
				select @SortValue = @SortValue + '0' + cast(@DigitCount as varchar) + @CurrentNumber
			else
				select @SortValue = @SortValue + cast(@DigitCount as varchar) + @CurrentNumber

			--==========================================================================================
			-- Reset for the next iteration
			--==========================================================================================
			select @DigitCount = 0
			select @CurrentNumber = ''
			select @LeadingZeroCount = 0
		end -- if (isnumeric(@Leftmost) = 1)

		--==========================================================================================
		-- The character we are currently working with is not a number, just tag it onto our return value
		--    Ignoring whitespace
		--==========================================================================================
		if (@Leftmost != ' ')
			select @SortValue = @SortValue + @Leftmost

		--==========================================================================================
		-- Trim off the character we just checked and continue the main loop
		--==========================================================================================
		select @WorkingItem = substring(@WorkingItem, 2, 50)

	end -- while (len(@WorkingItem) > 0)

	--==========================================================================================
	-- Finally, tag on the leading zero value and return our sort value
	--==========================================================================================
	select @SortValue = @SortValue +  ' ' + @LeadingZeroString

	return @SortValue
END
GO
/****** Object:  Table [dbo].[Trips]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trips](
	[trip_id] [nvarchar](250) NOT NULL,
	[vehicle] [nvarchar](50) NULL,
	[in_charge] [nvarchar](50) NULL,
	[expected_start] [datetime] NULL,
	[expected_end] [datetime] NULL,
	[actual_start] [datetime] NULL,
	[actual_end] [datetime] NULL,
	[cost] [money] NULL,
	[route] [nvarchar](50) NULL,
	[last_updated_on] [datetime] NULL,
 CONSTRAINT [PK_Trips] PRIMARY KEY CLUSTERED 
(
	[trip_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Trips] ([trip_id], [vehicle], [in_charge], [expected_start], [expected_end], [actual_start], [actual_end], [cost], [route], [last_updated_on]) VALUES (N'VGL-CEB1-TR-59', N'CDP09', N'jomer', CAST(0x0000AA1700000000 AS DateTime), CAST(0x0000AA1700000000 AS DateTime), NULL, NULL, NULL, N'AA', CAST(0x0000AA1600000000 AS DateTime))
INSERT [dbo].[Trips] ([trip_id], [vehicle], [in_charge], [expected_start], [expected_end], [actual_start], [actual_end], [cost], [route], [last_updated_on]) VALUES (N'VGL-CEB1-TR-60', N'CDP09', N'asd', CAST(0x0000AA1C00000000 AS DateTime), CAST(0x0000AA1C00000000 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Trips] ([trip_id], [vehicle], [in_charge], [expected_start], [expected_end], [actual_start], [actual_end], [cost], [route], [last_updated_on]) VALUES (N'VGL-CEB1-TR-61', N'CDP09', N'opaw', CAST(0x0000AA2700000000 AS DateTime), CAST(0x0000AA2700000000 AS DateTime), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Trips] ([trip_id], [vehicle], [in_charge], [expected_start], [expected_end], [actual_start], [actual_end], [cost], [route], [last_updated_on]) VALUES (N'VGL-CEB1-TR-62', N'CDT10', N'aw', CAST(0x0000AA2700000000 AS DateTime), CAST(0x0000AA2700000000 AS DateTime), NULL, NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[TripOrders]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripOrders](
	[trip] [nvarchar](250) NOT NULL,
	[order_id] [nvarchar](250) NOT NULL,
	[client] [nvarchar](250) NULL,
	[customer] [nvarchar](250) NULL,
	[customer_delivery_address] [nvarchar](250) NULL,
	[status] [nvarchar](250) NULL,
	[remarks] [nvarchar](250) NULL,
	[reference] [nvarchar](250) NULL,
	[reference_date] [datetime] NULL,
	[oms] [nvarchar](250) NULL,
	[doc_value] [money] NULL,
	[drop_sequence] [int] NULL,
 CONSTRAINT [PK_TripOrders] PRIMARY KEY CLUSTERED 
(
	[trip] ASC,
	[order_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TripOrders] ([trip], [order_id], [client], [customer], [customer_delivery_address], [status], [remarks], [reference], [reference_date], [oms], [doc_value], [drop_sequence]) VALUES (N'VGL-CEB1-TR-59', N'CEB1-INVOICE-1', N'COMARK', N'000006', NULL, N'FOR RECEIVING', NULL, N'1', CAST(0x0000AA1600000000 AS DateTime), N'COMARK', 0.0000, 1)
/****** Object:  Table [dbo].[TripOrderDetails]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripOrderDetails](
	[trip] [nvarchar](250) NOT NULL,
	[order_id] [nvarchar](250) NOT NULL,
	[product] [nvarchar](250) NOT NULL,
	[uom] [nvarchar](50) NOT NULL,
	[expected_qty] [int] NULL,
	[received_qty] [int] NULL,
	[delivered_qty] [int] NULL,
	[returned_qty] [int] NULL,
	[undelivered_qty] [int] NULL,
 CONSTRAINT [PK_TripOrderDetails] PRIMARY KEY CLUSTERED 
(
	[trip] ASC,
	[order_id] ASC,
	[product] ASC,
	[uom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TripOrderDetailDetails]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TripOrderDetailDetails](
	[trip] [nvarchar](250) NOT NULL,
	[order_id] [nvarchar](250) NOT NULL,
	[product] [nvarchar](250) NOT NULL,
	[uom] [nvarchar](50) NOT NULL,
	[lot_no] [nvarchar](50) NOT NULL,
	[expiry] [datetime] NOT NULL,
	[expected_qty] [int] NULL,
	[received_qty] [int] NULL,
	[delivered_qty] [int] NULL,
	[returned_qty] [int] NULL,
	[undelivered_qty] [int] NULL,
 CONSTRAINT [PK_TripOrderDetailDetails] PRIMARY KEY CLUSTERED 
(
	[trip] ASC,
	[order_id] ASC,
	[product] ASC,
	[uom] ASC,
	[lot_no] ASC,
	[expiry] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TMenu]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TMenu](
	[menu_id] [nvarchar](50) NOT NULL,
	[menu_current] [int] NULL,
 CONSTRAINT [PK_TMenu] PRIMARY KEY CLUSTERED 
(
	[menu_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TMenu] ([menu_id], [menu_current]) VALUES (N'TR', 63)
/****** Object:  Table [dbo].[OrderDeliveryStatuses]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDeliveryStatuses](
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_OrderDeliveryStatuses] PRIMARY KEY CLUSTERED 
(
	[status] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[OrderDeliveryStatuses] ([status]) VALUES (N'CANCELLED')
INSERT [dbo].[OrderDeliveryStatuses] ([status]) VALUES (N'DELIVERED')
INSERT [dbo].[OrderDeliveryStatuses] ([status]) VALUES (N'DELIVERED WITH CUT ITEMS')
/****** Object:  Table [dbo].[Customers]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[customer_id] [nvarchar](250) NOT NULL,
	[route] [nvarchar](250) NULL,
	[name] [nvarchar](250) NULL,
	[address] [nvarchar](250) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000006', NULL, N'GAISANO -SAN CARLOS', N'SAN CARLOS CITY, NEGROS')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000051', NULL, N'WATSON PERSONAL CARE STOR', N'RECLAMATION AREA CEBU C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000067', N'AA', N'AVF PHARMACY', N'51 COLON ST.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000243', NULL, N'SUPERVALUE INC.-ELIZABETH', N'P.DEL ROSARIO COR. L.KILAT ST.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000294', NULL, N'BASIC COMFORT DIST.', N'HVG ARCADE,SUBANGDAKU,MANDAUE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000494', NULL, N'GOOD LUCK MARKETING', N'BLK 2 LOT 6 CAIBAAN TACLOBAN')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000538', NULL, N'ALTURA''S SUPERMARKET', N'B. INTING ST., TAG.,BOHOL')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000539', NULL, N'ISLAND CITY MALL', N'DAO, TAGBILARAN CITY, BOHOL')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000540', NULL, N'METRO AYALA-INFANTS', N'AYALA BUSINESS CENTER,C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000541', NULL, N'SUPER METRO-INFANTS', N'HIGHWAY, MANDAUE CITY, CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000556', NULL, N'GAISANO MAIN-INFANTS', N'COLON ST., CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000557', NULL, N'GAISANO MAIN-COSMETICS', N'COLON ST., CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000558', NULL, N'G.COUNTRYMALL- INFANTS', N'BANILAD,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000559', NULL, N'G.COUNTRYMALL -COSMETICS', N'BANILAD,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000563', NULL, N'WHITE GOLD INC.-INFANTS', N'NORTH RECLAMATION AREA,C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000566', NULL, N'ROSE PHARMACY-MANDAUE', N'MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000568', NULL, N'GAISANO ORMOC- INFANTS', N'ORMOC CITY, LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000569', N'AA', N'FOODA SAVERS-GUADALUPE', N'BRGY. GUADALUPE, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000570', NULL, N'ROSE PHARMACY-COLON', N'COLON ST. , CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000610', NULL, N'ALISTO SMART', N'311 JONES AVE., CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000612', NULL, N'SASK306 CONV. STORE', N'588 WIRELESS, MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000816', NULL, N'BOTICA DE ALAS', N'LAPU LAPU CITY PUBLIC MARKET')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000817', NULL, N'ARISE & SHINE PHARMACY', N'PANGANIBAN ST., CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000818', NULL, N'MANDAUE CEBU TRADE CENTER', N'ELIZABETH BLDG.557,SUBANGDAKU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000819', NULL, N'PAULINO PHARMACY', N'195 V.GULLAS ST.,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000823', NULL, N'FARMACIA DUYONGCO', N'JUANA OSMEÑA ST., CAPITOL SITE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000824', NULL, N'JEMAN PHARMACY', N'137 GEN. MAXILOM AVE. EXT.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000825', NULL, N'WILLIAMS MARKETING', N'EDISON ST., LAHUG,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000826', NULL, N'C24 FOODMART', N'JUAN LUNA AVE.,MABOLO, C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000827', NULL, N'SMART MED PHARMACY', N'102 G.E. BLDG.,T.PADILLA')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000829', NULL, N'Q&H PHARMACY', N'HI-WAY MAMBALING,COR. TABADA')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000830', NULL, N'GINN PHARMACY', N'BASAK ,LAPU LAPU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000831', NULL, N'LAO MERCHANDISING', N'98 VILLAGONZALO ST.,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'000832', NULL, N'RAINBOW LA FARMACIAS', N'194-N.BACALSO AVE,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001041', NULL, N'BJB MARKETING', N'PULANG TUBIG, DUMAGUETE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001084', NULL, N'JARJAC MARKETING', N'A.S. FORTUNA ST., MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001162', NULL, N'HARDWARE WORKSHOP', N'NORTH RECLAMATION AREA, CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001219', NULL, N'FOODA HYPERMART', N'POBLACION, CONSOLACION')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001296', NULL, N'TACLOBAN HI-WAY MARKETING', N'IMELDA COR. PATERNO, TACLOBAN')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001302', NULL, N'CANG''S INCORPORATED', N'102 PERDICES ST. DUMAGUETE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001497', NULL, N'GAISANO DANAO DEPT. STORE', N'DANAO CITY, CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001498', NULL, N'CHILDREN''S PLACE', N'P. ZAMORA ST., TACLOBAN CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001522', NULL, N'BABY & SHOOPE', N'COR. ALLEN & R. GARCES ST.,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001525', NULL, N'868 CEBU SUPERMARKET', N'MANGO SQUARE GORODO AVE.,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001526', NULL, N'SNACPAC CORPORATION', N'SHEMBERGE COMP. RIZAL ST.,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001527', NULL, N'JET PHAR. & CONV. STORE', N'P. BURGOS ST. ORMOC CITY LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001528', NULL, N'UYMATIAO TRADING CORP.', N'GOV. M. PERDICES ST.,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001561', NULL, N'CY''S DEPTARTMET STORE', N'PUB. MARKET, UBAY, BOHOL')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001564', NULL, N'DGTE. FORTUNE MART, INC.', N'410 GOV. M. PERDICES ST.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001927', NULL, N'GAISANO GRAND MACTAN', N'BASAK, LAPU-LAPU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001988', NULL, N'GAISANO GRAND TOLEDO S/M', N'BRGY. SANGI, TOLEDO CITY, CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'001997', NULL, N'GAISANO CAPITAL RIVERSIDE', N'RIVERSIDE, ORMOC CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'002037', NULL, N'GAISANO MINGLANILLA', N'POB. MINGLANILLA, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'002335', NULL, N'GAISANO CENTRAL SM', N'JUSTICE ROMUALDEX ST.,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'004049', NULL, N'GAISANO CAPITAL SOGOD', N'ZONE V. SOGOD SOUTHERN LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'00561', NULL, N'GAISANO TACLOBAN INFANTS', N'TACLOBAN, LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'00562', NULL, N'GAISANO TACLOBAN-COSMETIC', N'TACLOBAN, LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'006372', NULL, N'JUVI''S MARKETING', N'BORROMEO ST. CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'006885', NULL, N'MAHLEN PHARMACY', N'1091 M.J CUENCO')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'007995', NULL, N'MESHE''S CONVENIENCE STORE', N'OSMEÑA ST. SOGOD LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008000', NULL, N'JM POULTRY & LIVESTOCK SUPPLY INC.', N'2ND FLR. ADM BLDG NORTH ROAD')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008003', NULL, N'FOODA SAVERS-KASAMBAGAN', N'F. CABAHUG ST. KASAMBAGAN,CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008004', NULL, N'GAISANO CAPITAL BASAK', N'BASAK, LAPU-LAPU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008005', NULL, N'GAISANO CASUNTINGAN', N'CASUNTINGAN, MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008006', NULL, N'GAISANO CAPITAL SRP', N'LARAY SN.ROQUE CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008039', NULL, N'GAISANO CAPITAL BANAWA', N'M.E PAVILLION CONDO, BANAWA')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008476', NULL, N'GAISANO MET-PHARMA-COLON', N'COLON ST.CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008799', NULL, N'AISON BAKERY & GROCERY', N'ORMOC CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008805', NULL, N'ROSE PHARMACY-TACLOBAN', N'ROVIC BLDG COR. DEL PILAR')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008806', NULL, N'ROSE PHARMACY-ZAMORA', N'35 P.ZAMORA ST.TACLOBAN')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008807', NULL, N'ROSE PHARMACY-SALAZAR', N'ZAMORA CORNER SALAZAR ST.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008808', NULL, N'ROSE PHARMACY-MAASIN', N'GARCES ST. MAASIN LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008809', NULL, N'ROSE PHARMACY-VETERANOS G', N'GF CYC BLDG. #166 AVENIDA')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008810', NULL, N'ROSE PHARMACY-TUNGATUNGA', N'TOMAS OPPUS ST. TUNGATUNGA')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008823', NULL, N'NESSOR''S ENTERPRISES', N'VICHAR CMPD. TABUC-TUBIG')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'008887', NULL, N'GAISANO BALAMBAN', N'BALAMBAN CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'009005', NULL, N'GAISANO GRAND MANDAUE', N'CENTRO MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'009016', NULL, N'SHOPWISE - BASAK', N'BASAK SAN NICOLAS, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'009042', NULL, N'FOODA SAVERS - TALISAY', N'TALISAY CITY CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'009098', NULL, N'COLONNADE - MANDAUE', N'CENTRO MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'009099', NULL, N'GAISANO GRAND TALAMBAN', N'TALAMBAN CITY, CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'012075', NULL, N'GAISANO MET-INFANTS-COLON', N'COLON STREET,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016334', NULL, N'NEGROS UNION DRUG,INC.', N'CERIACO -ESPINA STREET,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016357', NULL, N'PLAZA MARCELA', N'B-INTING ST.,TAG ,BOHOL')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016386', NULL, N'A.H.SHOPPERS MART.,INC.', N'TORALBU ST.,TAG.,BOHOL')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016483', NULL, N'CEBU RONEL MARKETING', N'273-1 MANLILI,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016500', NULL, N'CHING PHARMACY', N'MAGALLANES ST.,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016574', NULL, N'GAISANO MAIN-GROCERY', N'COLON STREET,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016580', NULL, N'GAZINI PLAZA-COLON  S/M', N'101 COLON STREET,CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016620', NULL, N'LAO ENG CHANG SONS & CO.', N'PLARIDEL ST, MABOLO, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016636', NULL, N'MABUHAY(JOL''S) PHARMACY', N'MANALILI ST. CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016642', NULL, N'MAJESTY PHARMACY', N'MAGALLANES ST.CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016688', NULL, N'QUEEN''S PHARMACY-CEBU', N'BORROMEO ST/LEON KILAT')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016698', NULL, N'ROSE PHARMACY INC.-OSMEÑA', N'COR.BACAYO/E.OSMENA ST.,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016733', NULL, N'ROZ LABORATORIES', N'1137-G ANDRES ABELLANA ST')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016779', NULL, N'WHITE GOLD CLUB-GROCERY', N'GENERAL MAXILOM AVENUE,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'016830', NULL, N'CONSUELO SUPERMARKET', N'#79 LUZURIAGA ST. 6100')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'017180', NULL, N'BEN HUA TRADING', N'63 RIZAL AVE. TAC. CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'017229', NULL, N'EVERWELL DRUGHOUSE', N'RIZAL AVE., TACLOBAN CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'017310', NULL, N'SAMS TRADING & DRUGHOUSE', N'SALAZAR ST, TACLOBAN CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'017491', NULL, N'L.G.C.(CEBU LEE MRKTG)', N'45 M.C. BRIONES ST.CC')
GO
print 'Processed 100 total records'
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'019618', NULL, N'ALAN COMMERCIAL', N'#40 IZNART ST. 5000 ILO²')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'019812', NULL, N'QUALITY DRUG', N'COR KATIPUNA, A LOPEZ ST.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'020657', NULL, N'BOHOL QUALITY CORP.-BOHOL', N'C.P.G AVE.TAG ,BOHOL')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'027261', NULL, N'BEROVAN MARKETING-CEBU', N'16E OSMENA ST, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'038883', NULL, N'GAISANO METRO-GROC-COLON', N'COLON STREET,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'039139', NULL, N'PLAZA FAIR MEN''S ACC.', N'191 JUAN LUNA ST.CC')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'042048', NULL, N'YAMPOY PHARMACY', N'LAPU LAPU PUBLIC MARKET')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'042670', NULL, N'GAISANO SOUTH-COLON S/M', N'COLON STREET, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'044710', NULL, N'LUZ PHARMACY', N'TOMAS OPPUS ST., TUNGA-TUNGA,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'044755', NULL, N'LA NUEVA SUPERMARKET', N'66-70 F.MAGALLANES ST,CC')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'045747', NULL, N'GAISANO TACLOBAN', N'TACLOBAN CITY, LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'045912', NULL, N'DBS MARKETING CORP.', N'PROGRESO ST.CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'046602', NULL, N'GAISANO-TABUNOK   S/M', N'TABUNOK, TALISAY CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'046745', NULL, N'LEE SUPER PLAZA -DGTE', N'DUMAGUETE CITY, NEGROS ORR.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'047191', NULL, N'PLAZA FAIR-OSMENA BLVD', N'OSMENA BLVD,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'048119', NULL, N'TACLOBAN TAP COMMERCIAL', N'26-28 P. GOMEZ STREET')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'049551', NULL, N'ROBINSON''S SUPERMARKET', N'FUENTE OSMEÑA BLVD, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'049950', NULL, N'D''MELLE ENTERPRISES', N'112-114 OSMENA BLVD.,CC')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'050315', NULL, N'JY SQUARE SUPERMARKET,INC', N'#7 SALINAS DRIVE,LAHUG')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'050464', NULL, N'RUSTAN''S SUPERMARKET', N'ARCENAS ESTATE, BANAWA, CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'052636', NULL, N'JARLYN MARKETING', N'CERIACO -ESPINA ST.,DGTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'056434', NULL, N'PRINCE WAREHOUSE CLUB,INC', N'RECLAMATION AREA,CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'056810', NULL, N'SANTRADE MARKETING INC.', N'25-1 SASON ROAD,LAHUG')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'057735', NULL, N'MANDAUE SUPERMARKET', N'HI-WAY,MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'061265', NULL, N'ALTURA''S DEPT. STORE-TAG', N'B.INTING ST.,BOHOL')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'062445', NULL, N'G.COUNTRY MALL-GROCERY', N'BANILAD ,STREET,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'063317', NULL, N'PRINCE WAREHOUSE MANDAUE', N'A.CORTES AVENUE,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'064321', NULL, N'ALTURA''S PHARMACY   -TAG', N'B. INTING ST.,TAG. BOHOL')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'064441', NULL, N'PACIFICA AGRIVET SUPPLIES', N'AS FORTUNA ST.,MAND.CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'064737', NULL, N'SM/SHOEMART SUPERMARKET', N'RECLAMATION AREA,C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'064892', NULL, N'ACE HARDWARE.INC.', N'RECLAMATION AREA,C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'065917', NULL, N'LA NUEVA SUPERMART (GON.)', N'F.GONZALES ST. C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'068382', NULL, N'R & R  PHARMACY', N'MANDAUE CITY, CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'069157', NULL, N'GAISANO -SUPER METRO MAND', N'MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'069562', NULL, N'GAISANO-MACTAN   S/M', N'MACTAN, LAPULAPU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'069870', NULL, N'AMADO LAO', N'C/O VGL INDUSTRIES')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'0702043', NULL, N'CEBU LEEKIM COMMERCIAL', N'93 LINCOLN ST.CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'070310', NULL, N'GAISANO METRO-AYALA  S/M', N'AYALA BUSINESS CENTER,')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'071165', NULL, N'HAM TAT TRADING', N'60 LINCOLN ST.CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'073041', NULL, N'ROBINSON''S DEPT.STORE-', N'FUENTE OSMENA BLVD,CC')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'073126', NULL, N'SM/SHOEMART DEPT.STORE', N'RECLAMATION AREA,C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'073149', NULL, N'CEBU CLEAN SERVICE', N'35 VICENTE URGELLO')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'077050', NULL, N'GAISANO ORMOC-GROCERY', N'ORMOC CITY, LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'077985', NULL, N'H & B , INC.', N'CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'078623', NULL, N'LEMA PHARMACEUTICAL', N'SUITE 201 MENCHAVEZ BLDG')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'081646', NULL, N'BLUEBELLS MARKETING', N'NORTH CENTRAL CABANCALAN')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'081983', NULL, N'COLONADE MALL/S MKT', N'82-89 COLON ST,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'082336', NULL, N'S L D I', N'TACLOBAN,LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'082365', NULL, N'F D S  MARKETING', N'DUMAGUETE CITY,NEG OR')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'082576', NULL, N'ARIES DISTRIBUTORS,INC.', N'CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'083882', NULL, N'VISION VL DISTRIBUTOR INC', N'TALISAY CITY, NEG. OCC.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'085188', NULL, N'ECONOQUICK MARKETING', N'TABUNOK TALISAY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'085496', NULL, N'MARYJOY PHARMACY', N'TABUNOK, TALISAY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'086231', NULL, N'S C M I', N'TIPOLO ,MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'088410', NULL, N'GIANCARLO GENERAL MDSE.', N'27 LINCOLN ST., CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'088575', NULL, N'ASIAN FOODS CORP.', N'MABOLO, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'089122', NULL, N'CPR MARKETING', N'85 BONIFACIO ST. AREVALO')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'089151', NULL, N'E G ENTERPRISES', N'DUERTE ROAD BANAWA, C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'089476', NULL, N'JAPER SUPERMART', N'POBLACION, LAPU-LAPU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'089499', NULL, N'GAISANO DANAO', N'DANAO CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090110', NULL, N'PRIME ADVANTAGE', N'32 WILSON ST. LAHUG C.C.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090171', NULL, N'BGT AGRIVET', N'ORMOC LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090174', NULL, N'GAISANO DUMANJUG', N'DUMANJUG CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090197', NULL, N'TACLOBAN GLOBALSOURCEMGKT', N'BRGY. 79 MARASBARAS')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090298', NULL, N'OPTION 24', N'SUBANGDAKO MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090308', NULL, N'BREEDERS AGRIVET SUPPLIES', N'IFMI COMPLEX, HI-WAY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090328', NULL, N'GAISANO CORDOVA', N'CORDOVA LAPU-LAPU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090342', NULL, N'GAISANO ORMOC COSMETICS', N'ORMOC CITY LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090344', NULL, N'GAISANO RVERSIDE COSMETIC', N'ORMOC CITY LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090345', NULL, N'GAISANO TACLOBAN COSMETIC', N'TACLOBAN CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090346', NULL, N'GAISANO CENTRAL COSMETICS', N'TACLOBAN CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090347', NULL, N'GASANO SOGOD COSMETICS', N'SOGOD SOUTHERN LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090353', NULL, N'NEW KEENS TRADING', N'BANILAD CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090411', NULL, N'CEBU ATLANTIC HARDWARE', N'TABOAN ST., CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090470', NULL, N'DAILY CARE PHARMACY', N'F LIMAS ST PUNTA PRINCESA')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090542', NULL, N'GAISANO CAPITAL SOGOD D/S', N'POBLACION SOGOD')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090645', NULL, N'SUPERVALUE INC.,- MACTAN', N'MEPZ 1 BRGY EBO,LAPU-LAPU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090729', NULL, N'CFG QUICKSTOP INC.', N'IT PARK LAHUG CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090734', NULL, N'GAISANO G. MOALBOAL', N'POBLACION MOALBOAL CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090743', NULL, N'CEBU FAR EASTERN DRUG INC', N'103-105 HOLY CHILD BLDG RES.')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090776', NULL, N'PRINCE PARDO', N'PARDO CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090777', NULL, N'PRINCE TOLEDO', N'TOLEDO CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090778', NULL, N'PRINCE BOGO', N'BOGO CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090822', NULL, N'LIFEMART PHARMACY', N'CENTRO MANDAUE CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090876', NULL, N'LUCKY 7S/M (ONG KIN KING)', N'MAGALLANES ST. CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090923', NULL, N'SERVEWELL PHARMACY', N'ORMOC CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'090924', NULL, N'JOWELJAN MKTG. CORP.', N'103 POB. CONSOLACION')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091005', NULL, N'ROSE PHARMACY - ROVIC', N'ROVIC BLDG. TACLOBAN')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091006', NULL, N'ROSE PHARMACY - MARASBARAS', N'MARASBARAS TACLOBAN')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091035', NULL, N'LIFEMART', N'BASAK LAPU-LAPU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091096', NULL, N'SELUCIA DEV''T. CORP.', N'PRINCE ARGAO')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091097', NULL, N'PRINCE GUIUAN', N'WARD 4A GUIUAN EASTERN SAMAR')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091099', NULL, N'PRINCE ISABEL', N'ISABEL LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091100', NULL, N'PRINCE MAASIN', N'TUNGA-TUNGA MAASIN LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091102', NULL, N'PRINCIPALITY INC.', N'PRINCE DALAGUETE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091103', NULL, N'PRINCE ABUYOG', N'LOYONSAWANG ABUYOG LEYTE')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091104', NULL, N'PRINCE BAYBAY', N'BONIFACIO ST., ZONE 2 BAYBAY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091137', NULL, N'SELUCIA DEV''T. CORP', N'PRINCE DANAO')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091138', NULL, N'PRINCE NAVAL', N'INOCENTES ST., NAVAL BILIRAN')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091147', NULL, N'GAISANO BOGO', N'BOGO, CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091200', NULL, N'G. CAPITAL SAVERS (SOHO)', N'B. RODRIGUES ST., GUADALUPE')
GO
print 'Processed 200 total records'
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091280', NULL, N'FOODA SAVERS MART-MANGO', N'GENERAL MAXILOM AVE., CC')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'091581', NULL, N'GRAND NSL COMMERCIAL', N'MANALILI ST., CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'602', NULL, N'GAISANO SOUTH-CONCESSION', N'COLON ST.,CEBU CITY')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'604', NULL, N'GAISANO MACTAN-CONCESSION', N'LAPU LAPU CITY, CEBU')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'90315', NULL, N'MIKYU MART', N'BRGY MARASBARAS TACLOBAN')
INSERT [dbo].[Customers] ([customer_id], [route], [name], [address]) VALUES (N'C421', NULL, N'PLAZA MARCELA-BOHOL-CONCS', N'TAGBILARAN,BOHOL')
/****** Object:  UserDefinedFunction [dbo].[SF_FuncListToTableInt]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE FUNCTION [dbo].[SF_FuncListToTableInt](@list as varchar(8000), @delim as varchar(10))
RETURNS @listTable table(Value INT)
AS
BEGIN
    --Declare helper to identify the position of the delim
    DECLARE @DelimPosition INT
    
    --Prime the loop, with an initial check for the delim
    SET @DelimPosition = CHARINDEX(@delim, @list)

    --Loop through, until we no longer find the delimiter
    WHILE @DelimPosition > 0
    BEGIN
        --Add the item to the table
        INSERT INTO @listTable(Value)
            VALUES(CAST(RTRIM(LEFT(@list, @DelimPosition - 1)) AS INT))
    
        --Remove the entry from the List
        SET @list = right(@list, len(@list) - @DelimPosition)

        --Perform position comparison
        SET @DelimPosition = CHARINDEX(@delim, @list)
    END

    --If we still have an entry, add it to the list
    IF len(@list) > 0
        insert into @listTable(Value)
        values(CAST(RTRIM(@list) AS INT))

  RETURN
END
GO
/****** Object:  Table [dbo].[RouteSchedules]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteSchedules](
	[route] [nvarchar](50) NOT NULL,
	[date] [datetime] NOT NULL,
	[vehicle] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RouteSchedules_1] PRIMARY KEY CLUSTERED 
(
	[date] ASC,
	[vehicle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Routes]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Routes](
	[route_id] [nvarchar](50) NOT NULL,
	[route_code] [nvarchar](50) NULL,
 CONSTRAINT [PK_Routes] PRIMARY KEY CLUSTERED 
(
	[route_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Routes] ([route_id], [route_code]) VALUES (N'AA', N'AA')
INSERT [dbo].[Routes] ([route_id], [route_code]) VALUES (N'BB', N'BB')
INSERT [dbo].[Routes] ([route_id], [route_code]) VALUES (N'CC', N'CC')
INSERT [dbo].[Routes] ([route_id], [route_code]) VALUES (N'CITY', N'CITY')
/****** Object:  Table [dbo].[RouteDetails]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteDetails](
	[route] [nvarchar](50) NOT NULL,
	[delivery_address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RouteDetails] PRIMARY KEY CLUSTERED 
(
	[route] ASC,
	[delivery_address] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[product_id] [nvarchar](250) NOT NULL,
	[description] [nvarchar](500) NOT NULL,
	[description1] [nvarchar](500) NOT NULL,
	[description2] [nvarchar](500) NOT NULL,
	[pcs_per_case] [int] NOT NULL,
	[category] [nvarchar](500) NULL,
	[pc_barcode] [nvarchar](200) NULL,
	[case_barcode] [nvarchar](200) NULL,
	[default_owner] [nvarchar](50) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'01300080', N'ZIM ALL PURP DETERGENT32G', N'', N'ZIM ALL PURP DETERGENT32G', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'10050063', N'FARLIN FOLDING BATH TUB', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010001', N'FARLIN SIL.NIPPLE POUCH', N'', N'FARLIN SIL.NIPPLE POUCH', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010002', N'FARLIN SIL.NIPPLE POUCH', N'', N'FARLIN SIL.NIPPLE POUCH', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010003', N'FARLIN SIL.NIPPLE POUCH', N'', N'FARLIN SIL.NIPPLE POUCH', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010004', N'FARLIN RUBBER NIPPLE', N'', N'FARLIN RUBBER NIPPLE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010011', N'FARLIN SIL.NIPPLE POUCH', N'', N'FARLIN SIL.NIPPLE POUCH', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010012', N'FARLIN RUBBER NIPPLES', N'', N'FARLIN RUBBER NIPPLES', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010014', N'F SN STD X', N'', N'F SN STD X', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010016', N'45 F FNIPLE SILNIMP M 12S', N'45 F FNIPLE SILNIMP M 12S', N'45 F FNIPLE SILNIMP M 12S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010017', N'45 F FNIPLE SILNIMP S 12S', N'45 F FNIPLE SILNIMP S 12S', N'45 F FNIPLE SILNIMP S 12S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010018', N'45 F FNIPLESILNIMPXCUT12S', N'45 F FNIPLESILNIMPXCUT12S', N'45 F FNIPLESILNIMPXCUT12S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010027', N'FARLIN SILICON NIPPLE', N'', N'F SIL NIP POUCH MEDIUM', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010028', N'FARLIN SILICONE NIPPLE', N'', N'F SIL NIP POUCH LARGE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010029', N'FARLIN SILICON NIPPLE', N'', N'F SIL NIP POUCH SMALL', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010030', N'FARLIN SILICON NIPPLE', N'', N'F SIL NIP POUCH X-CUT', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010033', N'FARLIN SN BCARD SMALL 2''S', N'', N'F SIL NIP BCARD SMALL', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010034', N'FARLIN SN BCARD X-CUT 3''S', N'', N'F SIL NIP BCARD X-CUT', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010044', N'FARLIN FN DISPENSER', N'', N'FARLIN FN DISPENSER', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010051', N'FARLIN SN BCARD MED. 2''S', N'', N'F SIL NIP BCARD MEDIUM', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010052', N'FARLIN SN BCARD LARGE 2''S', N'', N'F SIL NIP BCARD LARGE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010055', N'F SN STD L', N'', N'F SN STD L', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010069', N'FARLN SIL.NIPPLE BC XCUT', N'', N'FARLN SIL.NIPPLE BC XCUT', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010070', N'F. SIL NIP. B.C. 3''S', N'', N'', 36, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010071', N'FARLN SIL.NIPPLE BC SMALL', N'', N'FARLN SIL.NIPPLE BC SMALL', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010073', N'FARLN SIL.NIPPLE BC MED', N'', N'FARLN SIL.NIPPLE BC MED', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010075', N'FARLN SIL.NIPPLE BC LARGE', N'', N'FARLN SIL.NIPPLE BC LARGE', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010077', N'FARLIN RUBBER NIPPLES', N'', N'', 600, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010078', N'F. SIL NIPPLE POUCH', N'', N'', 600, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010079', N'F. SIL NIPPLE POUCH', N'', N'', 600, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010080', N'F. SIL NIPPLE POUCH', N'', N'', 600, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010081', N'F. SIL NIPPLE POUCH', N'', N'', 600, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010082', N'F.FED N WIDE NECK BC 2''S', N'', N'F FN WIDE NECK BC', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010083', N'FARLIN FN WIDE NECK BC', N'', N'FARLIN FN WIDE NECK BC', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010103', N'FARLIN SN BCARD SMALL 3''S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010104', N'F. B.C. SIL NIP. 3''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010105', N'F. B.C. SIL NIP. 3''S', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010106', N'FARLIN SN BCARD MEDIUM 3S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010107', N'F. B.C. SIL. NIP. 3''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010108', N'F. B.C. SIL. NIP. 3''S', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010109', N'FARLIN SN BCARD LARGE 3''S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010110', N'F. B.C. SIL. NIP. 3''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010111', N'F. B.C. SIL. NIP. 3''S', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010117', N'F WIDENECK SN 2S BCARDSML', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010119', N'F WIDENECK SN 2S BCARDMED', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010121', N'F WIDENECK SN 2S BCARDLAR', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11010123', N'F WIDENECK SN 2S BCARD XC', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020020', N'F FB CLCL WHT RN 8OZ', N'', N'F FB CLCL WHT RN 8OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020036', N'45 F FB CLSCCLR 3PK755950', N'45 F FB CLSCCLR 3PK755950', N'45 F FB CLSCCLR 3PK755950', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020043', N'F SOFT SCOOP SIL. SPOON', N'', N'F SOFT SCOOP SIL. SPOON', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020055', N'F FB DECORATED COL 8OZ', N'', N'F FB DECORATED COL 8OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020059', N'F FB DECORATED COL 4 OZ', N'', N'F FB DECORATED COL 4 OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020063', N'F FB CLASIC CLEAR 4 OZ', N'', N'F FB CLASIC CLEAR 4 OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020064', N'F FB CLASIC CLEAR 8 OZ', N'', N'F FB CLASIC CLEAR 8 OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020065', N'F FB CRYSTAL CLEAR 4 OZ', N'', N'F FB CRYSTAL CLEAR 4 OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020067', N'F FB CRYSTAL CLEAR 8 OZ', N'', N'F FB CRYSTAL CLEAR 8 OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020069', N'F FB DEC. GSET 3PK 8OZ', N'', N'F FB DEC. GSET 3PK 8OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020070', N'F FB 6PK GIFT SET', N'', N'F FB 6PK GIFT SET', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020071', N'F FB GIFT SET', N'', N'F FB GIFT SET', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020072', N'F FB CLASIC 3PK GSET 8 OZ', N'', N'F FB CLASIC 3PK GSET 8 OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020091', N'F FB RBABY SN 4OZ', N'', N'F FB RBABY SN 4OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020095', N'F FB TSTAR SN 4OZ', N'', N'F FB TSTAR SN 4OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020109', N'F FB ROW LBLU SN 8OZ', N'', N'F FB ROW LBLU SN 8OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020152', N'F HDUCK YLW SN 8OZ', N'', N'F HDUCK YLW SN 8OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020199', N'FARLIN FB LITTLE T POT', N'', N'FARLIN FB LITTLE T POT', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020218', N'F FB WWINKIE SN 4OZ', N'', N'F FB WWINKIE SN 4OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020236', N'F FB CLSC CLR 3PK W/RN', N'', N'F FB CLSC CLR 3PK W/RN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020280', N'F NGAME RN 4OZ', N'', N'F NGAME RN 4OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020322', N'F FLTR LBLU RN 4OZ', N'', N'F FLTR LBLU RN 4OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020338', N'F FB DECORATED COLLCTION', N'', N'F FB DECORATED COLLCTION', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020343', N'F FB DECORATED COLLCTION', N'', N'F FB DECORATED COLLCTION', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020349', N'FARLIN CLASSIC CLEAR W/SN', N'', N'FARLIN CLASSIC CLEAR W/SN', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020351', N'FARLIN CLASSIC CLEAR W/SN', N'', N'FARLIN CLASSIC CLEAR W/SN', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020352', N'F CLSC CLR GSET 3PK X 4''S', N'', N'F CLSC CLR GSET 3PK X 4''S', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020353', N'FARLIN CRYSTAL CLEAR W/SN', N'', N'FARLIN CRYSTAL CLEAR W/SN', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020354', N'FARLIN CRYSTAL CLEAR W/SN', N'', N'FARLIN CRYSTAL CLEAR W/SN', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020356', N'F FB DECO. GSET 3PK X 4''S', N'', N'F FB DECO. GSET 3PK X 4''S', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020358', N'F FB GIFT SET 4''S', N'', N'F FB GIFT SET 4''S', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020360', N'F 6PK FB DEC GIFT SET 4''S', N'', N'F 6PK FB DEC GIFT SET 4''S', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020372', N'45 F FB DECO SNGLSX3S', N'45 F FB DECO SNGLSX3S', N'45 F FB DECO SNGLSX3S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020390', N'F.DECORATED COLLECTION FB', N'', N'F DECORATED COLL.FB 4 OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020391', N'F.DECORATED COLLECTION FB', N'', N'F DECORATED COLL. FB 8OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020392', N'FARLIN CLASSIC CLEAR COL.', N'', N'F CLASSIC CLEAR 4 OZ FB', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020393', N'FARLIN CLASSIC CLEAR COL.', N'', N'F CLASSIC CLEAR 8OZ FB', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020394', N'FARLIN CRYSTAL CLEAR COLL', N'', N'F CRYSTAL CLR 4 OZ FB', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020395', N'FARLIN CRYSTAL CLEAR COLL', N'', N'F CRYSTAL CLR 8 OZ FB', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020396', N'FARLIN CLSC CLR GSET 8 OZ', N'', N'F CLSC CLR GSET 3PK 4''S', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020397', N'FARLIN DECO.COL.G-SET 8OZ', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020398', N'6-PK FB DECO.GIFT SET 8OZ', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020400', N'FARLIN FB WIDENECK COLL.', N'', N'F FB WIDENECK COLLN 9OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020401', N'F FB WIDE NECK COL.9OZ', N'', N'F FB WIDE NECK COL.9OZ', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020402', N'F FBWIDE NECK COLLN 5OZ', N'', N'F FBWIDE NECK COLLN 5OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020403', N'F FB WIDE NECK COLLN 5OZ', N'', N'F FB WIDE NECK COLLN 5OZ', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020404', N'FARLIN FB TINTED COLLTION', N'', N'F FB TINTED COLL 8OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020405', N'F FB TINTED COLL. 8OZ', N'', N'F FB TINTED COLL. 8OZ', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020406', N'FARLIN FB TINTED COLLTION', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020407', N'F FB TINTED COLL. 4OZ', N'', N'F FB TINTED COLL. 4OZ', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020408', N'FARLIN FB TINTED COLL.', N'', N'F FB TINTED COLL 2OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020409', N'F FB TINTED COLLN 2OZ.', N'', N'F FB TINTED COLLN 2OZ.', 24, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020413', N'45 F FB DECO W/SN 4OZX 3S', N'45 F FB DECO W/SN 4OZX 3S', N'45 F FB DECO W/SN 4OZX 3S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020416', N'45 F FB DECO 6-PKW/SN 8OZ', N'45 F FB DECO 6-PKW/SN 8OZ', N'45 F FB DECO 6-PKW/SN 8OZ', 12, N'FARLIN', N'', N'', N'COMARK')
GO
print 'Processed 100 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020417', N'45 F FB WIDE NECK W/SN9OZ', N'45 F FB WIDE NECK W/SN9OZ', N'45 F FB WIDE NECK W/SN9OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020418', N'45 F FB WIDE NECK W/SN5OZ', N'45 F FB WIDE NECK W/SN5OZ', N'45 F FB WIDE NECK W/SN5OZ', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020429', N'FARLIN EDUCATION COLL.', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020430', N'FARLIN EDUCATION COLL.', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020431', N'FRLN EDUCATION COLLECTION', N'', N'FRLN EDUCATION COLLECTION', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020432', N'FRLN EDUCATION COLLECTION', N'', N'FRLN EDUCATION COLLECTION', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020439', N'FARLIN FB NOVELTY COLL.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020440', N'FARLIN FB NOVELTY COL 5OZ', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020441', N'FARLIN FB NOVELTY COLL.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020442', N'FARLIN FB NOVELTY COLL', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020443', N'F.FB WHEN I GROW UP COLL.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020444', N'FRLN FB WHN I GRW UP COLL', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020445', N'F.FB WHEN I GROW UP COLL.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020446', N'FRLN FB WHN I GRW UP COLL', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020464', N'FARLIN FB BOTTLE GIFT SET', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020468', N'FARLIN SILICONE BOTTLE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020469', N'FARLIN SILICONE BOTTLE', N'', N'', 6, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020470', N'FARLIN SILICONE BOTTLE', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020474', N'FARLIN PP WIDE NECK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020476', N'FARLIN FB PP CLSC CLR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020478', N'FARLIN FB PP CLSC CLR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020480', N'FARLIN FB PP CLSC CLR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020482', N'FARLIN FB PP CLSC CLR 3PK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020484', N'FARLIN FB PP CLSC CLR 3PK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020486', N'FARLIN PP DECO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020488', N'FARLIN PP DECO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020490', N'FARLIN PP DECO 3PK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020492', N'FARLIN PP EDUC', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020494', N'FARLIN PP EDUC', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020496', N'FARLIN PP TINTED', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020498', N'FARLIN PP TINTED', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020500', N'FARLIN PP TINTED', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020502', N'FARLIN PP WIDE NECK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020504', N'FARLIN PP 6PK FB GIFT SET', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020506', N'FARLIN PP FB GIFT SET', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020508', N'FARLIN FB WIDE NECK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020509', N'F. PP CRSTAL CLEAR 4OZ', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020510', N'F. PP CRYSTAL CLEAR 8OZ', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020511', N'F PP FB GIFT SET 4/CS', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020519', N'F. WN TINTED COLL. PP', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11020522', N'F. WN TINTED COLL. PP', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030005', N'F TCUP RAIN PNK', N'', N'F TCUP RAIN PNK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030008', N'F TCUP BLU 6S', N'', N'F TCUP BLU 6S', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030009', N'F TCUP PNK 6S', N'', N'F TCUP PNK 6S', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030010', N'F TCUP SYS MSTAGE 6S', N'', N'F TCUP SYS MSTAGE 6S', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030011', N'F CLEAR TRAINING CUP PINK', N'', N'F CLEAR TRAINING CUP PINK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030012', N'F TRAINING CUP CLEAR PINK', N'', N'F TRAINING CUP CLEAR PINK', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030013', N'F CLEAR TRAINING CUP BLUE', N'', N'F CLEAR TRAINING CUP BLUE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030014', N'F TRAINING CUP CLEAR BLUE', N'', N'F TRAINING CUP CLEAR BLUE', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030015', N'F MULTISTAGE TRAINING CUP', N'', N'F MULTISTAGE TRAINING CUP', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030026', N'F TRAINING CUP MSTAGE 6''S', N'', N'F TRAINING CUP MSTAGE 6''S', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030027', N'F SPILL PROOF CUP PINK', N'', N'F SPILL PROOF CUP PINK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030028', N'F SPILL PROOF CUP PINK', N'', N'F SPILL PROOF CUP PINK', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030029', N'F SPILL PROOF CUP BLUE', N'', N'F SPILL PROOF CUP BLUE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030030', N'F SPILL PROOF CUP BLUE', N'', N'F SPILL PROOF CUP BLUE', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030031', N'F SPILL PROOF CUP M GREEN', N'', N'F SPILL PROOF CUP M GREEN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030032', N'F SPILL PROOF CUP M GREEN', N'', N'F SPILL PROOF CUP M GREEN', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030035', N'FARLIN SOFT SCOOP SILICON', N'', N'F SOFT SCOOP SIL SPOON', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030037', N'F S GRIP FORK&SPOON PINK', N'', N'F S GRIP FORK&SPOON PINK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030039', N'F S GRIP FORK&SPOON BLUE', N'', N'F S GRIP FORK&SPOON BLUE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030041', N'F S GRIP FORK&SPOON MGRN', N'', N'F S GRIP FORK&SPOON MGRN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030043', N'SOFT SCOOP SILICONE SPOON', N'', N'FARLIN SPOON SOFT SCOOP', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030044', N'F SPOON&FORK S GRIP PINK', N'', N'F SPOON&FORK S GRIP PINK', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030045', N'F SPOON&FORK S GRIP BLUE', N'', N'F SPOON&FORK S GRIP BLUE', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030046', N'F SPOON&FORK S GRIP MGRN', N'', N'F SPOON&FORK S GRIP MGRN', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030059', N'F TRAINING CUP CLEAR PINK', N'', N'F TRAINING CUP CLEAR PINK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030060', N'F TRAINING CUP CLEAR BLUE', N'', N'F TRAINING CUP CLEAR BLUE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030061', N'F. MULTI-STAGE TRAINING', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030065', N'F.SOFT GRIP FORK&SPN PINK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030066', N'F.SOFT GRIP FORK&SPN BLUE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030067', N'F.SOFTGRIP FORK&SPN GREEN', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030087', N'F. SOFT SCOOP SIL. SPOON', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030088', N'SOFT SCOOP SIL. SPOON', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030089', N'SOFT SCOOP SIL. SPOON', N'', N'', 72, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030091', N'F. PP TRAINING CUP PINK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030094', N'FARLIN PP MULTI-STAGE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030097', N'F. PP TRAINING CUP BLUE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030099', N'FARLIN PP BOWL SET', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030100', N'FARLIN PP BOWL SET.', N'', N'', 6, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030101', N'FARLIN PP BOWL SET', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030102', N'FARLIN PP PLATE SET', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030103', N'FARLIN PP PLATE SET', N'', N'', 6, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030104', N'FARLIN PP PLATE SET', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030105', N'F. PP TRNG CUP PINK', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030107', N'FARLIN TRAINING CUP BLUE', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030109', N'F NEWBORN FEEDING STARTER', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030110', N'F NEWBORN FEEDING STARTER', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030111', N'F. FEEDING PP PLATE SET', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11030113', N'F. FEEDING PP PLATE SET', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11040003', N'F MILK POWDER CONTAINER', N'', N'F MILK POWDER CONT 4LAYER', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11040009', N'F MILK POWDER CONTAINER', N'', N'F MILK POWDER CONTAINER', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11040010', N'F. 4 L. MILK POWDER CONT.', N'', N'', 24, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11040011', N'F MILK PWDR CONT.3SECTION', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11040012', N'F MILK PWDR CONT.3SECTION', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11040013', N'F. M. PWDER CONT. 4LAYER', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11040015', N'F. M. PWDER CONT. 4LAYER', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050002', N'F BANK GIFT SET BLU', N'', N'F BANK GIFT SET BLU', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050013', N'F STERILIZER SET W/ BOTLE', N'', N'FARLIN STERILIZER SET', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050014', N'F BANK BLU M', N'', N'F BANK BLU M', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050015', N'F BANK MTGRN', N'', N'F BANK MTGRN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050016', N'F BANK PNK M', N'', N'F BANK PNK M', 1, N'FARLIN', N'', N'', N'COMARK')
GO
print 'Processed 200 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050019', N'FARLIN RACK & TONG SET', N'', N'F ROCK & TONG SET', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050020', N'F BANK BABY MTGRN L', N'', N'F BANK BABY MTGRN L', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050021', N'FARLIN TONGS', N'', N'FARLIN TONGS', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050025', N'45 F STRILIZER SET+7FB RN', N'45 F STRILIZER SET+7FB RN', N'45 F STRILIZER SET+7FB RN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050026', N'F RACKTONG SET/CS', N'', N'F RACKTONG SET/CS', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050027', N'FARLIN TONG 12', N'', N'FARLIN TONG 12', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050028', N'FARLIN TONGS', N'', N'', 48, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050029', N'F STERILIZER W/O BOTTLES', N'', N'F STERILIZER W/O CNTNTS', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050032', N'45 F STERILIZER W/7FB(SN)', N'45 F STERILIZER W/7FB(SN)', N'45 F STERILIZER W/7FB(SN)', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050034', N'FARLIN SNAP-OFF HOOD', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050035', N'FARLIN SNAP-OFF HOOD', N'', N'FARLIN SNAP-OFF HOOD', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050036', N'F.CAPRING & SNAP-OFF HOOD', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050037', N'F CAPRING & SNAP-OFF HOOD', N'', N'FCAPRING&SNPOF HOOD12/CS', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050038', N'F STERILIZER SET', N'', N'F STERILIZER SET', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050039', N'F STERILISER W/O BOTTLES', N'', N'F STERILISER W/O BOTTLES', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050041', N'F. ELEC. STEAM STERILIZER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050048', N'FARLIN NIPPLE & BOT.BRUSH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050051', N'F. CAPRING SNAPHOOD PREM.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050052', N'F. NIPPLE BRUSH PREMIUM', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050053', N'F. NIP. & BOT. BRUSH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050054', N'F. NIP. & BOTTLE BRUSH', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050055', N'F. NIP. & BOTTLE BRUSH', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050056', N'FARLIN STEAM STERILIZER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050057', N'FARLIN PP BOT.&NIP. BRUSH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050058', N'FARLIN PP BOT.&NIP. BRUSH', N'', N'', 6, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050059', N'FARLIN PP BOT.&NIP. BRUSH', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050060', N'FARLIN ASPRTOR 12/CS', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050063', N'FARLIN FOLDING BATH TAB', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050064', N'F.6-BTL STEAM STERILIZER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050065', N'F.STEAM STERILIZER 6BOT', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050066', N'F. MICROWAVE STERILIZER', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11050403', N'F.BOTTLE BANK-LARGE-PINK', N'', N'F.BOTTLE BANK-LARGE-PINK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110001', N'F PURE&SOFT PACFR 12''S', N'', N'F PURE&SOFT PACFR 12''S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110003', N'F RPACIFIER SOFT', N'', N'F RPACIFIER SOFT', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110004', N'FARLIN ORTHO RUBBER PACIF', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110005', N'F PACIFIER W/COVER PINK', N'', N'F PACIFIER W/COVER PINK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110006', N'F PACIFIER W/COVER PINK', N'', N'F PACIFIER W/COVER PINK', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110007', N'F PACIFIER W/COVER BLUE', N'', N'F PACIFIER W/COVER BLUE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110008', N'F SPACIFIER P&SOFT O', N'', N'F SPACIFIER P&SOFT O', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110012', N'F PACIFIER W/COVER RED 1S', N'', N'F PACIFIER W/COVER RED 1S', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110014', N'F PACIFIER W/CVR RED12''S', N'', N'F PACIFIER W/CVR RED12''S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110016', N'F PACFR W/CVR BLU 12''S', N'', N'F PACFR W/CVR BLU 12''S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110018', N'F PACFR W/CVR  GRN 12''S', N'', N'F PACFR W/CVR  GRN 12''S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110020', N'F PACFR W/CVR YLW 12''S', N'', N'F PACFR W/CVR YLW 12''S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110022', N'F PACIFIER W/COVER BLUE', N'', N'F PACIFIER W/COVER BLUE', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110023', N'F PACIFIER W/COVER YELLOW', N'', N'F PACIFIER W/COVER YELLOW', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110024', N'F PACIFIER W/COVER YELLOW', N'', N'F PACIFIER W/COVER YELLOW', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110025', N'F PACIFIER W/COVER MGREEN', N'', N'F PACIFIER W/COVER MGREEN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110026', N'F PACIFIER W/COVER GREEN', N'', N'F PACIFIER W/COVER GREEN', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110027', N'F PURE&SOFT SIL PACIFIER', N'', N'F PURE&SOFT SIL PACIFIER', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110028', N'F PACIFIER SIL PURE&SOFT', N'', N'F PACIFIER SIL PURE&SOFT', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110029', N'F CLEAR SILICON PACIFIER', N'', N'F CLEAR SILICON PACIFIER', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110030', N'FARLIN PACIFIER CLEAR SIL', N'', N'FARLIN PACIFIER CLEAR SIL', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110040', N'FARLIN PURE&SOFT PACIFIER', N'', N'F PURE&SOFT PACIFIER', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110041', N'FARLIN CLEAR SILICONE', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110042', N'FARLIN PACIFIER W/COVER', N'', N'F PACIFIER W/ COVER PNK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110043', N'FARLIN PACIFIER W/COVER', N'', N'F PACIFIER W/ COVER BLUE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110047', N'FARLIN TINTED PACIFIER', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110048', N'FARLIN TINTED PACIFIER', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110049', N'F TINTED PACIFIER BLUE', N'', N'', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110050', N'F TINTED PACIFIER PINK', N'', N'', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110051', N'FARLIN PACIFIER W/H STRAP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11110052', N'FRLN PACFIER W/H STRAP', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130002', N'F CLR TEETHER PRIZEL ORN', N'', N'F CLR TEETHER PRIZEL ORN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130010', N'F. WATERFILL COOLING HAND', N'', N'F TEETHER WATERFILL HAND', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130017', N'F TEETHER WATERFILL HAND', N'', N'F TEETHER WATERFILL HAND', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130019', N'F. WATERFILL COLLING FOOT', N'', N'F TEETHER WATERFILL FOOT', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130020', N'F TEETHER WATERFILL FOOT', N'', N'F TEETHER WATERFILL FOOT', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130022', N'FARLIN WHEN I GROW UP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130023', N'FRLN TEETHER WHN I GRW UP', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130027', N'FARLIN FILLED TEETHER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130028', N'F. WATER FILLED TEETHER', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130029', N'F. WATER FILLED TEETHER', N'', N'', 72, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130030', N'F. WATER FILLED TEETHER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11130051', N'FRLN PACFIER W/H STRAP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210001', N'FARLIN TOOTHBRUSH', N'', N'FARLIN TOOTHBRUSH', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210003', N'FARLIN SILICONE TOOTBRUSH', N'', N'F SILICON TOOTBRUSH', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210008', N'FARLIN POWDER CASE W/PUFF', N'', N'F POWDER CASE W/PUFF BLUE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210009', N'FARLIN POWDER CASE W/PUFF', N'', N'F POWDER CASE W/PUFF PINK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210012', N'F PCASE W/PUFF PNK  6''S', N'', N'F PCASE W/PUFF PNK  6''S', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210013', N'F. POWD. CASE W/PUFF PINK', N'', N'', 24, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210014', N'F PCASE W/PUFF BLU 6''S', N'', N'F PCASE W/PUFF BLU 6''S', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210015', N'F. POWD CASE W/PUFF BLUE', N'', N'', 24, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210016', N'F TBRUSH SILICON 12', N'', N'F TBRUSH SILICON 12', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11210017', N'F. SIL. TOOTHBRUSH', N'', N'', 144, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220000', N'FARLIN DIAPER MINI PACK', N'', N'FARLIN DIAPER MINI PACK', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220002', N'FARLIN DIAPER MINI PACK', N'', N'FARLIN DIAPER MINI PACK', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220004', N'FARLIN DIAPER MINI PACK', N'', N'FARLIN DIAPER MINI PACK', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220006', N'FARLIN DIAPER MINI PACK', N'', N'FARLIN DIAPER MINI PACK', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220008', N'FARLIN DIAPER BUDGT PACK', N'', N'FARLIN DIAPER BUDGT PACK', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220010', N'FARLIN DIAPER BUDGT PACK', N'', N'FARLIN DIAPER BUDGT PACK', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220012', N'FARLIN DIAPER BUDGT PACK', N'', N'FARLIN DIAPER BUDGT PACK', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220014', N'FARLIN DIAPER BUDGT PACK', N'', N'FARLIN DIAPER BUDGT PACK', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220016', N'FARLIN DIAPER BIG PACK', N'', N'FARLIN DIAPER BIG PACK', 36, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220018', N'FARLIN DIAPER BUDGT PACK', N'', N'FARLIN DIAPER BUDGT PACK', 32, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220020', N'FARLIN DIAPER BIG PACK', N'', N'FARLIN DIAPER BIG PACK', 28, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220022', N'FARLIN DIAPER BIG PACK', N'', N'FARLIN DIAPER BIG PACK', 24, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220028', N'F DIAPER THINS MINI SML', N'', N'F DIAPER THINS MINI SML', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220030', N'F DIAPER THINS MINI MED', N'', N'F DIAPER THINS MINI MED', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220032', N'F DIAPER THINS MINI LRGE', N'', N'F DIAPER THINS MINI LRGE', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220034', N'F DIAPER THINS MINI XL', N'', N'F DIAPER THINS MINI XL', 4, N'FARLIN', N'', N'', N'COMARK')
GO
print 'Processed 300 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220036', N'F DIAPER THINS BDGT SML', N'', N'F DIAPER THINS BDGT SML', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220038', N'F DIAPER THINS BDGT MED', N'', N'F DIAPER THINS BDGT MED', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220040', N'F DIAPER THINS BDGT LRGE', N'', N'F DIAPER THINS BDGT LRGE', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220042', N'F DIAPER THINS BDGT XL', N'', N'F DIAPER THINS BDGT XL', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220044', N'F DIAPER THINS BIGPK SML', N'', N'F DIAPER THINS BIGPK SML', 36, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220046', N'F DIAPER THINS BIGPK MED', N'', N'F DIAPER THINS BIGPK MED', 32, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220048', N'F DIAPER THINS BIGPK LRGE', N'', N'F DIAPER THINS BIGPK LRGE', 28, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11220050', N'F DIAPER THINS BIGPK XL', N'', N'F DIAPER THINS BIGPK XL', 24, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240001', N'FARLIN BABY WIPES 10S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240002', N'FARLIN BABY WIPES 10''S', N'', N'', 120, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240003', N'FARLIN BABY WIPES 30S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240004', N'FARLIN BABY WIPES 30''S', N'', N'', 60, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240005', N'FARLIN BABY WIPES 80S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240006', N'FARLIN BABY WIPES 80''S', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240010', N'FARLIN BABY WIPES 10''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240011', N'FARLIN BABY WIPES 30''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240012', N'FARLIN BABY WIPES 80''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240013', N'BABY WIPES', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240014', N'BABY WIPES', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240015', N'BABY WIPES', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240018', N'FARLIN BABYWIFES', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240021', N'F.BBWIPES.UNSCENTED 30S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11240024', N'F.BBWIPES UNSCENTED 80S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250001', N'F PETROLEUM JELY UNSCENT.', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250002', N'F. PET. JELLY REG.', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250003', N'F. PET. JELLY REG.', N'', N'', 288, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250004', N'F. PETOLEUM JELY UNSCENT.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250005', N'F. PET. JELLY REG.', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250006', N'F. PET. JELLY REG.', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250007', N'F. P. JEL POWDER FRESH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250008', N'F. PET. JELLY POWD. FRESH', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250009', N'F. PET. JELLY POWD. FRESH', N'', N'', 288, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250010', N'F. P. JELY POWDER FRESH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250011', N'F. PET JELLY POWD. FRESH', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250012', N'F. PET. JELLY POWD. FRESH', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250013', N'F. P. JELY SWEET BLOSSOM', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250014', N'F. PET. JELLY SWEET BLOS.', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250015', N'F. PET. JELLY SWEET BLOS.', N'', N'', 288, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250016', N'F. P. JELY SWEET BLOSSOM', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250017', N'F. PET. JELLY SWEET BLOS.', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11250018', N'F. PET. JELLY SWEET BLOS.', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11260000', N'FARLIN FINGER PUPPETS', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310004', N'F PSTEM 200TIPS PBAG', N'', N'F PSTEM 200TIPS PBAG', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310007', N'F CBUDS PAPER 200 PO', N'', N'F CBUDS PAPER 200 PO', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310011', N'F C BUDS PLASTIC WHITE', N'', N'F CBUDS PLSTC PBAG WHT 50', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310012', N'F. COTTON BUDS WHITE', N'', N'', 48, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310013', N'F. COTTON BUDS WHITE', N'', N'', 576, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310014', N'F C BUDS PLASTIC BLUE', N'', N'F CBUDS PLSTC PBAG BLU 50', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310015', N'F. COTTON BUDS BLUE', N'', N'', 48, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310016', N'F. COTTON BUDS BLUE', N'', N'', 576, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310017', N'F C BUDS PLASTIC PINK', N'', N'F CBUDS PLSTC PBAG PNK 50', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310018', N'F. COTTON BUDS PINK', N'', N'', 48, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310019', N'F. COTTON BUDS PINK', N'', N'', 576, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310020', N'F C BUDS PLASTIC YELLOW', N'', N'F CBUDS PLSTC PBAG YLW 50', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310023', N'F C BUDS PLASTIC GREEN', N'', N'F CBUDS PLSTC PBAG GRN 50', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310026', N'F C BUDS PLASTIC ORANGE', N'', N'F CBUDS PLSTC PBAG ORA 50', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310029', N'F C BUDS PLASTIC WHITE', N'', N'F CBUDS PLSTC PBAG WHT108', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310030', N'F. COTTON BUDS WHITE', N'', N'', 48, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310031', N'F. COTTON BUDS WHITE', N'', N'', 576, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310032', N'F C BUDS PLASTIC BLUE', N'', N'F CBUDS PLSTC PBAG BLU108', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310033', N'F. COTTON BUDS BLUE', N'', N'', 48, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310034', N'F. COTTON BUDS BLUE', N'', N'', 576, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310035', N'F C BUDS PLASTIC PINK', N'', N'F CBUDS PLSTC PBAG PNK108', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310036', N'F. COTTON BUDS PINK', N'', N'', 48, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310037', N'F. COTTON BUDS PINK', N'', N'', 576, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310038', N'F C BUDS PLASTIC YELLOW', N'', N'F CBUDS PLSTC PBAG YLW108', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310041', N'F C BUDS PLASTIC GREEN', N'', N'F CBUDS PLSTC PBAG GRN108', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310044', N'F C BUDS PLASTIC ORANGE', N'', N'F CBUDS PLSTC PBAG ORA108', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310047', N'F C BUDS PLASTIC WHITE', N'', N'F CBUDS PLSTC PBAG WHT200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310048', N'F. COTTON BUDS WHITE', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310049', N'F. COTTON BUDS WHITE', N'', N'', 288, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310050', N'F C BUDS PLASTIC BLUE', N'', N'F CBUDS PLSTC PBAG BLU200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310051', N'F. COTTON BUDS BLUE', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310052', N'F. COTTON BUDS BLUE', N'', N'', 288, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310053', N'F C BUDS PLASTIC PINK', N'', N'F CBUDS PLSTC PBAG PNK200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310054', N'F. COTTON BUDS PINK', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310055', N'F. COTTON BUDS PINK', N'', N'', 288, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310056', N'F C BUDS PLASTIC YELLOW', N'', N'F CBUDS PLSTC PBAG YLW200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310059', N'F C BUDS PLASTIC GREEN', N'', N'F CBUDS PLSTC PBAG GRN200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310062', N'F C BUDS PLASTIC ORANGE', N'', N'F CBUDS PLSTC PBAG ORA200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310065', N'F CBUDS PLASTIC WHITE', N'', N'F CBUDS PLSTC CAN WHT 200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310068', N'F CBUDS PLASTIC(CAN) BLUE', N'', N'F CBUDS PLSTC CAN BLU 200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310071', N'F CBUDS PLASTIC(CAN) PINK', N'', N'F CBUDS PLSTC CAN PNK 200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310074', N'F CBUDS PLASTIC(CAN)YELLW', N'', N'F CBUDS PLSTC CAN YLW 200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310077', N'F CBUDS PLASTIC(CAN)GREEN', N'', N'F CBUDS PLSTC CAN GRN 200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310080', N'F CBUDS PLASTIC(CAN)ORANG', N'', N'F CBUDS PLSTC CAN ORA 200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310083', N'F CBUDS PLASTIC(BOX)WHITE', N'', N'F CBUDS PLSTC BOX WHT 440', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310086', N'F CBUDS PLASTIC(BOX) BLUE', N'', N'F CBUDS PLSTC BOX BLU 440', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310089', N'F CBUDS PLASTIC(BOX) PINK', N'', N'F CBUDS PLSTC BOX PNK 440', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310092', N'F CBUDS PLSTC BOX YELLOW', N'', N'F CBUDS PLSTC BOX YLW 440', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310095', N'F CBUDS PLSTC BOX GREEN', N'', N'F CBUDS PLSTC BOX GRN 440', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310098', N'F CBUDS PLSTC BOX ORA 440', N'', N'F CBUDS PLSTC BOX ORA 440', 200, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310101', N'F CBUDS PAPER PBAG WHT200', N'', N'F CBUDS PAPER PBAG WHT200', 200, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310104', N'F BB BUDS PLASTIC(CAN)WHT', N'', N'F BBUDS PLSTC CAN WHT 200', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310105', N'F. BABY BUDS', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310106', N'F. BABY BUDS', N'', N'', 288, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310109', N'F. PAPER STEM CTTN BDS', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310111', N'FARLIN CTTN BDS CAN', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310113', N'F. PAPER STEM CTTN BDS', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11310118', N'F COTTON BUDS 200 CAN', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11410056', N'SQUEEZE N''TOYS SET', N'', N'', 1, N'', N'', N'', N'COMARK')
GO
print 'Processed 400 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520001', N'F. DIAPER CLIPS PINK', N'', N'', 72, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520002', N'F. DIAPER CLIPS BLUE', N'', N'', 72, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520003', N'F. DIAPER CLIPS M. GREEN', N'', N'', 72, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520005', N'FARLIN DIAPER CLIPS BLUE', N'', N'F DIAPER CLIPS BLUE', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520006', N'F.DIAPER CLIPS MINT GREEN', N'', N'F DIAPER CLIPS MINT GREEN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520007', N'FARLIN DIAPER CLIPS PINK', N'', N'F DIAPER CLIPS PINK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520011', N'F SQ&SCR BATH 4X2', N'', N'F SQ&SCR BATH 4X2', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520051', N'F DIAPER CLIPS MTGRN 12''S', N'', N'F DIAPER CLIPS MTGRN 12''S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520052', N'F DIAPER CLIP BLU 12''S', N'', N'F DIAPER CLIP BLU 12''S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520053', N'F DIAPER CLIPS PNK 12 ''S', N'', N'F DIAPER CLIPS PNK 12 ''S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11520059', N'45 F DIAPERCLIPS ASSTDX3S', N'45 F DIAPERCLIPS ASSTDX3S', N'45 F DIAPERCLIPS ASSTDX3S', 12, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720003', N'FARLIN ORGA BAG 6S', N'', N'FARLIN ORGA BAG 6S', 6, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720023', N'F ORGANIZING BAG W/O ACCE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720045', N'FARLIN GIFT SET COMBO # 4', N'', N'FARLIN GIFT SET COMBO # 4', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720074', N'FARLIN HAPPY BABY PROMO#6', N'', N'FARLIN HAPPY BABY PROMO#6', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720075', N'F HBABY PROMO6 LSU', N'', N'F HBABY PROMO6 LSU', 30, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720076', N'FARLIN HAPPY BABY PROMO#7', N'', N'FARLIN HAPPY BABY PROMO#7', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720077', N'F HBABY PROMO7 LSU', N'', N'F HBABY PROMO7 LSU', 30, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720078', N'F HBABY PROMO8', N'', N'F HBABY PROMO8', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720098', N'F BABY BUNDLE 3''S 3/PK', N'', N'F BABY BUNDLE 3''S 3/PK', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720128', N'FARLIN GIFT PACK 3A', N'', N'FARLIN GIFT PACK 3A', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720133', N'FARLIN GIFT PACK 2', N'', N'FARLIN GIFT PACK 2', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720138', N'FARLIN GIFT PACK 3B', N'', N'FARLIN GIFT PACK 3B', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720139', N'FARLIN GIFT PACK 3C', N'', N'FARLIN GIFT PACK 3C', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720140', N'F.DECORATED GIFT SET', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720141', N'FRLIN DECO GIFTSET 4PK/CS', N'', N'FRLIN DECO GIFTSET 4PK/CS', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720142', N'F DECORATED GIFT SET 2', N'', N'F DECORATED GIFT SET 2', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720157', N'F DECORATED GIFT SET 2', N'', N'F DECORATED GIFT SET 2', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720160', N'45 BJOY SN POUCH PROMO S', N'45 BABJOY SN POUCH PROMO S X6''S', N'45 BJOY SN POUCH PROMO S', 6, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720161', N'45 BJOY SN POUCH PROMO M', N'45 BABYJOY SN POUCH PROMO M X6''S', N'45 BJOY SN POUCH PROMO M', 6, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720162', N'45 BJOY SN POUCH PROMO L', N'45 BABYJOY SN POUCH PROMO L X 6''S', N'45 BJOY SN POUCH PROMO L', 6, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720222', N'F STERILIZER G SET -PROMO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720223', N'F. STEAM STER. GIFT SET', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720225', N'FARLIN SPIRAL DRPLESS CUP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720232', N'FARLIN CLASSIC CLEAR 3PCK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11720501', N'F. X - MAS PACK W/ RN', N'', N'F. X - MAS PACK W/ RN', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11730002', N'FARLIN BREAST PUMP', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11730003', N'FARLIN BREAST PUMP', N'', N'', 4, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11730005', N'FARLIN BREAST PUMP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11730007', N'F.BREAST PUMP W/ ADAPTOR', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750002', N'FARLIN BABYWIPES 80''S+10S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750006', N'F BABYWIPES 80''S+ FEVER A', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750007', N'FARLIN FN BCARD L.3''S+NIP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750008', N'FARLIN FN BCARD M.3''S+NIP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750009', N'FARLIN FN BCARD S.3''S+NIP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750010', N'FARLIN FN BCARD X-C3S+NIP', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750011', N'F.SILICONE NBC XCT3''S POU', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750013', N'F.SILICON NBC SMAL3''S POU', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750015', N'F.SILICON NBC MED3''S POU', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750017', N'F.SILICON NBC LARGE3''S PO', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750022', N'SILICONE BTL+BBWIFES 10''S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750023', N'F.WIDENECK+CTTNBUDS 200S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750024', N'F.SIL TOOTBRUSH+SPOON', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750025', N'F.TINTED BTTLS 2PCS PROMO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750036', N'F.FB LIMITED EDITION 30YR', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750039', N'F.DECO 3PK+BOTTLE&BRUSH', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750040', N'TRAINING CUP+SILICONSPOON', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750041', N'F.CLSCCLR+SILCN TOOTHBRSH', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750043', N'TRAINING CUP+SILICONSPOON', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750046', N'F.BBYWPES+PPRSTEM BUD 108', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750049', N'F.TINTED+NIPPLE BCS3S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750053', N'F.2PCSTINTEDPP4OZ+SIL.SPN', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750055', N'F. CHRISTMAS PACK 1', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750056', N'F. CHRISTMAS PACK 2', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750059', N'F.CLSC CLR3PKPP8OZ+2PCSCR', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750060', N'F.DECOPP8OZ+NIPPLEBRUSH', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750061', N'F.DECO 3PK8OZW/ 30YRSBOT', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750062', N'F.CLSIC CLR3PK8OZW/30YRSB', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750063', N'FAR SILICONE COLLECTION', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750064', N'FWIPES80S 2PCS+BUD50S&10S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750065', N'F CLSC3PK PP4OZ+WIPES 10S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750067', N'F.TODOLIST+W.80''S&CLSC11Z', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750069', N'F.STEAMSTER 8BOT+WALLORG', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750070', N'FTINTED PP 4OZ+NIP BC3S M', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750071', N'F TRAINING CUP+WIPES 10S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750072', N'F CLSC3PK PP8OZ+NIPBC3S L', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750073', N'F TRAININGCUP+SILICON SPN', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750074', N'F CLSK3PKPP8OZ+BUDSPL108T', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750075', N'F.WDENCK9OZ+PLSTCBAG200T', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750096', N'F.STEM.STER 8 BOT+BOT ORG', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750097', N'F.2PCS WIPES80S+CBUDS108T', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750107', N'F.BOT.GSETPP+UNS.WIPES30S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750108', N'F6PKBOTGSETPP+UNSWIPE30S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750111', N'F BPUMP W/ ADAPTOR+SCEN80', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750112', N'F. E''STM.STER8BOT+TOTEBAG', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750113', N'F. E''STMSTER6BOT+TOTEBAG', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750114', N'F. 6PK B GIFTSET+TOTEBAG', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750116', N'F.3PKCLSCLR8OZPP+CALENDAR', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750117', N'F.3PK DCOLL8OZPP+CZLENDAR', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750118', N'F. WNECK 9OZ+TBUDSBOTCLEN', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750123', N'F TCUP PP BLUE SIL SPOON', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750124', N'F SIL TBRUSH+W PSCNT 10S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750125', N'F PACIFIER B+W PSCENT 10S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750126', N'F MPC4L+BWIPES PSCENT 10S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750127', N'FCLSC.CLRPP3PK8OZ+PCNT30S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750128', N'F DCO PP3PK8OZ+WPSCENT30S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750129', N'F TRNG CUP PINK+SIL SPOON', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750130', N'F. PAC PINK + WPSCENT 10S', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750131', N'F. BABYWIPES80''S + TSHIRT', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750132', N'F 3PK CLSC.CLR 8OZ+TOTBAG', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750133', N'F 3PK DECO 8OZ+F. TOTBAG', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
GO
print 'Processed 500 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750134', N'FARLIN 6PK 8OZ +WALL ORG.', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750135', N'F. WIPES 80 2S+VANITY KIT', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11750138', N'F. BREAST PUMP+VANITY KIT', N'', N'', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11760010', N'F.BBWIFES30+F.BUDS108TIPS', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'11760011', N'F.BBWIPES80+F.BUDS200TIPS', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010001', N'BABYJOY RUBBER NIPPLES', N'', N'BBJOY RUBBER NIPPLES', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010004', N'BBJOY STANDARD SIL NIP M', N'', N'BBJOY STANDARD SIL NIP M', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010008', N'BBY STD NIPPLES XCUT  12', N'', N'BBY STD NIPPLES XCUT  12', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010012', N'BABYJOY SIL. NIP. MEDIUM', N'', N'BBJOY SIL NIP POUCH MED', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010013', N'BABYJOY SIL. NIP. LARGE', N'', N'BBJOY SIL NIP POUCH LARGE', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010014', N'BABYJOY SIL. NIP. XCUT', N'', N'BBJOY SIL NIP POUCH X-CUT', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010023', N'BBJOY SIL NIP BCARD MED', N'', N'BBJOY SIL NIP BCARD MED', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010024', N'BBJOY SIL NIP BCARD SMALL', N'', N'BBJOY SIL NIP BCARD SMALL', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010025', N'BBJOY SIL NIP BCARD X-CUT', N'', N'BBJOY SIL NIP BCARD X-CUT', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010026', N'BABYJOY SIL. NIP. SMALL', N'', N'BBJOY SIL NIP POUCH SMALL', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010036', N'BBJ SILCNE NIPPLE POUCH', N'', N'BBJ SILCNE NIPPLE POUCH', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010037', N'BBJ SILCNE NIPPLE POUCH', N'', N'BBJ SILCNE NIPPLE POUCH', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010038', N'BBJ SILCNE NIPPLE POUCH', N'', N'BBJ SILCNE NIPPLE POUCH', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010039', N'BBY STD NIPPLES SML', N'', N'BBY STD NIPPLES SML', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010040', N'BBJOY SIL NIP BCARD LARGE', N'', N'BBJOY SIL NIP BCARD LARGE', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010048', N'BBJ SIL NIP BC X 3S 12', N'', N'BBJ SIL NIP BC X 3S 12', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010050', N'B SIL NIP  BC S 2S 12', N'', N'B SIL NIP  BC S 2S 12', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010052', N'B SIL NIP BC M 2S 12', N'', N'B SIL NIP BC M 2S 12', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010054', N'B FN SN BC L 2C 12', N'', N'B FN SN BC L 2C 12', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010056', N'BBJOY FN POUCH X-CUT', N'', N'BBJOY FN POUCH X-CUT', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010057', N'BBJ FN RUBBER NIPPLE', N'', N'BBJ FN RUBBER NIPPLE', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010063', N'BBJOY RUBBER NIPPLES', N'', N'', 600, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010064', N'BBJ SILICONE NIPPLE POUCH', N'', N'', 600, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010065', N'BBJ SILICONE NIPPLE POUCH', N'', N'', 600, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010066', N'BBJ SILICONE NIPPLE POUCH', N'', N'', 600, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010067', N'BBJ SILICONE NIPPLE POUCH', N'', N'', 600, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010071', N'45 BJOY RUBER NIPPLES X6S', N'45 BJOY RUBER NIPPLES X6S', N'45 BJOY RUBER NIPPLES X6S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010072', N'45 BJOY SN POUCH XCUT X6S', N'45 BJOY SN POUCH XCUT X6S', N'45 BJOY SN POUCH XCUT X6S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010073', N'45 BJOY SN POUCH S X 6S', N'45 BJOY SN POUCH S X 6S', N'45 BJOY SN POUCH S X 6S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010074', N'45 BJOY SN POUCH M X6S', N'45 BJOY SN POUCH M X6S', N'45 BJOY SN POUCH M X6S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010075', N'45 BJOY SN POUCH L 6XS', N'45 BJOY SN POUCH L 6XS', N'45 BJOY SN POUCH L 6XS', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010076', N'45 BJOY SN BC XCUT 3S', N'45 BJOY SN BC XCUT 3S', N'45 BJOY SN BC XCUT 3S', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010077', N'45 BJOY SN BC S 2S', N'45 BJOY SN BC S 2S', N'45 BJOY SN BC S 2S', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010078', N'45 BJOY SN BC M 2S', N'45 BJOY SN BC M 2S', N'45 BJOY SN BC M 2S', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010079', N'45 BJOY SN BC L 2S', N'45 BJOY SN BC L 2S', N'45 BJOY SN BC L 2S', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010080', N'45 BJOY FNIPLE BC XCUT 2S', N'45 BJOY FNIPLE BC XCUT 2S', N'45 BJOY FNIPLE BC XCUT 2S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010081', N'45 BJOY FNIPL BC SMALL 2S', N'45 BJOY FNIPL BC SMALL 2S', N'45 BJOY FNIPL BC SMALL 2S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010082', N'45 BJOY FNIP BC MEDIUM 2S', N'45 BJOY FNIP BC MEDIUM 2S', N'45 BJOY FNIP BC MEDIUM 2S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010083', N'45 BJOY FNIPL BC LARGE 2S', N'45 BJOY FNIPL BC LARGE 2S', N'45 BJOY FNIPL BC LARGE 2S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010084', N'BABYJOY BUNOT CARD', N'', N'BABYJOY BUNOT CARD', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010088', N'BABYJOY SN BCARD X-CUT 3S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010089', N'BBJ SIL. NIP. B.C. 3''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010090', N'BBJ SIL. NIP. B.C. 3''S', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010091', N'BABYJOY SN BCARD SML 3''S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010092', N'BBJ SIL. NIP. B.C. 3''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010093', N'BBJ SIL. NIP. B.C. 3''S', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010094', N'BABYJOY SN BCARD MED 3''S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010095', N'BBJ SIL. NIP. B.C. 3''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010096', N'BBJ SIL. NIP. B.C. 3''S', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010097', N'BABYJOY SN BCARD LRG 3''S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010098', N'BBJ SIL. NIP. B.C. 3''S', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12010099', N'BBJ SIL. NIP. B.C. 3''S', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020034', N'SM W/RN BLU 8OZ', N'', N'SM W/RN BLU 8OZ', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020035', N'SM W/RN COMBI 8OZ', N'', N'SM W/RN COMBI 8OZ', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020036', N'SM W/RN YLW 8O', N'', N'SM W/RN YLW 8O', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020069', N'B FB DECOR 8OZ', N'', N'B FB DECOR 8OZ', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020074', N'B FB DECOR 4OZ/CASE', N'', N'B FB DECOR 4OZ/CASE', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020081', N'BBJOY CLASSIC CLEAR W/ SN', N'', N'BBJOY CLASSIC CLEAR W/ SN', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020083', N'BBJOY CLASSIC CLEAR W/ SN', N'', N'BBJOY CLASSIC CLEAR W/ SN', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020086', N'BBJOY CLCLR GFSET 4PK X 3', N'', N'BBJOY CLCLR GFSET 4PK X 3', 4, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020088', N'BBJOY FB DEC. COLL 8 OZ', N'', N'BBJOY FB DEC. COLL 8 OZ', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020099', N'BBJOY FB DEC. COLL. 4OZ', N'', N'BBJOY FB DEC. COLL. 4OZ', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020105', N'BBJOY FB CLASIC CLEAR 4OZ', N'', N'BBJOY FB CLASIC CLEAR 4OZ', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020106', N'BBJOY FB CLASIC CLEAR 8OZ', N'', N'BBJOY FB CLASIC CLEAR 8OZ', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020107', N'BBJOY FB CLASIC CLEAR 3PK', N'', N'BBJOY FB CLASIC CLEAR 3PK', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020233', N'BBJOY F.B. DECO 8 OZ', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020234', N'BBJOY CLASIC CLEAR COLL.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020235', N'BBJOY CLASIC CLEAR COLL.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020236', N'BBJOY C. CLEAR COLL. 8 OZ', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020237', N'45 BJOY FB DECO W/SN 8OZ', N'45 BJOY FB DECO W/SN 8OZ', N'45 BJOY FB DECO W/SN 8OZ', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020238', N'45 BJOY FB DECO W/SN 4OZ', N'45 BJOY FB DECO W/SN 4OZ', N'45 BJOY FB DECO W/SN 4OZ', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020240', N'45 BJOY CLSCCLR FB4OZ X3S', N'45 BBJOY CLSC CLR FEEDINGBOTTLE4OZ3S', N'45 BJOY CLSCCLR FB4OZ X3S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020241', N'45 BJOY 3PKCLSCCLRCOLGSET', N'45 BJOY 3PKCLSCCLRCOLGSET', N'45 BJOY 3PKCLSCCLRCOLGSET', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020245', N'BBJ DECORATED COLLECTION', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020246', N'BBJ DECORATED COLLECTION', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020247', N'BBJOY DECORTED COLLECTION', N'', N'BBJOY DECORTED COLLECTION', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020248', N'BBJOY DECORTED COLLECTION', N'', N'BBJOY DECORTED COLLECTION', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020254', N'BBJ 3PCKGSET CLS. CLEAR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020255', N'BBJ CLS CLEAR 3-PACK', N'', N'', 4, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020257', N'BBJ 3PCK G.SET DECO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020265', N'BBJOY FB PP CLSC CLR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020267', N'BABYJOY FB PP CLSC CLR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020269', N'BBJOY PP FB CLSC CLR 3PAC', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020271', N'BBJOY FB PP CLSC CLR 3PK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020273', N'BBJOY FB PP DECO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020275', N'BABYJOY FB PP DECO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020277', N'BBJOY PP DECO 3-PK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020279', N'BJ PP DECO 3PK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12020281', N'BBJOY PP 6PK FB W/HOLDER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12030005', N'B 108 PSTEM POLYBAG', N'', N'B 108 PSTEM POLYBAG', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12030006', N'B 72 PSTEM POLYBAG', N'', N'B 72 PSTEM POLYBAG', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12050006', N'BABYJOY 6-PACK BOT. SET', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12050009', N'BABYJOY DECORATED 3PCKS', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12060001', N'BABYJOY MILK POWDER CONT.', N'', N'BBJOY MILK POWDER CON 3L', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12060002', N'BBJOY MILK POWDER CONT.', N'', N'BBJOY MILK POWDER CONT.', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12060004', N'BBJOY MILK POWDER CONT.', N'', N'BBJOY MILK POWDER CONT.', 12, N'BABYJOY', N'', N'', N'COMARK')
GO
print 'Processed 600 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12060005', N'BABYJOY MILK POWDER CONT.', N'', N'BBJOY MILK POWDER CON 4L', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12060006', N'45 BJOY MLKPWDRCONT3-LX2S', N'45 BJOY MLKPWDRCONT3-LX2S', N'45 BJOY MLKPWDRCONT3-LX2S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12060007', N'45 BJOY MLKPWDRCONT4-LX2S', N'45 BJOY MLKPWDRCONT4-LX2S', N'45 BJOY MLKPWDRCONT4-LX2S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12110006', N'BABYJOY SIL. PACIFIER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12345678', N'JASDFHLKJASDFS', N'ASDFJKL;', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12520001', N'BBJOY DIAPER CLIPS MGREEN', N'', N'BBJOY DIAPER CLIPS MGREEN', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12520002', N'BBJOY DIAPER CLIPS BLUE', N'', N'BBJOY DIAPER CLIPS BLUE', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12520003', N'BBJOY DIAPER CLIPS PINK', N'', N'BBJOY DIAPER CLIPS PINK', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530001', N'BBJOY POWDER CASE W/PUFF', N'', N'BBJOY POW CASE W/PUF PEAC', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530002', N'BBJOY POWDER CASE W/PUFF', N'', N'BBJOY POW CASE W/PUF MGRN', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530003', N'BBJOY PWDERCASE W/PUFF', N'', N'BBJOY PWDERCASE W/PUFF', 6, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530004', N'BBJOY PWDERCASE W/PUFF', N'', N'BBJOY PWDERCASE W/PUFF', 6, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530005', N'BBJOY POWDER CASE W/ PUFF', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530006', N'BBJOY POWDER CASE W/ PUFF', N'', N'', 36, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530007', N'45 BJOYPWDRCSEW/PUFMGRNX3', N'45 BABYJOY POWDERCASE W/PUFF 3S MINTGREEN', N'45 BJOYPWDRCSEW/PUFMGRNX3', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530008', N'45 BJOYPWDRCSEW/PFPEACHX3', N'45 BABYJOY POWDER CASE W/PUFF 3S PEACH', N'45 BJOYPWDRCSEW/PFPEACHX3', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530009', N'BJ POWDERCASE W/PUFF BLUE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12530012', N'BJ POWDERCASE W/PUFF PINK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540001', N'BABYJOY BOTTLE BRUSH', N'', N'BABYJOY BOTTLE BRUSH', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540003', N'BBJOY FB HOOD CAPS', N'', N'BBJOY FB HOOD CAPS', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540005', N'B ALUM STERILIZE SET', N'', N'B ALUM STERILIZE SET', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540007', N'BABYJOY NIPPLE BRUSH', N'', N'BABYJOY NIPPLE BRUSH', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540009', N'BABYJOY BOTTLE BRUSH', N'', N'BABYJOY BOTTLE BRUSH', 24, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540011', N'45 BJOY NIPPLE BRUSH X 6S', N'45 BJOY NIPPLE BRUSH X 6S', N'45 BJOY NIPPLE BRUSH X 6S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540012', N'45 BJOY BOTTLE BRUSH X 3S', N'45 BJOY BOTTLE BRUSH X 3S', N'45 BJOY BOTTLE BRUSH X 3S', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540024', N'BBJOY WATERFILLED TEETHER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540025', N'BBJ WATER FILLED TEETHER', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540026', N'BBJ WATER FILLED TEETHER', N'', N'', 72, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540030', N'BBJOY BOT&NIPPLE BRUSH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540032', N'BJ 6-BTL STEAM STERILIZER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540033', N'BBJOY WATERFILLED TEETHER', N'', N'', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12540035', N'BBJOY WATERFILLED TEETHER', N'', N'', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12550002', N'BJ SPIN PBEAR ASSTD', N'', N'BJ SPIN PBEAR ASSTD', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750006', N'BJ FN BCARD L 3''S+POUCH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750007', N'BJ FN BCARD MED 3''S+POUCH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750008', N'BJ FN BCARD SML 3''S=POUCH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750009', N'BJ FN BCARD X-CUT 3''S=POU', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750010', N'B.SILICON NBC XCUT3''S POU', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750012', N'B.SILICON NBC SMAL3''S POU', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750014', N'B.SILICON NPC MED.3''S POU', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750016', N'B.SILICON NBC LARGE3''S PO', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750019', N'BBJOY FB PC 3PK 2+1 PROMO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750020', N'BJDECO3PK W/SIL.NIPPLEBCM', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750023', N'BBJOY CHRISTMAS PACK 1', N'', N'', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750024', N'BJ S.STELIZER6B+MPC3L+BRS', N'', N'', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750025', N'BJ.PCFER+TETHER+NPLEBC3SL', N'', N'', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750026', N'BJ2PCSDECOPP8OZ+NIPBC3S L', N'', N'', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'12750027', N'BJ.2PCSDECOPP8OZ+TEETHER', N'', N'', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010011', N'BEST RUBBER NIPPLE POUCH', N'', N'', 60, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010012', N'BEST SILICONE NIPPLE JAR', N'', N'', 60, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010013', N'BEST SILICONE NIPPLE JAR', N'', N'', 60, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010014', N'BEST SILICONE NIPPLE JAR', N'', N'', 60, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010015', N'BEST SILICONE NIPPLE JAR', N'', N'', 60, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010016', N'BEST RUBBER NIP. POLYBAG', N'', N'', 60, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010017', N'BEST SIL. NIP. POLYBAG', N'', N'', 60, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010018', N'BEST SIL. NIP. POLYBAG', N'', N'', 60, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010019', N'BEST SIL. NIP. POLYBAG', N'', N'', 60, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18010020', N'BEST SIL. NIP. POLYBAG', N'', N'', 60, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'18020001', N'45 NB FBOTTLE 4''S WITHPRT', N'45 NB FBOTTLE 4''S WITHPRT', N'45 NB FBOTTLE 4''S WITHPRT', 12, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'19020005', N'NURTURE FB BEAR&BALLON 8O', N'', N'NURTURE FB BEAR&BALLON 8O', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'19020006', N'NURTURE FB BEAR&BALLON 4O', N'', N'NURTURE FB BEAR&BALLON 4O', 1, N'FARLIN', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'1D010001', N'FEVER AWAY COOL PATCH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'1D010002', N'FEVER AWAY COOL PATCH', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'1D010003', N'FEVER AWAY COOL PATCH', N'', N'', 120, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'1D010004', N'FEVER AWAY COOL PATCH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'1D010005', N'FEVER AWAY COOL PATCH', N'', N'', 48, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010006', N'AP AP SOLUTION 15 CC', N'', N'AP AP SOLUTION 15 CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010008', N'CEBU DE MACHO 1/4 OZ', N'', N'CEBU DE MACHO 1/4 OZ', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010011', N'SALICYLIC ACID 15ML', N'', N'SALICYLIC ACID 15ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010012', N'SALICYLIC ACID 30ML', N'', N'SALICYLIC ACID 30ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010013', N'AP AP SOLUTION 30 CC', N'', N'AP AP SOLUTION 30 CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010014', N'AP-AP SOL 15CC', N'', N'AP-AP SOL 15CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010015', N'AP-AP 15CC', N'', N'AP-AP 15CC', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010016', N'AP-AP 30CC', N'', N'AP-AP 30CC', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010017', N'SALICYLIC ACID 15ML', N'', N'SALICYLIC ACID 15ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010018', N'SALICYLIC ACID 30ML', N'', N'SALICYLIC ACID 30ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21010019', N'CMACHO 1/4OZ', N'', N'CMACHO 1/4OZ', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020004', N'BENZALKONIUM CHLORIDE', N'', N'', 288, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020005', N'BENZALKONIUM CHLORDE(PET)', N'', N'BENZALKONIUM CHLORIDE', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020006', N'BENZALKONIUM CHLORIDE', N'', N'BENZALKONIUM CHLORIDE', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020007', N'BENZALKONIUM CHLORIDE', N'', N'BENZALKONIUM CHLORIDE', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020008', N'BENZALKONIUM CHLORIDE', N'', N'', 288, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020009', N'BENZALKONIUM CHLORIDE 7.5', N'', N'BENZALKONIUM CHLORIDE 7.5', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020010', N'BENZALKONIUM CHLORIDE', N'', N'', 144, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020012', N'HYDROGEN PEROXIDE VOL. 10', N'', N'HYDROGEN PEROXIDE VOL. 10', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020014', N'HYDROGEN PEROXIDE VOL. 10', N'', N'HYDROGEN PEROXIDE VOL. 10', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020017', N'BENZALKONIUM CHLORIDE', N'', N'', 144, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020018', N'HYDROGEN PEROXIDE', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020019', N'HYDROGEN PEROXIDE', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020020', N'IODINE 10% G', N'', N'IODINE 10% G', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020021', N'IODINE 7.5% 1G', N'', N'IODINE 7.5% 1G', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020025', N'47 BENZAL CHLRDE 60ML 12S', N'47 BENZALKONIUM CHLORIDE 60MLX12', N'47 BENZAL CHLRDE 60ML 12S', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020026', N'47 BENZALCHLRDE 120ML 18S', N'47 BENZALCHLRDE 120ML 18S', N'47 BENZALCHLRDE 120ML 18S', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020028', N'BENZAL CHLORIDE 15ML', N'', N'BENZAL CHLORIDE 15ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020029', N'BENZAL CHLORIDE 30ML', N'', N'BENZAL CHLORIDE 30ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020030', N'BENZAL CHLORIDE  60ML', N'', N'BENZAL CHLORIDE  60ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020031', N'BENZAL CHLORIDE  120ML', N'', N'BENZAL CHLORIDE  120ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020032', N'PEROXIDE 60ML PACK', N'', N'PEROXIDE 60ML PACK', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020033', N'PEROXIDE 120ML PK', N'', N'PEROXIDE 120ML PK', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020039', N'BENZALKONIUM CHLORIDE', N'', N'BENZALKONIUM CHLORIDE', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020043', N'TINCTURE OF IODINE 15ML', N'', N'TINCTURE OF IODINE 15ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
GO
print 'Processed 700 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020091', N'BENZALKONIUM CHLORIDE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020115', N'CL CUTICLE TINT W/BENZAL', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020116', N'CL CUTICLE TINT W/BENZAL', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020117', N'CL CUTICLE TINT W/BENZAL', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21020118', N'CL CUTICLE TINT W/BENZAL', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21040004', N'OIL OF WINTERGREEN 15ML', N'', N'OIL OF WINTERGREEN 15ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21040005', N'OIL OF WINTERGREEN 30 ML', N'', N'OIL OF WINTERGREEN 30 ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21040006', N'OIL OF WINTERGREEN 60 ML', N'', N'OIL OF WINTERGREEN 60 ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21040007', N'O W GREEN 15ML', N'', N'O W GREEN 15ML', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21040008', N'O W GREEN 30ML', N'', N'O W GREEN 30ML', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21040009', N'O W GREEN 60ML', N'', N'O W GREEN 60ML', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21040010', N'OIL OF WINTERGREEN 120ML', N'', N'OIL OF WINTERGREEN 120ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060001', N'47 ACEITE MNZANLA 30ML12S', N'47 ACEITE MNZANLA 30ML12S', N'47 ACEITE MNZANLA 30ML12S', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060005', N'ACEITE ALCAMFORADO 15 CC', N'', N'ACEITE ALCAMFORADO 15 CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060006', N'ACEITE ALCAMFORADO 30 CC', N'', N'ACEITE ALCAMFORADO 30 CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060007', N'ACEITE MANZANILLA 15CC', N'', N'ACEITE MANZANILLA 15CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060008', N'ACEITE MANZANILLA 30 CC', N'', N'ACEITE MANZANILLA 30 CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060009', N'ACEITE MANZANILLA 60 CC', N'', N'ACEITE MANZANILLA 60 CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060012', N'ACEITE ALCAMFORADO 60 CC', N'', N'ACEITE ALCAMFORADO 60 CC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060015', N'ALCAMFORADO 30CC', N'', N'ALCAMFORADO 30CC', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060016', N'ALCAMFORADO 60CC', N'', N'ALCAMFORADO 60CC', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060017', N'MANZANILLA 15CC', N'', N'MANZANILLA 15CC', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060018', N'MANZANILLA 30CC', N'', N'MANZANILLA 30CC', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060019', N'MANZANILLA 60CC', N'', N'MANZANILLA 60CC', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21060020', N'A ALCA 15ML 12S', N'', N'A ALCA 15ML 12S', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070003', N'47 ACTONE 60ML 268996 12S', N'47 ACETONE 60MLX12S', N'47 ACTONE 60ML 268996 12S', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070004', N'47 CUTCLEREMOVR 120ML 18S', N'47 CUTICLE REMOVER 120MLX18S', N'47 CUTCLEREMOVR 120ML 18S', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070006', N'ACETONE', N'', N'ACETONE 120ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070007', N'ACETONE 15ML', N'', N'ACETONE 15ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070009', N'ACETONE 30ML', N'', N'ACETONE 30ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070010', N'ACETONE', N'', N'ACETONE 60ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070012', N'ACETONE 60ML', N'', N'', 144, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070013', N'ACETONE 120 ML', N'', N'', 144, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070015', N'NAIL CUTICLE REMOVER', N'', N'', 216, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070016', N'NAILS CUTICLE REMOVER(PET', N'', N'CUTICLE REMOVER 120ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070017', N'CUTICLE REMOVER 30ML', N'', N'CUTICLE REMOVER 30ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070018', N'NAILS CUTICLE REMOVER', N'', N'CUTICLE REMOVER 60ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070019', N'NAIL CUTICLE REMOVER', N'', N'', 144, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070021', N'HYDROGEN PEROXIDE VOL.20', N'', N'HYDROGEN PEROXIDE VOL.20', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070033', N'VALUE ACETONE', N'', N'VALUE ACETONE 60ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070042', N'ACETONE 15ML PACK', N'', N'ACETONE 15ML PACK', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070043', N'ACETONE 30ML PACK', N'', N'ACETONE 30ML PACK', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070044', N'ACETONE 60ML PACK', N'', N'ACETONE 60ML PACK', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070045', N'ACETONE 120ML PACK', N'', N'ACETONE 120ML PACK', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070051', N'CUTICLE REMOVER 30ML', N'', N'CUTICLE REMOVER 30ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070052', N'CUTICLE REMOVER 60ML', N'', N'CUTICLE REMOVER 60ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070053', N'CUTICLE REMOVER (PET)', N'', N'CUTICLE REMOVER 120ML', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070056', N'SM BUNOS CUTICLE RMVER/PC', N'', N'SM BUNOS CUTICLE RMVER/PC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070072', N'NAILS POLISH REMOVER', N'', N'', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070073', N'NAIL POLISH REMOVER', N'', N'NAIL POLISH REMOVER', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070074', N'NAILS POLISH REMOVE', N'', N'', 288, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070075', N'NAILS POLISH REMOVER', N'', N'', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070076', N'NAIL POLISH REMOVER', N'', N'NAIL POLISH REMOVER', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070077', N'NAILS POLISH REMOVER', N'', N'', 288, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070078', N'NAILS POLISH REMOVER', N'', N'', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070079', N'NAIL POLISH REMOVER', N'', N'NAIL POLISH REMOVER', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070080', N'NAILS POLISH REMOVER', N'', N'', 144, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070081', N'NAILS POLISH REMOVER(PET)', N'', N'', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070082', N'NAIL POLISH REMOVER (PET)', N'', N'NAIL POLISH REMOVER', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070083', N'NAILS POLISH REMOVER', N'', N'', 144, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070088', N'NAILS CUTICLE REMOVER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070090', N'NAILS CUTICLE REMOVER', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070094', N'NAILS POLISH REMOVER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070101', N'MY NAILS NPR W/ACETONE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070103', N'MYNAILS NAIL POLISH W/ACE', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070104', N'MY NAILS NPR W/ACETONE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070106', N'MYNAILS NAIL POLISH W/ACE', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070107', N'VALUE NPR W/ACETONE 60 ML', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070127', N'MY NAIL CUTICLE TINT', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070130', N'MY NAILS CUTILCE TINT', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070133', N'MY NAILS CUTICLE REMOVER', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070136', N'MY NAILS CUTICLE REMOVER', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070145', N'MY NAILS CUTICLE TINT NEW', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21070146', N'MY NAILS CUTICLE TINT NEW', N'', N'', 1, N'PHARMA', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21080003', N'SPIRIT OF AMMONIA 30ML 1S', N'', N'SPIRIT OF AMMONIA 30ML 1S', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21080004', N'SPIRIT OF AMMONIA 15ML 1S', N'', N'SPIRIT OF AMMONIA 15ML 1S', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21140003', N'ALCOHOL 70% 500ML', N'', N'ALCOHOL 70% 500ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21140006', N'MINERAL OIL 120ML', N'', N'MINERAL OIL 120ML', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21290001', N'DIMPLES (NI) STYLING GEL', N'', N'', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21290002', N'DIMPLES STYLING GEL', N'', N'', 50, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'21290003', N'DIMPLES STYLING GEL', N'', N'', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'25070001', N'MEDICROSS MEDI STRIP', N'', N'MEDICROSS MEDI STRIP', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'28010004', N'DYNASTY PAD SILVER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3|010001', N'KIM SHOECREAM PLISH BLACK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3|010002', N'KIM SHOECREAM PLISH BLACK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010002', N'47 ZIMPWDRCLNSRCALCAN500G', N'47 ZIMPWDRCLNSRCALCAN500G', N'47 ZIMPWDRCLNSRCALCAN500G', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010003', N'47 ZIMPWDRCLNSRCALREF350G', N'47 ZIM CLEANSER RFL CALAMANSI350GX12', N'47 ZIMPWDRCLNSRCALREF350G', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010004', N'ZIM CLEANSERFLORAL 144/CS', N'', N'ZIM CLEANSERFLORAL 144/CS', 144, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010005', N'47 ZIMPWDRCLNSRFLOCAN500G', N'47 ZIMPWDRCLNSRFLOCAN500G', N'47 ZIMPWDRCLNSRFLOCAN500G', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010006', N'47 ZIMPWDRCLNSRFLOREF350', N'47 ZIMPWDRCLNSRFLOREF350', N'47 ZIMPWDRCLNSRFLOREF350', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010007', N'ZIM CLEANSER FLORAL REF', N'', N'', 48, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010008', N'ZIM CLENSR FLRALCAN 48/CS', N'', N'ZIM CLENSR FLRALCAN 48/CS', 48, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010009', N'Z CLNSR FLRALCAN 24/CS', N'', N'Z CLNSR FLRALCAN 24/CS', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010010', N'ZIM CLEANSER CALAMANSI', N'', N'ZIM CLEANSER CALM 144/CS', 144, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010011', N'ZIMCLEANSER CALMREF 48/CS', N'', N'ZIMCLEANSER CALMREF 48/CS', 48, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010012', N'ZIM CLNSR CALM CAN  48/CS', N'', N'ZIM CLNSR CALM CAN  48/CS', 48, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010013', N'ZIM CLNSR CALM CAN 24/CS', N'', N'ZIM CLNSR CALM CAN 24/CS', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010014', N'ZM CLNSRFRESHCLNREF 48/CS', N'', N'ZM CLNSRFRESHCLNREF 48/CS', 48, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010015', N'ZM CLNSR FRSHCLNCAN 48/CS', N'', N'ZM CLNSR FRSHCLNCAN 48/CS', 48, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010016', N'ZM CLNSR FRESHCLEAN 24/CS', N'', N'ZM CLNSR FRESHCLEAN 24/CS', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010032', N'47 ZIMPWDRCLNSRCALCAN350G', N'47 ZIM CLEANSER CALAMANSI CAN 350GX12', N'47 ZIMPWDRCLNSRCALCAN350G', 12, N'ZIM', N'', N'', N'COMARK')
GO
print 'Processed 800 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010033', N'47 ZIMPWDRCLNSRFLOCAN350G', N'47 ZIMPWDRCLNSRFLOCAN350G', N'47 ZIMPWDRCLNSRFLOCAN350G', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010034', N'47 ZIM CLNSRCLMNSIREF150G', N'47 ZIM CLNSRCLMNSIREF150G', N'47 ZIM CLNSRCLMNSIREF150G', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010035', N'47 ZIM CLNSRFLOREF 150G', N'47 ZIM CLNSRFLOREF 150G', N'47 ZIM CLNSRFLOREF 150G', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010037', N'47 ZIMPDRCLNSRFRCLNCAN500', N'47 ZIMPDRCLNSRFRCLNCAN500', N'47 ZIMPDRCLNSRFRCLNCAN500', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010038', N'47 ZIMPDRCLNSRFRCLNREF350', N'47 ZIM CLEANSER RFL FRESHCLN 350GX12', N'47 ZIMPDRCLNSRFRCLNREF350', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010048', N'ZIM CLEANSER CALAMANSI', N'', N'ZIM CLEANSER CALAMANSI', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010049', N'ZIM CLEANSER FLORAL REF.', N'', N'ZIM CLEANSER FLORAL', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010057', N'ZIM CLEANSER FLORAL REF', N'', N'ZIM CLEANSER FLORAL REF', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010058', N'ZIM CLEANSER FLORAL CAN', N'', N'ZIM CLEANSER FLORAL CAN', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010059', N'ZIM CLEANSER FLORAL CAN', N'', N'ZIM CLEANSER FLORAL CAN', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010060', N'Z. CLEANSER CALAMANSI REF', N'', N'Z CLEANSER CALAMANSI REF', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010061', N'Z. CLEANSER CALAMANSI CAN', N'', N'Z CLEANSER CALAMANSI CAN', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010062', N'Z. CLEANSER CALAMANSI CAN', N'', N'Z CLEANSER CALAMANSI CAN', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010063', N'ZIM CLEANSER F CLEAN REF', N'', N'ZIM CLEANSER F CLEAN REF', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010064', N'ZIM CLEANSER F. CLEAN CAN', N'', N'ZIM CLEANSER F CLEAN CAN', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010065', N'ZIM CLEANSER F. CLEAN CAN', N'', N'ZIM CLEANSER F CLEAN CAN', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010086', N'Z CLNSR FLORAL TIPID PACK', N'', N'Z CLNSR FLORAL TIPID PACK', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010087', N'Z CLEANSR FLORAL SCNT REF', N'', N'Z CLEANSR FLORAL SCNT REF', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010088', N'Z CLEANSR FLORAL SCNT CAN', N'', N'Z CLEANSR FLORAL SCNT CAN', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010089', N'Z CLEANSR FLORAL SCNT CAN', N'', N'Z CLEANSR FLORAL SCNT CAN', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010090', N'Z CLEANSER CALAMANSI', N'', N'Z CLNSR CALMANSI TIPID PK', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010091', N'Z CLNSR CALMANSI SCNT REF', N'', N'Z CLNSR CALMANSI SCNT REF', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010092', N'Z CLNSR CALAMNSI SCNT CAN', N'', N'Z CLNSR CALAMNSI SCNT CAN', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010093', N'Z CLNSR CALAMNSI SCNT CAN', N'', N'Z CLNSR CALAMNSI SCNT CAN', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010094', N'Z CLNSR FRESH CLEAN REF', N'', N'Z CLNSR FRESH CLEAN REF', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010095', N'Z CLNSR FRESH CLEAN CAN', N'', N'Z CLNSR FRESH CLEAN CAN', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010096', N'Z CLNSR FRESH CLEAN CAN', N'', N'Z CLNSR FRESH CLEAN CAN', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010106', N'ZIM CLNSR FRSH CLN', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010107', N'ZIM FRESH CLEAN REF. 150G', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010108', N'ZIM FRESH CLEAN REF. 150G', N'', N'', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010113', N'Z.CLNSR FLORL 150+150REF', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010119', N'ZIM CLNSR CAL.150+150REF', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31010122', N'ZIM POWDERR CLEANSER FC', N'ZIM POWDER CLEANSER FRESH CLEAN', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020006', N'Z SCRNG PAD REGULAR SMALL', N'', N'Z SCRNG PAD REGULAR SMALL', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020012', N'ZIM HEAVY DUTY', N'', N'', 72, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020013', N'EZ ALL-PURPOSE SPONGE', N'', N'EZ SPONGE MEDIUM', 1, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020014', N'EZ ALL-PURPOSE SPONGE', N'', N'EZ SPONGE SMALL', 1, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020015', N'EZ ALL-PURPOSE SPONGE', N'', N'EZ SPONGE S-SHAPE', 1, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020017', N'Z SCPAD REG W/S M 12', N'', N'Z SCPAD REG W/S M 12', 48, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020024', N'CELL SPONGE RECTANGULAR', N'', N'CELL SPONGE RECTANGULAR', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020025', N'CELL SPONGE SCRUB SPONGE', N'', N'CELL SPONGE SCRUB SPONGE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020027', N'CELL SPONGE RECTANGULAR', N'', N'CELL SPONGE RECTANGULAR', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020030', N'EZ ALL PURPOSE SPONGE', N'', N'EZ ALL PURPOSE SPONGE', 12, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020031', N'EZ SPONGE SMALL', N'', N'', 48, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020032', N'EZ ALL PURPOSE SPONGE', N'', N'EZ ALL PURPOSE SPONGE', 12, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020033', N'EZ SPONGE MEDIUM', N'', N'', 48, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020034', N'EZ EASY GRIP SPNGE', N'', N'EZ EASY GRIP SPNGE', 12, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020035', N'EZ SPONGE S-SHAPED', N'', N'', 48, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020038', N'Z SCRNG PAD REG. SMALL', N'', N'SCOURING PAD REG SMALL', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020039', N'Z SCRNG PAD REG. MEDIUM', N'', N'SCOURING PAD REG MEDIUM', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020040', N'Z.SCOURING PAD HEAVY DUTY', N'', N'SCOURING PAD HEAVY DUTY', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020041', N'SCOURING PAD W/SPONGE SML', N'', N'SCOURING PAD W/SPONGE SML', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020042', N'SCOURING PAD W/SPONGE MED', N'', N'SCOURING PAD W/SPONGE MED', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020043', N'SCOURING PAD BUNOT CARD', N'', N'SCOURING PAD BUNOT CARD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020050', N'Z CELL SPONGE SINGLE RECT', N'', N'Z CELL SPONGE SINGLE RECT', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020052', N'Z CELL SPNGE DOUBLE RECT', N'', N'Z CELL SPNGE DOUBLE RECT', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020053', N'Z CELL SCRUB SPNGE PK', N'', N'Z CELL SCRUB SPNGE PK', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020055', N'Z SCRNG PAD REGULAR MED', N'', N'Z SCRNG PAD REGULAR MED', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020056', N'Z SCRNG PAD REG LRG /PK', N'', N'Z SCRNG PAD REG LRG /PK', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020057', N'Z SCRNG PAD HEAVY DUTY', N'', N'Z SCRNG PAD HEAVY DUTY', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020058', N'Z SCRNG PAD W/SPONGE SML', N'', N'Z SCRNG PAD W/SPONGE SML', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020059', N'Z SCRNG PAD W/SPONGE MED', N'', N'Z SCRNG PAD W/SPONGE MED', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020060', N'Z SCRNGPAD BUNOT CRD SML', N'', N'Z SCRNGPAD BUNOT CRD SML', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020063', N'ZIM SCOURING PAD LARGE', N'', N'ZIM SCOURING PAD LARGE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020103', N'ZIM SCRUB JR. SINGLES', N'', N'SCRUB JR.', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020105', N'ZIM ALL-PURPOSE SPONGE', N'', N'AP SPONGE EASY GRIP KKAY', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020107', N'ZIM DOUBLE DUTY 100X80X27', N'', N'DOUBLE DUTY', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020112', N'ALL PURPOSE SPONGE(KIKAY)', N'', N'ALL PURP SPONGE SML KKAY', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020116', N'ZIM TRIPLE VALUE PACK', N'', N'ZIM TRIPLE VALUE PACK', 4, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020117', N'ZIM TRIPLE VALUE PACK', N'', N'', 48, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020118', N'ZIM SCRUB JR.', N'', N'ZIM SCRUB JR.', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020119', N'SCRUB JUNIOR', N'', N'', 72, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020123', N'ZIM EASY GRIP', N'', N'ZIM EASY GRIP', 100, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020128', N'ZIM DOUBLE DUTY', N'', N'ZIM DOUBLE DUTY', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020129', N'DOUBLE DUTY', N'', N'', 72, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020130', N'ZIM POWER SCRUBBER', N'', N'ZIM POWER SCRUBBER', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020131', N'ZIM POWER SCRUBBER', N'', N'', 72, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020144', N'ZIM ALL-PURPSE SPNGE', N'', N'ZIM ALL-PURPSE SPNGE', 100, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020145', N'ZIM TRIPLE VALUE', N'TRIPLE VALUE PACK 3''S PACK 75 X 100 X 30MM', N'ZIM TRIPLE VALUE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020154', N'REG.SCOURING PAD(HANGERS)', N'', N'SCRNG PAD REG SML HANGER', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020155', N'ZSPD REG. SMALL HANGER', N'', N'ZSPD REG. SMALL HANGER', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020156', N'SCRNG PAD REG MED HANGER', N'', N'SCRNG PAD REG MED HANGER', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020157', N'ZSPD REG. MEDIUM HANGER', N'', N'ZSPD REG. MEDIUM HANGER', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020158', N'SCRNG PAD W/SPNG SML HANG', N'', N'SCRNG PAD W/SPNG SML HANG', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020159', N'ZSPD W/SPNGE SMALL HANGER', N'', N'ZSPD W/SPNGE SMALL HANGER', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020160', N'SCRNG PAD W/SPNG MED HANG', N'', N'SCRNG PAD W/SPNG MED HANG', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020161', N'ZSPD W/SPNGE MED. HANGER', N'', N'ZSPD W/SPNGE MED. HANGER', 6, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020162', N'Z.SCRUB JR.SINGLE(HANGER)', N'', N'SCRUB JR. HANGER', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020163', N'ZIM SCRUB JR. HANGER', N'', N'ZIM SCRUB JR. HANGER', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020164', N'POWER SCRUBBER HANGER', N'', N'POWER SCRUBBER HANGER', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020165', N'ZIM POWER SCRUBBER HANGER', N'', N'ZIM POWER SCRUBBER HANGER', 6, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020166', N'DOUBLE DUTY HANGER', N'', N'DOUBLE DUTY HANGER', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020167', N'ZIM DOUBLE DUTY HANGER', N'', N'ZIM DOUBLE DUTY HANGER', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020169', N'ALL-PURPOSE SPONGE 2''S PK', N'ALL-PURPOSE SPONGE 2''S PACK', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020181', N'REGULAR SCOURING PAD 4''S', N'REGULAR SCOURING PAD 4''S PACK SMALL', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020182', N'REGULAR SCOURING PAD 4''S', N'REGULAR SCOURING PAD 4''S PACK MEDIUM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020183', N'SCOURING PAD W/SPONGE 4''S', N'SCOURING PAD W/SPONGE 4''S PACK SMALL', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020184', N'SCOURING PAD W/SPONGE 4''S', N'SCOURING PAD W/SPONGE 4''S PACK MEDIUM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020185', N'SCRUB JR. 4''S PACK', N'SCRUB JR. 4''S PACK 75 X 75 X 30MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020186', N'DOUBLE DUTY 4''S PACK', N'DOUBLE DUTY 4''S PACK100X80X27MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020187', N'POWER SCRUBBER 4''S PACK', N'POWER SCRUBBER 4''S PACK STEEL BALL', N'', 1, N'', N'', N'', N'COMARK')
GO
print 'Processed 900 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020188', N'ALL-PURPOSE SPONGE 4''S', N'ALL-PURPOSE SPONGE 4''S PACK SMALL', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020190', N'HEAVY DUTY 4''S PACK', N'HEAVY DUTY 4''S PACK 75X100X20MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020191', N'EZ ALL-PURPOSE SPONGE 4''S', N'EZ ALL-PURPOSE SPONGE 4''S PACK SMALL', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020192', N'EZ ALL-PURPOSE SPONGE 4''S', N'EZ ALL-PURPOSE SPONGE 4''S MEDIUM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020194', N'TRIPLE VALUE PACK 3''S PCK', N'TRIPLE VALUE PACK 3''S PACK 75X100X30MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020195', N'ALL-PURPOSE SPONGE 2''S PK', N'ALL-PURPOSE SPONGE 2''S PACK S-SHAPED', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020196', N'ZIM ALL PURPOSE SPONGE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020203', N'ZIM POWER SCRUBBER', N'', N'ZIM POWER SCRUBBER', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020204', N'ZIM POWER SCRUBBER', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020205', N'ZIM POWER SCRUBBER', N'', N'', 72, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020215', N'A.P. SPONGE SINGLE(KIKAY)', N'ALL-PURPOSE SPONGE SINGLES 100X75X40MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020216', N'ALL PURPOSE SPONGE SINGLE', N'ALL-PURPOSE SPONGE SINGLE 145X100X40MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020217', N'REG SCOURING PAD 75X100X7', N'REGULAR SCOURING PAD SINGLES 75X100X7MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020218', N'REG SCOURING PAD SINGLES', N'REGULAR SCOURING PAD SINGLES 96X150X7MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020219', N'HEAVY DUTY SINGLE', N'HEAVY DUTY SINGLE 75X100X20MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020220', N'DOUBLE DUTY SINGLES', N'DOUBLE DUTY SINGLES 100X80X27MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020221', N'SCOURING PAD W/SPONGESNGL', N'SCOURING PAD W/SPONGE SINGLES 75X100X30MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020222', N'SCOURING PAD W/SPONGESNGL', N'SCOURING PAD W/SPONGE SINGLES 96X150X30MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020225', N'POWER SCRUBBER SINGLES', N'POWER SCRUBBER SINGLES STEEL BALL', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020226', N'SCRUB JR. SINGLES', N'SCRUB JR. SINGLES 75X75X30MM', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020237', N'ZIM REG. SCRNG. PAD JR.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020271', N'ZIM ALL PURPOSE SPONGE JR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020279', N'Z. TRIPLE VALUE SCRUB JR.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31020284', N'Z SCRUB SPONGE JR HANGER', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31040010', N'ZIM LIQUID ZOSA', N'', N'ZIM Z O S A', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31040011', N'ZIM LIQUID ZOSA', N'', N'ZIM Z O S A', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31040012', N'ZIM  LIQUID Z O S A', N'', N'ZIM  LIQUID Z O S A', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31040013', N'ZIM  LIQUID Z O S A', N'', N'ZIM  LIQUID Z O S A', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31040015', N'ZIM ZOSA 500ML X 4''S', N'47 ZIM ZOSA 500ML X 4''S', N'47 ZIM ZOSA 500ML X 4''S', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060001', N'Z G CLNR POTPOURRI THEAD', N'', N'Z G CLNR POTPOURRI THEAD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060002', N'Z G CLNR POTPOURRI REF500', N'', N'Z G CLNR POTPOURRI REF500', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060004', N'Z. G CLEANER LEMON REFILL', N'', N'Z G CLEANER LEMON 250 REF', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060005', N'Z G CLEANER LEMON REFILL', N'', N'Z G CLEANER LEMON REFILL', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060006', N'Z. G CLEANER LEMON T-HEAD', N'', N'Z G CLNR LEMON 250 THEAD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060007', N'Z G CLNR LEMON W/TRG-HEAD', N'', N'Z G CLNR LEMON W/TRG-HEAD', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060008', N'Z. G CLEANER LEMON REFILL', N'', N'Z CLEANER LEMON 500ML REF', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060009', N'Z G CLEANER LEMON REFILL', N'', N'Z G CLEANER LEMON REFILL', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060010', N'Z. G CLEANER LEMON T-HEAD', N'', N'Z G CLNR LEMON 500 THEAD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060012', N'Z G CLNR LEMON W/TRG-HEAD', N'', N'Z G CLNR LEMON W/TRG-HEAD', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060030', N'Z. G. CLEANER REG. REFILL', N'', N'G CLEANER REGULAR REFILL', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060031', N'Z. G CLEANER REG. T-HEAD', N'', N'G CLEANER REG W/T-HEAD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060032', N'Z. G CLEANER APPLE T-HEAD', N'', N'G CLEANER APPLE W/T-HEAD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060033', N'Z. G CLEANER APPLE REFILL', N'', N'G CLEANER APPLE REFILL', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060045', N'Z. G CLEANER REG. T-HEAD', N'', N'G CLEANER REG W/T-HEAD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060046', N'Z. G CLEANER REG. REFILL', N'', N'G CLEANSER REGULAR REF', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060047', N'Z. G CLEANER APPLE T-HEAD', N'', N'G CLEANER APPLE W/T-HEAD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060048', N'Z. G CLEANER APPLE REFILL', N'', N'G CLEANER APPLE REFILL', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060049', N'47 ZM GL CLNR PRME RG 500', N'47 ZM GLSSCLNRPRME REG500', N'47 ZM GL CLNR PRME RG 500', 2, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060050', N'Z G CLNR REG W/TRG-HEAD', N'', N'Z G CLNR REG W/TRG-HEAD', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060051', N'Z GLS CLNR REGULAR REFILL', N'', N'Z GLS CLNR REGULAR REFILL', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060052', N'Z G CLNR REG W/TRG-HEAD', N'', N'Z G CLNR REG W/TRG-HEAD', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060053', N'Z GLS CLNR REGULAR REFILL', N'', N'Z GLS CLNR REGULAR REFILL', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060054', N'Z G CLNR APPLE W/TRG-HEAD', N'', N'Z G CLNR APPLE W/TRG-HEAD', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060055', N'Z GLS CLNR APPLE REFILL', N'', N'Z GLS CLNR APPLE REFILL', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060056', N'Z G CLNR APPLE W/TRG-HEAD', N'', N'Z G CLNR APPLE W/TRG-HEAD', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060057', N'Z GLS CLNR APPLE REFILL', N'', N'Z GLS CLNR APPLE REFILL', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060060', N'47 ZM GLSCLNRAPPLE THD500', N'47 ZIM GLASS CLNR APL TRIG 500MLX2', N'47 ZM GLSCLNRAPPLE THD500', 2, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060061', N'Z G CLNR POTPOURRI REF250', N'', N'Z G CLNR POTPOURRI REF250', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060062', N'Z G CLNR POTPOURRI THEAD', N'', N'Z G CLNR POTPOURRI THEAD', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060067', N'47 ZIM GLASCLNR REGREF250', N'47 ZIM GLASCLNR REGREF250', N'47 ZIM GLASCLNR REGREF250', 2, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060072', N'47 ZIMGLSCLNR LEMONTHD500', N'47 ZIM GLASS CLNR LEM TRIG 500MLX2', N'47 ZIMGLSCLNR LEMONTHD500', 2, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060073', N'Z. G CLEANER STRAW T-HEAD', N'', N'', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060074', N'Z GLASS CLNR STRAW W/THD', N'', N'Z GLASS CLNR STRAW W/THD', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060075', N'Z. G CLEANER STRAW REFILL', N'', N'', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060076', N'Z GLASS CLNR STRAW REF', N'', N'Z GLASS CLNR STRAW REF', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060077', N'Z. G CLEANER STRAW T-HEAD', N'', N'', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060078', N'Z GLASS CLNR STRAW W/THD', N'', N'Z GLASS CLNR STRAW W/THD', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060079', N'Z. G CLEANER STRAW REFILL', N'', N'', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31060080', N'Z GLASS CLNR STRAW REF', N'', N'Z GLASS CLNR STRAW REF', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31100003', N'TOILET BOWL BRUSH RED', N'', N'TOILET BOWL BRUSH RED', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31100008', N'Z TOILET BWL BRSH BLUE PK', N'', N'Z TOILET BWL BRSH BLUE PK', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31100009', N'Z TOILET BWL BRSH RED PK', N'', N'Z TOILET BWL BRSH RED PK', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31110003', N'ZIM FISH DEO GARDEN 50G', N'', N'ZIM FISH DEO GARDEN 50G', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31130001', N'47 ZIM DWSHING LIQD 250ML', N'47 ZIM DWSHING LIQD 250ML', N'47 ZIM DWSHING LIQD 250ML', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31130003', N'Z DSH WSHNG LQUID LEMON', N'', N'Z DSH WSHNG LQUID LEMON', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31130005', N'ZIM DISHWASHING LIQUID', N'', N'ZIM DISHWASHING LIQUID', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31130006', N'Z DSH WSHNG LIQUID LEMON', N'', N'Z DSH WSHNG LIQUID LEMON', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31130008', N'ZIM DISHWASHING LIQUID', N'', N'ZIM DISHWASHING LIQUID', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31140005', N'Z PDET TULTRA 32GSAC', N'', N'Z PDET TULTRA 32GSAC', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31140006', N'Z PDET APURP 32GSAC', N'', N'Z PDET APURP 32GSAC', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31200001', N'ZIM L.FLOOR WAX NATURAL', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31200003', N'ZIM L.FLOOR WAX RED', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31200005', N'ZIM L.FLOOR WAX NATURAL', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31200007', N'ZIM L.FLOOR WAX RED', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31220001', N'ZIM.APC.CLEAN LEMON SCENT', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31220003', N'ZIM.APC MORNING BREEZE', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31220005', N'ZIM.APC CLEAN LEMON SCENT', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'31220007', N'ZIM.APC MORNING BREEZE', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'32010003', N'PENGUIN GLOVES SMALL', N'', N'PENGUIN GLOVES SMALL', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'32020004', N'BUTERFLY GLOVES MEDIUM', N'', N'BUTERFLY GLOVES MEDIUM', 1, N'BABYJOY', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35020026', N'ORCHID GLOVES', N'', N'ORCHID GLOVES', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030002', N'ORCHID DEO APPLE REFILL', N'', N'O DEO APPLE REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030003', N'ORCHID DEO APPLE W/HOLDER', N'', N'O DEO APPLE W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030004', N'ORCHID DEO APPLE W/HOLDER', N'', N'O DEO APPLE W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030005', N'ORCHID DEO CHERRY W/HOLDE', N'', N'O DEO CHERRY W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030006', N'ORCHID DEO CHERRY W/HOLDE', N'', N'O DEO CHERRY W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030008', N'ORCHID DEO LEMON W/HOLDER', N'', N'O DEO LEMON W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030009', N'ORHCID DEO LEMON W/HOLDER', N'', N'O DEO LEMON W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030010', N'ORCHID DEO STRAW W/HOLDER', N'', N'O DEO STRAWBERRY W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030011', N'ORCHID DEO STRAW W/HOLDER', N'', N'O DEO STRAWBERRY W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030012', N'ORCHID DEO SAMPAGUITA W/H', N'', N'O DEO SAMPAGUITA W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
GO
print 'Processed 1000 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030013', N'ORCHID DEO SAMPAGUITA W/H', N'', N'O DEO SAMPAGUITA W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030015', N'ORCHID DEO SAMPAGUITA REF', N'', N'O DEO SAMPAGUITA REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030016', N'ORCHID DEO APPLE REFILL', N'', N'O DEO APPLE REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030017', N'ORCHID DEO CHERRY REFILL', N'', N'O DEO CHERRY REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030018', N'ORCHID DEO CHERRY REFILL', N'', N'O DEO CHERRY REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030019', N'ORCHID DEO LEMON REFILL', N'', N'O DEO LEMON REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030020', N'ORCHID DEO LEMON REFILL', N'', N'ORCHID DEO LEMON REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030021', N'ORCHID DEO STRAW REFILL', N'', N'O DEO STRAWBERRY REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030022', N'ORCHID DEO STRAW REFILL', N'', N'O DEO STRAWBERRY REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030023', N'ORCHID DEO SAMPAGUITA REF', N'', N'O DEO SAMPAGUITA REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030031', N'ORCHID DEO F.DEWBERRY W/H', N'', N'O DEO F DEWBERRY W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030032', N'ORCHID DEO F.DEWBERRY W/H', N'', N'O DEO F DEWBERRY W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030033', N'ORCHID DEO F.DEWBERRY REF', N'', N'O DEO F DEWBERRY REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030034', N'ORCHID DEO F.DEWBERRY REF', N'', N'O DEO F DEWBERRY REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030035', N'ORCHID DEO J.SAMBA W/HOLD', N'', N'O DEO J SAMBA W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030036', N'ORCHID DEO J.SAMBA REFILL', N'', N'O DEO J SAMBA REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030051', N'ORCHID DEO J.SAMBA REFILL', N'', N'O DEO J SAMBA REFILL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030052', N'ORCHID DEO J.SAMBA W/HOLD', N'', N'O DEO J SAMBA W/HOLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030057', N'ORCHID DEODRZER LEMON REF', N'', N'ORCHID DEODRZER LEMON REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030058', N'ORCHID DEO CHERRY REF', N'', N'ORCHID DEO CHERRY REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030059', N'ORC DEO STRAWBERRY REF', N'', N'ORC DEO STRAWBERRY REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030060', N'ORCHID DEO SAMPAGUITA REF', N'', N'ORCHID DEO SAMPAGUITA REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030061', N'ORCHID DEO APPLE REF', N'', N'ORCHID DEO APPLE REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030062', N'OR DEO JAZZY SAMBA REF', N'', N'OR DEO JAZZY SAMBA REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030063', N'OR DEO FRUITYDEWBERRY REF', N'', N'OR DEO FRUITYDEWBERRY REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030064', N'ORCHID DEODRZER LEMON REF', N'', N'ORCHID DEODRZER LEMON REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030065', N'ORCHID DEO CHERRY REF', N'', N'ORCHID DEO CHERRY REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030066', N'ORC DEO STRAWBERRY REF', N'', N'ORC DEO STRAWBERRY REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030067', N'ORCHID DEO SAMPAGUITA REF', N'', N'ORCHID DEO SAMPAGUITA REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030068', N'ORCHID DEO APPLE REF', N'', N'ORCHID DEO APPLE REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030069', N'OR DEO JAZZY SAMBA REF', N'', N'OR DEO JAZZY SAMBA REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030070', N'OR DEO FRUITYDEWBERRY REF', N'', N'OR DEO FRUITYDEWBERRY REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030071', N'ORC DEO LEMON W/ HOLDER', N'', N'ORC DEO LEMON W/ HOLDER', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030072', N'ORC DEO CHERRY W/HOLDER', N'', N'ORC DEO CHERRY W/HOLDER', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030073', N'OR DEO STRAWBERRY W/HOLDR', N'', N'OR DEO STRAWBERRY W/HOLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030074', N'OR DEO SAMPAGUITA W/HOLDR', N'', N'OR DEO SAMPAGUITA W/HOLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030075', N'OR DEO APPLE W/ HOLDER', N'', N'OR DEO APPLE W/ HOLDER', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030076', N'OR DEO JAZZYSAMBA W/HOLDR', N'', N'OR DEO JAZZYSAMBA W/HOLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030077', N'OR DEO FRUITDWBRY W/HOLDR', N'', N'OR DEO FRUITDWBRY W/HOLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030078', N'ORC DEO W/HOLDER LEMON', N'', N'ORC DEO W/HOLDER LEMON', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030079', N'ORC DEO CHERRY W/HOLDER', N'', N'ORC DEO CHERRY W/HOLDER', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030080', N'OR DEO STRAWBERRY W/HOLDR', N'', N'OR DEO STRAWBERRY W/HOLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030081', N'OR DEO SAMPAGUITA W/HOLDR', N'', N'OR DEO SAMPAGUITA W/HOLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030082', N'OR DEO APPLE W/ HOLDER', N'', N'OR DEO APPLE W/ HOLDER', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030083', N'OR DEO JAZZYSAMBA W/HOLDR', N'', N'OR DEO JAZZYSAMBA W/HOLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030084', N'OR DEO FRUITDWBRY W/HOLDR', N'', N'OR DEO FRUITDWBRY W/HOLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030085', N'ORCD DEO W/O HOLD LEM 50G', N'', N'ORCD DEO W/O HOLD LEM 50G', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030086', N'ORCD DEO W/O HOLD CHRY50G', N'', N'ORCD DEO W/O HOLD CHRY50G', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030087', N'ORCD DEO W/O HOLD STRW50G', N'', N'ORCD DEO W/O HOLD STRW50G', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030088', N'ORCD DEO W/O HOLD SAM 50G', N'', N'ORCD DEO W/O HOLD SAM 50G', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030089', N'ORCD DEO W/O HOLD APLE50G', N'', N'ORCD DEO W/O HOLD APLE50G', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030090', N'O DEO JAZZY SAMBA REFILL', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030091', N'O DEO F DEWBERRY REFILL', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030092', N'ORCD DEO LEMON REFILL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030093', N'ORCHD DEO CHERRY REFILL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030094', N'ORCD DEO STRWBERRY REFILL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030095', N'ORCD DEO SAMPAGUITA REFIL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030096', N'ORCD BATH DEO APPLE REFIL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030097', N'ORCD DEO JAZZYSAMBA REFIL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030098', N'ORCD DEO DEWBERRY REFILL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030099', N'ORCD DEO LEMON W/HOLDER', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030100', N'ORCD DEO CHERRY W/HOLDER', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030101', N'ORCD DEO STRWBERRY W/HOLD', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030102', N'O DEO SAMPAGUITA W/HOLDER', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030103', N'O BATH DEO APPLE REF W/HO', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030104', N'ORCD DEO JAZZYSAMBA W/HOL', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030105', N'ORCD DEO DEWBERRY W/HOLDE', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030106', N'ORCD DEO LEMON W/HOLDER', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030107', N'ORCD DEO CHERRY W/HOLDER', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030108', N'ORCD DEO STRWBERRY W/HOLD', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030109', N'ORCHD DEO SAMPGTA W/HOLDE', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030110', N'ORCD DEO APPLE REF W/HOLD', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030111', N'ORCD DEO JAZZYSAMBA W/HOL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030112', N'ORCD DEO DEWBERRY W/HOLDE', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030148', N'47 ORCHID DEOREF 50GASSTD', N'47 ORCHID DEODORIZER ASSTD RFL50GX12', N'47 ORCHID DEOREF 50GASSTD', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030149', N'47 ORCHID DEOREF100GASSTD', N'47 ORCHID DEOREF100GASSTD', N'47 ORCHID DEOREF100GASSTD', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030152', N'ORCHID DEO ORANGE REFILL', N'', N'OR DEO ORNGE 50G REF', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030153', N'ORCHID DEO ORNGE 50G REF', N'', N'ORCHID DEO ORNGE 50G REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030154', N'ORCHID DEO ORANGE REFILL', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030155', N'ORCHID DEO ORANGE W/HOLDE', N'', N'OR DEO ORNGE 50G W/HLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030156', N'ORCHD DEO ORNGE 50GW/HLDR', N'', N'ORCHD DEO ORNGE 50GW/HLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030157', N'ORCHID DEO ORNGE W/HOLDER', N'', N'', 72, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030158', N'ORCHID DEO ORANGE REFILL', N'', N'OR DEO ORNGE 100G REF', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030159', N'ORCHID DEO ORNGE 100G REF', N'', N'ORCHID DEO ORNGE 100G REF', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030160', N'ORCD DEO ORANGE REFILL', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030161', N'ORCHID DEO ORANGE W/HOLDE', N'', N'OR DEO ORNGE 100G W/HLDER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030162', N'ORCHD DEO ORNGE100GW/HLDR', N'', N'ORCHD DEO ORNGE100GW/HLDR', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030163', N'ORCD DEO ORANGE W/HOLDER', N'', N'', 48, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030207', N'ORCHID DEO MELON REFILL', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030208', N'ORCHID DEO MELON REF. 50G', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030209', N'ORCHID DEO MELON REF. 50G', N'', N'', 72, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030210', N'ORCHID DEO MELON REFILL', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030211', N'ORCHID DEO MELON REF 100G', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030212', N'ORCHID DEO MELON REF 100G', N'', N'', 48, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030213', N'ORCHID DEO MELON W\HOLDER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030214', N'ORCHID DEO MELON W/H 50G', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030215', N'ORCHID DEO MELON W/H 100G', N'', N'', 72, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030216', N'ORCHID DEO MELON W/HOLDER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030219', N'ORCIHD DEO BLUE BERRY REF', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030222', N'ORCHID DEO BLUE BERRY REF', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030225', N'O DEO BLUE BERRY W\HOLDER', N'', N'', 1, N'', N'', N'', N'COMARK')
GO
print 'Processed 1100 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35030228', N'O DEO BLUE BERRY W/HOLDER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040003', N'ORCD NAPTH BALLS REGULAR', N'', N'', 144, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040004', N'ORCHIDS NAPTHALENE BALLS', N'', N'ORCHIDS NAPTHALENE BALLS', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040005', N'ORCD NAPTH BALLS REGULAR', N'', N'', 180, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040009', N'ORCHID NAPHTHALENE BALLS', N'', N'', 120, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040012', N'ORCHID NAPTHA.BALLS REG.', N'', N'ORCHIDS NAPTHALENE BALLS', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040016', N'ORCHID NAPTHA.BALLS REG.', N'', N'ORCHIDS NAPTHALENE BALLS', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040017', N'ORCHID NAPTHA BALLS REG.', N'', N'ORCHIDS NAPTHALENE BALLS', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040047', N'ORC NAPTHALENE BALLS  REG', N'', N'ORC NAPTHALENE BALLS  REG', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040048', N'ORC NAPTHALENE BALLS  REG', N'', N'ORC NAPTHALENE BALLS  REG', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040049', N'ORC NAPTHALENE BALLS  REG', N'', N'ORC NAPTHALENE BALLS  REG', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040050', N'OR NAPTH BLLS REG 200G PK', N'', N'OR NAPTH BLLS REG 200G PK', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35040054', N'47 ORCHID NAPTBALLS 100G', N'47 ORCHID NAPTBALLS 100G', N'47 ORCHID NAPTBALLS 100G', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070006', N'ALL-PURPOSE SPRAYER OVAL', N'', N'AL PURP SPRAYER OVAL TRAN', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070009', N'ALL-PURPOSE SPRAYER TRANS', N'', N'AL PURP SPRAYER L SHAPE', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070010', N'ALL-PURPOSE SPRAYER OVAL', N'', N'ALL PURPOSE SPRAYER OVAL', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070012', N'OR APUR SPYR OVL OPAQ RED', N'', N'OR APUR SPYR OVL OPAQ RED', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070013', N'OR ALLPURP OVAL TRANS RED', N'', N'OR ALLPURP OVAL TRANS RED', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070014', N'OR ALLPUR L-SHP TRANS RED', N'', N'OR ALLPUR L-SHP TRANS RED', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070019', N'ORCD ALL-PUR OVAL OPAQUE', N'', N'', 24, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070020', N'ORCD ALL-PUR OVAL TRANSLU', N'', N'', 24, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'35070021', N'O ALL-PUR L-SHAPED TRANSL', N'', N'', 24, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'36020001', N'DIMPLES STYLING GEL 16GM', N'', N'DIMPLES STYLING GEL 16GM', 12, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010001', N'47 CLMURACIDCOMM 1L263406', N'47 CLMURACIDCOMM 1L263406', N'47 CLMURACIDCOMM 1L263406', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010002', N'47 CL MACIDCOM250ML263380', N'47 CL MACIDCOM250ML263380', N'47 CL MACIDCOM250ML263380', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010003', N'47 CLMACIDCOMM500ML263393', N'47 CLMACIDCOMM500ML263393', N'47 CLMACIDCOMM500ML263393', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010007', N'M ACID COMMERCIAL GRADE', N'', N'M ACID COMMERCIAL GRADED', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010008', N'M ACID COMMERCIAL GRADE', N'', N'M ACID COMMERCIAL GRADED', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010009', N'M ACID COMMERCIAL GRADE', N'', N'M ACID COMMERCIAL GRADED', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010013', N'MURIATIC ACID COMMERCIAL', N'', N'MURIATIC ACID COMMERCIAL', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010014', N'MURIATIC ACID COMMERCIAL', N'', N'MURIATIC ACID COMMERCIAL', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010015', N'MURIATIC ACID COMMERCIAL', N'', N'MURIATIC ACID COMMERCIAL', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010020', N'MURIATIC ACID COMMERCIAL', N'', N'MURIATIC ACID COMMERCIAL', 48, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010021', N'MURIATIC ACID COMMERCIAL', N'', N'MURIATIC ACID COMMERCIAL', 24, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010022', N'47 CL MACID COMM250MLX12S', N'47 CL MACID COMM250MLX12S', N'47 CL MACID COMM250MLX12S', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010023', N'47 CL MCACIDCOMM500MLX 6S', N'47 CL MCACIDCOMM500MLX 6S', N'47 CL MCACIDCOMM500MLX 6S', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'38010024', N'47 CL MACID COMM 1L X 4S', N'47 CL MACID COMM 1L X 4S', N'47 CL MACID COMM 1L X 4S', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010001', N'M ACID CONCENTRATED GRADE', N'', N'M ACID CONCENTRATED', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010002', N'M ACID CONCENTRATED GRADE', N'', N'M ACID CONCENTRATED', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010003', N'M ACID CONCENTRATED GRADE', N'', N'M ACID CONCENTRATED', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010004', N'M ACID CONCENTRATED GRADE', N'', N'M ACID CONCENTRATED', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010005', N'47 CL MACID CONC 500ML8S', N'47 CL MACID CONC 500ML8S', N'47 CL MACID CONC 500ML8S', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010007', N'47 CL MACIDCONC1GAL263432', N'47 CL MURIATIC ACID CONC 1GAL', N'47 CL MACIDCONC1GAL263432', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010008', N'47 CL MACID CONC 1L263445', N'47 CL MACID CONC 1L263445', N'47 CL MACID CONC 1L263445', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010009', N'47 CLMACIDCONC250ML263419', N'47 CLMACIDCONC250ML263419', N'47 CLMACIDCONC250ML263419', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010010', N'MURIATIC ACID CONCENTRATE', N'', N'MURIATIC ACID CONCENTRATE', 48, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010014', N'M ACID CONCENTRATED GRADE', N'', N'M ACID CONCENTRATED', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010017', N'MURIATIC ACID CONCENTRATE', N'', N'MURIATIC ACID CONCENTRATE', 24, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010020', N'MURIATC ACID CONCENTRATED', N'', N'MURIATC ACID CONCENTRATED', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010021', N'MURIATC ACID CONCENTRATED', N'', N'MURIATC ACID CONCENTRATED', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010022', N'MURIATC ACID CONCENTRATED', N'', N'MURIATC ACID CONCENTRATED', 12, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010023', N'MURIATC ACID CONCENTRATED', N'', N'MURIATC ACID CONCENTRATED', 6, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010024', N'MURIATC ACID CONCENTRATED', N'', N'MURIATC ACID CONCENTRATED', 4, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010027', N'28 CL MURIATIC ACID CONC', N'', N'', 6, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'39010028', N'28 CL MURIATIC ACID CONC', N'', N'', 2, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010002', N'Z DWL 50ML B3T3', N'', N'Z DWL 50ML B3T3', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010003', N'Z DISHWL 50ML BY3TK3 24''S', N'', N'Z DISHWL 50ML BY3TK3 24''S', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010009', N'OR BATH COLLECTIBLE APPLE', N'', N'OR BATH COLLECTIBLE APPLE', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010010', N'OR BATH COLLECTIBLE CHER', N'', N'OR BATH COLLECTIBLE CHER', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010011', N'OR BATH COLLECTIBLE LEMON', N'', N'OR BATH COLLECTIBLE LEMON', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010012', N'Z D L "PLANGGANA BONANZA"', N'', N'Z D L "PLANGGANA BONANZA"', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010016', N'OR BATH COLLECTIBLE SAMP', N'', N'OR BATH COLLECTIBLE SAMP', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010017', N'OR BATH COLLECTIBLE STRAW', N'', N'OR BATH COLLECTIBLE STRAW', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010018', N'O BATH COLL APPLE 12', N'', N'O BATH COLL APPLE 12', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010019', N'O BATH COLL CHRRY 12', N'', N'O BATH COLL CHRRY 12', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010021', N'O BATH COLL LEMON 12', N'', N'O BATH COLL LEMON 12', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010022', N'O BATH COLL SAMPA 12', N'', N'O BATH COLL SAMPA 12', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010023', N'O BATH COLL SBRRY 12', N'', N'O BATH COLL SBRRY 12', 12, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010035', N'OR DEO W/H CHR50G+Z', N'', N'OR DEO W/H CHR50G+Z', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010036', N'OR DEO CHE100GREF+Z', N'', N'OR DEO CHE100GREF+Z', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010038', N'O DE DEWBERRY REF W/Z A P', N'', N'O DE DEWBERRY REF W/Z A P', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010041', N'O DEO DEWBERRY W/H+Z APUR', N'', N'O DEO DEWBERRY W/H+Z APUR', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010042', N'CL BRUSHRUSH PROMO COMM', N'', N'CL BRUSHRUSH PROMO COMM', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010045', N'CL BRSHRSH 250COM/CS', N'', N'CL BRSHRSH 250COM/CS', 16, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010046', N'OR DEO LEM100GREF+Z', N'', N'OR DEO LEM100GREF+Z', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010049', N'OR DEO W/H LEM50G+Z', N'', N'OR DEO W/H LEM50G+Z', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010050', N'OR DEO SAM100GREF+Z', N'', N'OR DEO SAM100GREF+Z', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010051', N'O DEO SAMPA W/H + Z T U', N'', N'O DEO SAMPA W/H + Z T U', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010052', N'OR DEO SAM50GREF+Z A', N'', N'OR DEO SAM50GREF+Z A', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010054', N'OR DEO STR50GREF+Z A', N'', N'OR DEO STR50GREF+Z A', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010055', N'OR DEO W/H STR50G+Z', N'', N'OR DEO W/H STR50G+Z', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010056', N'OR DEO STR100GREF+Z', N'', N'OR DEO STR100GREF+Z', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010058', N'CL BRUSHRUSH PROMO CONCEN', N'', N'CL BRUSHRUSH PROMO CONCEN', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010059', N'CL BRUSHRUSH  CON/CS', N'', N'CL BRUSHRUSH  CON/CS', 16, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010070', N'BOX O LUNCH SINGLE OFFER1', N'', N'BOX O LUNCH SINGLE OFFER1', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010071', N'BOX O LUNCH DOUBLE OFFER2', N'', N'BOX O LUNCH DOUBLE OFFER2', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010072', N'BOX-O-LUNCH OFFER1CS', N'', N'BOX-O-LUNCH OFFER1CS', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010073', N'BOX-O-LUNCH OFFER2CS', N'', N'BOX-O-LUNCH OFFER2CS', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010101', N'Z BEAUTY PROMO1', N'', N'Z BEAUTY PROMO1', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010104', N'Z BEAUTY PROMO4', N'', N'Z BEAUTY PROMO4', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010105', N'Z BEAUTY PROMO5', N'', N'Z BEAUTY PROMO5', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010118', N'Z P POWER OFFER 1 FLORAL', N'', N'Z P POWER OFFER 1 FLORAL', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010119', N'Z P POWER OFFER1 FLORAL', N'', N'Z P POWER OFFER1 FLORAL', 16, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010120', N'ZP POWER OFFER2 CALAMANSI', N'', N'ZP POWER OFFER2 CALAMANSI', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010121', N'Z P POWER OFFER2 CLMNSI', N'', N'Z P POWER OFFER2 CLMNSI', 16, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010122', N'Z P POWER OFFER3 F CLEAN', N'', N'Z P POWER OFFER3 F CLEAN', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010123', N'Z P POWER OFFER3 FRESH', N'', N'Z P POWER OFFER3 FRESH', 16, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010124', N'ZIM 342 OFFER1 SMALL 24''S', N'', N'ZIM 342 OFFER1 SMALL 24''S', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010125', N'ZIM 342 OFFER1 SMALL 24''S', N'', N'ZIM 342 OFFER1 SMALL 24''S', 24, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010126', N'ZIP 342 OFFER2 MEDIUM 24S', N'', N'ZIP 342 OFFER2 MEDIUM 24S', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010127', N'ZIM 342 OFFER2 MEDIUM 24S', N'', N'ZIM 342 OFFER2 MEDIUM 24S', 24, N'ZIM', N'', N'', N'COMARK')
GO
print 'Processed 1200 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010140', N'TRIPLE VALUE PACK', N'', N'TRIPLE VALUE PACK', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010142', N'Z GCLNR REG W/THD+HNDYRAG', N'', N'Z GCLNR REG W/THD+HNDYRAG', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010144', N'Z GCLNR APL W/THD+HNDYRAG', N'', N'Z GCLNR APL W/THD+HNDYRAG', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010146', N'Z GCLNR LEM W/THD+HNDYRAG', N'', N'Z GCLNR LEM W/THD+HNDYRAG', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010147', N'ZMCLNSR CALCN+ZCLNSR150RF', N'', N'ZMCLNSR CALCN+ZCLNSR150RF', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010148', N'Z CLNSR CALCAN+ZCALREF150', N'', N'Z CLNSR CALCAN+ZCALREF150', 10, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010150', N'ZMCLNSRFRSCLNCN+ZCLNSR150', N'', N'ZMCLNSRFRSCLNCN+ZCLNSR150', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010151', N'Z CLNSRFCLNCAN+ZFRLREF150', N'', N'Z CLNSRFCLNCAN+ZFRLREF150', 10, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010154', N'EZ SPON S-SHPE+ZIMDWL50ML', N'', N'EZ SPON S-SHPE+ZIMDWL50ML', 10, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010161', N'ZMCLNSRFLRLCN+ZCLNSR150RF', N'', N'ZMCLNSRFLRLCN+ZCLNSR150RF', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010162', N'Z CLNSR FRLCAN+ZFRLREF150', N'', N'Z CLNSR FRLCAN+ZFRLREF150', 10, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010178', N'ZGCLEM500MLWTHD+ZGC250RFL', N'', N'ZGCLEM500MLWTHD+ZGC250RFL', 15, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010181', N'ZGC APLE500WTHD+ZGC250RFL', N'', N'ZGC APLE500WTHD+ZGC250RFL', 15, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010184', N'ZGCREG500MLWTHD+ZGC250RFL', N'', N'ZGCREG500MLWTHD+ZGC250RFL', 15, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010186', N'ZGLASLEM250MLT-HD+HNDYRAG', N'', N'ZGLASLEM250MLT-HD+HNDYRAG', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010187', N'ZGCLEMN250MLWTHD+HNADYRAG', N'', N'ZGCLEMN250MLWTHD+HNADYRAG', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010189', N'ZGLASAPL250MLT-HD+HNDYRAG', N'', N'ZGLASAPL250MLT-HD+HNDYRAG', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010190', N'ZGCAPLE250MLWTHD+HANDYRAG', N'', N'ZGCAPLE250MLWTHD+HANDYRAG', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010192', N'ZGLASREG250MLT-HD+HNDYRAG', N'', N'ZGLASREG250MLT-HD+HNDYRAG', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010193', N'ZGCREG250ML WTHD+HANDYRAG', N'', N'ZGCREG250ML WTHD+HANDYRAG', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010194', N'ZMCLNSR FLRL+ESPONGE S 50', N'', N'ZMCLNSR FLRL+ESPONGE S 50', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010195', N'ZIMFLRL350GCN+EZSPNG S 50', N'', N'ZIMFLRL350GCN+EZSPNG S 50', 50, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010196', N'ZMCLNSRCALCAN+SPONGE S 50', N'', N'ZMCLNSRCALCAN+SPONGE S 50', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010197', N'ZIM CAL350GCN+EZSPNG S 50', N'', N'ZIM CAL350GCN+EZSPNG S 50', 50, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010198', N'ZMCLNSRFRESHCLN+SPONGE S', N'', N'ZMCLNSRFRESHCLN+SPONGE S', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010199', N'ZIMFLCEAN350GCN+EZSPNGS50', N'', N'ZIMFLCEAN350GCN+EZSPNGS50', 50, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010200', N'ZM SCRNGPDHDTY+EZSPNGE S', N'', N'ZM SCRNGPDHDTY+EZSPNGE S', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010201', N'ZIMSCPADHVYDTY+EZSPNG S72', N'', N'ZIMSCPADHVYDTY+EZSPNG S72', 72, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010202', N'BUY3TAKE1 EZSPONGE SMALL', N'', N'BUY3TAKE1 EZSPONGE SMALL', 1, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010203', N'EZ SPONGE S BUY3TAKE1 24S', N'', N'EZ SPONGE S BUY3TAKE1 24S', 24, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010204', N'ZMSCRGPDSPNGE2PC+EZSPNG S', N'', N'ZMSCRGPDSPNGE2PC+EZSPNG S', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010205', N'2ZM SCPADW/SPNG S+EZSPNGS', N'', N'2ZM SCPADW/SPNG S+EZSPNGS', 40, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010208', N'Z DWLQ 250ML BY1TK1 12/CS', N'', N'Z DWLQ 250ML BY1TK1 12/CS', 12, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010218', N'ZIM ZOSA250ML+BUGOFF1.5G', N'', N'ZIM ZOSA250ML+BUGOFF1.5G', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010219', N'2.ORCHID NAPTHA100G+SIPIT', N'', N'2.ORCHID NAPTHA100G+SIPIT', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010220', N'ORC NAPTA 110G+FREE SIPIT', N'', N'ORC NAPTA 110G+FREE SIPIT', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010221', N'Z ZOSA250+BUGOFF 1.5G', N'', N'Z ZOSA250+BUGOFF 1.5G', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010222', N'3PCSCRNGPDSPNGE.DSHTRAY.S', N'', N'3PCSCRNGPDSPNGE.DSHTRAY.S', 1, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010223', N'Z SCPADW/SPNG S+DSHPLATE', N'', N'Z SCPADW/SPNG S+DSHPLATE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010224', N'2.SCRNGPD.SPNGE.SCPSPUN.M', N'', N'2.SCRNGPD.SPNGE.SCPSPUN.M', 1, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010225', N'Z SCPADW/SPNGE M+SCOOP', N'', N'Z SCPADW/SPNGE M+SCOOP', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010226', N'2.ZCLNSR350GREF+BTHSCRUB', N'', N'2.ZCLNSR350GREF+BTHSCRUB', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010227', N'2.ZCLNSR350GREF+BATHSCRB', N'', N'2.ZCLNSR350GREF+BATHSCRB', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010228', N'ZIM ZOSA500ML+EZSPNGE SML', N'', N'ZIM ZOSA500ML+EZSPNGE SML', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010229', N'Z LQDZSA 500+EZSPNGE S', N'', N'Z LQDZSA 500+EZSPNGE S', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010230', N'MACCID COMM250ML+SIPIT', N'', N'MACCID COMM250ML+SIPIT', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010231', N'CL MACID COMM250+SIPIT-6S', N'', N'CL MACID COMM250+SIPIT-6S', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010232', N'MACID CONC250ML+SIPIT', N'', N'MACID CONC250ML+SIPIT', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010233', N'CL MACID CONC250+SIPIT-6S', N'', N'CL MACID CONC250+SIPIT-6S', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010234', N'MACID COMM500ML+BUGOFF1.5', N'', N'MACID COMM500ML+BUGOFF1.5', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010235', N'CL MACID COMM500+BGOFF', N'', N'CL MACID COMM500+BGOFF', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010236', N'MACID CONC500ML+BUGOFF1.5', N'', N'MACID CONC500ML+BUGOFF1.5', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010237', N'CL MACIDCONC500+BGOFF', N'', N'CL MACIDCONC500+BGOFF', 1, N'CL MURIATIC', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010238', N'2EZSPNGEMED+ZCLNSR150GREF', N'', N'2EZSPNGEMED+ZCLNSR150GREF', 1, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010239', N'EZ SPNGE M+Z. CLNSR150G', N'', N'EZ SPNGE M+Z. CLNSR150G', 1, N'EZ SPONGE', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010240', N'ZGLASREG500MLT-HD+TISSUE', N'', N'ZGLASREG500MLT-HD+TISSUE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010241', N'ZGLSCLNRREGW/H500M+TISSUE', N'', N'ZGLSCLNRREGW/H500M+TISSUE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010242', N'ZGLASAPL500MLT-HD+TISSUE', N'', N'ZGLASAPL500MLT-HD+TISSUE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010243', N'ZGCLNRAPPLEW/H500M+TISSUE', N'', N'ZGCLNRAPPLEW/H500M+TISSUE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010244', N'ZGLASLEM500MLT-HD+TISSUE', N'', N'ZGLASLEM500MLT-HD+TISSUE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010245', N'ZGCLNR LEMNW/H500M+TISSUE', N'', N'ZGCLNR LEMNW/H500M+TISSUE', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010246', N'3.ORCDEO50GREF+BUGOF1.5G', N'', N'3.ORCDEO50GREF+BUGOF1.5G', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010247', N'ORCHID DEO50G REF+BUG OFF', N'', N'ORCHID DEO50G REF+BUG OFF', 1, N'ORCHID', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010368', N'Z CLNSR FLRL+DYNASTY SLVR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010369', N'Z CLNSR FLRL+DYNASTY SILV', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010370', N'Z. CLNSR F.CLEAN+DYNASTY', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010371', N'Z CLNSR FCLN+DYNASTY SILV', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010374', N'CL MUR CONC.+WOODEN BRUSH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010375', N'CL MUR CONC. + FREE BRUSH', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010376', N'ZIM ZOSA+FREE BRUSH', N'', N'', 24, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010377', N'Z. LIQ.ZOZA+PLASTIC BRUSH', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010378', N'Z. G.CLNR TH STRWBRY+GLOV', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010379', N'Z G.CLNR TH STRWBRY+GLOVE', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010380', N'Z. G.CLNR TH APPLE+GLOVES', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010381', N'Z G.CLNR TH APPLE+GLOVES', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010382', N'Z. G.CLNR TH LEMON+GLOVES', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010383', N'Z G.CLNR TH LEMON+GLOVES', N'', N'', 12, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010525', N'EASYGRIP+D.DUTY+CLNS 150G', N'EASYGRIP + DOUBLE DUTY W/ CLNSR 150G. REF', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010526', N'Z TRIPLE VALUE+CLNSR 150G', N'ZIM TRIPLE VALUE PACK + CLNSR 150 G. REF', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010527', N'Z SCRUB SPONGE+12 ZIM', N'ZIM SCRUB SPONGE MED. + 12 ZIM ZIPIT', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010542', N'Z G CL STRAW W/TH+250 REF', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010543', N'Z G CL APPLE W/TH 500ML +', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010544', N'Z G CL LEMON W/TH 500ML +', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010545', N'Z G CL REG. W/TH 500 ML +', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010558', N'POWDER FLORAL CAN+REG.SCR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010559', N'POWDER CAL. CAN+REG.SCRG', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010560', N'POW FRESH.C. CAN+REG.SCRG', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010561', N'B2T1 ZIM POWDER REF. ASST', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010562', N'Z.CAL.CAN + Z. ALL PUR. S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010563', N'Z.FLORAL CAN+Z. ALL PUR.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010564', N'Z.F.CLEAN CAN+Z. ALL PUR.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010565', N'B1T1 ALL PURPOSE SPONGE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010566', N'B1T1 ALL PUR. SPONGE EASY', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010567', N'B1T1 ZIM DOUBLE DUTY', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010568', N'B1T1 ZIM HEAVY DUTY', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010569', N'B1T1 ZIM POWER SCRUBBER', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010570', N'B1T1 REG. SCRG.PAD SMALL', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010571', N'B1T1 REG. SCRG. PAD MED.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010572', N'B1T1 SCRG. PAD W/ SPONGE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010573', N'B1T1 Z SCRG. PAD W/SPONGE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010574', N'B1T1 ZIM SCRUB JR.', N'', N'', 1, N'', N'', N'', N'COMARK')
GO
print 'Processed 1300 total records'
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010582', N'ZIM H. DUTY + ZIM H. DUTY', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010616', N'Z GCLNR TH APPL+F 2CLNCLO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010617', N'Z GCLNR TH SBRY+F.2CLNCLO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010618', N'Z GCLNR TH LMN+F.2 CLNCLO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010619', N'Z GCLNR TH REG+F.2 CLNCLO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010620', N'Z GCLNR TH APL+F. CLEANCL', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010621', N'Z GCLNR TH SBRY+F.CLEANCL', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010622', N'Z GCLNR TH LMN+F.CLEANCLO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010623', N'Z GCLNR TH REG+F.CLEANCLO', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010632', N'Z APS EASYGRIP+F Z CLNSR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010633', N'ZIM DD + FREE Z CLNSR 50G', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010634', N'Z PWR SCRB + Z CLNSR 50 G', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010635', N'Z REG SCPAD MED+Z CLNSR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010636', N'Z SCPAD W/SPNGE M+Z CL', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010637', N'Z TRIPLE VALUE + Z CLNSR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010644', N'Z APS SMALL + Z CLNSR 50G', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010645', N'Z SCRUB JR + Z CLNSR 50G', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010648', N'Z CLNS FLORAL REF+ZIM JR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010649', N'Z. CLNS. CAL. REF+ZIM JR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B010650', N'Z CLNS F CLEAN REF+ZIM JR', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020019', N'ZIM 2PCS HEAVY DUTY+DAZZ', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020021', N'Z 2SCRG W/SPONGE MED+DAZZ', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020065', N'Z.CLNSR F.CLEAN+100G CAN', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020067', N'Z.CLNSR F.CLEAN+150G CAN', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020069', N'Z.CLNSR FLORAL+100G CAN', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020071', N'ZIM CLNSR FLORAL+150G', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020073', N'Z.CLNSR CALAMANSI+100GCAN', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020075', N'Z.CLNSR CALAMANSI+150GCAN', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020085', N'ZIM TOL SOL PACK 7', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020086', N'ZIM TOL SOL PACK 8', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020087', N'ZIM TOTAL SOL PACK 2', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020088', N'ZIM TOTAL SOL PACK 3', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B020112', N'Z. 2PCS ASS.APC+Z. TSHIRT', N'', N'', 1, N'CONSUMER', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B030027', N'Z. AP SPONGE SML+F.C. 50G', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B030028', N'Z. SCRUB JR+FRESH C. 50G.', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B030029', N'Z. POWER SCRB+FRESH C.50G', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B030104', N'B2DEOLEMONREF+APPLE50REF', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B030105', N'B2DEOS.BERRYREF+APLE50REF', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3B030106', N'B2DEOSMPGUITAREF+APLE50RE', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3D010004', N'FEVER AWAY COOL PATCH 6''S', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3D090001', N'LIQUID Z O S A  1GAL', N'', N'LIQUID Z O S A  1GAL', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3G010001', N'SUPER SAVER LIQUID ZOSA', N'', N'SUPER SAVER LIQUID ZOSA', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3G010002', N'SUPER SAVER LIQUID ZOSA', N'', N'SUPER SAVER LIQUID ZOSA', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3G020001', N'SUPER SAVER M ACID CONC', N'', N'SUPER SAVER M ACID CONC', 1, N'ZIM', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3G020002', N'SUPER SAVER M ACID CONC', N'', N'SUPER SAVER M ACID CONC', 1, N'PHARMACEUTICAL', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3I010001', N'K SHOECREAM POLISH BLACK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'3I010002', N'K SHOECREAM POLISH BLACK', N'', N'', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'53010001', N'CENTURY LIGHTER FLUID 120', N'', N'CENTURY LIGHTER FLUID 120', 1, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'53010002', N'CENTURY FLUID 120ML 144', N'', N'CENTURY FLUID 120ML 144', 144, N'', N'', N'', N'COMARK')
INSERT [dbo].[Products] ([product_id], [description], [description1], [description2], [pcs_per_case], [category], [pc_barcode], [case_barcode], [default_owner]) VALUES (N'53010003', N'CENTURY LIGHTER FLUID 12S', N'', N'CENTURY LIGHTER FLUID 12S', 12, N'', N'', N'', N'COMARK')
/****** Object:  Table [dbo].[ProductPricing]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPricing](
	[oms] [nvarchar](250) NOT NULL,
	[product] [nvarchar](250) NOT NULL,
	[uom] [nvarchar](50) NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_ProductPricing] PRIMARY KEY CLUSTERED 
(
	[oms] ASC,
	[product] ASC,
	[uom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ProductPricing] ([oms], [product], [uom], [price]) VALUES (N'OMS1', N'NPC23', N'CASES', 240.0000)
INSERT [dbo].[ProductPricing] ([oms], [product], [uom], [price]) VALUES (N'OMS1', N'NPC23', N'PIECES', 10.0000)
/****** Object:  Table [dbo].[Pricelists]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pricelists](
	[pricelist_id] [nvarchar](250) NOT NULL,
	[name] [nvarchar](50) NULL,
	[avail_date_start] [datetime] NULL,
	[avail_date_end] [datetime] NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pricelists] PRIMARY KEY CLUSTERED 
(
	[pricelist_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PricelistDetails]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PricelistDetails](
	[pricelist] [nvarchar](250) NOT NULL,
	[product] [nvarchar](250) NOT NULL,
	[uom] [nvarchar](50) NOT NULL,
	[delivery_date_start] [datetime] NULL,
	[delivery_date_ned] [datetime] NULL,
	[price] [money] NULL,
 CONSTRAINT [PK_PricelistDetails] PRIMARY KEY CLUSTERED 
(
	[pricelist] ASC,
	[product] ASC,
	[uom] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SP_IsTripScheduleConflict]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_IsTripScheduleConflict] 
 @vehicle NVARCHAR(20), 
 @date    DATE
AS
     BEGIN
         DECLARE @result BIT
         IF EXISTS
         (
             SELECT vehicle
             FROM Trips
             WHERE vehicle = @vehicle
                   AND @date >= expected_start
                   AND @date <= expected_end
         )
             SET @result = 1
             ELSE
             SET @result = 0
         SELECT @result
     END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetVehicleWithTripSchedule]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetVehicleWithTripSchedule] 
 @date DATE, 
 @flag SMALLINT = 0
AS
     IF @flag = 1 -- All trips
         BEGIN
             SELECT t.trip_id, 
                    t.vehicle, 
                    t.expected_start, 
                    t.expected_end, 
                    t.in_charge, 
                    t.route, 
                    CONVERT(VARCHAR(10), t.last_updated_on, 101) last_updated_on
             FROM dbo.Trips t
             WHERE expected_start >= @date
             ORDER BY dbo.UDF_CreateAlphanumericSortValue(t.trip_id)
         END
         ELSE
         IF @flag = 2 -- With orders
             BEGIN
                 SELECT t.trip_id, 
                        t.vehicle, 
                        t.expected_start, 
                        t.expected_end, 
                        t.in_charge, 
                        t.route, 
                        CONVERT(VARCHAR(10), t.last_updated_on, 101) last_updated_on
                 FROM dbo.Trips t
                 WHERE expected_start >= @date
                       AND t.trip_id IN
                 (
                     SELECT trip
                     FROM TripOrders
                     WHERE t.trip_id = trip
                 )
                 ORDER BY dbo.UDF_CreateAlphanumericSortValue(t.trip_id)
             END
             ELSE
             IF @flag = 3 -- With no orders
                 BEGIN
                     SELECT t.trip_id, 
                            t.vehicle, 
                            t.expected_start, 
                            t.expected_end, 
                            t.in_charge, 
                            t.route, 
                            CONVERT(VARCHAR(10), t.last_updated_on, 101) last_updated_on
                     FROM dbo.Trips t
                     WHERE expected_start >= @date
                           AND t.trip_id NOT IN
                     (
                         SELECT trip
                         FROM TripOrders
                         WHERE t.trip_id = trip
                     )
                     ORDER BY dbo.UDF_CreateAlphanumericSortValue(t.trip_id)
                 END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetVehicleOnTrip]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetVehicleOnTrip] 
 @date DATE
AS
     BEGIN
         SELECT t.trip_id, 
                t.vehicle, 
                t.expected_start, 
                t.expected_end
         FROM dbo.Trips t
         WHERE expected_start >= @date
     END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetTripOrders]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetTripOrders] 
 @flag    BIT          = 0, 
 @trip_id NVARCHAR(30)
AS
     IF @flag = 0
         BEGIN
             SELECT drop_sequence, 
                    order_id out_shipment_id, 
                    CONVERT(VARCHAR(10), reference_date, 101) [Ref Doc Date], 
                    reference [Ref Doc], 
                    Client, 
                    c.customer_id, 
                    name, 
                    doc_value
             FROM TripOrders tor
                  INNER JOIN Customers c ON tor.customer = c.customer_id
             WHERE trip = @trip_id
             ORDER BY dbo.UDF_CreateAlphanumericSortValue(trip)
         END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetRoutes]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetRoutes]
AS
     BEGIN
         SELECT r.route_id, 
                r.route_code
         FROM Routes r
     END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetOutShipmentForScheduling]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetOutShipmentForScheduling] 
 @flag BIT          = 0, 
 @id   NVARCHAR(30) = ''
AS
     IF @flag = 0
         BEGIN
             SELECT out_shipment_id, 
                    CONVERT(VARCHAR(10), document_reference_date, 101) [Ref Doc Date], 
                    document_reference [Ref Doc], 
                    Client, 
                    c.customer_id, 
                    name, 
                    CAST(SUM(osrd.expected_qty * osrd.price) AS DECIMAL(12, 2)) [Doc Value]
             FROM oms_db.dbo.OutgoingShipmentRequests osr
                  INNER JOIN oms_db.dbo.OutgoingShipmentRequestDetails osrd ON osr.out_shipment_id = osrd.out_shipment
                  INNER JOIN dbo.Customers c ON osr.customer_id = c.customer_id
             WHERE STATUS = 'FOR SCHEDULING'
             GROUP BY osr.out_shipment_id, 
                      osr.document_reference_date, 
                      osr.document_reference, 
                      client, 
                      c.customer_id, 
                      c.name, 
                      osr.tms_trip_id
             ORDER BY dbo.UDF_CreateAlphanumericSortValue(out_shipment_id)
         END
         ELSE
         BEGIN
             SELECT '' drop_sequence, 
                    out_shipment_id, 
                    CONVERT(VARCHAR(10), document_reference_date, 101) [Ref Doc Date], 
                    document_reference [Ref Doc], 
                    Client, 
                    c.customer_id, 
                    name, 
                    '' route, 
                    CAST(SUM(osrd.expected_qty * osrd.price) AS DECIMAL(12, 2)) [Doc Value]
             FROM oms_db.dbo.OutgoingShipmentRequests osr
                  INNER JOIN oms_db.dbo.OutgoingShipmentRequestDetails osrd ON osr.out_shipment_id = osrd.out_shipment
                  INNER JOIN dbo.Customers c ON osr.customer_id = c.customer_id
             WHERE STATUS = 'FOR SCHEDULING'
                   AND osr.out_shipment_id = @id
             GROUP BY osr.out_shipment_id, 
                      osr.document_reference_date, 
                      osr.document_reference, 
                      client, 
                      c.customer_id, 
                      c.name, 
                      osr.tms_trip_id
         END
GO
/****** Object:  StoredProcedure [dbo].[SP_AvailableVehicle]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_AvailableVehicle] 
 @start DATE, 
 @end   DATE
AS
     SELECT v.vehicle_id Vehicle
     FROM dbo.Vehicles v
     WHERE vehicle_id NOT IN
     (
         SELECT t.vehicle
         FROM Trips t
         WHERE expected_start <= @start
               AND expected_end >= @start -- cases 3,5,7
               OR expected_start < @end
                  AND t.expected_end >= @end --cases 6,6
               OR @start <= expected_start
                  AND @end >= expected_start --case 4
     )
     ORDER BY dbo.UDF_CreateAlphanumericSortValue(v.vehicle_id)
GO
/****** Object:  UserDefinedFunction [dbo].[SF_IsTripScheduleConflict]    Script Date: 04/10/2019 16:44:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SF_IsTripScheduleConflict]
(
@vehicle nvarchar(20),
@date date
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result bit

	-- Add the T-SQL statements to compute the return value here
	Set @result = (SELECT vehicle FROM Trips WHERE vehicle = @vehicle AND @date >= expected_start AND @date <=expected_end)

	-- Return the result of the function
	RETURN @result

END
GO
/****** Object:  ForeignKey [FK_PricelistDetails_Pricelists]    Script Date: 04/10/2019 16:44:41 ******/
ALTER TABLE [dbo].[PricelistDetails]  WITH CHECK ADD  CONSTRAINT [FK_PricelistDetails_Pricelists] FOREIGN KEY([pricelist])
REFERENCES [dbo].[Pricelists] ([pricelist_id])
GO
ALTER TABLE [dbo].[PricelistDetails] CHECK CONSTRAINT [FK_PricelistDetails_Pricelists]
GO
