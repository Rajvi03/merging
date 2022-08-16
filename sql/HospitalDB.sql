CREATE DATABASE Hospital;

USE Hospital; 

CREATE TABLE Department 
( 
departmentID INT PRIMARY KEY, 
departmentName varchar(50) 
) 

CREATE TABLE Doctors 
(
doctorsId INT PRIMARY KEY, 
doctorName varchar(30), 
departmentId int CONSTRAINT FK_deptId FOREIGN KEY REFERENCES Department(departmentID) 
) 

CREATE TABLE Assistants 
( 
assistantsId INT PRIMARY KEY, 
assistantName varchar(30), 
departmentId int FOREIGN KEY REFERENCES Department(departmentID) 
) 

CREATE TABLE Patients 
( 
patientId INT PRIMARY KEY, 
patientName varchar(30), 
doctorId INT CONSTRAINT FK_docId FOREIGN KEY REFERENCES Doctors(doctorsId), 
assistantId INT CONSTRAINT FK_AssistantId FOREIGN KEY REFERENCES Assistants(assistantsId) 
) 

CREATE TABLE Drugs 
( 
drugId INT PRIMARY KEY, 
drugName varchar(30) 
) 

CREATE TABLE DrugsDetails 
( 
drugsDetailsId INT PRIMARY KEY, 
patientId INT CONSTRAINT FK_PatientId FOREIGN KEY REFERENCES Patients(patientId), 
drugId INT CONSTRAINT FK_DrugId FOREIGN KEY REFERENCES Drugs(drugId), 
timing VARCHAR(30) CONSTRAINT CK_Time CHECK(timing='Morning' or timing = 'Afternoon' or timing = 'Night') 
) 

INSERT INTO Department VALUES 
(1,'physiotherapy'), 
(2,'Cardiologist') 

SELECT * FROM Department 

INSERT INTO Doctors VALUES 
(1,'Doctor1',1), 
(2,'Doctor2',2), 
(3,'Doctor3',1), 
(4,'Doctor4',2) 

SELECT * FROM Doctors 
INSERT INTO Assistants VALUES 
(1,'Assistant1',1), 
(2,'Assistant2',2) 
SELECT * FROM Assistants 

INSERT INTO Patients VALUES 
(1,'John',1,NULL), 
(2,'Anna',2,2) 

SELECT * FROM Patients 
INSERT INTO Drugs VALUES 
(1,'Drug1'), (2,'Drug2') 

SELECT * FROM Drugs 

INSERT INTO DrugsDetails VALUES 
(1,1,1,'Morning'), 
(2,1,1,'Night'), 
(3,2,2,'Morning'), 
(4,2,2,'Afternoon') 

SELECT * FROM DrugsDetails