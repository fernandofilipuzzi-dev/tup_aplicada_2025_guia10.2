
USE master;

GO

USE Guia11_1_GeometriaDataBase_DB;

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