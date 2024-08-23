using bt1.Models;

namespace bt1.Repository.IRepository
{
        public interface IJobApplicationsRepository : IRepository<JobApplications>
        {
            void Update(JobApplications jobApplications);
        }
}
