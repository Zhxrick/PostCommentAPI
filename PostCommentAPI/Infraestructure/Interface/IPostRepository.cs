using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.Infraestructure.Interface
{
    public interface IPostRepository
    {
        public List<Post> GetListadoPost();
        public bool CreatePost(PostDTO post);
        public bool UpdatePost(UpdatePostDTO post);
        public bool DeletePost(int PostId);
    }
}
