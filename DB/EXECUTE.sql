--Creo la database a utilizar
BEGIN

CREATE DATABASE ChallengeSG;

END
GO

--Selecciono la db
BEGIN

USE ChallengeSG;

END
GO

--creo las tablas rol y usuario
BEGIN

CREATE TABLE Rol (
	Id INT NOT NULL UNIQUE IDENTITY,
	Nombre VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX),
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Rol PRIMARY KEY (Id)
);

CREATE TABLE Usuario (
	Id INT NOT NULL UNIQUE IDENTITY,
	IdRol INT NOT NULL,
	NombreUsuario VARCHAR(MAX) NOT NULL,
	Contrasenia VARCHAR(MAX) NOT NULL,
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Usuario PRIMARY KEY(Id),
	CONSTRAINT FK_Usuario_IdRol FOREIGN KEY(IdRol) REFERENCES Rol(Id),
	CONSTRAINT FK_Usuario_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Usuario_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

END
GO

--realizo los inserts iniciales
BEGIN

INSERT INTO Rol (Nombre, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('ADMIN', 1, GETDATE(), 1, GETDATE(), 1),
('USER', 1, GETDATE(), 1, GETDATE(), 1);

INSERT INTO Usuario (IdRol, NombreUsuario, Contrasenia, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES (1, 'PFREYTES', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 1, GETDATE(), 1, GETDATE(), 1),
(2, 'RRODRIGUEZ', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 1, GETDATE(), 1, GETDATE(), 1),
(2, 'MBRITEZ', '5994471abb01112afcc18159f6cc74b4f511b99806da59b3caf5a9c173cacfc5', 1, GETDATE(), 1, GETDATE(), 1);

--modifico tabla rol para agregar la relacion a la tabla usuario
ALTER TABLE Rol
ADD CONSTRAINT FK_Rol_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
CONSTRAINT FK_Rol_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id);

END
GO

--creamos las tablas moneda y pais
BEGIN

CREATE TABLE Moneda (
	Id INT NOT NULL UNIQUE IDENTITY,
	Codigo VARCHAR(MAX) NOT NULL,
	Nombre VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX),
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Moneda PRIMARY KEY(Id),
	CONSTRAINT FK_Moneda_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Moneda_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

CREATE TABLE Pais (
	Id INT NOT NULL UNIQUE IDENTITY,
	Codigo VARCHAR(MAX) NOT NULL,
	Nombre VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX),
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Pais PRIMARY KEY(Id),
	CONSTRAINT FK_Pais_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Pais_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

END
GO

--realizamos inserts iniciales en las tablas recien creadas
BEGIN 

INSERT INTO Moneda (Codigo, Nombre, Descripcion, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('ARS', 'Peso', 'Peso Argentino', 1, GETDATE(), 1, GETDATE(), 1),
('USD', 'Dolar', 'Dolar Estadounidense', 1, GETDATE(), 1, GETDATE(), 1),
('EUR', 'Euro', '', 1, GETDATE(), 1, GETDATE(), 1);

INSERT INTO Pais (Codigo, Nombre, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('ARG', 'Argentina',1, GETDATE(), 1, GETDATE(), 1);

END
GO

--creamos la tabla monedapais para la relacin muchos a muchos
BEGIN

CREATE TABLE MonedaPais (
	Id INT NOT NULL UNIQUE IDENTITY,
	IdMoneda INT NOT NULL,
	IdPais INT NOT NULL,
	Descripcion VARCHAR(MAX),
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_MonedaPais PRIMARY KEY(Id),
	CONSTRAINT FK_MonedaPais_IdMoneda FOREIGN KEY(IdMoneda) REFERENCES Moneda(Id),
	CONSTRAINT FK_MonedaPais_IdPais FOREIGN KEY(IdPais) REFERENCES Pais(Id),
	CONSTRAINT FK_MonedaPais_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_MonedaPais_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

END
GO

--realizamos el insert de la relacion
BEGIN

INSERT INTO MonedaPais (IdMoneda, IdPais, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES (1, 1, 1, GETDATE(), 1, GETDATE(), 1);

END
GO

--creamos tablas provincia y tipo cuenta
BEGIN

CREATE TABLE TipoCuenta (
	Id INT NOT NULL UNIQUE IDENTITY,
	Codigo VARCHAR(MAX) NOT NULL,
	Nombre VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX),
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_TipoCuenta PRIMARY KEY(Id),
	CONSTRAINT FK_TipoCuenta_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_TipoCuenta_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

CREATE TABLE Provincia (
	Id INT NOT NULL UNIQUE IDENTITY,
	Codigo VARCHAR(MAX) NOT NULL,
	Nombre VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX),
	IdPais INT NOT NULL,
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Provincia PRIMARY KEY(Id),
	CONSTRAINT FK_Provincia_IdPais FOREIGN KEY(IdPais) REFERENCES Pais(Id),
	CONSTRAINT FK_Provincia_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Provincia_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

END
GO

--inserts a tipo cuenta y provincia
BEGIN 

INSERT INTO Provincia (Codigo, Nombre, IdPais, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('AR-B', 'Buenos Aires',1, 1, GETDATE(), 1, GETDATE(), 1),
('AR-S', 'Santa Fe', 1,1, GETDATE(), 1, GETDATE(), 1),
('AR-X', 'Cordoba', 1,1, GETDATE(), 1, GETDATE(), 1);

INSERT INTO TipoCuenta (Codigo, Nombre, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('CC', 'Cuenta Corriente',1, GETDATE(), 1, GETDATE(), 1),
('CS', 'Cuenta Sueldo',1, GETDATE(), 1, GETDATE(), 1),
('CA', 'Caja de Ahorro',1, GETDATE(), 1, GETDATE(), 1);

END
GO

--creamos tabla localidades
BEGIN

CREATE TABLE Localidad (
	Id INT NOT NULL UNIQUE IDENTITY,
	Codigo VARCHAR(MAX) NOT NULL,
	Nombre VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX),
	IdProvincia INT NOT NULL,
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Localidad PRIMARY KEY(Id),
	CONSTRAINT FK_Localidad_IdProvincia FOREIGN KEY(IdProvincia) REFERENCES Provincia(Id),
	CONSTRAINT FK_Localidad_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Localidad_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

END
GO

--inserts a localidades

BEGIN 

INSERT INTO Localidad (Codigo, Nombre, IdProvincia, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('AR-BS', 'Buenos Aires', 1, 1, GETDATE(), 1, GETDATE(), 1),
('AR-ROS', 'Rosario', 2, 1, GETDATE(), 1, GETDATE(), 1),
('AR-SF', 'Santa Fe', 2, 1, GETDATE(), 1, GETDATE(), 1),
('AR-CC', 'Cordoba', 3, 1, GETDATE(), 1, GETDATE(), 1);

END
GO

--creamos la tabla banco
BEGIN

CREATE TABLE Banco (
	Id INT NOT NULL UNIQUE IDENTITY,
	Codigo VARCHAR(MAX) NOT NULL,
	Nombre VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX),
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Banco PRIMARY KEY(Id),
	CONSTRAINT FK_Banco_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Banco_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

END
GO

--inserts a banco
BEGIN

INSERT INTO Banco(Codigo, Nombre, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('BNA', 'Banco de la Nacion Argentina', 1, GETDATE(), 1, GETDATE(), 1),
('BBVA', 'Banco Bilbao Vizcaya Argentaria', 1, GETDATE(), 1, GETDATE(), 1),
('SAN', 'Banco Santander', 1, GETDATE(), 1, GETDATE(), 1);

END
GO

--creamos entidad sucursal
BEGIN

CREATE TABLE Sucursal (
	Id INT NOT NULL UNIQUE IDENTITY,
	Codigo VARCHAR(MAX) NOT NULL,
	IdBanco INT NOT NULL,
	IdLocalidad INT NOT NULL,
	Calle VARCHAR(MAX),
	NroCalle INT,
	Descripcion VARCHAR(MAX),
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Sucursal PRIMARY KEY(Id),
	CONSTRAINT FK_Sucursal_IdBanco FOREIGN KEY(IdBanco) REFERENCES Banco(Id),
	CONSTRAINT FK_Sucursal_IdLocalidad FOREIGN KEY(IdLocalidad) REFERENCES Localidad(Id),
	CONSTRAINT FK_Sucursal_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Sucursal_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

END
GO


--inserts a sucursal
BEGIN

INSERT INTO Sucursal(Codigo, IdBanco, IdLocalidad, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('C01', 1, 2, 1, GETDATE(), 1, GETDATE(), 1),
('C27', 2, 2, 1, GETDATE(), 1, GETDATE(), 1),
('S45', 2, 3, 1, GETDATE(), 1, GETDATE(), 1),
('G77', 3, 4, 1, GETDATE(), 1, GETDATE(), 1);

END
GO

--creams tabla tipodocumento
BEGIN

CREATE TABLE TipoDocumento(
	Id INT NOT NULL UNIQUE IDENTITY,
	TipoDoc VARCHAR(MAX) NOT NULL,
	Descripcion VARCHAR(MAX),
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_TipoDocumento PRIMARY KEY(Id),
	CONSTRAINT FK_TipoDocumento_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_TipoDocumento_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);

END
GO

--insert tipo doc
BEGIN

INSERT INTO TipoDocumento (TipoDoc, Descripcion, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('DNI', 'Documento Nacional de Identidad', 1, GETDATE(), 1, GETDATE(), 1),
('LC', 'Libreta Civica', 1, GETDATE(), 1, GETDATE(), 1),
('LE', 'Libreta de Enrolamiento', 1, GETDATE(), 1, GETDATE(), 1);

END
GO

--creamos tabla cliente
BEGIN 

CREATE TABLE Cliente (
	Id INT NOT NULL UNIQUE IDENTITY,
	Nombre VARCHAR(MAX) NOT NULL,
	Apellido VARCHAR(MAX) NOT NULL,
	FechaNacimiento DATETIME NOT NULL,
	IdUsuario INT NOT NULL,
	IdTipoDocumento INT NOT NULL,
	NroDocumento VARCHAR(MAX) NOT NULL,
	CUIT VARCHAR(MAX),
	CUIL VARCHAR(MAX),
	Mail VARCHAR(MAX),
	Calle VARCHAR(MAX),
	NroCalle INT,
	Piso INT,
	Departamento INT,
	IdLocalidad INT NOT NULL,
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Cliente PRIMARY KEY(Id),
	CONSTRAINT FK_Cliente_IdUsuario FOREIGN KEY(IdUsuario) REFERENCES Usuario(Id),
	CONSTRAINT FK_Cliente_IdTipoDocumento FOREIGN KEY(IdTipoDocumento) REFERENCES TipoDocumento(Id),
	CONSTRAINT FK_Cliente_IdLocalidad FOREIGN KEY(IdLocalidad) REFERENCES Localidad(Id),
	CONSTRAINT FK_Cliente_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Cliente_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);
END
GO

--inserts a cliente
BEGIN

INSERT INTO Cliente (Nombre, Apellido, FechaNacimiento, IdUsuario, IdTipoDocumento, NroDocumento, Mail, IdLocalidad, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES ('Paula', 'Freytes', '19940319', 1, 1, 37903658, 'paulafreytes@outlook.com', 1, 1, GETDATE(), 1, GETDATE(), 1),
('Roberto', 'Rodriguez', '19541009', 2, 2, 23987453, '', 3, 1, GETDATE(), 1, GETDATE(), 1),
('Margarita', 'Britez', '19720805', 3, 3, 42756092, '', 2, 1, GETDATE(), 1, GETDATE(), 1);

END
GO

--creamos tabla cuenta
BEGIN 

CREATE TABLE Cuenta (
	Id INT NOT NULL UNIQUE IDENTITY,
	IdCliente INT NOT NULL,
	IdSucursal INT NOT NULL,
	IdTipoCuenta INT NOT NULL,
	IdMoneda INT NOT NULL,
	NroCuenta INT NOT NULL,
	CBU VARCHAR(MAX) NOT NULL,
	Alias VARCHAR(MAX),
	Saldo DECIMAL(16,2) NOT NULL,
	Observacion VARCHAR(MAX),
	Activo bit NOT NULL,
	FechaUltimaModif DATETIME NOT NULL,
	UsuarioUltimaModif INT NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	UsuarioCreacion INT NOT NULL,
	CONSTRAINT PK_Cuenta PRIMARY KEY(Id),
	CONSTRAINT FK_Cuenta_IdCliente FOREIGN KEY(IdCliente) REFERENCES Cliente(Id),
	CONSTRAINT FK_Cuenta_IdSucursal FOREIGN KEY(IdSucursal) REFERENCES Sucursal(Id),
	CONSTRAINT FK_Cuenta_IdTipoCuenta FOREIGN KEY(IdTipoCuenta) REFERENCES TipoCuenta(Id),
	CONSTRAINT FK_Cuenta_IdMoneda FOREIGN KEY(IdMoneda) REFERENCES Moneda(Id),
	CONSTRAINT FK_Cuenta_UsuarioUltimaModif FOREIGN KEY(UsuarioUltimaModif) REFERENCES Usuario(Id),
	CONSTRAINT FK_Cuenta_UsuarioCreacion FOREIGN KEY(UsuarioCreacion) REFERENCES Usuario(Id)
);
END
GO

--inserts a cuenta
BEGIN

INSERT INTO Cuenta (IdCliente, IdSucursal, IdTipoCuenta, IdMoneda, NroCuenta, CBU, Saldo, Activo, FechaUltimaModif, UsuarioUltimaModif, FechaCreacion, UsuarioCreacion)
VALUES	(1, 2, 1, 1, 7569402, '142213434113450', 1986725, 1, GETDATE(), 1, GETDATE(), 1),
		(1, 2, 2, 2, 4856760, '838349421344213', 374650, 1, GETDATE(), 1, GETDATE(), 1),
		(2, 3, 3, 1, 8923489, '349421344213000', 389378512, 1, GETDATE(), 1, GETDATE(), 1),
		(3, 1, 1, 3, 4275920, '423342342234112', 2834167234, 1, GETDATE(), 1, GETDATE(), 1);

END
GO

