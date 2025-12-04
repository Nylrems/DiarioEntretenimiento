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

        /// <summary>
        /// Método para obtener los items ingresados.
        /// </summary>
        /// <returns></returns>
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
                                Comentario = lector["Comentario"] != DBNull.Value ? lector["Comentario"].ToString() : null
                            });
                        }
                    }
                }

                return lista;
            }
        }

        /// <summary>
        /// Método para agregar algún tipo de Item.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Insertar(ItemEntretenimiento item)
        {
            int nuevoId = 0;

            using (var conexion = new SqlConnection(_cadenaConexion))
            {
                using (var comando = new SqlCommand("PA_InsertarEntretenimiento", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("@Titulo", item.Titulo);
                    comando.Parameters.AddWithValue("@Tipo", item.Tipo);
                    comando.Parameters.AddWithValue("@Estado", item.Estado);
                    comando.Parameters.AddWithValue("@Calificacion", item.Calificacion);

                    comando.Parameters.AddWithValue("@ImagenURL",
                        (object)item.ImagenURL ?? DBNull.Value);

                    comando.Parameters.AddWithValue("@Comentario",
                        (object)item.Comentario ?? DBNull.Value);

                    conexion.Open();

                    nuevoId = Convert.ToInt32(comando.ExecuteScalar());
                }
            }

            return nuevoId;
        }
    }
}
