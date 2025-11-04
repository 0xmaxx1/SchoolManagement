using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Bases.Implementation;
using SchoolManagement.Infrastructure.Contracts.Repositories;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepoAsync<Departments>, IDepartmentRepository
    {

        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
