using bt1.Data;
using bt1.Repository.IRepository;

namespace bt1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDBContext _dbContext;
        public ICategoriesRepository CategoriesRepository { get; private set; }
        public IProfilesRepository ProfilesRepository { get; private set; }
        public IJobsRepository JobsRepository { get; private set; }
        public IJobApplicationsRepository JobApplicationsRepository { get; private set; }
        public UnitOfWork(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            ProfilesRepository = new ProfilesRepository(_dbContext);
            JobsRepository = new JobsRepository(_dbContext);
            JobApplicationsRepository = new JobApplicationsRepository(_dbContext);
            CategoriesRepository = new CategoriesRepository(_dbContext);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
