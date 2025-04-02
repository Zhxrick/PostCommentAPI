using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.ApplicationService.Interface
{
    public interface IPostServices
    {
        public Task<List<Post>> GetListadoPost();
        public Task<string> CreatePost(PostDTO post);
        public Task<string> UpdatePost(UpdatePostDTO post);
        public Task<string> DeletePost(int PostId);
    }
}
