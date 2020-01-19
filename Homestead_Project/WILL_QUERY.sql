-------Select Statements

DROP TABLE tbl_Activity;
DROP TABLE tbl_Activity_Attendance;
DROP TABLE tbl_Activity_Attendance_Status;
DROP TABLE tbl_Address;
DROP TABLE tbl_Child;
DROP TABLE tbl_Child_Note;
DROP TABLE tbl_Child_Treament_History;
DROP TABLE tbl_Documents;
DROP TABLE tbl_Employee;
DROP TABLE tbl_Facility;
DROP TABLE tbl_Family;
DROP TABLE tbl_Family_Notes;
DROP TABLE tbl_Job_Role;
DROP TABLE tbl_Points;
DROP TABLE tbl_School;
DROP TABLE tbl_Treatment;
DROP TABLE tbl_Treatment_Type;
DROP TABLE tbl_Daily_Attendance;
DROP TABLE dbo.tbl_Gender;

-------Select Statements

select * from tbl_Activity
select * from tbl_Activity_Attendance
select * from tbl_Activity_Attendance_Status
select * from tbl_Address
select * from tbl_Child
select * from tbl_Child_Note
select * from tbl_Child_Treament_History
select * from tbl_Documents
select * from tbl_Employee
select * from tbl_Facility
select * from tbl_Family
select * from tbl_Family_Notes
select * from tbl_Job_Role
select * from tbl_Points
select * from tbl_School
select * from tbl_Treatment
select * from tbl_Treatment_Type
SELECT * FROM tbl_Daily_Attendance;
SELECT * FROM tbl_Employee_Status;
SELECT * FROM tbl_Gender;

select facilityID, facilityName from tbl_Facility;

alter table tbl_Activity_Attendance_Status ALTER COLUMN activityAttendanceStatusType varchar(30);
ALTER TABLE tbl_Employee ADD contactNumber VARCHAR(10);
ALTER TABLE tbl_Child ADD admissionDate DATE;
ALTER TABLE tbl_Child ADD exitDate DATE;
ALTER TABLE tbl_Child ADD courtOrderDate DATE;


ALTER TABLE tbl_Employee DROP COLUMN empEmploymentTerminationDate
ALTER TABLE tbl_Employee DROP COLUMN empEmploymentStartDate

alter table tbl_Family ALTER COLUMN nationality varchar(30);

ALTER TABLE dbo.tbl_Address ADD postalCode INT;


alter table tbl_Treatment_Type ALTER COLUMN treatmentTypeDescription varchar(80)

--change frield type
alter table tbl_Employee ALTER COLUMN empStatus INT
ALTER TABLE tbl_Employee ALTER COLUMN empGender INT;
--change to add constraint
alter table tbl_Employee add CONSTRAINT Fk_tbl_Employee_Status FOREIGN KEY (empStatus) REFERENCES tbl_Employee_Status(employeeStatusID)

-------create Statments
CREATE TABLE tbl_Daily_Attendance(
	dailyAttendanceID INT IDENTITY(1,1),
	fileNumber VARCHAR(40),
	dailyAttendanceStatusID INT,

	CONSTRAINT PK_tbl_Daily_Attendance PRIMARY KEY(dailyAttendanceID),
	CONSTRAINT fk_tbl_Daily_Attendance_Type FOREIGN KEY(fileNumber) REFERENCES dbo.tbl_Child(fileNumber),
	CONSTRAINT fk_tbl_DailyAttendanceStatus FOREIGN KEY(dailyAttendanceStatusID) REFERENCES tbl_DailyAttendanceStatus(dailyAttendanceStatusID),
);

CREATE TABLE tbl_DailyAttendanceStatus(
	dailyAttendanceStatusID INT IDENTITY(1,1),
	dailyAttendanceType varchar(10),
	
	CONSTRAINT PK_tbl_DailyAttendanceStatus PRIMARY KEY(dailyAttendanceStatusID)
);

create table tbl_Job_Role
(
	jobRoleID int identity(1,1),
	jobRoleDescription varchar(50),

	Constraint PK_tbl_Role Primary key(jobRoleID)
);

create table tbl_Address
(
	addressID 	int identity(1,1),
	province	varchar(20),
	suburb		varchar(20),
	town		varchar(30),
	streetName	varchar(30),
	houseNumber	varchar(10),

	Constraint PK_tbl_Address Primary key(addressID),
);

select addressID FROM tbl_Address WHERE houseNumber = '18';

