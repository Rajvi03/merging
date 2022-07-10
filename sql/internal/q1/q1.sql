CREATE DATABASE internal

USE internal

CREATE TABLE Product
(
	ProductID int identity(1,1) PRIMARY KEY,
	Name varchar(50) NOT NULL,
	Price money NOT NULL,
	Status varchar(30) NOT NULL DEFAULT 'InStock' CONSTRAINT CK_Status CHECK(Status ='InStock' OR Status = 'OutofStock'),
	CreatedDate date
)
CREATE TABLE Users
(
	UserID int identity(1,1) PRIMARY KEY,
	UserName varchar(50) NOT NULL,
	isPrime int NOT NULL
)
CREATE TABLE Orders
(
	OrderID int identity(1,1) PRIMARY KEY,
	UserID int CONSTRAINT FK_UserID FOREIGN KEY REFERENCES Users(UserID),
	OrderDate date NOT NULL,
	OrderStatus varchar(30) DEFAULT 'Placed',
	OrderAmount money,
	DiscountAmount money,
	PayableAmount money
)
CREATE TABLE Discount 
(
	DiscountID int identity(1,1) PRIMARY KEY,
	ProductID int NOT NULL,
	DiscountPercentage int NOT NULL,
	DateStart date NOT NULL,
	DateEnd date NOT NULL
)

CREATE TABLE OrderItem
(
	OrderItemID int identity(1,1) PRIMARY KEY,
	ProductID int CONSTRAINT FK_ProductID FOREIGN KEY REFERENCES Product(ProductID),
	OrderID int CONSTRAINT FK_OrderID FOREIGN KEY REFERENCES Orders(OrderID),
	Qty int NOT NULL
)

INSERT INTO Product
VALUES
('Toy',500,'InStock','2022-02-01'),
('Mobile Phone',18000,'InStock','2022-03-02'),
('Monitor',10000,'InStock','2022-03-03'),
('Mouse',600,'InStock','2022-03-04')
SELECT * FROM Product

INSERT INTO Users
VALUES
('Reema',0),
('Ronit',1),
('Megha',1),
('Rohit	',0)

SELECT * FROM Users

INSERT INTO Orders
VALUES
(1,'2022-03-01','Placed',65000,5550,59450)

SELECT * FROM Orders

INSERT INTO Discount
VALUES
(1,15,'2022-03-01','2022-03-01'),
(1,10,'2022-03-02','2022-03-02'),
(1,20,'2022-07-07','2022-07-08')
SELECT * FROM Discount

INSERT INTO OrderItem
VALUES
(1,1,2),
(2,1,3),
(3,1,1)

SELECT * FROM OrderItem

UPDATE D
SET D.DiscountPercentage = 20
FROM Discount AS D 
JOIN Product AS P 
ON D.ProductID = P.ProductID
WHERE P.Name = 'Mobile Phone'