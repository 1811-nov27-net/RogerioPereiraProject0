-- use database
use Project0
go

-- drop tables
drop table if exists pizza.orderPizzas;
drop table if exists pizza.orders;
drop table if exists pizza.addresses;
drop table if exists pizza.customers;
drop table if exists pizza.pizzasIngredients;
drop table if exists pizza.pizzas;
drop table if exists pizza.ingredients;
go

-- drop schema
drop schema if exists pizza
go
create schema pizza
go

-- create tables
create table pizza.ingredients(
	id int IDENTITY(1,1) NOT NULL,
	name nvarchar(100) NOT NULL,
	stock int NULL
);

create table pizza.pizzas (
	id int IDENTITY(1,1) NOT NULL,
	name nvarchar(100) NOT NULL,
	price money NOT NULL,
);

create table pizza.pizzasIngredients (
	id int IDENTITY(1,1) NOT NULL,
	pizzaId int not null,
	ingredientId int not null,
);

create table pizza.customers (
	id int IDENTITY(1,1) NOT NULL,
	firstName nvarchar(50) not null,
	lastName nvarchar(50) not null,
);

create table pizza.addresses (
	id int IDENTITY(1,1) NOT NULL,
	customerId int not null,
	address1 nvarchar(100) not null,
	address2 nvarchar(100) not null,
	city nvarchar(100) not null,
	state nchar(2) not null,
	zipcode int not null
);

create table pizza.orders (
	id int IDENTITY(1,1) NOT NULL,
	customerId int not null,
	addressId int not null,
	value money not null,
	date datetime2 not null
);

create table pizza.orderPizzas (
	id int IDENTITY(1,1) NOT NULL,
	orderId int not null,
	pizzaId int not null
);

-- primary keys
alter table pizza.ingredients
	add constraint PK_Ingredients primary key (id);
alter table pizza.pizzas
	add constraint PK_Pizzas primary key (id);
alter table pizza.pizzasIngredients
	add constraint PK_Pizzas_Ingredients primary key (id);
alter table pizza.customers
	add constraint PK_Customers primary key (id);
alter table pizza.addresses
	add constraint PK_Addresses primary key (id);
alter table pizza.orders
	add constraint PK_Orders primary key (id);
alter table pizza.orderPizzas
	add constraint PK_OrderPizzas primary key (id);

-- foreign keys
alter table pizza.pizzasIngredients
	add constraint FK_PizzaIngredient_Pizzas foreign key (pizzaId) references pizza.pizzas (id)
		on delete cascade
		on update cascade;
alter table pizza.pizzasIngredients
	add constraint FK_PizzaIngredient_Ingredients foreign key (ingredientId) references pizza.ingredients (id)
		on delete no action
		on update cascade;
alter table pizza.addresses
	add constraint FK_Address_Customer foreign key (customerId) references pizza.customers (id)
		on delete cascade
		on update cascade;
alter table pizza.orders
	add constraint FK_Order_Customer foreign key (customerId) references pizza.customers (id)
		on delete no action
		on update no action;
alter table pizza.orders
	add constraint FK_Order_Address foreign key (addressId) references pizza.addresses (id)
		on delete no action
		on update no action;
alter table pizza.orderPizzas
	add constraint FK_OrderPizza_Order foreign key (orderId) references pizza.orders (id)
		on delete cascade
		on update cascade;
alter table pizza.orderPizzas
	add constraint FK_OrderPizza_Pizza foreign key (pizzaId) references pizza.pizzas (id)
		on delete no action
		on update cascade;
