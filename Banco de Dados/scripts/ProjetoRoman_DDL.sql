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
	IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipoUsuario),
	Email VARCHAR (200) NOT NULL UNIQUE,
	Senha VARCHAR (200) NOT NULL	
);
GO

CREATE TABLE Professores(
	IdProfessor     INT PRIMARY KEY IDENTITY,
	IdUsuario		INT FOREIGN KEY REFERENCES Usuarios(IdUsuario),
	NomeProfessor   VARCHAR (200) NOT NULL

);
GO

CREATE TABLE Temas(
	IdTema         INT PRIMARY KEY IDENTITY,
	NomeTema   VARCHAR (200) NOT NULL,

);
GO

CREATE TABLE Projetos(
	IdProjeto     INT PRIMARY KEY IDENTITY,
	IdTema        INT FOREIGN KEY  REFERENCES Temas(IdTema),
	NomeProjeto   VARCHAR (200) NOT NULL,
	Descricao     TEXT 
)
GO


