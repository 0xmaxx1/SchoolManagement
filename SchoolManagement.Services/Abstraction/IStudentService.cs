using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Helpers.Enums;

namespace SchoolManagement.Services.Abstraction
{
    public interface IStudentService
    {
        public Task<IEnumerable<Students>> GetAllStudentsAsync();
        public Task<Students?> GetStudentsByIdWithIncludeAsync(int id);
        public Task<Students?> GetByIdAsync(int id);
        public Task<string> AddStudentAsync(Students student);
        public Task<string> UpdateStudentAsync(Students student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
        public Task<bool> DeleteAsync(Students students);
        public IQueryable<Students> GetStudentsQueryable();
        public IQueryable<Students> FilterStudedntsPaginatedQueryable(StudentOrderingEnum orderBy, string? searchTerm);

        public IQueryable<Students> GetStudentsByDepartmentIdQuerable(int id);


    }
}
