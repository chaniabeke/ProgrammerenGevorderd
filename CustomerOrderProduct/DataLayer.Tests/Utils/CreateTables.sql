
create table [Product] (
	[ProductId] int identity(1,1) not null,
	[Name] varchar(100) not null,
[Price] decimal(18,2) not null,
	primary key clustered([ProductId] asc),
);

create table [OrderT] (
	[OrderId] int identity(1,1) not null,
	[Is_Checked] BIT not null,
	[PriceAlreadyPayed] decimal(18,2) not null,
	[DateTime] datetime not null,
	[CustomerId] int null,
	primary key clustered([OrderId] asc),
);

create table [OrderProduct] (
	[OrderId] int not null,
	[ProductId] int not null,
	[Amount] int not null,
	constraint FK_OrderProductOrder foreign key (OrderId) references OrderT(OrderId),
	constraint FK_OrderTProductProduct foreign key (ProductId) references Product(ProductId)
);

create table [Customer] (
	[CustomerId] int identity(1,1) not null,
	[Name] varchar(100) not null,
	[Address] varchar(200) not null,
	primary key clustered([CustomerId] asc),
	constraint FK_CustomerOrder foreign key (CustomerId) references Customer(CustomerId),
);
