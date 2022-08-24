using OngProject.Core.Interfaces;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CategoriesBusiness : ICategoriesBusiness
    {
        public Task<Category> CreateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Category>> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> GetCategoryById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Category> UpdateCategory(int id, Category categoryDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
