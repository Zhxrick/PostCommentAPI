using Microsoft.Data.SqlClient;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.Infraestructure.Interface;
using System.Data;

namespace PostCommentAPI.Infraestructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly string _conexionSQL;
        public PostRepository(IConfiguration configuration)
        {
            _conexionSQL = configuration.GetConnectionString("ConexionSQL");

        }

        public List<Post> GetListadoPost()
        {
            List<Post> posted = new List<Post>();
            DataTable dtDatos = new DataTable();
            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_listaPosts]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        new SqlDataAdapter(cmd).Fill(dtDatos);
                    }
                }
                if (dtDatos.Rows.Count > 0)
                {
                    dtDatos.AsEnumerable().ToList().ForEach(fila =>
                    {
                        posted.Add(new Post()
                        {
                            PostId = Convert.ToInt32(fila["PostId"]),
                            Nombre = Convert.ToString(fila["Nombre"]),
                            Contenido = Convert.ToString(fila["Contenido"]),
                            FechaCreacion = Convert.ToDateTime(fila["FechaCreacion"]),
                            FechaActualizacion = Convert.ToDateTime(fila["FechaActualizacion"]),
                            Estado = Convert.ToString(fila["Estado"])

                        });
                    });

                }
                return posted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public bool CreatePost(PostDTO post)
        {
            bool res = false;
            DataTable table = new DataTable();
            table.Columns.Add("CategoryId", typeof(int)); 

            foreach (var categoria in post.Categorias)
            {
                table.Rows.Add(categoria.Id); 
            }
            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_CrearPosts]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = post.Nombre;
                        cmd.Parameters.Add("@Contenido", SqlDbType.NVarChar, 100).Value = post.Contenido;
                        cmd.Parameters.Add("@Categorias", SqlDbType.Structured, 100).Value = table;
                        conexion.Open();
                        res = cmd.ExecuteNonQuery() > 0;
                    }
                }

                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
       
        public bool UpdatePost(UpdatePostDTO post)
        {
            bool res = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_EditarPosts]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = post.PostId;
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = post.Nombre;
                        cmd.Parameters.Add("@Contenido", SqlDbType.NVarChar, 100).Value = post.Contenido;
                        conexion.Open();
                        res = cmd.ExecuteNonQuery() > 0;
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }


        public bool DeletePost(int PostId)
        {
            bool res = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_eliminarPosts]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = PostId;
                        conexion.Open();
                        res = cmd.ExecuteNonQuery() > 0;
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }


    }
}
