namespace PostCommentAPI.ApplicationService.Models
{
    public class PostDetailsDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
        public List<CategoryInfoDTO> Categories { get; set; } 
        public List<CommentInfoDTO> Comments { get; set; } 
    }

    public class CategoryInfoDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }

    public class CommentInfoDTO
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }
    }
}
