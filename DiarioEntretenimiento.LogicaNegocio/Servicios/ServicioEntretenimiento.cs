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
    }
}