--Points update might not have a specific activity associated with it. No half points can be added. only integer values
create table tbl_Facility
( 
	facilityID			int identity(1,1),
	addressID			int,
	facilityName		varchar(50),
	facilityDescription	varchar(50),

	Constraint PK_tbl_Facility Primary key(facilityID),
	Constraint FK_tbl_Facility_Address FOREIGN KEY (addressID) REFERENCES tbl_Address (addressID)
);

--Possible complications with the date and time fields. Maybe join them togeth under a dateTime datatype and you can pull the information from one field. dateTime format YYYY-MM-DD HH:MM:SS 
create table tbl_Activity
(
	activityID					int identity(1,1),
	facilityID					int,
	activityDescription			varchar(30),
	activityDate				date,
	activityTime				time,
	activityPointAllocation		int,

	Constraint PK_tbl_Activity Primary key(activityID),
	Constraint FK_tbl_Activity_facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID)
);

---

create table tbl_Activity_Attendance_Status
(
	activityAttendanceStatusID		int identity(1,1),
	activityAttendanceStatusType	varchar(30),

	Constraint PK_Activity_Attendance_Status Primary key(activityAttendanceStatusID),

);
------

create table tbl_Treatment_Type
(
	treatmentTypeId				int identity(1,1),
	treatmentTypeDescription	varchar(20),

	Constraint PK_tbl_Treatment_Type Primary key(treatmentTypeId),
);
-------
create table tbl_School
(
	schoolID			int identity(1,1),
	addressID			int,
	schoolName			varchar(40),
	schoolContactNum	varchar(10),

	Constraint PK_tbl_School Primary key(schoolID),
	Constraint FK_tbl_School_Address FOREIGN KEY (addressID) REFERENCES tbl_Address (addressID),
);

------
create table tbl_Family_Notes
(
	familyNoteID		int identity(1,1),
	noteDescription		varchar(50),
	noteDate			datetime,

	Constraint PK_tbl_family_Note Primary key(familyNoteID),

);

CREATE TABLE tbl_Nationality(
	nationalityID INT IDENTITY(1,1),
	nationalityDesc VARCHAR(20),

	CONSTRAINT pk_tbl_Nationality PRIMARY KEY(nationalityID)
);
----------------
-- unsure of number of family notes a specific family member may have. Thinking of doing the same as i did with the child and child notes table where you only put notes in the child notes table with a link to which child the 
-- note is associated with. Can revert this at a later date if there are problems
create table tbl_Family
(
	familyMemberID		int identity(1,1),
	addressID			int,
	familyNoteID		int,
	firstName			varchar(30),
	lastName			varchar(30),
	dateOfBirth			date,
	genderID						int,
	nationalityID					int,
	
	Constraint PK_tbl_Family Primary key(familyMemberID),
	Constraint FK_tbl_Family_Address FOREIGN KEY (addressID) REFERENCES tbl_Address (addressID),
	Constraint FK_tbl_Family_Notes FOREIGN KEY (familyNoteID) REFERENCES tbl_Family_Notes (familyNoteID),
	Constraint FK_tbl_Family_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Family_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID)
);

-----------------------------------------------------------------------------------
create table tbl_Employee
(
	empID							int identity(1,1),
	facilityID						int,
	addressID						int,
	jobRoleID 						int,
	empFirstName					varchar(50),
	empLastName						varchar(50),
	empEmail						varchar(30),
	empDateOfBirth					date,
	genderID						int,
	nationalityID					int,
	employeeStatusID						int,
	empPassword						varchar(50),
	

	Constraint PK_tbl_Employee Primary key(empID),
	Constraint FK_tbl_Employee_Facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	Constraint FK_tbl_Employee_Address FOREIGN KEY (addressID) REFERENCES tbl_Address(addressID),
	Constraint FK_tbl_Employee_JobRoleID FOREIGN KEY (jobRoleID) REFERENCES tbl_Job_Role(jobRoleID),
	Constraint FK_tbl_Employee_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Employee_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID),
	Constraint FK_tbl_Employee_StatusID FOREIGN KEY (employeeStatusID) REFERENCES tbl_Employee_Status(employeeStatusID)
);

CREATE TABLE tbl_Gender(
	genderID INT IDENTITY(1,1),
	genderDescription VARCHAR(10),

	CONSTRAINT pk_tbl_Gender PRIMARY KEY(genderID)
	);


