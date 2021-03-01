--Drop sequence for tables
drop table orders;
drop table inventory;
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
	address varchar(50) not null,
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
create table inventory
(
	id int identity primary key,
	quantity int not null,
	productId int not null,
	locationId int not null,
	foreign key(productId) references products(id),
	foreign key(locationId) references locations(id)
);
create table orders
(
	id int identity primary key,
	total decimal(7,2) not null,
	date smalldatetime not null,
	customerId int not null,
	locationId int not null,
	foreign key(customerId) references customers(id),
	foreign key(locationId) references locations(id)
);

-- Adding seed data
insert into customers (name, email) values
('Jacob Gaughan', 'jacob.gaughan@revature.net'), ('Sam Garrison', 'sammyG@gmail.com');

insert into locations (address, city, state, zipcode) values
('225 West 8th St.', 'Hays', 'KS', '67601'), ('3924 Hillcrest Dr.', 'Durango', 'CO', '81302'), ('1920 Park St.', 'Charleston', 'SC', '29401');

insert into products (name, price) values
('Vanilla', 3.99), ('Chocolate', 4.99), ('Strawberry', 5.99);

insert into inventory (quantity, productId, locationId) values
(4, 1, 1), (4, 2, 1), (4, 3, 1), (5, 1, 2), (5, 2, 2), (5, 3, 2), (6, 1, 3), (6, 2, 3), (6, 3, 3);

insert into orders (total, date, customerId, locationId) values
(25.00, convert(datetime,'28-04-20 05:30:12 PM',5), 1, 1), (50.00, convert(datetime,'07-08-20 11:20:00 AM',5), 2, 2), (20.00, convert(datetime,'07-08-20 9:20:00 PM',5), 2, 1);

select * from products inner join inventory on products.id = inventory.productId;

select * from customers inner join orders on customers.id = orders.customerId;

select * from locations inner join inventory on locations.id = inventory.locationId;