using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Bases.Implementation;
using SchoolManagement.Infrastructure.Contracts.Repositories;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    internal class InstructorRepository : GenericRepoAsync<Instructors>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
