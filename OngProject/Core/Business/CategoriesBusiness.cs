using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models.DTOs.CategoriesDTO;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CategoriesBusiness : ICategoriesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAmazonS3Client _amazonClient;

        public CategoriesBusiness(IUnitOfWork unitOfWork, IAmazonS3Client amazonClient)
        {
            this._unitOfWork = unitOfWork;
            _amazonClient = amazonClient;
        }
        public async Task<GetCategoriesDTO> CreateCategory(CreateCategoriesDTO categoryDTO)
        {
            var mapper = new CategoriesMapper();
            var category = mapper.CreateCategoryByDTO(categoryDTO);

            if(categoryDTO.Image != null)
            {
                category.Image = await _amazonClient.UploadObject(categoryDTO.Image);
            }
            else
            {
                category.Image = null;
            }
            

            await _unitOfWork.CategoriesRepository.Insert(category);
            _unitOfWork.SaveChanges();

            var dto = mapper.GetCategories(category);
            return dto;

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

        public async Task<bool> RemoveCategory(int id)
        {
            var existing = await _unitOfWork.CategoriesRepository.GetById(id);

            if (existing == null)
                throw new Exception("Category not found.");

            await _unitOfWork.CategoriesRepository.Delete(existing);
            _unitOfWork.SaveChanges();

            return true;
        }

        public Task<Category> UpdateCategory(int id, Category categoryDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
