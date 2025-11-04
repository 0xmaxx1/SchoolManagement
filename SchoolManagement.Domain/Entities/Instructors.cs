using SchoolManagement.Domain.Localizations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Domain.Entities
{
    public class Instructors : LocalizableEntity
    {
        public int Id { get; set; }
        public string ENameEn { get; set; } = string.Empty;
        public string? ENameAr { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Departments.Instructors))]
        public Departments Department { get; set; }
        public int SupervisorId { get; set; }
        [ForeignKey(nameof(SupervisorId))]
        //[InverseProperty(nameof(Subjects.Instructors))]
        public virtual ICollection<Subjects> Subjects { get; set; } = new HashSet<Subjects>();

    }
}