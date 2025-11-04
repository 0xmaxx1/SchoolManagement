using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Bases.Implementation;
using SchoolManagement.Infrastructure.Contracts.Repositories;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepoAsync<Students>, IStudentRepository
    {
        private readonly DbSet<Students> _students;

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Students>();
        }
        public async Task<IEnumerable<Students>> GetStudentsAsync()
        {
            return await _students.Include(s => s.Department).ToListAsync();
        }
    }
}
