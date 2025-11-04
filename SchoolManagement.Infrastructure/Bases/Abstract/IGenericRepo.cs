using Microsoft.EntityFrameworkCore.Storage;

namespace SchoolManagement.Infrastructure.Bases.Abstract
{
    public interface IGenericRepoAsync<T>
        where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        Task<T?> GetByIdAsync(int id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(ICollection<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}
