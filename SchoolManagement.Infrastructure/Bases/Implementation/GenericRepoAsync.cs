using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolManagement.Infrastructure.Bases.Abstract;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Bases.Implementation
{
    public class GenericRepoAsync<T> : IGenericRepoAsync<T>
        where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepoAsync(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }


        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }


        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<T> entities)
        {

            _dbContext.Set<T>().RemoveRange(entities);
            await _dbContext.SaveChangesAsync();

        }


        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();

        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }






        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }



        public async Task UpdateRangeAsync(ICollection<T> entities)
        {

            _dbContext.Set<T>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetTableNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _dbContext.Set<T>();
        }
    }
}
