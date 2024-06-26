﻿CREATE DATABASE CONSULTORIODB
GO
USE CONSULTORIODB

CREATE TABLE ROLES (
	id INT IDENTITY PRIMARY KEY,
	rol_name VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE USUARIOS (
	id INT IDENTITY PRIMARY KEY,
	email VARCHAR(70) NOT NULL UNIQUE,
	password_hash VARCHAR(200) NOT NULL,
	id_rol INT FOREIGN KEY REFERENCES ROLES(id),
	img_url VARCHAR(200) NULL,
	fecha_creacion DATETIME NULL,
	activo BIT NOT NULL
)

CREATE TABLE RECEPCIONISTAS (
	id INT IDENTITY PRIMARY KEY,
	usuario_id INT NULL UNIQUE,
	nombre VARCHAR(50) NULL,
	apellido VARCHAR(50) NULL,
	nacimiento DATE NULL
	FOREIGN KEY (usuario_id) REFERENCES USUARIOS(id)
)

CREATE TABLE DOCTORES (
	id INT IDENTITY PRIMARY KEY,
	usuario_id INT NULL UNIQUE,
	nombre VARCHAR(50) NULL,
	apellido VARCHAR(50) NULL,
	nacimiento DATE NULL,
	FOREIGN KEY (usuario_id) REFERENCES USUARIOS(id)
)

CREATE TABLE ESPECIALIDADES (
	id INT IDENTITY PRIMARY KEY,
	especialidad_name VARCHAR(50) NOT NULL UNIQUE,
)

CREATE TABLE ESPECIALIDADES_X_DOCTORES (
	id INT IDENTITY,
	doctor_id INT NOT NULL,
	especialidad_id INT NOT NULL,
	FOREIGN KEY (doctor_id) REFERENCES DOCTORES(id),
	FOREIGN KEY (especialidad_id) REFERENCES ESPECIALIDADES(id),
	PRIMARY KEY (id, doctor_id, especialidad_id)
)

CREATE TABLE TURNOS_DE_TRABAJO (
	doctor_id INT NOT NULL,
	dia varchar(50) NOT NULL ,
	hora_inicio TIME NOT NULL,
	hora_final TIME NOT NULL,
	FOREIGN KEY (doctor_id) REFERENCES DOCTORES (id),
	PRIMARY KEY (doctor_id, fecha, hora_inicio, hora_final)
)

CREATE TABLE PACIENTES (
	id INT IDENTITY PRIMARY KEY,
	nombre VARCHAR(50) NULL,
	apellido VARCHAR(50) NULL,
	email VARCHAR(70) NULL UNIQUE,
	telefono VARCHAR(20) NULL UNIQUE,
	nacimiento DATE NULL,
	dni VARCHAR(15) NULL UNIQUE,
	activo BIT NOT NULL
)

CREATE TABLE ESTADOS (
	id INT IDENTITY PRIMARY KEY,
	tipo VARCHAR(50) UNIQUE
)
CREATE TABLE TURNOS (
	id INT IDENTITY PRIMARY KEY,
	paciente_id INT NOT NULL,
	doctor_id INT NOT NULL,
	fecha DATE NOT NULL,
	hora TIME NOT NULL,
	estado_id INT NOT NULL,
	observacion TEXT,
	FOREIGN KEY (paciente_id) REFERENCES PACIENTES(id),
	FOREIGN KEY (doctor_id) REFERENCES DOCTORES(id),
	FOREIGN KEY (estado_id) REFERENCES ESTADOS(id),
	UNIQUE (paciente_id, fecha, hora),
	UNIQUE (doctor_id, fecha, hora)
)
