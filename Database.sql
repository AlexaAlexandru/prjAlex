CREATE TABLE Service
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
Name VARCHAR(100),
FullDescription VARCHAR(500)
)

CREATE TABLE NutritionServices
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
Description VARCHAR(500),
ServiceId INT REFERENCES Service(Id)
)

CREATE TABLE Dietitian
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Email VARCHAR(30),
Phone VARCHAR(15),
Presentation VARCHAR(200)
)

CREATE TABLE ServiceDietitian
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
ServiceId INT REFERENCES Service(Id),
DietitianId INT REFERENCES Dietitian(Id),
Price MONEY,
)

CREATE TABLE Team
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
Specialization VARCHAR(50),
ShortDescription VARCHAR(150)
)

CREATE TABLE DietitianTeam
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
DietitianId INT REFERENCES Dietitian(Id),
TeamId INT REFERENCES Team(Id)
)

CREATE TABLE UserProfile
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Birthday DATE,
Sex BIT,
Height FLOAT,
Weight FLOAT,
Phone VARCHAR(15),
Email VARCHAR(30),
)

CREATE TABLE ShoppingBasket
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
UserProfileId INT REFERENCES UserProfile(Id),
ServiceDietitian INT REFERENCES ServiceDietitian(Id),
TypeOfAppointment BIT,
)

CREATE TABLE Appointment
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
Date SMALLDATETIME,
Reason VARCHAR(100),
ShoppingBasketId INT REFERENCES ShoppingBasket(Id)
)

CREATE TABLE DietitianAppointment
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
DietitianId INT REFERENCES Dietitian(Id),
AppointmentId INT REFERENCES Appointment(Id)
)

CREATE TABLE UserAppointment
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
UserProfileId INT REFERENCES UserProfile(Id),
AppointmentId INT REFERENCES Appointment(Id)
)

CREATE TABLE About
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
MottoDescription VARCHAR(500),
ReasonChoosing VARCHAR(500),
)

CREATE TABLE Testimonials
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Review VARCHAR(500),
DietitianId INT REFERENCES Dietitian(Id)
)

CREATE TABLE Contact
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
Phone VARCHAR(15),
Email VARCHAR(30),
Address VARCHAR(50)
)

CREATE TABLE GetInTouch
(
Id INT IDENTITY(1, 1) PRIMARY KEY,
FirstName VARCHAR(50),
LastName VARCHAR(50),
Email VARCHAR(30),
Message VARCHAR(500)
)
