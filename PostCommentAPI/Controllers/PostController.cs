using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostServices _postCommentService;

        public PostController(IPostServices postCommentService)
        {

            _postCommentService = postCommentService;
        }


        [HttpGet("api/[action]")]
        public async Task<ActionResult> GetListadoPost()
        {
            try
            {
                var res = await _postCommentService.GetListadoPost();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }


        [HttpPost("api/[action]")]
        public async Task<ActionResult> CreatePost([FromBody] PostDTO post)
        {
            try
            {
                var res = await _postCommentService.CreatePost(post);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }


        [HttpPut("api/[action]")]
        public async Task<ActionResult> UpdatePost([FromBody] UpdatePostDTO post)
        {
            try
            {
                var res = await _postCommentService.UpdatePost(post);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }


        [HttpDelete("api/[action]")]
        public async Task<ActionResult> DeletePost(int PostId)
        {
            try
            {
                var res = await _postCommentService.DeletePost(PostId);
                if (res == null)
                {
                    return NotFound(new { message = "Post no encontrado." });
                }

                return Ok(new { message = "Post eliminada exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Se produjo un error interno.", error = ex.Message });
            }
        }




    }
}



