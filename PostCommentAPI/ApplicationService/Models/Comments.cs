namespace PostCommentAPI.ApplicationService.Models
{
    public class Comment
    {
            public int CommentId { get; set; }
            public int PostId { get; set; }
            public string Contenido { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaActualizacion { get; set; }
            public string Estado { get; set; }
    }

    public class CommentDTO
    {
        public int PostId { get; set; }
        public string Contenido { get; set; }
    }

    public class UpdateCommentDTO
    {
        public int CommentId { get; set; }
        public string Contenido { get; set; }
    }



}
