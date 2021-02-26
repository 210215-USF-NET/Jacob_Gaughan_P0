--Drop sequence for tables
drop table orders;
drop table item;
drop table products;
drop table locations;
drop table customers;

--creating tables
create table customers
(
	id int identity primary key,
	name varchar(50) not null,
	email varchar(50) not null
);
create table locations
(
	id int identity primary key,
	city varchar(40) not null,
	state varchar(2) not null,
	zipcode varchar(12) not null
);
create table products
(
	id int identity primary key,
	name varchar(50) not null,
	price decimal(6,2) not null
);
create table item
(
	id int identity primary key,
	quantity int not null,
	product int references products(id),
	location int references locations(id)
);
create table orders
(
	id int identity primary key,
	total decimal(7,2) not null,
	date datetime not null,
	customer int references customers(id),
	location int references locations(id)
);

--Adding seed data
insert into products (name, price) values 
('Vanilla', 3.99), ('Chocolate', 4.99), ('Strawberry', 5.99);

insert into locations (city, state, zipcode) values
('Hays', 'KS', '67601'), ('Durango', 'CO', '81302'), ('Charleston', 'SC', '29401');

insert into customers (name, email) values
('Jacob Gaughan', 'jacob.gaughan@revature.net'), ('Sam Garrison', 'sammyG@gmail.com');

insert into orders (total, date, customer, location) values
(25.00, convert(datetime,'28-04-20 05:30:12 PM',5), 1, 1), (50.00, convert(datetime,'07-08-20 11:20:00 AM',5), 2, 2);

select * from customers;

select * from locations;

select * from customers inner join orders on customers.id = orders.customer;