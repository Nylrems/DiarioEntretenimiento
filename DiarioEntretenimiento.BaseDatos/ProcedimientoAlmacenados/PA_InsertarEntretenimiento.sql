USE DiarioEntretenimientoDB;
GO

CREATE OR ALTER PROCEDURE PA_InsertarEntretenimiento
    @Titulo NVARCHAR(100),
    @Tipo NVARCHAR(20),
    @Estado NVARCHAR(20),
    @Calificacion TINYINT,
    @ImagenUrl NVARCHAR(500),
    @Comentario NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Entretenimiento (Titulo, Tipo, Estado, Calificacion, ImagenUrl, Comentario)
    VALUES (@Titulo, @Tipo, @Estado, @Calificacion, @ImagenUrl, @Comentario);

    -- Devuelve el ID que se acaba de generar (clave para el backend)
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS NuevoId;
END;
GO