using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.ApplicationService.Interface
{
    public interface ICommentsServices
    
    {
            public Task<string> CreateComment(CommentDTO comment);
            public Task<string> UpdateComment(UpdateCommentDTO comment);
            public Task<string> DeleteComment(int CommentId);
    }
}
