
using Microsoft.AspNetCore.Identity;

namespace SchoolManagement.Domain.Entities.Identity
{
    public class UserApplication : IdentityUser<int>
    {
        public string FullName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Country { get; set; }
    }
}
