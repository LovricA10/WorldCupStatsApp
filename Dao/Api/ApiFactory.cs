using Dao.Json;
using Dao.Repo;

namespace Dao.Api
{
    public static class ApiFactory
    {
        public static IApi GetApi()
        {
            var repo = new FileRepo();
            string source = repo.GetDataSource();

            return source == "JSON" ? new LocalJsonReader() : new JsonApi();
        }
    }
}
