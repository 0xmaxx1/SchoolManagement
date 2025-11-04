using SchoolManagement.Domain.Localizations;

namespace SchoolManagement.Domain.Entities
{
    public class Students : LocalizableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? NameAr { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public int? DepartmentId { get; set; }
        public virtual Departments? Department { get; set; }
        //public virtual ICollection<Subjects>? Subjects { get; set; } = new HashSet<Subjects>();
    }
}

// Null 