using APIFirst.DAL;
using APIFirst.Entities;
using APIFirst.Repositories.Interfaces;

namespace APIFirst.Repositories.Implimentations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
