using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.Infraestructure.Interface
{
    public interface ICommentsRepository
    {
        public bool CreateComment(CommentDTO comment);
        public bool UpdateComment(UpdateCommentDTO comment);
        public bool DeleteComment(int CommentId);

    }
}
