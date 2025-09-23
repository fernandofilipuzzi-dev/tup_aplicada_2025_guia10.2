
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO

-- a- Realice la consulta de la tabla Figuras.

SELECT * FROM Figuras WHERE Id=@Id_Figura;


-- b- Establezca el valor de la Id , por ejemplo: 3.
DECLARE @Id_Figura INT=3;


-- c- Realice el delete del registro
DELETE FROM Figuras 
WHERE Id=@Id_Figura

-- d- Realice la consulta de la tabla Figuras.
SELECT * FROM Figuras WHERE Id=@Id_Figura;

GO

USE master