using Microsoft.Data.SqlClient;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.Infraestructure.Interface;
using System.Data;

namespace PostCommentAPI.Infraestructure.Repositories
{
    public class PostDetailsRepository : IPostDetailsRepository
    {
        public readonly string _conexionSQL;

        public PostDetailsRepository(IConfiguration configuration)
        {
            _conexionSQL = configuration.GetConnectionString("ConexionSQL");
        }


        public PostDetailsDTO ObtenerDetallesPost(int postId)
        {
            PostDetailsDTO postDetalles = new PostDetailsDTO();
            List<CategoryInfoDTO> categories = new List<CategoryInfoDTO>();
            List<CommentInfoDTO> comments = new List<CommentInfoDTO>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                using (SqlCommand cmd = new SqlCommand("sp_oBtenerPostDetalles", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = postId;

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            postDetalles = new PostDetailsDTO
                            {
                                PostId = (int)reader["PostId"],
                                Title = reader["Titulo"].ToString(),
                                Content = reader["Contenido"].ToString(),
                                CreatedAt = (DateTime)reader["FechaCreacion"],
                                UpdatedAt = (DateTime)reader["FechaActualizacion"],
                                Status = reader["Estado"].ToString()
                            };
                        }
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new CategoryInfoDTO
                                {
                                    CategoryId = (int)reader["CategoryId"],
                                    Name = reader["Categoria"].ToString()
                                });
                            }
                        }
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                comments.Add(new CommentInfoDTO
                                {
                                    CommentId = (int)reader["CommentId"],
                                    PostId = postId,
                                    Content = reader["Contenido"].ToString(),
                                    CreatedAt = (DateTime)reader["FechaCreacion"],
                                    UpdatedAt = (DateTime)reader["FechaActualizacion"],
                                    Status = reader["Estado"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            postDetalles.Categories = categories;
            postDetalles.Comments = comments;

            return postDetalles;
        }



    }
}
