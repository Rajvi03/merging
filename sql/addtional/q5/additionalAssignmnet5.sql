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

SELECT S.name,P.month , P.present, (select present AS Attendance_Report_for_CurrentMonth from studentpresent)
FROM student AS S 
JOIN studentpresent AS P 
ON S.studentid=P.studentid 
WHERE P.month = DATEPART(M,GETDATE()) 
