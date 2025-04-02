using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.Infraestructure.Interface
{
    public interface IPostDetailsRepository
    {
        PostDetailsDTO ObtenerDetallesPost(int postId);
    }
}
