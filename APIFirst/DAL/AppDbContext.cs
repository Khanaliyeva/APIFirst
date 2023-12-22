using APIFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIFirst.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        public DbSet<Category> Categories { get; set; }
    }
}
