using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Data.Configurations
{
    public class StudentsSubjectsConfigurations : IEntityTypeConfiguration<StudentsSubjects>
    {
        public void Configure(EntityTypeBuilder<StudentsSubjects> builder)
        {

            builder.HasKey(k => new { k.StudentId, k.SubjectId });

            builder.HasOne(ss => ss.Students)
                .WithMany()
                .HasForeignKey(ss => ss.StudentId)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);



            builder.HasOne(ss => ss.Subjects)
                .WithMany()
                .HasForeignKey(ss => ss.SubjectId)
                 .OnDelete(deleteBehavior: DeleteBehavior.Restrict);




        }
    }
}
