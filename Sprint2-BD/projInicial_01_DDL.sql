CREATE DATABASE projetoInicial3T
GO

--DDL

--  Nome que o projeto deverá ter : senai_projInicial3T_01_DDL.sql

USE projetoInicial3T
GO

CREATE TABLE tiposUsuario(
	idTiposUsuario		INT PRIMARY KEY IDENTITY,
	nome				VARCHAR(200) NOT NULL UNIQUE
)
GO

CREATE TABLE usuario(
	idUsuario			INT PRIMARY KEY IDENTITY,
	nome				VARCHAR(200) NOT NULL,
	email				VARCHAR(200) NOT NULL UNIQUE,
	senha				VARCHAR(200) NOT NULL,
	idTiposUsuario		INT FOREIGN KEY REFERENCES tiposUsuario(idTiposUsuario)
)
GO

CREATE TABLE equipamentos(
	idEquipamento		INT PRIMARY KEY IDENTITY,
	marca				VARCHAR(100) NOT NULL,
	tipo				VARCHAR(200) NOT NULL,
	numeroSerie			VARCHAR(12) NOT NULL UNIQUE,
	descricao			VARCHAR(500) NOT NULL,
	numeroPatrimonio	VARCHAR(6) NOT NULL UNIQUE,
	disponivel			BIT NOT NULL
)
GO

CREATE TABLE salas(
	idSala				INT PRIMARY KEY IDENTITY,
	andar				INT NOT NULL UNIQUE,
	nome				VARCHAR(100) NOT NULL,
	metragem			INT NOT NULL,
	idUsuario			INT FOREIGN KEY REFERENCES usuario(idUsuario)
)
GO

CREATE TABLE salasEquipamentos(
	idSalasEquipamento	INT PRIMARY KEY IDENTITY NOT NULL,
	idSala				INT FOREIGN KEY REFERENCES salas(idSala),
	idEquipamento		INT FOREIGN KEY REFERENCES equipamentos(idEquipamento)
)
GO