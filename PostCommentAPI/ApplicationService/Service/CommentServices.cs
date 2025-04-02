using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.Infraestructure.Interface;
using PostCommentAPI.Infraestructure.Repositories;
using System.ComponentModel.Design;

namespace PostCommentAPI.ApplicationService.Service
{
    public class CommentServices : ICommentsServices
    {
        private readonly ICommentsRepository _commentsRepository;

        public CommentServices(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }


        public async Task<string> CreateComment(CommentDTO comment)
        {
            bool respuesta = _commentsRepository.CreateComment(comment);
            if (respuesta)
            {
                return "Comentario creado exitosamente";
            }
            return "No se puedo crear el comentario";
        }


        public async Task<string> UpdateComment(UpdateCommentDTO comment)
        {
            bool respuesta = _commentsRepository.UpdateComment(comment);
            if (respuesta)
            {
                return "Comentatio actualizado exitosamente";
            }
            return "No se puedo actualizar el comentario";
        }


        public async Task<string> DeleteComment(int CommentId)
        {
            bool respuesta = _commentsRepository.DeleteComment(CommentId);
            if (respuesta)
            {
                return "Comentario eliminado exitosamente";
            }
            return "No se puedo eliminar el Comentario";
        }
    }

}

