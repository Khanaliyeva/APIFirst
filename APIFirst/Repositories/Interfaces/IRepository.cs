using APIFirst.Entities;
using APIFirst.Entities.Base;
using System.Linq.Expressions;

namespace APIFirst.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>?
            expression = null,
            Expression<Func<T, object>>?
            orderByExpression = null,
            bool isDescending = false,
            params string[] includes);
        Task<T> GetByIdAsync(int id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChangesAsync();
    }
}
