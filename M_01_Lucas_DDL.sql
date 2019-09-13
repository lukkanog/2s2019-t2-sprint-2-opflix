CREATE DATABASE M_Opflix
GO

USE M_Opflix;
GO

CREATE TABLE Categorias(
	IdCategoria INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(255) NOT NULL UNIQUE
);
GO

CREATE TABLE TiposLancamentos(
	IdTipoLancamento INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(255) NOT NULL UNIQUE
);
GO

CREATE TABLE TiposUsuarios(
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(255) NOT NULL UNIQUE
);
GO

CREATE TABLE Plataformas(
	IdPlataforma INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(255) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuarios(
	IdUsuario INT PRIMARY KEY IDENTITY
	,IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipoUsuario) NOT NULL
	,Nome VARCHAR(255) NOT NULL
	,Email VARCHAR(255) UNIQUE NOT NULL 
	,Senha VARCHAR(50) NOT NULL
	,DataCadastro DATETIME
);
GO

CREATE TABLE Lancamentos(
	IdLancamento INT PRIMARY KEY IDENTITY
	,IdCategoria INT FOREIGN KEY REFERENCES Categorias(IdCategoria) NOT NULL
	,IdTipoLancamento INT FOREIGN KEY REFERENCES TiposLancamentos(IdTipoLancamento) NOT NULL
	,Titulo VARCHAR(255) NOT NULL
	,Sinopse TEXT
	,Duracao INT NOT NULL
);
GO

CREATE TABLE LancamentosFavoritos(
	IdUsuario INT FOREIGN KEY REFERENCES Usuarios(IdUsuario) NOT NULL
	,IdLancamento INT FOREIGN KEY REFERENCES Lancamentos(IdLancamento) NOT NULL
);
GO

ALTER TABLE Lancamentos
	ADD IdPlataforma INT FOREIGN KEY REFERENCES Plataformas(IdPlataforma);
GO

ALTER TABLE Usuarios
	ADD DataNascimento DATE
GO

ALTER TABLE Lancamentos
	ADD  DataLancamento DATE NOT NULL
GO

ALTER TABLE Lancamentos
	ADD Duracao INT
GO

ALTER TABLE Usuarios
	DROP COLUMN DataNascimento
GO

ALTER TABLE Usuarios
	ADD DataNascimento DATE DEFAULT('1900-12-31')
GO



