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
DROP TABLE tbl_DailyAttendanceStatus;
DROP TABLE dbo.tbl_Gender;

DROP TABLE dbo.tbl_StatutoryType

ALTER TABLE tbl_Facility DROP constraint FK_tbl_Facility_Address;

--EWAN--
CREATE table tbl_Activity_Attendance_Status
(
	activityAttendanceStatusID	int identity(1,1),
	activityAttendanceStatusType	varchar(30),

	Constraint PK_Activity_Attendance_Status Primary key(activityAttendanceStatusID),

);

insert into tbl_Activity_Attendance_Status
values
('Present'),
('Excused'),
('Did not Attend');

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

create table tbl_Facility
( 
	facilityID			int identity(1,1),
	facilityName		varchar(50),
	facilityDescription	varchar(50),

	Constraint PK_tbl_Facility Primary key(facilityID),
	
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

create table tbl_Activity_Attendance
(
	activityAttendanceID	int identity(1,1),
	activityID				int,
	fileNumber				varchar(40),
	attendanceStatusID		int,
	activityDate			DATE,

	Constraint PK_tbl_Activity_Attendance Primary key(activityAttendanceID),
	Constraint FK_tbl_Activity_Attendance_Child FOREIGN KEY (fileNumber) REFERENCES tbl_Child (fileNumber),
	Constraint FK_tbl_Activity_Attendance_Status FOREIGN KEY (attendanceStatusID) REFERENCES tbl_Activity_Attendance_Status (activityAttendanceStatusID)
);

insert into tbl_Activity_Attendance
values
(1,'HS1346',1,'2019-09-06'),
(1,'HS1389',1,'2019-09-06'),
(1,'HS1234',3,'2019-09-06');

insert into tbl_Job_Role
values
('Child Care Worker'),
('Director')
('Big Boss Man');


insert into tbl_Facility
values
(1,'Launch Pad','Counceling, Job Placement'),
(2,'Drop In Center','Shower and Food, Street Child Care'),
(3,'Early Intervention','Living facilities, rehab'),
(3,'Shelter Name here','Living facilities, rehab');

INSERT INTO tbl_Gender
VALUES
('Male'),
('Female');

INSERT INTO dbo.tbl_Nationality
VALUES
('South African'),
('Other');

--SHAUN--
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

INSERT INTO tbl_Points
VALUES
('HS1234',1,20,'Attendance'),
('HS1346',1,20,'Attendance'),
('HS1389',1,-20,'Did not Pitch'),
('HS1234',2,10,'Attendance'),
('HS1346',2,10,'Attendance'),
('HS1389',2,10,'Attendance'),
('HS1234',3,-15,'Did not Pitch'),
('HS1346',3,15,'Attendance'),
('HS1389',3,-15,'Did not Pitch');

--ROY--
CREATE TABLE tbl_DailyAttendanceStatus(
	dailyAttendanceStatusID INT IDENTITY(1,1),
	dailyAttendanceType varchar(50),	

	CONSTRAINT PK_tbl_DailyAttendanceStatus PRIMARY KEY(dailyAttendanceStatusID),	
);

INSERT INTO tbl_DailyAttendanceStatus 
VALUES
('Slept in'), 
('Detained'),
('Absconded'),
('Home Visit'),
('Slept in'),
('Absconded Home'),
('Discharged')

SELECT * FROM tbl_DailyAttendanceStatus

CREATE TABLE tbl_Daily_Attendance(
	dailyAttendanceID INT IDENTITY(1,1),
	fileNumber VARCHAR(40),
	dailyAttendanceStatusID INT,
	dailyDate date,
	

	CONSTRAINT PK_tbl_Daily_Attendance PRIMARY KEY(dailyAttendanceID),
	CONSTRAINT fk_tbl_Daily_Attendance_Type FOREIGN KEY(fileNumber) REFERENCES tbl_Child(fileNumber),
	CONSTRAINT fk_tbl_DailyAttendanceStatus FOREIGN KEY(dailyAttendanceStatusID) REFERENCES tbl_DailyAttendanceStatus(dailyAttendanceStatusID),
);

--SIPHO--
create table tbl_Employee_Status
(
	employeeStatusID	int identity(1,1),
	employeeStatusDescription	varchar(20),

	Constraint PK_Employee_Status Primary key (employeeStatusID)
);

CREATE TABLE tbl_Gender(
	genderID INT IDENTITY(1,1),
	genderDescription VARCHAR(10),

	CONSTRAINT pk_tbl_Gender PRIMARY KEY(genderID)
	);

CREATE TABLE tbl_Nationality(
	nationalityID INT IDENTITY(1,1),
	nationalityDesc VARCHAR(20),

	CONSTRAINT pk_tbl_Nationality PRIMARY KEY(nationalityID)
);


create table tbl_Job_Role
(
	jobRoleID int identity(1,1),
	jobRoleDescription varchar(50),

	Constraint PK_tbl_Role Primary key(jobRoleID)
);

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
	contactNumber					VARCHAR(10),
	

	Constraint PK_tbl_Employee Primary key(empID),
	Constraint FK_tbl_Employee_Facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	Constraint FK_tbl_Employee_Address FOREIGN KEY (addressID) REFERENCES tbl_Address(addressID),
	Constraint FK_tbl_Employee_JobRoleID FOREIGN KEY (jobRoleID) REFERENCES tbl_Job_Role(jobRoleID),
	Constraint FK_tbl_Employee_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Employee_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID),
	Constraint FK_tbl_Employee_StatusID FOREIGN KEY (employeeStatusID) REFERENCES tbl_Employee_Status(employeeStatusID)
);

