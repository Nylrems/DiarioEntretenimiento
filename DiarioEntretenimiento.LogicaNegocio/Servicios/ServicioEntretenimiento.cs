using DiarioEntretenimiento.AccesoDatos.Modelos;
using DiarioEntretenimiento.AccesoDatos.Repositorios;

namespace DiarioEntretenimiento.LogicaNegocio.Servicios
{
    public class ServicioEntretenimiento
    {
        private readonly RepositorioEntretenimiento _repositorio;

        public ServicioEntretenimiento(string cadenaConexion)
        {
            _repositorio = new RepositorioEntretenimiento(cadenaConexion);
        }

        public List<ItemEntretenimiento> ObtenerCatalogo()
        {
            return _repositorio.ObtenerCatalogo();
        }

        public int AgregarNuevo(ItemEntretenimiento item)
        {
            if (string.IsNullOrEmpty(item.Titulo))
            {
                throw new ArgumentException("El título es obligatorio.");
            }

            if (item.Calificacion < 0 || item.Calificacion > 10)
            {
                throw new ArgumentException("La calificación debe de estar entre 0 y 10");
            }

            return _repositorio.Insertar(item);
        }
    }
}
