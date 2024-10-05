create database HospMgmt

create table patient (patientid int primary key identity(1,1),
firstname varchar(50) not null,
lastname varchar(50) not null,
dateofbirth date not null,
gender varchar(10) not null,
contactnumber varchar(15) not null,
address varchar(255) not null)

create table doctor (doctorid int primary key identity(1,1),
firstname varchar(50) not null,
lastname varchar(50) not null,
specialization varchar(100) not null,
contactnumber varchar(15) not null
)

create table appointment (appointmentid int primary key identity(1,1),
patientid int not null,
doctorid int not null,
appointmentdate datetime not null,
description varchar(255),
foreign key (patientid) references patient(patientid),
foreign key (doctorid) references doctor(doctorid)
)

insert into patient values
('Varun','G','2003-05-03','Male','9191919191','Church Street, Bangalore, India.'),
('John','Meyer','1990-05-15','Male','14898238911','Los Angeles, California, USA.'),
('Robert', 'Pattinson', '1978-03-10', 'Male', '7328469234', '789 Pine Rd, Village')

insert into doctor values 
('dr. Ram', 'Raj', 'cardiology', '9999999999'),
('dr. Krish', 'Naik', 'Radiology', '888888888'),
('dr. Rama', 'Devi', 'orthopedics', '7777777777');

insert into appointment values 
(1, 1, '2024-10-10', 'regular checkup'),
(2, 2, '2024-10-11', 'follow-up check up'),
(3, 3, '2024-10-12', 'consultation');


select * from appointment where appointmentid=1
