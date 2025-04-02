using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.ApplicationService.Service;
using PostCommentAPI.Infraestructure.Interface;

namespace PostCommentAPI.Controllers
{
    public class PostDetailsController : Controller
    {
        private readonly IPostDetailsService _postDetailsService;


        public PostDetailsController(IPostDetailsService postDetailsService)
        {
            _postDetailsService = postDetailsService;
        }


        [HttpGet("api/[action]")]
        public IActionResult ObtenerDetallesPost(int postId)
        {
            var postDetails = _postDetailsService.ObtenerDetallesPost(postId);
            if (postDetails == null)
            {
                return NotFound("Detalles no encontrados.");
            }
            return Ok(postDetails);
        }


    }
}
