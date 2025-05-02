using Dao.Json;

namespace Dao.Api
{
    public static class ApiFactory
    {
        public static IApi GetApi() => new JsonApi();
    }
}
