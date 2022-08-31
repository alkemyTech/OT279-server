using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CategoriesBusiness : ICategoriesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public Task<Category> CreateCategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<CategoriesGetDTO>> GetAllCategories()
        {
            var categoriesDTO = new List<CategoriesGetDTO>();
            var categories = await _unitOfWork.CategoriesRepository.GetAll();

            foreach(var category in categories)
            {
                categoriesDTO.Add(new CategoriesGetDTO { Name = category.Name });
            }

            return categoriesDTO;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var listaCategorias = await _unitOfWork.CategoriesRepository.GetById(id);
            if(listaCategorias != null)
            {
                return listaCategorias;
            }
            return null;
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
