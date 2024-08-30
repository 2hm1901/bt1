namespace bt1.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IJobApplicationsRepository JobApplicationsRepository { get; }
        IJobsRepository JobsRepository { get; }
        IProfilesRepository ProfilesRepository { get; }
        ICategoriesRepository CategoriesRepository { get; }
        void Save();
    }
}
