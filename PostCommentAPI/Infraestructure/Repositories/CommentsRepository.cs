using Microsoft.Data.SqlClient;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.ApplicationService.Service;
using PostCommentAPI.Infraestructure.Interface;
using System.Data;

namespace PostCommentAPI.Infraestructure.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly string _ConexionSQL;
        public CommentsRepository(IConfiguration configuration)
        {
            _ConexionSQL = configuration.GetConnectionString("ConexionSQL");
        }


        public bool CreateComment(CommentDTO comment)
        {
            bool res = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_ConexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_crearComment]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@PostId", SqlDbType.Int).Value = comment.PostId;
                        cmd.Parameters.Add("@Contenido", SqlDbType.NVarChar, 500).Value = comment.Contenido;
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

        public bool UpdateComment(UpdateCommentDTO comment)
        {
            bool res = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_ConexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_editarComment]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@CommentId", SqlDbType.Int).Value = comment.CommentId;
                        cmd.Parameters.Add("@Contenido", SqlDbType.NVarChar, 100).Value = comment.Contenido;
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

        public bool DeleteComment(int CommentId)
        {
            bool res = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_ConexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_eliminarComment]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@CommentId", SqlDbType.Int).Value = CommentId;
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

    



