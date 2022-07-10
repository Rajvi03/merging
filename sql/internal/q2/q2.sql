SELECT * FROM Product
SELECT * FROM Users
SELECT * FROM Orders
SELECT * FROM Discount
SELECT * FROM OrderItem

--Find out the product details for which no order is place as of now.
SELECT P.* FROM Product AS P
LEFT JOIN OrderItem AS OI ON OI.ProductID = P.ProductID
WHERE OI.ProductID IS NULL

--Find out that products on which there is no discount today
SELECT P.* FROM Product AS P
JOIN Discount AS D
ON P.ProductID = D.ProductID
WHERE D.DateEnd <> CONVERT(VARCHAR(30),GETDATE(),111)

--Find out the list of the product which are created in last 2 days and it is inStock.
SELECT * FROM Product WHERE DATEDIFF(YY,CreatedDate,GETDATE())=0 AND DATEDIFF(MM,CreatedDate,GETDATE())=0 AND DATEDIFF(DAY,CreatedDate,GETDATE())<2
