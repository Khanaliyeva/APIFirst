using APIFirst.DAL;
using APIFirst.DTOs.CategoryDtos;
using APIFirst.Entities;
using APIFirst.Repositories.Interfaces;
using APIFirst.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        private readonly ICategoryService _service;

        public CategoriesController( ICategoryRepository repository, ICategoryService service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _service.GetByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, category);
        }

        [HttpPost]
        public async Task<IActionResult> CreatAsync([FromForm] CreateCategoryDto categoryDto)
        {
            var category = await _service.Create(categoryDto);
            return StatusCode(StatusCodes.Status201Created,category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, string Name)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            var category= await _repository.GetByIdAsync(id);
            if(category==null) return StatusCode(StatusCodes.Status404NotFound);
            category.Name = Name;
            _repository.Update(category);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK,category);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(id<=0) return StatusCode(StatusCodes.Status400BadRequest);
            var category=await _repository.GetByIdAsync(id);
            if(category==null) return StatusCode(StatusCodes.Status404NotFound);
            _repository.Delete(category);
            await _repository.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, category);
        }
    }
}
