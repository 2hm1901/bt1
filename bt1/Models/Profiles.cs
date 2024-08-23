
using Microsoft.AspNetCore.Identity;
namespace bt1.Models

{
    public class Profiles : IdentityUser
    {
        public string Name { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? phone { get; set; }
        public string? resume { get; set; }
    }
}
