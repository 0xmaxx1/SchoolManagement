using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Entities.Identity;

namespace SchoolManagement.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserApplication, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInformation).Assembly);

        }

        #region Identity

        public DbSet<UserApplication> Users { get; set; }


        #endregion


        public DbSet<Departments> Departments { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        //public DbSet<DepartmentsSubjects> DepartmentsSubjects { get; set; }
        //public DbSet<StudentsSubjects> StudentsSubjects { get; set; }




    }
}
