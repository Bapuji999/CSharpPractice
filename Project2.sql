CREATE DATABASE Project2;
USE Project2;

------------------------------------------------------- ------------------------------------------------------------------------------------------------------------------------

CREATE TABLE University
(
	UniversityId INT PRIMARY KEY AUTO_INCREMENT,
	UniversityName VARCHAR(250) NOT NULL,
	UnversityType VARCHAR(50),
	UnvesrsityGrade VARCHAR(50),
	UnversityAddress VARCHAR(500)
);

INSERT INTO University(UniversityName, UnversityType, UnvesrsityGrade, UnversityAddress) 
			VALUES('AAAAAA', 'Private', 'A', 'Mahatma Gandhi Road, Fort, Mumbai, Maharashtra 400032.');
INSERT INTO University(UniversityName, UnversityType, UnvesrsityGrade, UnversityAddress) 
			VALUES('BBBBBB', 'Autonomous', 'B', 'NH-16, Chaitanya Knowledge City, Rajamahendravaram, Andhra Pradesh 533296');
INSERT INTO University(UniversityName, UnversityType, UnvesrsityGrade, UnversityAddress) 
			VALUES('BPUT', 'State', 'C', 'Chhend Colony, Rourkela, Odisha-769015');
		
------------------------------------------------------- ------------------------------------------------------------------------------------------------------------------------

CREATE TABLE College
(
	CollegeId INT PRIMARY KEY AUTO_INCREMENT,
	CollegeName VARCHAR(250) NOT NULL,
	CollegeType VARCHAR(50),
	CollegeAddress VARCHAR(500),
    UniversityId INT,
	FOREIGN KEY (UniversityId) REFERENCES University(UniversityId)
);

INSERT INTO  College(CollegeName, CollegeType, CollegeAddress, UniversityId)
			 VALUES('Narsee Monjee College of Commerce and Economics', 'Business', 'Bhagubai Mafatlal Complex, Swami Bhaktivedant Marg, opp. Cooper Hospital, Navpada, Suvarna Nagar, Vile Parle West, Mumbai, Maharashtra 400056', 1);

INSERT INTO  College(CollegeName, CollegeType, CollegeAddress, UniversityId)
			 VALUES('Jai Hind College', 'arts and sciences', 'Bhalesar Road, Ward 20, Mahasamund, Chhattisgarh 493445', 1);
             
INSERT INTO  College(CollegeName, CollegeType, CollegeAddress, UniversityId)
			 VALUES('K.J. Somaiya Institute of Management', 'MBA', 'Somaiya Vidyavihar University, Vidya Vihar East, Mumbai, Maharashtra 400077', 1);
             
INSERT INTO  College(CollegeName, CollegeType, CollegeAddress, UniversityId)
			 VALUES('KL University (KLU)', 'B.Tech', 'Green Fields, K L UNIVERSITY, Vaddeswaram, Andhra Pradesh 522303', 2);
             
INSERT INTO  College(CollegeName, CollegeType, CollegeAddress, UniversityId)
			 VALUES('Birla Institute of Technology & Science (BITS)', 'M.Pharm', 'BITS Pilani Hyderabad Campus, Secunderabad, Telangana 500078', 2);
             
INSERT INTO  College(CollegeName, CollegeType, CollegeAddress, UniversityId)
			 VALUES('ADARSHA COLLEGE OF ENGINEERING', 'B.Tech', 'AT-SARADHAPUR, PO-KUMURISINGHA, ANUGUL-759122', 3);
             
------------------------------------------------------- ------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Department
(
	DepartmentId INT PRIMARY KEY AUTO_INCREMENT,
	DepartmentName VARCHAR(250) NOT NULL,
	NuumberOfClass INT,
	DepartmentHead VARCHAR(250),
	CollegeId INT,
	FOREIGN KEY (CollegeId) REFERENCES College(CollegeId)
);

INSERT INTO Department(DepartmentName, NuumberOfClass, DepartmentHead, CollegeId)
				VALUES('Accounting', 3, 'Rossen Petkov', 1);
INSERT INTO Department(DepartmentName, NuumberOfClass, DepartmentHead, CollegeId)
				VALUES('Business Administration', 2, 'Dr. Muindi Florence', 1);
INSERT INTO Department(DepartmentName, NuumberOfClass, DepartmentHead, CollegeId)
				VALUES('Physics', 4, 'Dr.K.ANBUKUMARAN', 2);
INSERT INTO Department(DepartmentName, NuumberOfClass, DepartmentHead, CollegeId)
				VALUES('English', 2, 'Dr. Shagufta Parween', 2);
INSERT INTO Department(DepartmentName, NuumberOfClass, DepartmentHead, CollegeId)
				VALUES('Marketing', 1, 'Seth Godin', 3);
INSERT INTO Department(DepartmentName, NuumberOfClass, DepartmentHead, CollegeId)
				VALUES('Computer Science', 2, 'Tanmay De', 4);
