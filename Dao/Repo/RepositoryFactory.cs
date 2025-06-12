namespace Dao.Repo
{
    public static class RepositoryFactory
    {
        public static IRepository GetRepository() => new FileRepo();
    }
}
