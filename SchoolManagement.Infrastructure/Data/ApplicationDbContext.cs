using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);

        }

        public DbSet<Departments> Departments { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        //public DbSet<DepartmentsSubjects> DepartmentsSubjects { get; set; }
        //public DbSet<StudentsSubjects> StudentsSubjects { get; set; }




    }
}
