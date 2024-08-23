using bt1.Models;

namespace bt1.Repository.IRepository
{
        public interface IProfilesRepository : IRepository<Profiles>
        {
            void Update(Profiles profiles);
        }
}