create table tbl_Employee_Status
(
	employeeStatusID	int identity(1,1),
	employeeStatusDescription	varchar(20),

	Constraint PK_Employee_Status Primary key (employeeStatusID)
);
-- calculating total points of a child is done when needed. No total points of a child will be stored in the child table or the points table
-- Separate child note from child table as there be more than one note per child on a specific day.
create table tbl_Child
(
	fileNumber			varchar(40),
	schoolID			int,
	facilityID			int,
	familyID			int,
	addressID			int,
	childName			varchar(30),
	childSurname		varchar(30),
	dateOfBirth			date,
	genderID			int,
	nationalityID		int,
	admissionDate		DATE,
	exitDate			DATE,
	courtOrderExpirationDate DATE,

	Constraint PK_tbl_Child Primary key(fileNumber),
	Constraint FK_tbl_Child_School FOREIGN KEY (schoolID) REFERENCES tbl_School (schoolID),
	Constraint FK_tbl_Child_facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	Constraint FK_tbl_Child_family FOREIGN KEY (familyID) REFERENCES tbl_Family (familyMemberID),
	Constraint FK_tbl_Child_Address FOREIGN KEY (addressID) REFERENCES tbl_Address (addressID),
	Constraint FK_tbl_Child_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Child_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID),
);
--
--Composite key of all the fields linked or a single primary key???
create table tbl_Activity_Attendance
(
	activityAttendanceID	int identity(1,1),
	activityID				int,
	fileNumber				varchar(40),
	facilityID				int,
	attendanceStatusID		int,

	Constraint PK_tbl_Activity_Attendance Primary key(activityAttendanceID),
	Constraint FK_tbl_Activity_Attendance_facility_ FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	Constraint FK_tbl_Activity_Attendance_Child FOREIGN KEY (fileNumber) REFERENCES tbl_Child (fileNumber),
	Constraint FK_tbl_Activity_Attendance_Status FOREIGN KEY (attendanceStatusID) REFERENCES tbl_Activity_Attendance_Status (activityAttendanceStatusID)
);
--
create table tbl_Points
(
	pointsID			int identity(1,1),	
	fileNumber			varchar(40) not null,
	activityID			int,
	allocatedPointValue	int not null,
	reasonForPoints		varchar(30),

	Constraint PK_tbl_Points Primary key(pointsID),
	Constraint FK_tbl_Points_Child FOREIGN KEY (fileNumber) REFERENCES tbl_Child (fileNumber),
	Constraint FK_tbl_Points_Activity FOREIGN KEY (activityID) REFERENCES tbl_Activity (activityID)
);

create table tbl_Child_Note
(
	childNotesID		int identity(1,1),
	fileNumber			varchar(40),
	noteDescription		varchar(50),
	noteDate			datetime,

	Constraint PK_tbl_ChildNotes Primary key(childNotesID),
	Constraint FK_tbl_ChildNotes_Child FOREIGN KEY (fileNumber) REFERENCES tbl_Child (fileNumber),
);

--there may be multiple documents to a child. Dont want to link the child to the documents. Link a document to a child. Might cause complications in the latter with duplicate data.
create table tbl_Documents
(
	documentID			int identity(1,1),
	fileNumber			varchar(40),
	documentName		varchar(40),
	documentDescription	varchar(40),

	Constraint PK_tbl_Documents Primary key(documentID),
	Constraint FK_tbl_Documents_Child FOREIGN KEY (fileNumber) REFERENCES tbl_Child (fileNumber),
);

--treatment dateTime
create table tbl_Treatment
(
	treatmentID					int identity(1,1),
	empID						int,
	fileNumber					varchar(40),
	facilityID					int,
	treatmentTypeID				int,
	treatmentDescription		varchar(30),
	treatmentDate				datetime,

	Constraint PK_tbl_Treatment Primary key(treatmentID),
	Constraint FK_tbl_Treatment_Employee FOREIGN KEY (empID) REFERENCES tbl_Employee (empID),
	Constraint FK_tbl_Treatment_Child FOREIGN KEY (fileNumber) REFERENCES tbl_Child (fileNumber),
	Constraint FK_tbl_Treatment_Facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	Constraint FK_tbl_Treatment_Type FOREIGN KEY (treatmentTypeID) REFERENCES tbl_Treatment_Type (treatmentTypeID),
);

