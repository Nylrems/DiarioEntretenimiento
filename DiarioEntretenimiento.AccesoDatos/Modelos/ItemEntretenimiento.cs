namespace DiarioEntretenimiento.AccesoDatos.Modelos
{
    public class ItemEntretenimiento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public byte Calificacion { get; set; }
        public string ImagenURL { get; set; }
        public string Comentario { get; set; }
    }
}
