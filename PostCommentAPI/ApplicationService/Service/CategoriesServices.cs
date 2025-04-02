using Microsoft.AspNetCore.Mvc;
using PostCommentAPI.ApplicationService.Interface;
using PostCommentAPI.ApplicationService.Models;
using PostCommentAPI.Infraestructure.Interface;
using System.Collections.Generic;

namespace PostCommentAPI.ApplicationService.Service
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly ICategoriesRepository _categoryRepository;

        public CategoriesServices(ICategoriesRepository CategoryRepository) {

            _categoryRepository = CategoryRepository;
        }

        public async Task<List<Category>> GetListadoCategorias() {

            List<Category> categorias = _categoryRepository.GetListadoCategorias();
            return categorias;

        }


        public async Task<string>CreateCategoria(CategoryDTO category)
        {
            bool respuesta = _categoryRepository.CreateCategoria(category);
            if (respuesta)
            {
                return "Categoría creada exitosamente";
            }
            return "No se puedo crear la categoría";
        }


        public async Task<string> UpdateCategoria(UpdateCategoryDTO category)
        {
            bool respuesta = _categoryRepository.UpdateCategoria(category);
            if (respuesta)
            {
                return "Categoría actualizar exitosamente";
            }
            return "No se puedo actualizar la categoría";
        }


        public async Task<string> DeleteCategoria(int categoryId)
        {
            bool respuesta = _categoryRepository.DeleteCategoria(categoryId);
            if (respuesta)
            {
                return "Categoría eliminada exitosamente";
            }
            return "No se puedo eliminar la categoría";
        }


    }
}