--Naomi--
CREATE TABLE tbl_LegalStatus (

	statusID			INT IDENTITY(1,1),
	statusDescription	VARCHAR(30),

	Constraint PK_tbl_LegalStatus Primary key(statusID), 

);

insert into tbl_LegalStatus
values
('South African Citizen'),
('Immigrant'),
('Foreign'),
('Unknown');

CREATE TABLE tbl_Relationship (

	relationshipID			INT IDENTITY(1,1),
	relationshipDescription	VARCHAR(30),

	Constraint PK_tbl_Relationship Primary key(relationshipID), 
);


insert into tbl_Relationship
values
('Parent'),
('Legal Gaurdian'),
('Sibling');

insert into tbl_Employee_Status
values
('Currently Employed'),
('On Leave'),
('Not longer working');

SELECT * FROM tbl_LegalStatus

CREATE TABLE tbl_StatutoryType (

	statutoryID				INT IDENTITY(1,1),
	statutoryDescription	VARCHAR(30),

	Constraint PK_tbl_StatutoryType Primary key(statutoryID), 
);

insert into tbl_StatutoryType
values
('3 Months'),
('6 Months'),
('1 Year'),
('Pending')

SELECT * FROM tbl_Address

SELECT @@IDENTITY FROM tbl_School

create table tbl_School
(
	schoolID			int identity(1,1),
	schoolName			varchar(40),
	schoolContactNum	varchar(10),

	Constraint PK_tbl_School Primary key(schoolID),
);


INSERT into tbl_School
values
('GIRLS bOY HIGH SCHOOL', '0217624187')
SELECT @@IDENTITY AS SCHOOLID FROM tbl_School

create table tbl_Family_Notes
(
	familyNoteID		int identity(1,1),
	noteDescription		varchar(50),
	noteDate			datetime,

	Constraint PK_tbl_family_Note Primary key(familyNoteID),

);

ALTER TABLE tbl_Child add Constraint FK_tbl_Child_ChildWorker FOREIGN KEY (childCareWorkerID) REFERENCES tbl_Employee(empID)
ALTER TABLE tbl_Child ADD childCareWorkerID INT

ALTER TABLE tbl_Child DROP COLUMN addressID

SELECT * FROM tbl_Child

DROP TABLE tbl_Child
create table tbl_Child
(
	childID INT IDENTITY(1,1),
	fileNumber			varchar(40),
	schoolID			int,
	facilityID			int,
	familyID			int,
	
	childName			varchar(30),
	childSurname		varchar(30),
	dateOfBirth			date,
	genderID			int,
	nationalityID		int,
	legalStatusID		INT,
	statutoryID			INT,
	courtOrderExpirationDate DATE,
	admissionDate		DATE,
	exitDate			DATE,
	socialWorkerID		INT, 
	childCareWorkerID	INT


	CONSTRAINT PK_tbl_Child PRIMARY KEY(childID),
	Constraint FK_tbl_Child_School FOREIGN KEY (schoolID) REFERENCES tbl_School (schoolID),
	Constraint FK_tbl_Child_facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	Constraint FK_tbl_Child_family FOREIGN KEY (familyID) REFERENCES tbl_Family (familyMemberID),
	
	Constraint FK_tbl_Child_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Child_LegalStatus FOREIGN KEY (legalStatusID) REFERENCES tbl_LegalStatus(statusID),
	Constraint FK_tbl_Child_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID),
	Constraint FK_tbl_Child_Statutory FOREIGN KEY (statutoryID) REFERENCES dbo.tbl_StatutoryType(statutoryID),
	Constraint FK_tbl_Child_SocialWorker FOREIGN KEY (socialWorkerID) REFERENCES tbl_Employee(empID),
	Constraint FK_tbl_Child_ChildWorker FOREIGN KEY (childCareWorkerID) REFERENCES tbl_Employee(empID)
);

