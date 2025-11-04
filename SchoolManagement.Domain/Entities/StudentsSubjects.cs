namespace SchoolManagement.Domain.Entities
{
    public class StudentsSubjects
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public decimal grade { get; set; }

        public virtual Students Students { get; set; } = null!;
        public virtual Subjects Subjects { get; set; } = null!;


    }
}
