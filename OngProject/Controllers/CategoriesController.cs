using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.CategoriesDTO;
using OngProject.Entities;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        private readonly ICategoriesBusiness _service;
        public CategoriesController(ICategoriesBusiness service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {

            var categories = await _service.GetAllCategories();

            if (categories != null)
            {
                return Ok(categories);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromQuery] CreateCategoriesDTO categoryDTO)
        {

            var category = await _service.CreateCategory(categoryDTO);

            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            try
            {
                bool category = await _service.RemoveCategory(id);
                return Ok();
            }
            catch (System.Exception err)
            {
                return NotFound(err.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromForm] CategoryUpdateDto categoryDTO)
        {
            try
            {
                var category = await _service.UpdateCategory(id, categoryDTO);
                return Ok(category);
            }
            catch (Exception er)
            {
                if (er.Message.Contains("Not Found"))
                    return NotFound(er.Message);

                return BadRequest(er.Message);
            }

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetCategoryById([FromQuery(Name = "id")] int id)
        {

            var category = await _service.GetCategoryById(id);

            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
