using Microsoft.Data.SqlClient;
using System.Data;
using DiarioEntretenimiento.AccesoDatos.Modelos;

namespace DiarioEntretenimiento.AccesoDatos.Repositorios
{
    public class RepositorioEntretenimiento
    {
        private readonly string _cadenaConexion;

        public RepositorioEntretenimiento(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public List<ItemEntretenimiento> ObtenerCatalogo()
        {
            var lista = new List<ItemEntretenimiento>();

            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                using (var comando = new SqlCommand("PA_ObtenerEntretenimiento", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(new ItemEntretenimiento
                            {
                                Id = Convert.ToInt32(lector["Id"]),
                                Titulo = lector["Titulo"].ToString(),
                                Tipo = lector["Tipo"].ToString(),
                                Estado = lector["Estado"].ToString(),
                                Calificacion = Convert.ToByte(lector["Calificacion"]),
                                ImagenURL = lector["ImagenURL"] != DBNull.Value ? lector["ImagenURL"].ToString() : null,
                                Comentario = lector["Comentario"] != DBNull.Value ? lector["Calificacion"].ToString() : null
                            });
                        }
                    }
                }

                return lista;
            }
        }
    }
}