CREATE TABLE tbl_Statutory(
	statutoryID INT IDENTITY(1,1),
	statutoryIDesc VARCHAR(10),

	CONSTRAINT pk_tbl_Statutory PRIMARY KEY(statutoryID)
);

ALTER TABLE tbl_Family ALTER COLUMN familyNoteID VARCHAR(225);
ALTER TABLE tbl_Family ADD CONSTRAINT FK_tbl_Relationship FOREIGN KEY(relationshipToChild) REFERENCES dbo.tbl_Relationship(relationshipID)

create table tbl_Family
(
	familyMemberID		int identity(1,1),
	addressID			int,
	familyNoteID		VARCHAR(225),
	firstName			varchar(30),
	lastName			varchar(30),
	dateOfBirth			date,
	genderID			int,
	nationalityID		int,
	relationshipToChild	INT,
	
	Constraint PK_tbl_Family Primary key(familyMemberID),
	Constraint FK_tbl_Family_Address FOREIGN KEY (addressID) REFERENCES tbl_Address (addressID),
	Constraint FK_tbl_Family_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Family_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID),
	CONSTRAINT FK_tbl_Relationship FOREIGN KEY(relationshipToChild) REFERENCES dbo.tbl_Relationship(relationshipID)
);





SELECT * FROM dbo.tbl_Job_Role


create table tbl_Activity
(
	activityID					int identity(1,1),
	facilityID					int,
	activityStatusID			INT,
	activityDescription			varchar(30),
	activityDate				date,
	activityTime				time,
	activityPointAllocation		int,

	Constraint PK_tbl_Activity Primary key(activityID),
	Constraint FK_tbl_Activity_facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	CONSTRAINT FK_tbl_Activity_Status FOREIGN KEY(activityStatusID) REFERENCES tbl_Activity_Status(activityStatusID)
);

CREATE TABLE tbl_Activity_Status(

activityStatusID int IDENTITY(1,1),
statusDescription varchar(40),

CONSTRAINT PK_tbl_Activity_Status PRIMARY KEY(activityStatusID)


);

SELECT * FROM dbo.tbl_Employee
create table tbl_Address
(
	addressID 	int identity(1,1),
	province	varchar(20),
	suburb		varchar(20),
	town		varchar(30),
	streetName	varchar(30),
	houseNumber	varchar(10),
	postalcode	INT,

	Constraint PK_tbl_Address Primary key(addressID),
);


create table tbl_Facility
( 
	facilityID			int identity(1,1),
	addressID			int,
	facilityName		varchar(50),
	facilityDescription	varchar(50),

	Constraint PK_tbl_Facility Primary key(facilityID),
	Constraint FK_tbl_Facility_Address FOREIGN KEY (addressID) REFERENCES tbl_Address (addressID)
);

SELECT * FROM tbl_StatutoryType

insert into tbl_Address(province,suburb,town,streetName,houseNumber, postalCode) 
values 
('Western Cape','Southern Suburbs','Cape Town','hopkins road','24', 7708),
('Western Cape','Belhar','Cape Town','Stevens road','56', 1800),
('Eastern Cape','Kenton-on-Sea','Port Elizabeth','Bobern','21', 2300);


insert into tbl_Facility
values
('Launch Pad','Counceling, Job Placement'),
('Drop In Center','Shower and Food, Street Child Care'),
('Early Intervention','Living facilities, rehab'),
('Shelter Name here','Living facilities, rehab');


insert into tbl_Activity
values
(1,1,'Soccer game','2019-09-02','14:30:00',20),
(4,2,'Sex education','2019-09-09','09:45:00',10),
(2,1,'Personal Hygiene Talk','2019-09-02','12:22',5);

INSERT into tbl_Employee 
VALUES 
(1, 4, 2, 'Bonnie', 'White', 'bonniewhite@gmail.com', '1998/03/15', 2, 2, 1, 'white', '0823672239')

UPDATE tbl_Employee SET jobRoleID = 2 WHERE empID = 1
INSERT INTO tbl_Activity_Status
VALUES('Active'),
('Inactive');

SELECT * FROM dbo.tbl_Employee

INSERT INTO tbl_Family
VALUES 
(1, 'Father Unknown', 'Elsie Zuziwe', 'Dyasi', '1965/08/05', 2, 1, 1, '0835531494')

INSERT INTO tbl_Child
VALUES 
('H3223', 3, 4, 2, 'Khaya', 'Dyasi', '1998/11/15', 1, 1, 1, 3, '2020/01/30', '2019/02/28', '2020/02/28', 1, 2)

