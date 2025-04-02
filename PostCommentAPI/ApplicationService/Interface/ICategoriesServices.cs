using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.ApplicationService.Interface
{
    public interface ICategoriesServices
    {
        public Task<List<Category>> GetListadoCategorias();
        public Task <string> CreateCategoria(CategoryDTO category);
        public Task<string> UpdateCategoria(UpdateCategoryDTO category);
        public Task<string> DeleteCategoria(int CategoryId);


    }
}
