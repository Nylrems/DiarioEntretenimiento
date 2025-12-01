CREATE TABLE [dbo].[Entretenimiento]
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Titulo NVARCHAR (100) NOT NULL,
	Tipo NVARCHAR(20) NOT NULL, -- Videojuego, Libro, Anime, Serie
	Estado NVARCHAR(20) NOT NULL, -- Finalizado, Pendiente, Abandonado
	Calificacion TINYINT CHECK (Calificacion BETWEEN 0 AND 10),
	ImagenURL NVARCHAR(1000) NULL,
	Comentario NVARCHAR(MAX) NULL,
	FechaRegistro DATETIME DEFAULT GETDATE()
);
