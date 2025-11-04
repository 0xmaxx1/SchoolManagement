using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Bases.Implementation;
using SchoolManagement.Infrastructure.Contracts.Repositories;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class SubjectRepository : GenericRepoAsync<Subjects>, ISubjectRepository
    {
        public SubjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
