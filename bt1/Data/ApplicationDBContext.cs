using bt1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bt1.Data
{
    public class ApplicationDBContext: IdentityDbContext
    {
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobApplications> JobApplications { get; set; }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
