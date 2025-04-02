using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.Controllers
{
    public class CategoriesController : Controller
    {
       
        private readonly ICategoriesServices _postCommentService;

        public CategoriesController(ICategoriesServices postCommentService){
        
            _postCommentService = postCommentService;   
        }


        [HttpGet("api/[action]")]
        public async Task<ActionResult> GetListadoCategorias()
        {
            try
            {
                var res = await _postCommentService.GetListadoCategorias();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }


        [HttpPost("api/[action]")]
        public async Task<ActionResult> CreateCategoria([FromBody]CategoryDTO category)
        {
            try
            {
                var res = await _postCommentService.CreateCategoria(category);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }


        [HttpPut("api/[action]")]
        public async Task<ActionResult> UpdateCategoria([FromBody] UpdateCategoryDTO category)
        {
            try
            {
                var res = await _postCommentService.UpdateCategoria(category);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }


        [HttpDelete("api/[action]")]
        public async Task<ActionResult> DeleteCategoria(int categoryId)
        {
            try
            {
                var res = await _postCommentService.DeleteCategoria(categoryId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno.");

            }
        }



    }
}



