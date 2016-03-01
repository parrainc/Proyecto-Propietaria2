CREATE DATABASE proyecto_empleos;
GO

USE proyecto_empleos;
GO

CREATE TABLE categorias
(
	id INT IDENTITY(1,1) NOT NULL,
	descripcion NVARCHAR(100) NOT NULL
);
GO

CREATE TABLE usuarios
(
	id INT IDENTITY(1,1) NOT NULL,
	nombre NVARCHAR(100) NOT NULL,
	telefono NCHAR(15),
	correo NVARCHAR(100),
	website NVARCHAR(100)
);
GO

CREATE TABLE empleos
(
	id INT IDENTITY(1,1) NOT NULL,
	titulo NVARCHAR(100) NOT NULL,
	descripcion NVARCHAR(MAX) NOT NULL,
	categoria INT NOT NULL,
	sueldo DECIMAL(8,2),
	published_by INT NOT NULL

	CONSTRAINT PK_id_empleos PRIMARY KEY(id)	 
);
GO

ALTER TABLE usuarios
ADD
CONSTRAINT PK_id_usuario PRIMARY KEY(id);
GO

ALTER TABLE categorias
ADD
CONSTRAINT PK_id_categoria PRIMARY KEY(id);
GO

ALTER TABLE empleos
ADD 
CONSTRAINT FK_published_by FOREIGN KEY(published_by)
REFERENCES usuarios(id)  ON UPDATE CASCADE ON DELETE CASCADE;
GO

ALTER TABLE empleos
ADD 
CONSTRAINT FK_categoria_empleo FOREIGN KEY(categoria)
REFERENCES categorias(id)  ON UPDATE CASCADE ON DELETE CASCADE;
GO

-------------Añadiendo algunos registros en categorias----

DECLARE @I INT;
SET @I = 1;

WHILE @I < 50
BEGIN;
	INSERT INTO categorias
	VALUES
	(,CONCAT('Categoria ',@I));
	SET @I = @I + 1;
END;

SELECT * FROM categorias;

-------------Añadiendo algunos registros en usuarios----

DECLARE @I INT;
SET @I = 1;

WHILE @I < 20
BEGIN;
	INSERT INTO usuarios
	VALUES
	(CONCAT('Usuario ',@I), '8092386666', CONCAT('correo-usuario',@I,'@gmail.com'), CONCAT('http://www.mysite', @I,'.com/'));
	SET @I = @I + 1;
END;

SELECT * FROM usuarios;