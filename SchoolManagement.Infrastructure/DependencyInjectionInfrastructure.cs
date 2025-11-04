using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Infrastructure.Bases.Abstract;
using SchoolManagement.Infrastructure.Bases.Implementation;
using SchoolManagement.Infrastructure.Contracts.Repositories;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {

        public static IServiceCollection AddDependenciesToContainer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection"));
            });


            services.AddTransient(typeof(IGenericRepoAsync<>), typeof(GenericRepoAsync<>));
            services.AddTransient(typeof(IStudentRepository), typeof(StudentRepository));
            services.AddTransient(typeof(IDepartmentRepository), typeof(DepartmentRepository));
            services.AddTransient(typeof(ISubjectRepository), typeof(SubjectRepository));
            services.AddTransient(typeof(IInstructorRepository), typeof(InstructorRepository));



            return services;


        }


    }
}
