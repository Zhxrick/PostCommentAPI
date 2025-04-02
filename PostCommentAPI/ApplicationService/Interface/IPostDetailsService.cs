using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.ApplicationService.Interface
{
    public interface IPostDetailsService
    {
        PostDetailsDTO ObtenerDetallesPost(int postId);
    }

}
