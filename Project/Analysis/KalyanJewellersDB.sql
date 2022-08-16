CREATE DATABASE KalyanJewellers

USE KalyanJewellers

CREATE TABLE Users
(
	UsersID INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	MobileNo VARCHAR(12) NOT NULL,
	Password VARCHAR(30),
	AlternateMobileNo VARCHAR(12),
	Gender VARCHAR(7),
	UserRole VARCHAR(10) DEFAULT 'User',
	DOB DATE ,
	AnniversaryDate  DATE ,
	Company VARCHAR(30),
	StreetAddress VARCHAR(100),
	StreetAddress2 VARCHAR(100),
	ZipCode INT,
	City VARCHAR(30),
	State VARCHAR(30),
	Country VARCHAR(30),
	SubscribersID INT FOREIGN KEY REFERENCES Subscribers(SubscribersID),
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE
) 
SELECT * FROM Users

CREATE TABLE Subscribers
(
	SubscribersID INT  PRIMARY KEY IDENTITY(1,1),
	Email VARCHAR(30) NOT NULL,
	MobileNo VARCHAR(12) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE MaterialType
(
	MaterialTypeID INT  PRIMARY KEY IDENTITY(1,1),
	MaterialName VARCHAR(30) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE JewelleryType
(
	JewelleryTypeID INT  PRIMARY KEY IDENTITY(1,1),
	MaterialTypeID INT FOREIGN KEY REFERENCES MaterialType(MaterialTypeID),
	JewelleryName VARCHAR(30) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE
)


CREATE TABLE ProductDesign
(
	ProductDesignID INT  PRIMARY KEY IDENTITY(1,1),
	JewelleryTypeID INT FOREIGN KEY REFERENCES JewelleryType(JewelleryTypeID),
	DesignName VARCHAR(30) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE Product
(
	ProductID INT  PRIMARY KEY IDENTITY(1,1),
	ProductName VARCHAR(30) NOT NULL,
	ProductDescription VARCHAR(30),
	SKU VARCHAR(10) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE ProductDetails
(
	ProductDetailsID INT  PRIMARY KEY IDENTITY(1,1),
	ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
	StyleNo VARCHAR(10),
	Height DECIMAL(5,2) ,
	TotalWeight DECIMAL(5,2) ,
	size VARCHAR(20) ,
	MetalWeight DECIMAL(5,2),
	ProductDesignID  INT FOREIGN KEY REFERENCES ProductDesign(ProductDesignID),
	UserCategory INT FOREIGN KEY REFERENCES TblObject(TblObjectID),
	MetalColor INT FOREIGN KEY REFERENCES TblObject(TblObjectID),
	Metalpurity INT FOREIGN KEY REFERENCES TblObject(TblObjectID),
	ProductStatus INT FOREIGN KEY REFERENCES TblObject(TblObjectID),
	MetalPrice INT,
	MakingCharges INT,
	PCreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	Stock INT ,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE,
)


CREATE TABLE DiamondDetails
(
	DiamondDetailsID INT  PRIMARY KEY IDENTITY(1,1),
	ProductDetailsID INT FOREIGN KEY REFERENCES ProductDetails(ProductDetailsID),
	TotalNoOfDiamonds INT,
	TotalWeight INT,
	Clarity INT FOREIGN KEY REFERENCES TblObject(TblObjectID),
	Color VARCHAR(30),
	SettingType VARCHAR(30),
	Shape VARCHAR(30),
	DiamondWeight INT,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE Images
(
	ImagesID INT  PRIMARY KEY IDENTITY(1,1),
	ProductDetailsID INT FOREIGN KEY REFERENCES ProductDetails(ProductDetailsID),
	ImageName VARCHAR(50) NOT NULL,
	ImageURL NVARCHAR(MAX) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)
CREATE TABLE Discount
(
	DiscountID INT  PRIMARY KEY IDENTITY(1,1),
	ProductDetailsID INT FOREIGN KEY REFERENCES ProductDetails(ProductDetailsID),
	DiscountPercentage INT NOT NULL,
	DateStart DATE CONSTRAINT CH_DateStart CHECK(DateStart >= CONVERT(DATE,GETDATE())),
	DateEnd DATE DEFAULT CONVERT(DATE,GETDATE()) CHECK(DateEnd >= CONVERT(DATE,GETDATE())),
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE WishList
(
	WishListID INT  PRIMARY KEY IDENTITY(1,1),
	UserID INT FOREIGN KEY REFERENCES Users(UsersID),
	ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)



CREATE TABLE Cart
(
	CartID INT  PRIMARY KEY IDENTITY(1,1),
	UserID INT FOREIGN KEY REFERENCES Users(UsersID),
	CartTotal INT,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE CartDetail
(
	CartDetailID INT  PRIMARY KEY IDENTITY(1,1),
	CartID INT FOREIGN KEY REFERENCES Cart(CartID),
	ProductID INT FOREIGN KEY REFERENCES Product(ProductID),
	WishListTotal INT,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE OrderAddress
(
	OrderAddressID INT  PRIMARY KEY IDENTITY(1,1),
	UserID INT FOREIGN KEY REFERENCES Users(UsersID) NOT NULL,
	Company VARCHAR(30) NOT NULL,
	StreetAddress VARCHAR(100) NOT NULL,
	StreetAddress2 VARCHAR(100) NOT NULL,
	ZipCode INT NOT NULL,
	City VARCHAR(30) NOT NULL,
	State VARCHAR(30) NOT NULL,
	Country VARCHAR(30) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE Orders
(
	OrdersID INT  PRIMARY KEY IDENTITY(1,1),
	UserID INT FOREIGN KEY REFERENCES Users(UsersID) NOT NULL,
	CartDetailID INT FOREIGN KEY REFERENCES Users(UsersID) NOT NULL,
	OrderAddressID INT FOREIGN KEY REFERENCES OrderAddress(OrderAddressID) NOT NULL,
	OrderDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	OrderAmount INT,
	DiscountAmount INT,
	PayableAmount INT,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)



CREATE TABLE TblType
(
	TblTypeID INT  PRIMARY KEY IDENTITY(1,1),
	TypeName VARCHAR(30) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE 
)

CREATE TABLE TblObject
(
	TblObjectID INT  PRIMARY KEY IDENTITY(1,1),
	TblTypeID INT FOREIGN KEY REFERENCES TblType(TblTypeID),
	ObjectValue VARCHAR(30) NOT NULL,
	CreatedDate DATE DEFAULT CONVERT(DATE,GETDATE()),
	ModifiedDate DATE
)

INSERT INTO TblType(TypeName)
VALUES
( 'Gender'),
( 'MetalColor'),
( 'MetalPurity'),
( 'DiamondQuality'),
( 'ProductStatus'),
( 'FeedBackType')

SELECT * FROM TblType


INSERT INTO TblObject(TblTypeID, ObjectValue)
VALUES
(  1, 'Male'),
(  1, 'Female'),
(  1, 'Kids'),
(  1, 'Unisex'),
(  2, 'White Gold'),
(  2, 'Yellow Gold'),
(  2, 'Rose Gold'),
(  2, 'Platinum'),
(  3, '14k'),
(  3,'18k'),
(  4, 'SI IJ'),
(  4, 'SI GH'),
(  4, 'VS GH'),
(  4, 'VVS EF'),
(  4, '12 GH'),
(  5, 'Instock'),
(  5, 'Outstock'),
(  6, 'Store Related Complaint'),
(  6, 'Product Related Complaint'),
(  6, 'General Queries'),
(  6, 'Other Queries')

SELECT * FROM TblObject

INSERT INTO MaterialType(MaterialName)
VALUES
('GOLD'),
('DIAMOND'),
('PEARL'),
('WHITE GOLD'),
('GEMSTONE'),
('PLATINUM')

SELECT * FROM MaterialType

INSERT INTO JewelleryType(MaterialTypeID, JewelleryName)
VALUES
(1,'CHAINS'),
(1,'RINGS'),
(1,',NECKLACES'),
(1,'EARRINGS'),
(1,'BRACELETS'),
(1,'BANGLES'),
(1,'Kada'),
(4,'CHAINS'),
(4,'RINGS'),
(4,',NECKLACES'),
(4,'EARRINGS'),
(4,'BRACELETS'),
(4,'BANGLES'),
(4,'Kada'),
(6,'CHAINS'),
(6,'RINGS'),
(6,',NECKLACES'),
(6,'EARRINGS'),
(6,'BRACELETS'),
(6,'BANGLES'),
(6,'Kada')

SELECT * FROM JewelleryType

INSERT INTO ProductDesign(JewelleryTypeID,DesignName)
VALUES
(1,'Dailywear'),
(1,'Mangalsutra Chains'),
(1,'Handcrafted'),
(15,'Dailywear'),
(15,'Mangalsutra Chains'),
(15,'Handcrafted')


SELECT * FROM ProductDesign

INSERT INTO Product(ProductName, ProductDescription, SKU)
VALUES
('Lozenge Gold Chain','NULL', 'K000472'),
('Small Gold Rope Chain',Null,'K000680')

SELECT * FROM Product

INSERT INTO ProductDetails
VALUES
(2,'K000680',NULL,2.19,18,2.19,4,2,2,10,16,8738,3372,DEFAULT,15,DEFAULT,NULL)

SELECT * FROM ProductDetails

INSERT INTO Images(ProductDetailsID,ImageName,ImageURL)
VALUES
(2,'k000680_1','https://www.candere.com/media/jewellery/images/k000680_1.jpeg'),
(2,'k000680_2','https://www.candere.com/media/jewellery/images/k000680_2.jpeg')

SELECT * FROM Images

INSERT INTO Discount(ProductDetailsID,DiscountPercentage,DateStart,DateEnd)
VALUES
(2,35,'2022-08-13','2022-08-20')

SELECT * FROM Discount