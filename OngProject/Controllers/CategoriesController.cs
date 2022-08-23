﻿using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        private readonly ICategoriesService _service;
        public CategoriesController(ICategoriesService service)
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
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDTO categoryDTO)
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

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory([FromQuery(Name = "id")] int id)
        {

            bool category = await _service.RemoveCategory(id);

            if (category)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromQuery(Name = "id")] int id, [FromBody] CategoryDTO categoryDTO)
        {
            var category = await _service.UpdateCategory(id, categoryDTO);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound(400);
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