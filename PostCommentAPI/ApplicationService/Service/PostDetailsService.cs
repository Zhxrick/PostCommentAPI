using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.Infraestructure.Interface;

namespace PostCommentAPI.ApplicationService.Service
{
    public class PostDetailsService : IPostDetailsService
    {
        private readonly IPostDetailsRepository _postDetailsRepository;

        public PostDetailsService (IPostDetailsRepository postDetailsRepository)
        {
            _postDetailsRepository = postDetailsRepository;
        }

        public PostDetailsDTO ObtenerDetallesPost(int postId)
        {
            return _postDetailsRepository.ObtenerDetallesPost(postId);
        }



    }
}
