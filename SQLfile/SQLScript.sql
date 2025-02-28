CREATE DATABASE School;
USE School;

CREATE TABLE Student (
    roll_no INT PRIMARY KEY,          
    name VARCHAR(100) NOT NULL     
);

CREATE TABLE Teacher (
    id INT PRIMARY KEY, 
    name VARCHAR(100) NOT NULL,       
    subject_taught VARCHAR(100) NOT NULL 
);

CREATE TABLE Staff (
    id INT PRIMARY KEY,  
    name VARCHAR(100) NOT NULL,       
    designation VARCHAR(100) NOT NULL  
);

INSERT INTO Student (roll_no, name)
VALUES 
(101, 'Clive Esperance'),
(102, 'Ankur Falari'),
(103, 'Monesh Haldonkar');

INSERT INTO Teacher
VALUES 
(201,'Mr Ramrao', 'Mathematics'),
(202,'Mrs Preeti', 'Physics'),
(203,'Mr Roberts', 'Chemistry');


INSERT INTO Staff
VALUES 
(1,'Jack', 'Administrative Officer'),
(2,'Jill', 'Librarian'),
(3,'Mike', 'Security');


SELECT * FROM Student;
SELECT * FROM Teacher;
SELECT * FROM Staff;

ALTER TABLE Student
ADD teacher_id INT;

ALTER TABLE Student
ADD CONSTRAINT Student_Teacher
FOREIGN KEY (teacher_id) REFERENCES Teacher(id);

CREATE TABLE UserProfile
(
	UserId INT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(15),
	Password VARCHAR(15),
	IsActive BIT
);

USE School;

INSERT INTO UserProfile (Username, Password, IsActive)
VALUES ('Clive','123456789',1);

SELECT * FROM UserProfile;