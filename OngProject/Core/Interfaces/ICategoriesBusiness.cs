using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICategoriesBusiness
    {
        public Task<List<CategoriesGetDTO>> GetAllCategories();
        public Task<Category> GetCategoryById(int id);
        public Task<Category> CreateCategory(Category category);
        public Task<bool> RemoveCategory(int id);
        public Task<Category> UpdateCategory(int id, Category categoryDTO);
    }
}
