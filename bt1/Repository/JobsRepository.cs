using bt1.Data;
using bt1.Models;
using bt1.Repository.IRepository;

namespace bt1.Repository
{
    public class JobsRepository : Repository<Jobs>, IJobsRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public JobsRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Jobs jobs)
        {
            _dbContext.Jobs.Update(jobs);
        }
    }
}
