
USE ordShop;

CREATE TABLE ord_clients(
	id bigint identity(1,1) not null,
	identification varchar(25) not null,
	[name] varchar(125) not null,
	addres varchar(150) null,
	primary key(id)
)
CREATE TABLE ord_products(
	id bigint identity(1,1) not null,
	code varchar(20) not null,
	[name] varchar(150) not null,
	[value] decimal not null,
	primary key(id)
)
CREATE TABLE ord_purchaseOrders(
	id bigint identity(1,1) not null,
	[date] datetime default getdate(),
	idClient bigint not null,	
	primary key (id),
	foreign key (idClient) references ord_clients(id)
)

CREATE TABLE ord_purchaseOrdersBody(
	id bigint identity(1,1) not null,
	[date] datetime default getdate(),
	idOrder bigint not null,
	idProduct bigint not null,
	cant int not null,
	valueUnit decimal not null,
	valueTotal decimal not null,
	[priority] bit not null, 
	primary key(id),
	foreign key (idProduct) references ord_products(id),
	foreign key (idOrder) references ord_purchaseOrders(id)
)


insert into ord_clients values ('1192747646', 'Andres Verjan', 'Calle 100')

insert into ord_products values ('CODIPHONE', 'Iphone X', 3000)
insert into ord_products values ('MOTO', 'Motorola One', 2000)