select activityID, activityDescription, activityDate, activityTime, facilityName, statusDescription, activityPointAllocation from tbl_Activity join tbl_Facility on tbl_Activity.facilityID = tbl_facility.facilityID 
join tbl_Activity_Status on tbl_Activity.activityStatusID = tbl_Activity_Status.activityStatusID;

SELECT childID, CONCAT(childName, ' ', childSurname) AS childFullName FROM tbl_Child

UPDATE tbl_Child SET childSurname = 'Dyasi', childName = 'Buhle' WHERE childID = 2
SELECT * FROM tbl_Child WHERE childID = 2;

SELECT * FROM tbl_Child WHERE childID = 2
SELECT * FROM tbl_Child

SELECT c.fileNumber, s.schoolName, s.schoolContactNum, f.facilityName, fa.familyNotes, fa.firstName, fa.lastName, fa.dateOfBirth, fg.genderDescription, fg.nationalityDesc, r.relationshipDescription,
c.childName, c.childSurname, c.dateOfBirth, cg.genderDescription

SELECT * FROM dbo.tbl_Family
ALTER TABLE tbl_Family ADD contactNumber VARCHAR(10)

select tbl_Child.childName, tbl_Child.childSurname , tbl_Child.fileNumber, tbl_StatutoryType.statutoryDescription, tbl_Relationship.relationshipDescription, tbl_Facility.facilityName, tbl_Child.dateOfBirth, DATEDIFF(YEAR, tbl_Child.dateOfBirth, GETDATE()) AS Age,  tbl_Gender.genderDescription, tbl_School.schoolName, tbl_School.schoolContactNum, tbl_Nationality.nationalityDesc, tbl_LegalStatus.statusDescription, tbl_Family.firstName, tbL_Family.contactNumber, tbl_Address.houseNumber, tbl_Address.streetName, tbl_Address.suburb, tbl_Address.town, tbl_Child.courtOrderExpirationDate, tbl_Child.admissionDate, tbl_Child.exitDate, DATEDIFF(YEAR, tbl_Child.admissionDate, tbl_Child.exitDate) AS YearsInShelter, 
(SELECT tbl_Employee.empFirstName FROM tbl_Employee, tbl_Child WHERE (tbl_Employee.empID = tbl_Child.socialWorkerID)  AND  (tbl_Child.fileNumber = 'H3223')) AS 'socialworker', 
(SELECT tbl_Employee.empFirstName FROM tbl_Employee, tbl_Child WHERE (tbl_Employee.empID = tbl_Child.childCareWorkerID) AND (tbl_Child.fileNumber = 'H3223')) AS 'childcareworker'
FROM tbl_Child, tbl_Gender, tbl_School, tbl_Nationality, tbl_LegalStatus, tbl_Family, tbl_Address , tbl_Facility, tbl_Relationship, tbl_StatutoryType
WHERE(tbl_Child.schoolID = tbl_School.schoolID) AND (tbl_StatutoryType.statutoryID = tbl_Child.statutoryID) AND (tbl_Child.facilityID = tbl_Facility.facilityID) AND (tbl_Relationship.relationshipID = tbl_Family.relationshipToChild) AND (tbl_Child.nationalityID = tbl_Nationality.nationalityID) AND(tbl_Child.genderID = tbl_Gender.genderID) AND(tbl_Child.legalStatusID = tbl_LegalStatus.statusID) AND(tbl_Child.familyID = tbl_Family.familyMemberID) AND(dbo.tbl_Family.addressID = tbl_Address.addressID) AND tbl_Child.fileNumber = 'H3223'

 SELECT tbl_Employee.empFirstName FROM tbl_Employee, tbl_Child 
 WHERE (tbl_Employee.empID = tbl_Child.socialWorkerID) AND (tbl_Child.fileNumber = 'H3223')

 SELECT DATEDIFF(YEAR, tbl_Child.admissionDate, tbl_Child.exitDate) AS difference FROM tbl_Child WHERE fileNumber = 'H3223'

SELECT * FROM tbl_Child c, tbl_Gender g, tbl_School s, tbl_Facility fc, tbl_Family f, tbl_Employee e, tbl_Address a, dbo.tbl_LegalStatus l, tbl_StatutoryType st
WHERE (c.genderID = g.genderID) AND (c.schoolID = s.schoolID) AND (c.facilityID = fc.facilityID) AND (c.familyID = f.familyMemberID)
AND (c.legalStatusID = l.statusID) AND (c.statutoryID = st.statutoryID) AND (c.socialWorkerID = e.empID) AND (c.childCareWorkerID = e.empID) AND (c.childID = 2)

SELECT * FROM tbl_Employee;
SELECT * FROM tbl_Gender;


