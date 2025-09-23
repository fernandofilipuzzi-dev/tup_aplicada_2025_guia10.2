
-- Ejercicio 1 - Table Per Hierarchy (TPH)


-- a- Crear la base para el ejercicio 1

USE master;

GO

DROP DATABASE IF EXISTS GUIA10_1_Ejercicio1_DB;

GO

CREATE DATABASE GUIA10_1_Ejercicio1_DB

GO

USE GUIA10_1_Ejercicio1_DB;

GO

-- b- Crear las tablas

CREATE TABLE Figuras(
	Id INT PRIMARY KEY IDENTITY(1,1),	
	Tipo INT NOT NULL,
	Area DECIMAL(18, 2),
	Ancho DECIMAL(18,2), 
	Largo DECIMAL(18,2),
	Radio DECIMAL(18,2)
);

GO

-- c- Insertar figuras como ejemplo
DECLARE @Ids TABLE(Id INT);
DECLARE @Id INT;

INSERT INTO Figuras(Tipo, Ancho, Largo, Radio) 
OUTPUT INSERTED.Id INTO @Ids 
VALUES
(1, 1,    1,    NULL),
(1, 1,    2,    NULL),
(2, NULL, NULL, 1),
(1, 2.2,    1,    NULL),
(2, NULL, NULL, 2.1);

SELECT TOP 1 @Id=Id FROM @Ids

SELECT @Id




SELECT f.Id,
	   CASE WHEN f.Tipo=1 THEN 'Rectangulo'
			WHEN f.Tipo=2 THEN 'Circulo'
	   ELSE 'Desconocido' END AS Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f;


GO

USE master

GO