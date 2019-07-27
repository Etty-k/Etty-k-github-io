create database DB_freeQueue

use DB_freeQueue

create table tbl_stores(
Id int primary key identity,
StoreName nvarchar(30),
StoreAddress nvarchar(50),
Phone nvarchar(10),
About nvarchar(300),
KashrutCertification nvarchar(30),
Img nvarchar(20),
StoreCategory nvarchar(10),
ReservedSeats bit,
Club bit,
Tip bit,
StoreLoad bit,
Bank int,
Brunch int,
Account nvarchar(13)
)
go
create table tbl_storesActivityTime(
Id int primary key identity,
Store int foreign key references tbl_stores(Id),
ActivityDay int,
StartTime nvarchar(4),
EndTime nvarchar(4)
)
go
create table tbl_productsCategories(
Id int primary key identity,
Store int foreign key references tbl_stores(Id),
Category nvarchar(20)
)

create table tbl_storesMenu(
Id int primary key identity,
Store int foreign key references tbl_stores(Id),
ProductName nvarchar(30),
ProductCategory int foreign key references tbl_productsCategories(Id),
ProductPrice float,
ProductStatus bit,
QuickProduct bit,
ProductImage nvarchar(100),
PreperationTime int,
AdditionQuantity int
)

create table tbl_menuAddittions(
Id int primary key identity,
Product int foreign key references tbl_storesMenu(Id),
Addition nvarchar(50),
AddtionPrice float,
AdditionStatus bit,
AdditionImage nvarchar(100)
)

create table tbl_menuTastes(
Id int primary key identity,
Product int foreign key references tbl_storesMenu(Id),
Taste nvarchar(20),
TasteStatus bit,
TasteImage nvarchar(100)
)

create table tbl_purchases(
	Id int primary key identity,
	StoreId int foreign key references tbl_stores(Id),
	PurchaseDate datetime,
	CustomerName nvarchar(20),
	CustomerPhone nvarchar(10),
	CreditCard nvarchar(18),
	CreditDate nvarchar(4),
	CreditDigits nvarchar(3),
	DeliveryAddress nvarchar(50),
	GroupName nvarchar(15),
	ReservedSeats int,
	Club bit,
	Tip float,
	PurchaseSum float null,
	ReceiptTime nvarchar(5)
)
create table tbl_purchasesProducts(
	Id int primary key identity,
	PurchaseId int foreign key references tbl_purchases(Id),
	Product int foreign key references tbl_storesMenu(Id),
	ProductCount int,
	Price float
)

create table tbl_purchasesAdditions(
	Id int primary key identity,
	Product int foreign key references tbl_purchasesProducts(Id),
	Addition int foreign key references tbl_menuAddittions(Id)
)

create table tbl_purchasesTastes(
	Id int primary key identity,
	Product int foreign key references tbl_purchasesProducts(Id),
	Taste int foreign key references tbl_menuTastes(Id)
)

