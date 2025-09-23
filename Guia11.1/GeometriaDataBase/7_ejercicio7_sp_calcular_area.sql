
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO

-- a- Cree un sp llamado sp_CalcularAreas que calcule el área de todas las entidades.

CREATE OR ALTER PROCEDURE sp_CalcularAreas
AS
BEGIN
	DECLARE Figura_CURSOR CURSOR FOR 
	SELECT Id, Tipo, Area, Ancho, Largo, Radio 
	FROM Figuras;

	OPEN Figura_CURSOR;

	DECLARE @Id NUMERIC(18,2), @Tipo INT, @Area NUMERIC(18,2),
	@Ancho NUMERIC(18,2), @Largo NUMERIC(18,2), @Radio NUMERIC(18,2);

	FETCH NEXT 
	FROM Figura_CURSOR INTO @Id, @Tipo, @Area, @Ancho, @Largo, @Radio;

	WHILE @@FETCH_STATUS=0
	BEGIN

		IF @Tipo=1
		BEGIN 
			SET @Area=@Ancho*@Largo;			
		END
		ELSE IF @Tipo=2
		BEGIN
			SET @Area=3.1415*POWER(@Radio,2);
		END

		UPDATE Figuras SET Area=@Area 
		WHERE Id=@Id;
		
		FETCH NEXT 
		FROM Figura_CURSOR INTO @Id, @Tipo, @Area, @Ancho, @Largo, @Radio;
	END 

	CLOSE Figura_CURSOR;
	DEALLOCATE Figura_CURSOR;

END

GO

-- b- Ejecutar el procedimiento almacenado
EXEC  sp_CalcularAreas

GO

-- c- Realice la consulta de la tabla Figuras.

SELECT f.Id,
	   CASE WHEN f.Tipo=1 THEN 'Rectangulo'
			WHEN f.Tipo=2 THEN 'Circulo'
	   ELSE 'Desconocido' END AS Tipo,
	   f.Area,
	   f.Ancho,
	   f.Largo,
	   f.Radio
FROM Figuras f


--USE master

