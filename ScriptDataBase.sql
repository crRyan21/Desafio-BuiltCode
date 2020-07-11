

CREATE DATABASE Hospital

USE Hospital

CREATE TABLE Pacientes(
	IdPaciente INT PRIMARY KEY IDENTITY NOT NULL
	,Nome VARCHAR(120) NOT NULL
	,BirdDate DATE NOT NULL
	,CPF VARCHAR(30) NOT NULL UNIQUE
);

CREATE TABLE Doutores(
	IdDoutor INT PRIMARY KEY IDENTITY NOT NULL
	,Nome VARCHAR(255) not null
	,Crm Varchar(30) not null unique
	,CrmUF Varchar(30) not null 
	,IdPaciente INT FOREIGN KEY REFERENCES Pacientes(IdPaciente)
);




