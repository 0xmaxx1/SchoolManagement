
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Bases.Abstract;

namespace SchoolManagement.Infrastructure.Contracts.Repositories
{
    public interface IStudentRepository : IGenericRepoAsync<Students>
    {
        // Add The Method In Student 
        public Task<IEnumerable<Students>> GetStudentsAsync();
    }
}