INSERT INTO Department(DepartmentName, NuumberOfClass, DepartmentHead, CollegeId)
				VALUES('Medicinal Chemistry', 5, 'Dr. N. Shankaraiah', 5);
INSERT INTO Department(DepartmentName, NuumberOfClass, DepartmentHead, CollegeId)
				VALUES('Computer Science', 4, 'Prof. M.R.Ravi', 6);

------------------------------------------------------- ------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Professor
(
	ProfessorId INT PRIMARY KEY AUTO_INCREMENT,
	ProfessorName VARCHAR(250) NOT NULL,
	ProfessorAddress VARCHAR(500),
	ProfessorAge INT  CHECK(ProfessorAge >= 0 AND ProfessorAge <=100),
	Salary FLOAT,
	DepartmentId INT,
	FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);

INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Rossen Petkov', 'Bhagubai Mafatlal Complex, Swami Bhaktivedant Marg', 45, 40000.00, 1);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Dr.M.Swapna', 'Bhagubai Mafatlal Complex, Swami Bhaktivedant Marg', 35, 50000.00, 1);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Dr. Muindi Florence', 'Bhagubai Mafatlal Complex, Swami Bhaktivedant Marg', 47, 65000.00, 2);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('‎Subhash Chandra Mishra', 'Bhagubai Mafatlal Complex, Hanuman Marg', 44, 58000.00, 2);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('‎Dr. N. K. Chougule', 'Bhalesar Road, Ward 20, Mahasamund, Chhattisgarh 493445', 34, 31000, 3);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('‎Dr.K.ANBUKUMARAN', 'Bhalesar Road, Ward 20, Mahasamund, Chhattisgarh 493445', 38, 52000, 3);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Dr. Shagufta Parween', 'Bhalesar Road, Ward 20, Mahasamund, Chhattisgarh 493445', 32, 32000, 4);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Dr. B. D Sahoo', 'Bhalesar Road, Ward 20, Mahasamund, Chhattisgarh 493445', 36, 21000, 4);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Seth Godin', 'Somaiya Vidyavihar University, Vidya Vihar East, Mumbai, Maharashtra 400077', 56, 48000, 5);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Tanmay De', 'Green Fields, K L UNIVERSITY, Vaddeswaram, Andhra Pradesh 522303', 34, 41000, 6);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Dr. N. Shankaraiah', 'BITS Pilani Hyderabad Campus, Secunderabad, Telangana 500078', 52, 68000, 7);
INSERT INTO Professor(ProfessorName, ProfessorAddress, ProfessorAge, Salary, DepartmentId)
			   VALUES('Prof. M.R.Ravi', 'AT-SARADHAPUR, PO-KUMURISINGHA, ANUGUL-759122', 32, 45000, 8);
               
               
------------------------------------------------------- ------------------------------------------------------------------------------------------------------------------------

CREATE TABLE Student
(
	StudentId INT PRIMARY KEY AUTO_INCREMENT,
	StudentName VARCHAR(250) NOT NULL,
	StudentAddress VARCHAR(500),
	Age INT CHECK(Age >= 0 AND Age <=100),
	StudentPercentage FLOAT,
	StudentMarks FLOAT CHECK(StudentMarks >= 0 AND StudentMarks <=1000),
	StudentResult VARCHAR(4),
	DepartmentId INT,
	FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);

DELIMITER //
CREATE TRIGGER CalculatePercentage 
BEFORE INSERT ON Student 
FOR EACH ROW 
BEGIN
    SET NEW.StudentPercentage = (NEW.StudentMarks / 1000) * 100, 
		NEW.StudentResult = CASE WHEN NEW.StudentMarks < 300 THEN 'Fail' ELSE 'Pass' END;
END //
DELIMITER ;

INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Akash', 'Bidaya Pur', 22, 553.68, 1);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Prakash', 'Ambala', 24, 671.68, 1);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Dinesh', 'Uk', 21, 577.96, 1);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ravi', 'Delhi', 26, 207.44, 1);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suman', 'Hariyana', 22, 643.68, 2);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Raman', 'Ambala', 24, 781.49, 2);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suresh', 'Uk', 21, 278.56, 2);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ramesh', 'Delhi', 26, 816.64, 2);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Rosni', 'Hariyana', 22, 541.68, 3);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ansu', 'Ambala', 24, 451.49, 3);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suresh', 'Uk', 21, 478.56, 3);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ramesh', 'Delhi', 26, 636.64, 3);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Akash', 'Bidaya Pur', 22, 603.68, 4);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Prakash', 'Ambala', 24, 681.44, 4);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Dinesh', 'Uk', 21, 777.36, 4);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ravi', 'Delhi', 26, 507.64, 4);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suman', 'Hariyana', 22, 443.38, 5);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Raman', 'Ambala', 24, 981.80, 5);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suresh', 'Uk', 21, 278.56, 5);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ramesh', 'Delhi', 26, 816.64, 5);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Rosni', 'Hariyana', 22, 341.68, 6);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ansu', 'Ambala', 24, 450.49, 6);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suresh', 'Uk', 21, 718.56, 6);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ramesh', 'Delhi', 26, 536.64, 6);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suman', 'Hariyana', 22, 610.08, 7);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Raman', 'Ambala', 24, 351.50, 7);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suresh', 'Uk', 21, 468.16, 7);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ramesh', 'Delhi', 26, 606.31, 7);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Rosni', 'Hariyana', 22, 781.67, 8);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ansu', 'Ambala', 24, 670.67, 8);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Suresh', 'Uk', 21, 488.62, 8);
INSERT INTO Student(StudentName, StudentAddress, Age, StudentMarks, DepartmentId)
			VALUES('Ramesh', 'Delhi', 26, 236.14, 8);
            
