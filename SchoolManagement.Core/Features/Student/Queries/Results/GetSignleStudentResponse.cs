namespace SchoolManagement.Core.Features.Student.Queries.Results
{
    public class GetSignleStudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string DepartmentName { get; set; } = string.Empty;
    }
}
