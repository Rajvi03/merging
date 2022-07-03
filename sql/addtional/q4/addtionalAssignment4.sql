--Write a query which will return value '5.0' for input value of '4.1' as well as '4.8'.
SELECT CEILING(4.1)  AS CelliValue,CEILING(4.8) AS CelliValue

--Write a query which will return value '4.0' for input value of '4.1' as well as '4.8'.
SELECT FLOOR(4.1) AS FloorValue, FLOOR(4.8) AS FloorValue

-- What will be the output of following query:
SELECT MOD(11,3)
SELECT 11 % 3

--Write a query to find 2 raise to power 3.
SELECT POWER(2,3)

--Write a query to generate random number using MS SQL function.
SELECT RAND()

--Write a query to supply seed to the function generating random number.
SELECT RAND(2)

--Write a query which will return value '4' for '3.5' and '3' for '3.4'.
SELECT CEILING(3.5),CEILING(3),CEILING(3.4)

--Write a query so that output will be '15.75' for the value '15.7463847'.
SELECT ROUND(15.7463847,2)

--Write a query to find square root of given value. What will be the output if the provided value is negative?
SELECT SQRT(25)
SELECT SQRT(-25)

--Write a query so that output will be '15.74' for the value '15.7463847'.
SELECT ROUND(15.7463847,2)

-- Write a query which will output '15.2500' for provided value '15.25'.
SELECT ROUND(15.25,4)

--Tables Used:=
    
--    -	student  (studentid, name)

--    -   studentdetail (studentdetailid, studentid, standard, gender)

--    -   studentpresent (studentpresentid, studentid, month, present)

--    -   studenthours (studenthoursid, studentid, datex, hours)

--    -   product (productid, name)

--    -   productprice (productpriceid, productid, code, effdt, price)

USE sqlPractice
CREATE TABLE student 
(
	studentid int PRIMARY KEY,
	name varchar(100) NOT NULL
)
CREATE TABLE studentdetail 
(
	studentdetailid int PRIMARY KEY,
	studnentid int CONSTRAINT FK_studentid FOREIGN KEY  REFERENCES student(studentid),
	standard int NOT NULL,
	gender varchar(50) not null
)
CREATE TABLE studentpresent 
(
	studentpresentid int ,
	studentid int CONSTRAINT FK_studentid1 FOREIGN KEY REFERENCES student(studentid),
	month int CHECK(month <= 12) NOT NULL,
	present int NOT NULL
)
CREATE TABLE studenthours
(
	studenthoursid int ,
	studentid int CONSTRAINT FK_studentid2 FOREIGN KEY REFERENCES student(studentid),
	datex date NOT NULL,
	hours int NOT NULL
)
INSERT INTO student VALUES
(1,'John'),
(2,'Smit'),
(3,'Anna'),
(4,'Peter'),
(5,'Harry'),
(6,'Anna')

SELECT * FROM student
DROP TABLE student

INSERT INTO	 studentdetail VALUES 
(1,2,1,'Female'),
(2,3,1,'Male'),
(3,4,2,'Female'),
(4,1,2,'Male'),
(5,5,3,'Female')

SELECT * FROM studentdetail
DROP TABLE studentdetail

INSERT INTO studentpresent VALUES
(1,2,2,25),
(2,1,9,22),
(3,5,12,30),
(4,4,2,20),
(5,3,9,27),
(1,2,12,5),
(3,5,1,15),
(4,4,5,23)

SELECT * FROM studentpresent
DROP TABLE studentpresent

INSERT INTO studenthours VALUES 
(1,2,'2020-5-6',5),
(2,3,'2020-6-26',6),
(3,4,'2020-2-16',9),
(4,1,'2020-12-12',6),
(5,5,'2020-4-4',10),
(6,2,'2020-4-4',2)

SELECT * FROM studenthours
DROP TABLE studenthours

CREATE TABLE stuproducts
(
	productid int NOT NULL UNIQUE,
	name varchar(100) NOT NULL
)

INSERT INTO stuproducts VALUES
(1,'Pen'),
(2,'Pencile'),
(3,'Book'),
(4,'Textbook'),
(5,'Eraser')

SELECT * FROM stuproducts
DROP TABLE stuproducts

CREATE TABLE productprice
(
	productpriceid int NOT NULL,
	productid int ,
	code varchar(50) NOT NULL,
	effdt date NOT NULL,
	price int NOT NULL
)

INSERT INTO productprice VALUES 
(1,5,'AB','2020-5-6',25),
(2,2,'CD','2020-6-6',50),
(3,1,'EF','2020-4-6',15),
(4,3,'GH','2020-8-6',45),
(5,4,'IJ','2020-12-6',75)

SELECT * FROM productprice
DROP TABLE productprice
--Write a query to display all the product names with code in bracket in one column 
--and 2 decimal significant price in second column, 
--	e.g. : MS Sql book (MS09210) | 10.99
--Here 'MS Sql book' is product name and 'MSSQL09210' is the product code while '10.99'
--is the 2 decimal significant price.
SELECT P.name + ' (' + PP.code +') | ' + CONVERT(VARCHAR(25),PP.price) AS productDetails FROM stuproducts AS P JOIN productprice AS PP ON P.productid = PP.productid


--Write a query to display following information separated by comma in a single row for the students who have atleast one 'a' in their name. 
--	The column heading should be STUDENTINFO.
	
--	student name, standard, gender

SELECT S.name + ',' + CONVERT(VARCHAR(25),SD.standard) + ','+ SD.gender AS STUDENTINFO  FROM student AS S JOIN studentdetail AS SD ON S.studentid = SD.studnentid WHERE S.name LIKE '%a%'