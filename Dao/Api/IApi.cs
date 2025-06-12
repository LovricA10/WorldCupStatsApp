namespace Dao.Api
{
    public interface IApi
    {
        public  Task<T> GetDataAsync<T>(string endpoint);
    }
}