------------------------------------------------------- ------------------------------------------------------------------------------------------------------------------------

-- 1. Get the list of students who belong with a University Name is ‘AAAAAA’. --

SELECT S.*
FROM Student S
INNER JOIN Department D ON D.DepartmentId = S.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
INNER JOIN University U ON U.UniversityId = C.UniversityId
WHERE UniversityName = 'AAAAAA';

-- 2. Groups the students university-wise, college-wise, and department-wise. --

SELECT S.*, UniversityName, CollegeName, DepartmentName
FROM Student S
INNER JOIN Department D ON D.DepartmentId = S.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
INNER JOIN University U ON U.UniversityId = C.UniversityId
ORDER BY U.UniversityId, C.CollegeId, D.DepartmentId;

--  3. Get the list of professors(University name, 'Collegename' , 'DepartmentName', 'ProfessorId', 'ProfessorName', 'ProfessorAddress', 'ProfessorAge') whose salary is more than $ 50,000.00.  --

SELECT UniversityName, CollegeName, DepartmentName, ProfessorId, ProfessorName, ProfessorAddress, ProfessorAge
FROM Professor P
INNER JOIN Department D ON D.DepartmentId = P.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
INNER JOIN University U ON U.UniversityId = C.UniversityId
WHERE Salary > 50000;

-- 4. Get the sum of salary whose belonging university Name is ‘BBBBBB’. -- 

SELECT SUM(Salary) TotalSalary
FROM Professor P
INNER JOIN Department D ON D.DepartmentId = P.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
INNER JOIN University U ON U.UniversityId = C.UniversityId
WHERE UniversityName = 'BBBBBB';

--  5. Count students university-wise who have passed first, second and third division. --

SELECT 
	UniversityName,
	SUM(CASE WHEN StudentPercentage > 60 THEN 1 ELSE 0 END) AS First,
	SUM(CASE WHEN StudentPercentage > 50 AND StudentPercentage < 60 THEN 1 ELSE 0 END) AS Second,
	SUM(CASE WHEN StudentPercentage > 30 AND StudentPercentage < 50 THEN 1 ELSE 0 END) AS Third
FROM Student S
INNER JOIN Department D ON D.DepartmentId = S.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
INNER JOIN University U ON U.UniversityId = C.UniversityId
GROUP BY U.UniversityId, UniversityName;

-- 6. Get List of students who study in the ‘Computer Science’ department. --

SELECT S.*, DepartmentName
FROM Student S
INNER JOIN Department D ON D.DepartmentId = S.DepartmentId
WHERE DepartmentName = 'Computer Science';

-- 7. Get the name of the university who have passed with maximum marks. --

SELECT UniversityName
FROM Student S
INNER JOIN Department D ON D.DepartmentId = S.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
INNER JOIN University U ON U.UniversityId = C.UniversityId
WHERE StudentMarks IN (SELECT MAX(StudentMarks) FROM Student);

-- 8. Get list of students who study in grade ‘A’ University --

SELECT s.*
FROM Student S
INNER JOIN Department D ON D.DepartmentId = S.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
INNER JOIN University U ON U.UniversityId = C.UniversityId
WHERE UnvesrsityGrade = 'A';

-- 9. The percentage of passed students who belong with a University Name is ‘AAAAAA’. --

SELECT ((SUM(CASE WHEN StudentResult = 'Pass' THEN 1 ELSE 0 END)/COUNT(StudentId))*100) AS PassStudentPercentage
FROM Student S
INNER JOIN Department D ON D.DepartmentId = S.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
INNER JOIN University U ON U.UniversityId = C.UniversityId
WHERE UniversityName = 'AAAAAA';

-- 10.Get the percentage of the result college wise. --

SELECT C.CollegeId, CollegeName, ROUND(((SUM(StudentMarks)/(COUNT(StudentId)*1000))*100),2) TotalResult
FROM Student S
INNER JOIN Department D ON D.DepartmentId = S.DepartmentId
INNER JOIN College C ON C.CollegeId = D.CollegeId
GROUP BY C.CollegeId;
