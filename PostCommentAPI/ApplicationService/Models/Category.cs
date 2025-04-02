namespace PostCommentAPI.ApplicationService.Models
{
    public class Category
    {
        public int  CategoryId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Estado { get; set; }  
       
            
    }

    public class CategoryDTO
    {
        public string Nombre { get; set; }
    }



    public class UpdateCategoryDTO
    {
        public int CategoryId { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }


}
