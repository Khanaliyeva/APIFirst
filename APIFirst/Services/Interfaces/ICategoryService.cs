using APIFirst.DTOs.CategoryDtos;
using APIFirst.Entities;

namespace APIFirst.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IQueryable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> Create(CreateCategoryDto categoryDto);
    }
}
