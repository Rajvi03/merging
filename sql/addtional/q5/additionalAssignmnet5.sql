USE sqlPractice

SELECT * FROM student
SELECT * FROM studentdetail
SELECT * FROM studentpresent
SELECT * FROM studenthours
SELECT * FROM stuproducts
SELECT * FROM productprice

--Q-1 Write a query which will print name of each student, and his or her attendance report for current month. 
--Fields : Name, Attendance Report for Current Month
   
--	Under "Attendance Report for Current Month" column:
--		if 'studentpresent.present' is less than or equal to 7 print "Poor", 
--		if 'studentpresent.present' is more than 7 and less than or equals 15 print "Good", 
--		if 'studentpresent.present' is more than 15 and less than or equals 20 print "Better", 
--		if 'studentpresent.present' is more than 20 print "Best".

SELECT S.name,CASE WHEN SP.present <=7 THEN 'POOR'
					WHEN SP.present BETWEEN 7 AND 15 THEN 'Good'
					WHEN SP.present BETWEEN 15 AND 20 THEN 'Better'
					WHEN SP.present >20 THEN 'Best'
				END AS  Attendance_Report_for_CurrentMonth
FROM studentpresent AS SP 
JOIN student AS S
ON S.studentid = SP.studentid
WHERE SP.month = DATEPART(M,GETDATE()) 

--Q-2 Write a query to print student name, total number of hours for Jan, Feb, March month. Information for each student should be printed in a single row.

--	Fields : Name, Working Hours for Jan, Working Hours for Feb, Working Hours for March

--	See following example:
--	Name		Working Hours for Jan	Working Hours for Feb	Working Hours for March
--	Minesh		80			70			90
--	Reena		70			80			90

SELECT S.name, SH.hours AS Working_Hours_for_April,
(SELECT  SH.hours  FROM studenthours AS SH WHERE S.studentid = SH.studentid  AND  DATENAME(MONTH, SH.datex) = 'May' )AS Working_Hours_for_May,
(SELECT  SH.hours FROM studenthours AS SH WHERE S.studentid = SH.studentid  AND  DATENAME(MONTH, SH.datex) = 'june' )AS Working_Hours_for_June
FROM student AS S 
JOIN studenthours AS SH
ON S.studentid = SH.studentid
WHERE  DATENAME(MONTH, SH.datex) = 'April' 

--Print information for the student having name like "Mira", "Kabir", "Om", "Manas"
--	Fields: Name, Standard
SELECT s.studentid, s.name, sd.standard FROM student AS S
JOIN studentdetail AS SD 
ON S.studentid = SD.studnentid
WHERE S.name IN ('Mira','Kabir','Om','Manas')

--Q-4 Print information for the student having name other than "Mira", "Kabir", "Om", "Manas"
--	Fields: Name, Standard
SELECT s.studentid, s.name, sd.standard FROM student AS S
JOIN studentdetail AS SD 
ON S.studentid = SD.studnentid
WHERE S.name NOT IN ('Mira','Kabir','Om','Manas')

--Q-5 Print information for the student having presence for Jananuary between 20 to 25.
--	Fields: Name, Standard, Present

SELECT s.studentid, s.name, sd.standard, SP.present FROM student AS S
JOIN studentdetail AS SD ON S.studentid = SD.studnentid
JOIN studentpresent AS SP ON S.studentid = SP.studentid
WHERE SP.month =1 AND present BETWEEN 20 AND 25

--Q-6 Print information for the student having charcter "r" at the third position of their name.
	--Fields: Name, Standard
	--Eg: It should print information for "Mira", "Gira" etc.
SELECT s.studentid, s.name, sd.standard FROM student AS S
JOIN studentdetail AS SD
ON S.studentid = SD.studnentid
WHERE S.name LIKE '__r%'

--Q-7 Print information for the student having "bhai" in their name. 
--	Fields: Name, Standard
SELECT s.studentid, s.name, sd.standard FROM student AS S
JOIN studentdetail AS SD
ON S.studentid = SD.studnentid
WHERE S.name LIKE '%bhai%'

--Q-8 Print information for the student who do not have any presence in the college.
--	Fields: Name, Standard

SELECT s.studentid, s.name,sd.standard FROM student AS S
LEFT JOIN studentpresent AS SP ON S.studentid = SP.studentid
JOIN studentdetail AS SD ON S.studentid = SD.studnentid
WHERE SP.studentid IS NULL


SELECT S.name,SD.standard FROM student AS S
INNER JOIN studentdetail AS SD ON S.studentid = SD.studnentid
WHERE S.studentid NOT IN (SELECT studentid FROM studentpresent  )

--Q-9 Write a query which will print name of each student, and his or her attendance report for current month. 
--	Fields : Name, Attendance Report for Current Month

--	In "Attendance Report for Current Month" column 
--	if student has presence for that month then print "Present"
--	else print "Not Present".
SELECT S.name, SP.present ,SP.month,CASE WHEN SP.month = DATEPART(MONTH,GETDATE()) THEN 'Present'
										ELSE 'Not Present'
									END AS Attendance_Report_for_Current_Month
FROM student AS S
JOIN studentpresent AS SP
ON S.studentid = SP.studentid


--Q-10 Execute following queries and evaluate the output by giving appropriate reason.
--The STRCMP() function compares two strings.
--If string1 = string2, this function returns 0
--If string1 < string2, this function returns -1
--If string1 > string2, this function returns 1
	--SELECT STRCMP('text', 'text2'); ANS = -1
	--SELECT STRCMP('text2', 'text'); ANS = 1
	--SELECT STRCMP('text', 'text'); ANS = 0


--Q-11 Print the student information having average presence (in percentage) for Jan, Feb and March between 60 to 75.
--	Fields: Name, Standard, Present

SELECT S.name, SD.standard,CONVERT(VARCHAR(30), AVG((SP.present*100)/30)) + '%' AS average_presence FROM student AS S
JOIN studentdetail AS SD ON S.studentid = SD.studnentid
JOIN studentpresent AS SP ON S.studentid = SP.studentid
WHERE SP.month IN (5,7,9)
GROUP BY S.name, SD.standard
HAVING CONVERT(VARCHAR(30), AVG((SP.present*100)/30))  BETWEEN 60 AND 75

--Q-12 List information of the product having "Maximum Price" within date range 01-01-2006 to 15-01-2006