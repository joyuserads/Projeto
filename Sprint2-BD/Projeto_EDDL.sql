-- Criação do banco de dados
CREATE DATABASE GestaoEquipamentos;
GO

USE GestaoEquipamentos;
GO

-- Tabela de Tipos de Usuário
CREATE TABLE TipoUsuario (
    IdTipoUsuario INT PRIMARY KEY IDENTITY(1,1),
    NomeTipo NVARCHAR(50) NOT NULL UNIQUE
);

-- Tabela de Usuários
CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    SenhaHash NVARCHAR(255) NOT NULL,
    IdTipoUsuario INT NOT NULL,
    CONSTRAINT FK_Usuario_TipoUsuario FOREIGN KEY (IdTipoUsuario)
        REFERENCES TipoUsuario(IdTipoUsuario)
);

-- Tabela de Equipamentos
CREATE TABLE Equipamento (
    IdEquipamento INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255),
    NumeroPatrimonio NVARCHAR(50) UNIQUE
);

-- Tabela de Salas
CREATE TABLE Sala (
    IdSala INT PRIMARY KEY IDENTITY(1,1),
    NomeSala NVARCHAR(100) NOT NULL,
    Localizacao NVARCHAR(255) NOT NULL
);

-- Tabela associativa SalaEquipamento
CREATE TABLE SalaEquipamento (
    IdSalaEquipamento INT PRIMARY KEY IDENTITY(1,1),
    IdSala INT NOT NULL,
    IdEquipamento INT NOT NULL,
    DataAlocacao DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_SalaEquipamento_Sala FOREIGN KEY (IdSala) REFERENCES Sala(IdSala),
    CONSTRAINT FK_SalaEquipamento_Equipamento FOREIGN KEY (IdEquipamento) REFERENCES Equipamento(IdEquipamento),
    CONSTRAINT UQ_Sala_Equipamento UNIQUE (IdSala, IdEquipamento)
);

-- Índices
CREATE INDEX IDX_Usuario_Email ON Usuario(Email);
CREATE INDEX IDX_Sala_Localizacao ON Sala(Localizacao);
CREATE INDEX IDX_Equipamento_NumeroPatrimonio ON Equipamento(NumeroPatrimonio);