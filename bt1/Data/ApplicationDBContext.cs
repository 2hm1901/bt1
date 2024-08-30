using bt1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bt1.Data
{
    public class ApplicationDBContext: IdentityDbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobApplications> JobApplications { get; set; }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categories>().HasData(
                new Categories { Id = 1, Name = "Education Training", Status = "Active" },
                new Categories { Id = 2, Name = "Design, Art & Multimedia", Status = "Active" },
                new Categories { Id = 3, Name = "Accounting / Finance", Status = "Active" },
                new Categories { Id = 4, Name = "Human Resource", Status = "Active" },
                new Categories { Id = 5, Name = "Telecommuncations", Status = "Active" }
                );
        }
    }
}
