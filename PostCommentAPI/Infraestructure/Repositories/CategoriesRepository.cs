using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.Infraestructure.Interface;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PostCommentAPI.Infraestructure.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly string _conexionSQL;
        public CategoriesRepository(IConfiguration configuration)
        {
            _conexionSQL = configuration.GetConnectionString("ConexionSQL");
        }
        public List<Category> GetListadoCategorias()
        {
            List<Category> categories = new List<Category>();
            DataTable dtDatos = new DataTable();
            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_ListaCategorias]", conexion))
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
                        categories.Add(new Category()
                        {
                            CategoryId = Convert.ToInt32(fila["CategoryId"]),
                            Nombre = Convert.ToString(fila["Nombre"]),
                            FechaCreacion = Convert.ToDateTime(fila["FechaCreacion"]),
                            FechaActualizacion = Convert.ToDateTime(fila["FechaActualizacion"]),
                            Estado = Convert.ToString(fila["Estado"])

                        });
                    });

                }
                return categories;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        public bool CreateCategoria(CategoryDTO category)
        {
            bool res = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_CrearCategory]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = category.Nombre;
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
        public bool UpdateCategoria(UpdateCategoryDTO category)
        {
            bool res = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_editarCategory]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = category.CategoryId;
                        cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = category.Nombre;
                        cmd.Parameters.Add("@Estado", SqlDbType.NVarChar, 4).Value = category.Estado;
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
        public bool DeleteCategoria(int CategoryId)
        {
            bool res = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(_conexionSQL))
                {
                    using (SqlCommand cmd = new SqlCommand("[sp_eliminarCategory]", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 900000;
                        cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = CategoryId;
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



