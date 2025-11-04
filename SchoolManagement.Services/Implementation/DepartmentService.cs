using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Infrastructure.Contracts.Repositories;
using SchoolManagement.Services.Abstraction;

namespace SchoolManagement.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }


        public async Task<Departments?> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                .Where(x => x.Id.Equals(id))
               .Include(d => d.Instructors)
               //.Include(d => d.Students)
               .Include(d => d.Subjects)
               .Include(d => d.Instructor)
               .AsQueryable().FirstOrDefaultAsync();


            return department;




        }

        public async Task<bool> IsDepartmentIdExist(int id)
        {
            var isDepartmentExist = await _departmentRepository.GetTableNoTracking()
                .Where(e => e.Id.Equals(id)).AnyAsync();

            return isDepartmentExist;

        }
    }
}
