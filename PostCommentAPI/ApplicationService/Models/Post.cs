namespace PostCommentAPI.ApplicationService.Models
{
  
    public class Post
    {
        public int PostId { get; set; }
        public string Nombre { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Estado { get; set; }
    }

    public class PostDTO
    {
        public string Nombre { get; set; }
        public string Contenido { get; set; }

        public List<CategoryIdDTO> Categorias { get; set; }
    }


    public class CategoryIdDTO
    {
        public int Id { get; set; }
    }

    public class UpdatePostDTO
    {
        public int @PostId { get; set; }
        public string @Nombre { get; set; }
        public string @Contenido { get; set; }
     
    }



}
