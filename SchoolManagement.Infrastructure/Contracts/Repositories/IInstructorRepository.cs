using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Bases.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Contracts.Repositories
{
    public interface IInstructorRepository : IGenericRepoAsync<Instructors>
    {
    }
}
