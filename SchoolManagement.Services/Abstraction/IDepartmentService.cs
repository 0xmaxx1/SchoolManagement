using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Services.Abstraction
{
    public interface IDepartmentService
    {
        public Task<Departments?> GetDepartmentById(int id);



    }
}
