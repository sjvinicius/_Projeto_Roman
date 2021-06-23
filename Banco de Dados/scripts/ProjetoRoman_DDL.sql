CREATE DATABASE ProjetoRoman;
GO

USE ProjetoRoman;
GO

CREATE TABLE TiposUsuarios(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	NomeTipoUsuario VARCHAR (200) NOT NULL
);
GO

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipoUsuario)
);
GO

CREATE TABLE Professores(
	IdProfessor     INT PRIMARY KEY IDENTITY,
	NomeProfessor   VARCHAR (200) NOT NULL

);
GO

CREATE TABLE Temas(
	IdTema         INT PRIMARY KEY IDENTITY,
	NomeProjeto    VARCHAR (200) NOT NULL,
	Descrição      VARCHAR (200)
);
GO



