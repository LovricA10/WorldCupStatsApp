using Dao.Api;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Dao.Json
{
    public class JsonApi : IApi
    {
        public async Task<T> GetDataAsync<T>(string endpoint)
        {
            var client = new RestClient();
            var request = new RestRequest(endpoint);
            var response = await client.ExecuteAsync(request);

            if (string.IsNullOrWhiteSpace(response.Content))
            {
                throw new Exception("Api returned empty content");
            }

            T? data = JsonConvert.DeserializeObject<T>(response.Content); // check if is null 

            //if (data == null)
            //{
            //    throw new Exception("Deserilization returned null");
            //}


            return data ?? throw new Exception("Deserilization returned null");
        }
    }
}
