using PostCommentAPI.ApplicationService.Models;

namespace PostCommentAPI.Infraestructure.Interface
{
    public interface ICategoriesRepository
    {
        public List<Category> GetListadoCategorias();
        public bool CreateCategoria(CategoryDTO category);
        public bool UpdateCategoria(UpdateCategoryDTO category);
       public bool DeleteCategoria(int CategoryId);

    }
}