--composite primary or single primary for table? can pull the date of treatment from the treatment table.
create table tbl_Child_Treament_History
(
	treatmentHistoryID		int identity(1,1),
	treatmentID				int,
	treatmentTypeID			int,
	fileNumber				varchar(40),

	Constraint PK_tbl_Child_Treament_History Primary key(treatmentHistoryID),
	Constraint FK_tbl_Child_Treament_History_Treatment FOREIGN KEY (treatmentID) REFERENCES tbl_Treatment (treatmentID),
	Constraint FK_tbl_Child_Treament_History_Treatment_Type FOREIGN KEY (treatmentTypeID) REFERENCES tbl_Treatment_Type (treatmentTypeID),
	Constraint FK_tbl_Child_Treament_History_Child FOREIGN KEY (fileNumber) REFERENCES tbl_Child (fileNumber),
);

----------------------------------------------------------------------------------------------------------------------------------------------------
--insert Statements

insert into tbl_Address(province,suburb,town,streetName,houseNumber) 
values 
('Western Cape','Southern Suburbs','Cape Town','hopkins road','24'),
('Western Cape','Belhar','Cape Town','Stevens road','56'),
('Eastern Cape','Kenton-on-Sea','Port Elizabeth','Bobern','21');

insert into tbl_Job_Role
values
('Facility Manager'),
('Social Worker'),
('Big Boss Man');



insert into tbl_School
values
(2,'Kuyasa Primary','0216358759'),
(3,'Joe Slovo High','0213729035'),
(1,'Homba Primary','2162346780');

insert into tbl_Activity_Attendance_Status
values
('Present'),
('Excused'),
('Did not Attend');

SELECT * FROM dbo.tbl_Facility

insert into tbl_Facility
values
(1,'Launch Pad','Counceling, Job Placement'),
(2,'Drop In Center','Shower and Food, Street Child Care'),
(3,'Early Intervention','Living facilities, rehab'),
(3,'Shelter Name here','Living facilities, rehab');

--YYYY-MM-DD HH:MM:SS
insert into tbl_Family_Notes
values
('Sibling','2019-08-02 09:48:25'),
('Spouse','2015-07-14 15:11:11'),
('Father','2018-06-04 17:57:45'),
('Mother','2017-04-20 14:32:59'),
('Sister','2018-02-26 13:44:32');

--default date format YYYY-MM-DD, default time format HH:MM:SS
insert into tbl_Activity
VALUES
(2,'Personal Hygiene Talk','2019-10-02','12:22',5)
(2,'Soccer game','2019-09-02','14:30:00',20),
(4,'Sex education','2019-09-09','09:45:00',10),
(2,'Personal Hygiene Talk','2019-09-02','12:22',5);

SELECT * FROM dbo.tbl_Facility

SELECT * FROM dbo.tbl_Activity;
  select tbl_Activity.activityDescription, tbl_Facility.facilityName, tbl_Activity.activityDate, tbl_Activity.activityTime, tbl_Activity.activityPointAllocation 
  FROM tbl_Activity, tbl_Facility
  WHERE (tbl_Activity.facilityID = tbl_Facility.facilityID) AND (tbl_Activity.activityDate = '2019/10/04');

---familyMemberID Ai, addressId, familymemberID, firstName, lastName, dateOfBirth, gender, nationality
insert into tbl_Family
values
(3,1,'NomNom','Moloko','1996-06-12',2,2),
(2,2,'Siphosethu','Dyasi','1999-07-06',2,1),
(1,3,'Ewan','Tasker','1998-05-22',1,2);

SELECT * FROM tbl_Employee_Status
insert into tbl_Employee_Status
values
('Currently Employed'),
('On Leave'),
('Not longer working');

--pk ai, facilityID, addressID, jobRoleID, empFirstName,empLastName, empEmail, empDateOfBirth, empGender, empNationality, empStatus,empPassword, empEmploymentStartDate, v
insert into tbl_Employee
values
(2,14,1,'Bob','Ross','br@gmail.com','1969-07-12',1,1,1,'Password','2010-01-01',NULL, '0835531494' ),
(3,2,2,'Tim','Stevens','Tstevens@gmail.com','1989-08-27','Male','South Africa',1,'Password','2019-06-22',''),
(4,2,3,'Kim','Lo','Klo@yahoo.co.za','1991-04-03','Female','Zimbabwe',1,'Password','2016-11-26','');

SELECT * FROM tbl_Employee;
SELECT * FROM TBL_Address;
SELECT * FROM tbl_Facility;

SELECT * FROM tbl_Employee
WHERE (empEmail = 'br@gmail.com') 
AND (empPassword = 'Password')

SELECT * FROM tbl_Employee WHERE (empEmail = 'br@gmail.com') AND (empPassword = 'Password');


AND (employeeStatusID = 1);


