create table AcademicYear
(
	ID int primary key identity(1,1),
	AcademicYearName nvarchar(50)
)

create table Student
(
	Stu_ID int primary key identity(1,1),
	NationalId nvarchar(14),
    FristName nvarchar(50),
    LastName nvarchar(50),
    ThirdName nvarchar(50),
    FouthName nvarchar(50),
    Password nvarchar(50),
    Address nvarchar(200),
    Phone nvarchar(11),
    Gender nvarchar(50),
    AcademicYear_ID int
)

create table Instractor
(
    ID int primary key identity(1,1),
    NationalId nvarchar(14),
    FristName nvarchar(50),
    LastName nvarchar(50),
    ThirdName nvarchar(50),
    FouthName nvarchar(50),
    Password nvarchar(50),
    Address nvarchar(200),
    Phone nvarchar(11),
    Gender nvarchar(50)
)

create table Admin
(
    ID int primary key identity(1,1),
    NationalId nvarchar(14),
    FristName nvarchar(50),
    LastName nvarchar(50),
    ThirdName nvarchar(50),
    FouthName nvarchar(50),
    Password nvarchar(50),  
)

create table Room
(
    ID int primary key identity(1,1),
    Name nvarchar(50),
    Address nvarchar(30),
    Long decimal,
    Lat decimal
)

create table Subject
(
    ID int primary key identity(1,1),
    Name varchar(200)
)

create table Lecture
(
    ID int primary key identity(1,1),
    Name nvarchar(50),
    Description nvarchar(50),
    RoomID int,
    SubjectID int,
    InstractorID int
)

create table Department
(
ID int primary key identity(1,1),
Name varchar(50)
)

create table Instractor_Subject
(
    SubjectCode int,
    InstractorCode int
)


create table Attendance
(
    StudentCode int,
    LectureCode int,
    isAttendance nvarchar(15)
)

create table Quiz_Marks
(
    StudentCode int,
    Attendance nvarchar(50),
    Markes nvarchar(10)
)

alter table Student add foreign key (AcademicYear_ID) references AcademicYear (ID)

alter table Lecture add foreign key (RoomID) references Room (ID)

alter table Lecture add foreign key (SubjectID) references Subject (ID)

alter table Lecture add foreign key (InstractorID) references Instractor (ID)

alter table Instractor_Subject add foreign key (SubjectID) references Subject (ID)

alter table Instractor_Subject add foreign key (InstractorID) references Inctractor (ID)

alter table Attendance add foreign key (StudentCode) references Student (ID)

alter table Attendance add foreign key (LectureCode) references Lecture (ID)

alter table Quiz_Marks add foreign key (StudentCode) references Student (Stu_ID)


