using APIFirst.DTOs.CategoryDtos;
using APIFirst.Entities;
using APIFirst.Repositories.Interfaces;
using APIFirst.Services.Interfaces;
using AutoMapper;
using System.Linq.Expressions;

namespace APIFirst.Services.Implimentations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IQueryable<Category>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            if (id <= 0) throw new Exception("not found");
            var category=await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not found");
            return category;
        }
        public async Task<Category> Create(CreateCategoryDto categoryDto)
        {
            if (categoryDto == null) throw new Exception("Not found");
            Category category = _mapper.Map<Category>(categoryDto);
            await _repository.Create(category);
            await _repository.SaveChangesAsync();
            return category;
        }
    }
}