CREATE TABLE tbl_Daily_Attendance
(
	dailyAttendanceID INT IDENTITY(1,1),
	fileNumber varchar(40),
	dailyAttendanceStatusID INT,
	dailyDate date,
	
	CONSTRAINT PK_tbl_Daily_Attendance PRIMARY KEY(dailyAttendanceID),
	CONSTRAINT fk_tbl_Daily_Attendance_Type FOREIGN KEY(fileNumber) REFERENCES tbl_Child(fileNumber),
	CONSTRAINT fk_tbl_DailyAttendanceStatus FOREIGN KEY(dailyAttendanceStatusID) REFERENCES tbl_DailyAttendanceStatus(dailyAttendanceStatusID),
);


UPDATE tbl_Child SET facilityID = 1 WHERE childID = 4;

update tbl_Child set fileNumber = 'H3223', facilityID = 2, familyID = 1, childName = 'khaya', childSurname = 'bolt', dateOfbirth = '1998/11/16', legalStatusID = 1,
                                       statutoryID = 3, courtOrderExpirationDate = '2020/01/30', admissionDate = '2019/02/28',
                                        socialWorkerID = 1, childCareWorkerID = 2 where childID = 4;
            
update tbl_Child set fileNumber = 'H3223', facilityID = 2, familyID = 1, childName = 'Khaya', childSurname = 'Khaya', dateOfbirth = '1998/11/16', legalStatusID = 1, statutoryID = 3, courtOrderExpirationDate = '2020/01/30', admissionDate = '2019/02/28', exitDate = '2020/02/28', socialWorkerID = 1, childCareWorker = 2 where childID = 4
update tbl_Child set fileNumber = 'H3223', facilityID = 2, familyID = 1, childName = 'Khaya', childSurname = 'Khaya', dateOfbirth = '1998/11/16', legalStatusID = 1, statutoryID = 3, courtOrderExpirationDate = '2020/01/30', admissionDate = '2019/02/28', exitDate = '2020/02/28', socialWorkerID = 1, childCareWorkerID = 2 where childID = 4

SELECT * FROM tbl_Child WHERE fileNumber = 'H3223'

select tbl_Child.childID, tbl_Child.childName, tbl_Child.childSurname , tbl_Child.socialWorkerID, tbl_Family.familyNoteID, tbl_Child.childCareWorkerID, tbl_Child.fileNumber, tbl_Child.statutoryID, tbl_Family.relationshipToChild, tbl_Child.facilityID, tbl_Child.dateOfBirth,  tbl_Child.genderID, tbl_Child.schoolID, tbl_School.schoolName, tbl_School.schoolContactNum, tbl_Child.nationalityID, tbl_Child.legalStatusID, tbl_Child.familyID, tbl_Family.firstName, tbl_Family.lastName, tbL_Family.contactNumber, tbl_Family.addressID, tbl_Address.houseNumber, tbl_Address.streetName, tbl_Address.suburb, tbl_Address.town, tbl_Address.province, tbl_Address.postalCode, tbl_Child.courtOrderExpirationDate, tbl_Child.admissionDate, tbl_Child.exitDate, tbl_Family.genderID AS familyGender,  DATEDIFF(YEAR, tbl_Child.admissionDate, tbl_Child.exitDate) AS YearsInShelter
FROM tbl_Child, tbl_Gender, tbl_School, tbl_Nationality, tbl_LegalStatus, tbl_Family, tbl_Address , tbl_Facility, tbl_Relationship, tbl_StatutoryType, tbl_Employee
WHERE(tbl_Child.schoolID = tbl_School.schoolID) AND (tbl_Child.socialWorkerID = tbl_Employee.empID) AND (tbl_StatutoryType.statutoryID = tbl_Child.statutoryID) AND (tbl_Child.facilityID = tbl_Facility.facilityID) AND (tbl_Relationship.relationshipID = tbl_Family.relationshipToChild) AND (tbl_Child.nationalityID = tbl_Nationality.nationalityID) AND(tbl_Child.genderID = tbl_Gender.genderID) AND(tbl_Child.legalStatusID = tbl_LegalStatus.statusID) AND(tbl_Child.familyID = tbl_Family.familyMemberID) AND(tbl_Family.addressID = tbl_Address.addressID) AND tbl_Child.fileNumber = 'H3223'

SELECT * FROM tbl_Daily_Attendance

select c.childName,c.childSurname,c.fileNumber,d.dailyAttendanceType, CONCAT(DATENAME(WEEKDAY,DAY(e.dailyDate)) + ' ' + DATENAME(DAY,e.dailyDate) + ' ' +  DATENAME(MONTH, e.dailyDate)+ ' '  ,  YEAR(e.dailyDate)) as datetime  from tbl_child c, tbl_DailyAttendanceStatus d, tbl_Daily_Attendance e where(c.fileNumber = e.fileNumber)and(d.dailyAttendanceStatusID = e.dailyAttendanceStatusID)