--fileNumber, schoolID, facilityID, familyID, addressID, childName, childSurname, dateOfBirth, childGender, childNationality
insert into tbl_Child
VALUES
('HS1420',2,2,2,1,'Bonniew','Dell','2019-10-14',2,2, '2015-04-20', NULL, '2019-10-26'),
('HS1403',2,2,2,1,'Bella','Dell','2019-09-14',2,2),
('HS1346',1,2,2,3,'Tom','Cruse','1999-08-27',1,1),
('HS1389',1,3,3,1,'Jim','Bo','1998-03-22',2,2),
('HS1234',3,4,3,2,'Heather','Smith','1996-03-11','Female','South Africa');

SELECT * FROM tbl_Child;

SELECT childName, childSurname, dateOfBirth, courtOrderDate FROM dbo.tbl_Child
WHERE (MONTH(dateOfBirth) = MONTH('2019/09/22')) OR (DAY(courtOrderDate) = DAY('2019-09-26'))
UNION 
SELECT childName, childSurname, courtOrderDate FROM tbl_Child 
WHERE MONTH(courtOrderDate) = MONTH('2019-09-26')
	AND DAY(courtOrderDate) = DAY('2019-09-26');

SELECT childName, childSurname, courtOrderDate FROM tbl_Child
WHERE MONTH(courtOrderDate) = MONTH('2019/10/22')

SELECT childName, childSurname, dateOfBirth FROM tbl_Child
WHERE MONTH(dateOfBirth) = MONTH('2019/10/22')

SELECT activityDescription, activityDate, activityTime FROM tbl_Activity
WHERE MONTH(activityDate) = MONTH('2019/10/22')

SELECT * FROM dbo.tbl_Activity;

  select tbl_Activity.activityDescription, tbl_Facility.facilityName, tbl_Activity.activityDate, tbl_Activity.activityTime, tbl_Activity.activityPointAllocation 
  FROM tbl_Activity, tbl_Facility
  WHERE (tbl_Activity.facilityID = tbl_Facility.facilityID) AND (MONTH(activityDate) = MONTH('2019/10/14'));

SELECT childName, childSurname, court
--childNotesID Aim, fileNumber, noteDescription, noteDate
--default date format YYYY-MM-DD, default time format HH:MM:SS
insert into tbl_Child_Note
values
('HS1346','Child needs rehab','2019-09-02 11:56:11'),
('HS1389','Child has Cancer','2018-06-11 03:22:24'),
('HS1403','Child needs psychiatric help','2019-09-02 15:45:54'),
('HS1234','Child Gone home','2014-03-22 17:32:34');

--documentID AI, fileNumber, documentName, documentDescription
insert into tbl_Documents
values
('HS1346','Birth Certificate','Proof of birth of child'),
('HS1346','Arrest Warrent','null'),
('HS1234','Medical Report','For when child was in car accident');

--activityAttendanceID AI, activityID, fileNumber, facilityID, attendanceStatusID
insert into tbl_Activity_Attendance
values
(1,'HS1346',1,1),
(1,'HS1389',1,1),
(1,'HS1234',1,3);

--pointsID ai, fileNumber, activityID, allocatedPointValue, reasonForPoints
insert into tbl_Points
values
('HS1346',1,20,'Attendance'),
('HS1389',1,20,'Attendance'),
('HS1234',1,20,'Attendance');

--treatmentTypeId ai, treatmentTypeDescription
insert into tbl_Treatment_Type
values
('Rehabilitation'),
('Counseling'),
('Behaviour modification');

--treatmentID ai, empID, fileNumber, facilityID, treatmentTypeID, treatmentDescription, treatmentDate
-- Defalt datetime YYYY-MM-DD HH:MM:SS
insert into tbl_Treatment
values
(1,'HS1346',1,1,'Drug addiction','2019-09-01 14:30:22'),
(2,'HS1346',1,2,'Aggressive tendancies','2019-09-02 14:30:22'),
(3,'HS1346',2,1,'Life improvement','2019-09-02 13:20:12');

--treatmentHistoryID ai, treatmentID, treatmentTypeID, fileNumber	
insert into tbl_Child_Treament_History
values
(2,1,'HS1346'),
(3,2,'HS1346'),
(4,1,'HS1346');

SELECT * FROM dbo.tbl_Gender

INSERT INTO tbl_Gender
VALUES
('Male'),
('Female');

SELECT * FROM dbo.tbl_Nationality

INSERT INTO dbo.tbl_Nationality
VALUES
('South African'),
('Other');

SELECT * FROM tbl_Employee;