using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models.DTOs.CategoriesDTO;
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

        public async Task<List<GetNameCategoriesDTO>> GetAllCategories()
        {
            var categoriesDTO = new List<GetNameCategoriesDTO>();
            var categories = await _unitOfWork.CategoriesRepository.GetAll();

            foreach(var category in categories)
            {
                categoriesDTO.Add(new GetNameCategoriesDTO { Name = category.Name });
            }

            return categoriesDTO;
        }

        public async Task<GetCategoriesDTO> GetCategoryById(int id)
        {
            var Categorias = await _unitOfWork.CategoriesRepository.GetById(id);
            
            if(Categorias != null)
            {
                GetCategoriesDTO listaCategorias = new GetCategoriesDTO
                {
                    Name = Categorias.Name,
                    Image = Categorias.Image,
                    Description = Categorias.Description
                };
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
