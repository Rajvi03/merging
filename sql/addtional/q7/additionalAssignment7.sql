--Q-1 Write a query which will output 123,456.78(as string datatype) for the input value of 123456.77912.
SELECT CONVERT(varchar(20),STUFF(ROUND(123456.77912,2),4,0,','))
--Q-2 Write a query to find position of letter 'd' in the string 'abcdefgh'.
SELECT CHARINDEX('d','abcdefgh')

--Q-3 Write a query which will output "hello world" for input string "Hello World".
SELECT LOWER('Hello World')

--Q-4 Write a query to find 3 characters from the left of any given string.
SELECT LEFT( 'HELLO WORLD', 3 )

--Q-5 Write a query to find 3 characters from the right of any given string.
SELECT RIGHT( 'HELLO WORLD', 3 )

--Q-6 Write a query which will return length of any given string.
SELECT LEN( 'HELLO WORLD')

--Q-7 Write a query which will output "------abcd" for input string "abcd".
SELECT  REPLICATE('-', 6) + 'abcd'

--Q-8 Write a query which will output "abcd......" for input string "abcd".
SELECT 'abcd' +  REPLICATE('.', 6) 

