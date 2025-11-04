using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Helpers.Enums;
using SchoolManagement.Infrastructure.Contracts.Repositories;
using SchoolManagement.Services.Abstraction;
using System.Linq.Expressions;

namespace SchoolManagement.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }


        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetStudentsAsync();
        }

        public Task<Students?> GetStudentsByIdWithIncludeAsync(int id)
        {
            // logic 
            var student = _studentRepository.GetTableNoTracking()
                .Where(s => s.Id == id)
                .Include(s => s.Department)
                .FirstOrDefaultAsync();

            return student;

        }


        public async Task<string> AddStudentAsync(Students student)
        {
            var studentResult = _studentRepository.GetTableNoTracking()
                 .Where(s => s.Name.Equals(student.Name));

            await _studentRepository.AddAsync(student);
            return "Success";
        }
        public async Task<bool> IsNameExist(string name)
        {
            var isNameExist = await _studentRepository.GetTableNoTracking()
                .Where(s => s.Name.Equals(name)).AnyAsync();

            return isNameExist;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            var isNameExist = await _studentRepository.GetTableNoTracking()
                .Where(s => s.Name.Equals(name) && !s.Id.Equals(id)).AnyAsync();

            return isNameExist;
        }

        public async Task<string> UpdateStudentAsync(Students student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<bool> DeleteAsync(Students students)
        {
            var trans = _studentRepository.BeginTransaction();


            try
            {
                await _studentRepository.DeleteAsync(students);
                await trans.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return false;
            }

        }

        public Task<Students?> GetByIdAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                 .Where(s => s.Id == id)
                 .FirstOrDefaultAsync();

            return student;
        }

        public IQueryable<Students> GetStudentsQueryable()
        {

            return _studentRepository.GetTableNoTracking().Include(p => p.Department).AsQueryable();
        }

        public IQueryable<Students> FilterStudedntsPaginatedQueryable(StudentOrderingEnum orderBy, string? searchTerm)
        {
            var queryable = _studentRepository.GetTableNoTracking().Include(p => p.Department).AsQueryable();

            if (searchTerm is not null)
            {
                queryable = queryable.Where(

                     x => x.Name.ToUpper().Contains(searchTerm.ToUpper())
                     ||
                     x.Address.ToUpper().Contains(searchTerm.ToUpper()));
            }

            #region Trush Switch

            //switch (orderBy)
            //{
            //    case StudentOrderingEnum.NameAsc:
            //        queryable.OrderBy(x => x.Name); break;

            //    case StudentOrderingEnum.NameDesc:
            //        queryable.OrderByDescending(x => x.Name); break;

            //    case StudentOrderingEnum.AddressAsc:
            //        queryable.OrderBy(x => x.Address); break;

            //    case StudentOrderingEnum.AddressDesc:
            //        queryable.OrderByDescending(x => x.Address); break;

            //    case StudentOrderingEnum.StudIdAsc:
            //        queryable.OrderBy(x => x.Id); break;

            //    case StudentOrderingEnum.StudIdDesc:
            //        queryable.OrderByDescending(x => x.Id); break;

            //    case StudentOrderingEnum.DepartmentNameAsc:
            //        queryable.OrderBy(x => x.Department.Name); break;

            //    case StudentOrderingEnum.DepartmentNameDesc:
            //        queryable.OrderByDescending(x => x.Department.Name); break;
            //}

            //return queryable; 
            #endregion

            var orderSelectors = new Dictionary<StudentOrderingEnum, Expression<Func<Students, object>>>()
             {
               { StudentOrderingEnum.NameAsc, x => x.Name },
               { StudentOrderingEnum.NameDesc, x => x.Name },
               { StudentOrderingEnum.AddressAsc, x => x.Address },
               { StudentOrderingEnum.AddressDesc, x => x.Address },
               { StudentOrderingEnum.StudIdAsc, x => x.Id },
               { StudentOrderingEnum.StudIdDesc, x => x.Id },
               { StudentOrderingEnum.DepartmentNameAsc, x => x.Department.Name },
               { StudentOrderingEnum.DepartmentNameDesc, x => x.Department.Name },
             };

            if (orderSelectors.TryGetValue(orderBy, out var selector))
            {

                if (orderBy.ToString().EndsWith("Desc"))
                {
                    queryable = queryable.OrderByDescending(selector);
                }
                else
                {
                    queryable = queryable.OrderBy(selector);
                }

            }

            return queryable;

        }

        public IQueryable<Students> GetStudentsByDepartmentIdQuerable(int id)
        {

            var students = _studentRepository.GetTableNoTracking()
                   .Where(x => x.Id.Equals(id)).AsQueryable();
            return students;

        }
    }
}
