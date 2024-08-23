using bt1.Data;
using bt1.Models;
using bt1.Repository.IRepository;
namespace bt1.Repository
{
    public class JobApplicationsRepository : Repository<JobApplications>, IJobApplicationsRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public JobApplicationsRepository(ApplicationDBContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
        public void Update(JobApplications jobApplications)
        {
            _dbContext.JobApplications.Update(jobApplications);
        }
    }
}
