using SchoolManagement.Domain.Localizations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Domain.Entities
{
    public class Departments : LocalizableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameAr { get; set; } = null!;
        public virtual ICollection<Instructors> Instructors { get; set; }
        public virtual ICollection<Students> Students { get; set; }
        public virtual ICollection<Subjects> Subjects { get; set; }
        public int? InsManagerId { get; set; }
        [ForeignKey(nameof(InsManagerId))]
        public virtual Instructors? Instructor { get; set; }
    }
}