SELECT c.childName,c.childSurname,c.fileNumber,d.dailyAttendanceType, DATE_FORMAT(e.dailyDate, "%M %d %Y")  from tbl_child c, tbl_DailyAttendanceStatus d, tbl_Daily_Attendance e where(c.fileNumber = e.fileNumber)and(d.dailyAttendanceStatusID = e.dailyAttendanceStatusID)



SP_RENAME 'tbl_Activity_Attendance.activityDate', 'attendanceDate', 'COLUMN'


--The one thing that is anoying to me is that the address was removed form the child table which is fine but where are we going to find the address or location of a child if the facility doesnt have an address?

--Be careful if you want to rename a column it could break things if you have tables linked to the table you are editing.
sp_rename 'tbl_Family.familyNoteID', familyNote

--think of this as a secondary pk for child. allows me to query the table from the unique index
CREATE UNIQUE INDEX pk2_Child ON tbl_Child (fileNumber);

alter table tbh_Child drop index pk2_Child;
Alter table tbl_Points drop Constraint FK_tbl_Points_Child
Alter table tbl_Points add Constraint FK_tbl_Points_Child foreign key(fileNumber) references tbl_Child(fileNumber)

ALTER TABLE tbl_Family ADD contactNumber VARCHAR(10)

--Create tables
CREATE table tbl_Activity_Attendance_Status
(
	activityAttendanceStatusID	int identity(1,1),
	activityAttendanceStatusType	varchar(30),

	Constraint PK_Activity_Attendance_Status Primary key(activityAttendanceStatusID),

);

create table tbl_Employee_Status
(
	employeeStatusID	int identity(1,1),
	employeeStatusDescription	varchar(20),

	Constraint PK_Employee_Status Primary key (employeeStatusID)
);

CREATE TABLE tbl_Gender
(
	genderID INT IDENTITY(1,1),
	genderDescription VARCHAR(10),

	CONSTRAINT pk_tbl_Gender PRIMARY KEY(genderID)
);

CREATE TABLE tbl_Nationality
(
	nationalityID INT IDENTITY(1,1),
	nationalityDesc VARCHAR(20),

	CONSTRAINT pk_tbl_Nationality PRIMARY KEY(nationalityID)
);

create table tbl_Job_Role
(
	jobRoleID int identity(1,1),
	jobRoleDescription varchar(50),

	Constraint PK_tbl_Role Primary key(jobRoleID)
);

CREATE TABLE tbl_LegalStatus 
(

	statusID			INT IDENTITY(1,1),
	statusDescription	VARCHAR(30),

	Constraint PK_tbl_LegalStatus Primary key(statusID), 
);

CREATE TABLE tbl_Relationship (

	relationshipID			INT IDENTITY(1,1),
	relationshipDescription	VARCHAR(30),

	Constraint PK_tbl_Relationship Primary key(relationshipID), 
);


CREATE TABLE tbl_StatutoryType (

	statutoryID				INT IDENTITY(1,1),
	statutoryDescription	VARCHAR(30),

	Constraint PK_tbl_StatutoryType Primary key(statutoryID), 
);


create table tbl_School
(
	schoolID			int identity(1,1),
	schoolName			varchar(40),
	schoolContactNum	varchar(10),

	Constraint PK_tbl_School Primary key(schoolID),
);

CREATE TABLE tbl_Activity_Status(

activityStatusID int IDENTITY(1,1),
statusDescription varchar(40),

CONSTRAINT PK_tbl_Activity_Status PRIMARY KEY(activityStatusID)

);

