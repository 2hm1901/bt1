using bt1.Data;
using bt1.Models;
using bt1.Repository.IRepository;

namespace bt1.Repository
{
    public class ProfilesRepository : Repository<Profiles>, IProfilesRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ProfilesRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Profiles profiles)
        {
            _dbContext.Profiles.Update(profiles);
        }
    }
}
