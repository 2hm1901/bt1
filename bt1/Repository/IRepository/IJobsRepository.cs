using bt1.Models;

namespace bt1.Repository.IRepository
{
        public interface IJobsRepository : IRepository<Jobs>
        {
            void Update(Jobs jobs);
        }
}
