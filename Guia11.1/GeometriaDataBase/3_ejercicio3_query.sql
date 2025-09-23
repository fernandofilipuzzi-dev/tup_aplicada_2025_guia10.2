
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO


-- listar la figura por ID.

DECLARE @Id INT =3;

SELECT f.Id,
	   CASE WHEN f.Tipo=1 THEN 'Rectangulo'
			WHEN f.Tipo=2 THEN 'Circulo'
	   ELSE 'Desconocido' END AS Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f
WHERE f.Id=@Id

GO

USE master