using SchoolManagement.Domain.Localizations;

namespace SchoolManagement.Domain.Entities
{
    public class Subjects : LocalizableEntity
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameAr { get; set; }
        public int? Period { get; set; }
        public ICollection<Instructors> Instructors { get; set; } = new HashSet<Instructors>();
    }
}
