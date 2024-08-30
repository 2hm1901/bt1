using bt1.Models;

namespace bt1.Repository.IRepository
{
    public interface ICategoriesRepository : IRepository<Categories>
    {
        void Update(Categories entity);
    }
}
