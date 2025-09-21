
USE master;

GO

USE GUIA6_1_Ejercicio1_DB;

GO


-- a- Realice la consulta de la tabla Figuras.

SELECT * FROM Figuras;

GO

-- b- Establezca variables T-SQL con valores iniciales.

DECLARE @FIGURA_NUEVA TABLE(Id INT);
DECLARE @Tipo INT =1; --rectangulo
DECLARE @Ancho DECIMAL(18,2)=10;
DECLARE @Largo DECIMAL(18,2)=12;
DECLARE @Radio DECIMAL(18,2)=NULL;


-- c- insertar la nueva figura según los valores especificados, imprimir el Id generado. (cláusula OUTPUT)

INSERT INTO Figuras (Tipo, Ancho, Largo, Radio)
OUTPUT INSERTED.Id 
VALUES
(@Tipo, @Ancho, @Largo, @Radio)


-- d- Realice la consulta de la tabla Figuras.

SELECT * FROM Figuras;

GO

USE master