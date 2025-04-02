using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.ApplicationService.Service;
using PostCommentAPI.Infraestructure.Interface;

namespace PostCommentAPI.Controllers
{
    public class CommentsController : Controller
    {
       private readonly ICommentsServices _commentsServices;

        public CommentsController(ICommentsServices commentsServices)
        {
            _commentsServices = commentsServices;
        }


        [HttpPost("api/[action]")]
        public async Task<ActionResult> CreateComments([FromBody] CommentDTO comment)
        {
            try
            {
                var res = await _commentsServices.CreateComment(comment);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }


        [HttpPut("api/[action]")]
        public async Task<ActionResult> UpdateComment([FromBody] UpdateCommentDTO comment)
        {
            try
            {
                var res = await _commentsServices.UpdateComment(comment);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }


        [HttpDelete("api/[action]")]
        public async Task<ActionResult> DeleteComments(int CommentId)
        {
            try
            {
                var res = await _commentsServices.DeleteComment(CommentId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }







    }
}
