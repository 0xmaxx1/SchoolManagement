using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Data.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Departments>
    {
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            builder.HasMany(d => d.Students)
                 .WithOne(s => s.Department)
                 .HasForeignKey(s => s.DepartmentId);

            builder.HasMany(d => d.Subjects)
                .WithMany();



        }
    }
}