create table tbl_Facility
( 
	facilityID			int identity(1,1),
	addressID			int,
	facilityName		varchar(50),
	facilityDescription	varchar(50),

	Constraint PK_tbl_Facility Primary key(facilityID),
	
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

CREATE TABLE tbl_DailyAttendanceStatus
(
	dailyAttendanceStatusID INT IDENTITY(1,1),
	dailyAttendanceType varchar(50),	

	CONSTRAINT PK_tbl_DailyAttendanceStatus PRIMARY KEY(dailyAttendanceStatusID),	
);


create table tbl_Activity
(
	activityID					int identity(1,1),
	facilityID					int,
	activityStatusID			INT,
	activityDescription			varchar(30),
	activityDate				date,
	activityTime				time,
	activityPointAllocation		int,

	Constraint PK_tbl_Activity Primary key(activityID),
	Constraint FK_tbl_Activity_facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	CONSTRAINT FK_tbl_Activity_Status FOREIGN KEY(activityStatusID) REFERENCES tbl_Activity_Status(activityStatusID)
);

create table tbl_Family
(
	familyMemberID		int identity(1,1),
	addressID			int,
	familyNote			VARCHAR(225),
	firstName			varchar(30),
	lastName			varchar(30),
	dateOfBirth			date,
	genderID			int,
	nationalityID		int,
	relationshipToChild	INT,
	
	Constraint PK_tbl_Family Primary key(familyMemberID),
	Constraint FK_tbl_Family_Address FOREIGN KEY (addressID) REFERENCES tbl_Address (addressID),
	Constraint FK_tbl_Family_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Family_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID),
	CONSTRAINT FK_tbl_Relationship FOREIGN KEY(relationshipToChild) REFERENCES dbo.tbl_Relationship(relationshipID)
);

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
	contactNumber					VARCHAR(10),
	

	Constraint PK_tbl_Employee Primary key(empID),
	Constraint FK_tbl_Employee_Facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	Constraint FK_tbl_Employee_Address FOREIGN KEY (addressID) REFERENCES tbl_Address(addressID),
	Constraint FK_tbl_Employee_JobRoleID FOREIGN KEY (jobRoleID) REFERENCES tbl_Job_Role(jobRoleID),
	Constraint FK_tbl_Employee_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Employee_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID),
	Constraint FK_tbl_Employee_StatusID FOREIGN KEY (employeeStatusID) REFERENCES tbl_Employee_Status(employeeStatusID)
);


create table tbl_Child
(
	childID				INT IDENTITY(1,1),
	fileNumber			varchar(40),
	schoolID			int,
	facilityID			int,
	familyID			int,
	childName			varchar(30),
	childSurname		varchar(30),
	dateOfBirth			date,
	genderID			int,
	nationalityID		int,
	legalStatusID		INT,
	statutoryID			INT,
	courtOrderExpirationDate DATE,
	admissionDate		DATE,
	exitDate			DATE,
	socialWorkerID		INT, 
	childCareWorkerID	INT,


	CONSTRAINT PK_tbl_Child PRIMARY KEY(childID),
	Constraint FK_tbl_Child_School FOREIGN KEY (schoolID) REFERENCES tbl_School (schoolID),
	Constraint FK_tbl_Child_facility FOREIGN KEY (facilityID) REFERENCES tbl_Facility (facilityID),
	Constraint FK_tbl_Child_family FOREIGN KEY (familyID) REFERENCES tbl_Family (familyMemberID),
	
	Constraint FK_tbl_Child_GenderID FOREIGN KEY (genderID) REFERENCES tbl_Gender(genderID),
	Constraint FK_tbl_Child_LegalStatus FOREIGN KEY (legalStatusID) REFERENCES tbl_LegalStatus(statusID),
	Constraint FK_tbl_Child_NationalityID FOREIGN KEY (nationalityID) REFERENCES tbl_Nationality(nationalityID),
	Constraint FK_tbl_Child_Statutory FOREIGN KEY (statutoryID) REFERENCES dbo.tbl_StatutoryType(statutoryID),
	Constraint FK_tbl_Child_SocialWorker FOREIGN KEY (socialWorkerID) REFERENCES tbl_Employee(empID),
	Constraint FK_tbl_Child_ChildWorker FOREIGN KEY (childCareWorkerID) REFERENCES tbl_Employee(empID)
);


CREATE TABLE tbl_Daily_Attendance
(
	dailyAttendanceID INT IDENTITY(1,1),
	fileNumber varchar(40),
	dailyAttendanceStatusID INT,
	dailyDate date,
	
	CONSTRAINT PK_tbl_Daily_Attendance PRIMARY KEY(dailyAttendanceID),
	CONSTRAINT fk_tbl_Daily_Attendance_Type FOREIGN KEY(fileNumber) REFERENCES tbl_Child(fileNumber),
	CONSTRAINT fk_tbl_DailyAttendanceStatus FOREIGN KEY(dailyAttendanceStatusID) REFERENCES tbl_DailyAttendanceStatus(dailyAttendanceStatusID),
);

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

create table tbl_Activity_Attendance
(
	activityAttendanceID	int identity(1,1),
	activityID				int,
	fileNumber				varchar(40),
	attendanceStatusID		int,
	activityDate			DATE,

	Constraint PK_tbl_Activity_Attendance Primary key(activityAttendanceID),
	Constraint FK_tbl_Activity_Attendance_Child FOREIGN KEY (fileNumber) REFERENCES tbl_Child (fileNumber),
	Constraint FK_tbl_Activity_Attendance_Status FOREIGN KEY (attendanceStatusID) REFERENCES tbl_Activity_Attendance_Status (activityAttendanceStatusID)
);


--Inserts
insert into tbl_Activity_Attendance_Status
values
('Present'),
('Excused'),
('Did not Attend');

