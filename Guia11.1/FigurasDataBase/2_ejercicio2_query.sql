
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO

-- listar todas las figuras

SELECT f.Id,
	   f.Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f
ORDER BY f.Id

GO

USE master