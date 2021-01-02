
create table [Product] (
	[ProductId] int identity(1,1) not null,
	[Name] varchar(100) not null,
	[Price] decimal not null,
	primary key clustered([ProductId] asc),
);

create table [OrderT] (
	[OrderId] int identity(1,1) not null,
	[Is_Checked] BIT not null,
	[PriceAlreadyPayed] decimal not null,
	[DateTime] datetime not null
	primary key clustered([OrderId] asc),
);

create table [OrderProduct] (
	[Id] int identity(1,1) not null,
	[OrderId] int not null,
	[ProductId] int not null,
	primary key clustered([Id] asc),
	constraint FK_OrderProductOrder foreign key (OrderId) references OrderT(OrderId),
	constraint FK_OrderTProductProduct foreign key (ProductId) references Product(ProductId)
);

create table [Customer] (
	[CustomerId] int identity(1,1) not null,
	[Name] varchar(100) not null,
	[Address] varchar(200) not null,
	primary key clustered([CustomerId] asc),
);

create table [CustomerOrder] (
	[Id] int identity(1,1) not null,
	[CustomerId] int,
	[OrderId] int not null,
	primary key clustered([Id] asc),
	constraint FK_CustomerOrderCustomer foreign key (CustomerId) references Customer(CustomerId),
	constraint FK_CustomerOrderOrder foreign key (OrderId) references OrderT(OrderId)
);