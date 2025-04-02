using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.Infraestructure.Interface;

namespace PostCommentAPI.ApplicationService.Service
{
   
        public class PostServices : IPostServices
        {
            private readonly IPostRepository _postRepository;

            public PostServices(IPostRepository postRepository)
            {

                _postRepository = postRepository;
            }

            public async Task<List<Post>> GetListadoPost()
            {

                List<Post> post = _postRepository.GetListadoPost();
                return post;

            }


            public async Task<string> CreatePost(PostDTO post)
            {
                bool respuesta = _postRepository.CreatePost(post);
                if (respuesta)
                {
                    return "Post creado exitosamente";
                }
                return "No se puedo crear el post";
            }


            public async Task<string> UpdatePost(UpdatePostDTO post)
            {
                bool respuesta = _postRepository.UpdatePost(post);
                if (respuesta)
                {
                    return "Post actualizado exitosamente";
                }
                return "No se puedo actualizar el post";
            }


            public async Task<string> DeletePost(int PostId)
            {
                bool respuesta = _postRepository.DeletePost(PostId);
                if (respuesta)
                {
                    return "Post eliminada exitosamente";
                }
                return "No se puedo eliminar el post";
            }
        }
    }

