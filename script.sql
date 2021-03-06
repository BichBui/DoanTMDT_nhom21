USE [MvcPhone]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 06/21/2020 18:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[tendangnhap] [nvarchar](max) NULL,
	[matkhau] [nvarchar](max) NULL,
	[hoten] [nvarchar](max) NULL,
	[gmail] [nvarchar](max) NULL,
	[sdt] [nvarchar](max) NULL,
	[diachi] [nvarchar](max) NULL,
	[matkhaunhaplai] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX  = ON, STATISTICS_NORECOMPUTE  = ON, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 06/21/2020 18:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[idLSP] [int] IDENTITY(1,1) NOT NULL,
	[tenloai] [nvarchar](max) NULL,
	[maloai] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categorys] PRIMARY KEY CLUSTERED 
(
	[idLSP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/21/2020 18:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 06/21/2020 18:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[idSP] [int] IDENTITY(1,1) NOT NULL,
	[idLSP] [int] NOT NULL,
	[tenSP] [nvarchar](max) NULL,
	[mota] [nvarchar](max) NULL,
	[gia] [real] NOT NULL,
	[hinhanh] [nvarchar](max) NULL,
	[CategorysidLSP] [int] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[idSP] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 06/21/2020 18:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[idHD] [int] IDENTITY(1,1) NOT NULL,
	[idUser] [int] NOT NULL,
	[hoten_user] [nvarchar](max) NULL,
	[gmail_user] [nvarchar](max) NULL,
	[phone_user] [nvarchar](max) NULL,
	[diachi_user] [nvarchar](max) NULL,
	[tongtien] [real] NOT NULL,
	[payment] [nvarchar](max) NULL,
	[ngaytao] [datetime2](7) NOT NULL,
	[trangthai] [int] NOT NULL,
	[CustomersidUser] [int] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[idHD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 06/21/2020 18:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[idCTHD] [int] IDENTITY(1,1) NOT NULL,
	[idHD] [int] NOT NULL,
	[idSP] [int] NOT NULL,
	[soluong] [int] NOT NULL,
	[dongia] [real] NOT NULL,
	[thanhtien] [real] NOT NULL,
	[khuyenmai] [real] NOT NULL,
	[OrdersidHD] [int] NULL,
	[ProductsidSP] [int] NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[idCTHD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 06/21/2020 18:34:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[idNV] [nvarchar](max) NULL,
	[hoten] [nvarchar](max) NULL,
	[sdt] [nvarchar](max) NULL,
	[diachi] [nvarchar](max) NULL,
	[ngaysinh] [datetime2](7) NOT NULL,
	[gioitinh] [nvarchar](max) NULL,
	[luong] [int] NOT NULL,
	[pass] [nvarchar](max) NULL,
	[trangthai] [nvarchar](max) NULL,
	[phanquyen] [nvarchar](max) NULL,
	[CategorysidLSP] [int] NULL,
	[ProductsidSP] [int] NULL,
	[OrdersidHD] [int] NULL,
	[OrderDetailsidCTHD] [int] NULL,
	[CustomersidUser] [int] NULL,
 CONSTRAINT [PK_Workers] PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_OrderDetails_Orders_OrdersidHD]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrdersidHD] FOREIGN KEY([OrdersidHD])
REFERENCES [dbo].[Orders] ([idHD])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrdersidHD]
GO
/****** Object:  ForeignKey [FK_OrderDetails_Products_ProductsidSP]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductsidSP] FOREIGN KEY([ProductsidSP])
REFERENCES [dbo].[Products] ([idSP])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductsidSP]
GO
/****** Object:  ForeignKey [FK_Orders_Customers_CustomersidUser]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers_CustomersidUser] FOREIGN KEY([CustomersidUser])
REFERENCES [dbo].[Customers] ([idUser])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers_CustomersidUser]
GO
/****** Object:  ForeignKey [FK_Products_Categorys_CategorysidLSP]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categorys_CategorysidLSP] FOREIGN KEY([CategorysidLSP])
REFERENCES [dbo].[Categorys] ([idLSP])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categorys_CategorysidLSP]
GO
/****** Object:  ForeignKey [FK_Workers_Categorys_CategorysidLSP]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Categorys_CategorysidLSP] FOREIGN KEY([CategorysidLSP])
REFERENCES [dbo].[Categorys] ([idLSP])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Categorys_CategorysidLSP]
GO
/****** Object:  ForeignKey [FK_Workers_Customers_CustomersidUser]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Customers_CustomersidUser] FOREIGN KEY([CustomersidUser])
REFERENCES [dbo].[Customers] ([idUser])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Customers_CustomersidUser]
GO
/****** Object:  ForeignKey [FK_Workers_OrderDetails_OrderDetailsidCTHD]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_OrderDetails_OrderDetailsidCTHD] FOREIGN KEY([OrderDetailsidCTHD])
REFERENCES [dbo].[OrderDetails] ([idCTHD])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_OrderDetails_OrderDetailsidCTHD]
GO
/****** Object:  ForeignKey [FK_Workers_Orders_OrdersidHD]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Orders_OrdersidHD] FOREIGN KEY([OrdersidHD])
REFERENCES [dbo].[Orders] ([idHD])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Orders_OrdersidHD]
GO
/****** Object:  ForeignKey [FK_Workers_Products_ProductsidSP]    Script Date: 06/21/2020 18:34:18 ******/
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Products_ProductsidSP] FOREIGN KEY([ProductsidSP])
REFERENCES [dbo].[Products] ([idSP])
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Products_ProductsidSP]
GO
