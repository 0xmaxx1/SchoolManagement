namespace SchoolManagement.Core.Features.Student.Queries.Results
{
    public class GetStudentPaginatedListResponse
    {
        public GetStudentPaginatedListResponse(int id, string name, string address, string departmentName)
        {
            Id = id;
            Name = name;
            Address = address;
            DepartmentName = departmentName;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string DepartmentName { get; set; } = string.Empty;
    }
}
