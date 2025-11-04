using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Services.Abstraction;
using SchoolManagement.Services.Implementation;

namespace SchoolManagement.Services
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IStudentService), typeof(StudentService));
            services.AddTransient(typeof(IDepartmentService), typeof(DepartmentService));

            return services;
        }
    }
}