insert into tbl_Job_Role
values
('Facility Manager'),
('Social Worker'),
('Big Boss Man'),
('Child Care Worker'),
('Director');

INSERT INTO dbo.tbl_Nationality
VALUES
('South African'),
('Other');

insert into tbl_StatutoryType
values
('3 Months'),
('6 Months'),
('1 Year'),
('Pending')

insert into tbl_Relationship
values
('Parent'),
('Legal Gaurdian'),
('Sibling');

insert into tbl_Employee_Status
values
('Currently Employed'),
('On Leave'),
('Not longer working');

insert into tbl_LegalStatus
values
('South African Citizen'),
('Immigrant'),
('Foreign'),
('Unknown');

INSERT INTO tbl_DailyAttendanceStatus 
VALUES
('Slept in'), 
('Detained'),
('Absconded'),
('Home Visit'),
('Slept in'),
('Absconded Home'),
('Discharged')

INSERT INTO tbl_Gender
VALUES
('Male'),
('Female');

INSERT INTO tbl_Address 
VALUES 
('Western Cape', 'Distric Six', 'Cape Town', 'Kale Street', '253', 7708),
('Western Cape', 'Kenilworth', 'Cape Town', 'Stamford Road', '14', 7708)
insert into tbl_Facility
values
(1,'Launch Pad','Counceling, Job Placement'),
(2,'Drop In Center','Shower and Food, Street Child Care'),
(1,'Early Intervention','Living facilities, rehab'),
(2,'Shelter Name here','Living facilities, rehab');

INSERT INTO tbl_Activity_Status
VALUES('Active'),
('Inactive');

INSERT INTO tbl_Family
VALUES 
(1, 'Father Unknown', 'Elsie Zuziwe', 'Dyasi', '1965/08/05', 2, 1, 1, '0835531494')

INSERT INTO tbl_School 
VALUES 
('Wynberg High School', '0217624187'),
('Wynberg Boys High School', '0835531494')




INSERT into tbl_Employee 
VALUES 
(1, 1, 1, 'Bonnie', 'White', 'bonniewhite@gmail.com', '1998/03/15', 2, 2, 1, 'white', '0823672239'),
(1, 1, 2, 'Sipho', 'White', 'sipho@gmail.com', '1998/03/15', 2, 2, 1, '124', '0823672239'),
(1, 1, 2, 'Jesus', 'White', 'jesus@gmail.com', '1998/03/15', 2, 2, 1, '369', '0823672239'),
(1, 1, 4, 'Sarah', 'White', 'sarah@gmail.com', '1998/03/15', 2, 2, 1, '124', '0823672239'),
(1, 1, 4, 'Kyle', 'White', 'kyle@gmail.com', '1998/03/15', 2, 2, 1, '124', '0823672239')


insert into tbl_Child
values
('HS1234',1,1,1,'Ben','Low','1990-12-12',2,1,1,1,'2020-02-24','2018-06-06','2019-06-06',1,2),
('HS1346',1,1,1,'Shoot','Me Now','1990-12-12',2,1,1,2,'2020-02-24','2018-08-17','2019-06-06',1,2),
('HS1389',1,2,1,'Steve','lolz','1992-06-24',2,1,1,3,'2020-02-24','2018-06-06','2019-06-06',1,2);

insert into tbl_Activity_Attendance
values
(1,'HS1346',1,'2019-09-06'),
(1,'HS1389',1,'2019-09-06'),
(1,'HS1234',3,'2019-09-06');

insert into tbl_Activity
values
(1,1,'Soccer game','2019-09-02','14:30:00',20),
(4,2,'Sex education','2019-09-09','09:45:00',10),
(2,1,'Personal Hygiene Talk','2019-09-02','12:22',5);

INSERT INTO tbl_Points
VALUES
('HS1234',2,20,'Attendance'),
('HS1346',2,20,'Attendance'),
('HS1389',2,-20,'Did not Pitch'),
('HS1234',3,10,'Attendance'),
('HS1346',3,10,'Attendance'),
('HS1389',3,10,'Attendance'),
('HS1234',1,-15,'Did not Pitch'),
('HS1346',1,15,'Attendance'),
('HS1389',1,-15,'Did not Pitch');

SELECT * FROM tbl_Job_Role

SELECT COUNT(*) FROM tbl_Child 
WHERE (MONTH(courtOrderExpirationDate) = 10) AND facilityID = 2

SELECT COUNT(*) FROM  tbl_Daily_Attendance, tbl_Child
WHERE (MONTH(dailyDate) = 10) AND ( dailyAttendanceStatusID = 1) AND (tbl_Child.fileNumber = tbl_Daily_Attendance.fileNumber) AND (tbl_Child.facilityID = 1)



