USE DiarioEntretenimientoDB;
GO

-- Ejecutamos el SP con los datos del libro
EXEC PA_InsertarEntretenimiento 
    @Titulo = 'Apología de Sócrates',
    @Tipo = 'Libro',
    @Estado = 'Finalizado',
    @Calificacion = 10, -- ¡Un clásico merece un 10!
    @ImagenUrl = 'https://upload.wikimedia.org/wikipedia/commons/thumb/8/8c/David_-_The_Death_of_Socrates.jpg/800px-David_-_The_Death_of_Socrates.jpg',
    @Comentario = 'Obra de Platón que detalla la defensa de Sócrates durante su juicio. Una lectura fundamental sobre ética y filosofía.';
GO

-- Verificación rápida para que veas que quedó guardado
SELECT * FROM Entretenimiento WHERE Titulo = 'Apología de Sócrates';
GO
