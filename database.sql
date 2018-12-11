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
	stock int NOT NULL
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
	defaultAddress bit not null,
	address1 nvarchar(100) not null,
	address2 nvarchar(100) null,
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

--Default Value
ALTER TABLE pizza.ingredients
	ADD CONSTRAINT DefaultValue_Ingredient_Stock DEFAULT 0 FOR stock ; 
ALTER TABLE pizza.addresses
	ADD CONSTRAINT DefaultValue_Address_Default DEFAULT 0 FOR defaultAddress ; 

--Seeds
--Ingredients
insert into pizza.ingredients (name, stock) values
('Dough', 10),				--1
('Tomato Sauce', 10),		--2
('Mozzarela', 10),			--3
('Provolone', 10),			--4
('Cheddar', 10),			--5
('Ham', 10),				--6
('Bacon', 10),				--7
('Canadian Bacon', 10),		--8
('Tomato', 10),				--9
('Olive', 10),				--10
('Egg', 10),				--11
('Pea', 10),				--12 --ervilha
('basil', 10);				--13 --manjeiricão

--Pizzas
insert into pizza.pizzas (name, price) values
('Ham and Cheese', 20),	--1
('Canadian Bacon', 40),	--2
('Bacon', 40),			--3
('Protuguese', 50),		--4
('Margherita', 30);		--5

--PizzasIngredients
insert into pizza.pizzasIngredients (pizzaId, ingredientId) values
-- Ham and Cheese (dought, Tomato Sauce, Mozzarela, Ham
(1, 1),
(1, 2),
(1, 3),
(1, 6),
-- Canadian Bacon (dought, Tomato Sauce, Mozzarela, Canadian Bacon)
(2, 1),
(2, 2),
(2, 3),
(2, 8),
-- Bacon (dought, Tomato Sauce, Mozzarela, Bacon)
(3, 1),
(3, 2),
(3, 3),
(3, 7),
-- Portuguese (dought, Tomato Sauce, Mozzarela, Ham, Egg, Pea)
(4, 1),
(4, 2),
(4, 3),
(4, 6),
(4, 11),
(4, 12),
-- Margherita (dought, Tomato Sauce, Mozzarela, Tomato, Basil)
(5, 1),
(5, 2),
(5, 3),
(5, 9),
(5, 13);

--Customers
insert into pizza.customers (firstName, lastName) values
('Rogerio', 'Pereira'), --1
('Customer', '1'),		--2
('Customer', '2'),		--3
('Customer', '3');		--4

insert into pizza.addresses (customerId, address1, address2, city, state, zipcode, defaultAddress) values
(1, '332 North Croft Ave', null, 'Los Angeles', 'CA', 90048, 0),
(1, '701 W Mitchell Street', '328 D', 'Arlington', 'TX', 76013, 1),
(2, '2 Address Customer 2', null, 'City', 'ST', 12345, 1),
(3, '3 Address Customer 3', null, 'City', 'ST', 45678, 1),
(4, '4 Address Customer 4', null, 'City', 'ST', 98765, 1);

insert into pizza.orders (customerId, addressId, value, date) values
(1, 1, 40, '2018-12-06 10:27:00'),	--1
(2, 2, 40, '2018-12-06 10:27:00'),	--2
(3, 3, 40, '2018-12-06 10:27:00'),	--3
(4, 4, 40, '2018-12-06 10:27:00');	--4

insert into pizza.orderPizzas (orderId, pizzaId) values
(1, 3),
(2, 3),
(3, 3),
(4, 3);