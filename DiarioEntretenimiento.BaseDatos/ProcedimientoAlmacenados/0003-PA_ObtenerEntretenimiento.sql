USE DiarioEntretenimientoDB;
GO

CREATE PROCEDURE [dbo].[PA_ObtenerEntretenimiento]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, Titulo, Tipo, Estado, Calificacion, ImagenURL, Comentario
	FROM Entretenimiento
	ORDER BY FechaRegistro DESC;
END;
GO