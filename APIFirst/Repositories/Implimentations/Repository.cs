using APIFirst.DAL;
using APIFirst.Entities;
using APIFirst.Entities.Base;
using APIFirst.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace APIFirst.Repositories.Implimentations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    { 
        private readonly AppDbContext _context;
        private DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table=_context.Set<T>();
        }

        public async Task<IQueryable<T>> 
            GetAllAsync(Expression<Func<T, bool>>?
            expression=null,
            Expression <Func<T,object>>? 
            orderByExpression=null,
            bool isDescending=false,
            params string[] includes)
        {
            IQueryable<T> query = _table;
            if(orderByExpression!= null)
            {
                query = isDescending ? 
                    query.OrderByDescending(orderByExpression)
                    : query.OrderBy(orderByExpression);
            }
            if(expression is not null)
            {
                query = query.Where(expression);
            }
            if(includes is not null)
            {
                for(int i=0;i<includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            
            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Update(T entity)
        {
            _table.Update(entity);
        }

        public async Task Create(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
