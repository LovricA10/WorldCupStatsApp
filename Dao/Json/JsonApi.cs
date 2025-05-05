using Dao.Api;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using Dao.Models;

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
            Debug.WriteLine("RAW JSON content from API:");
            Debug.WriteLine(response.Content);

            try
            {
                T? data = JsonConvert.DeserializeObject<T>(response.Content); // check if is null 
                return data ?? throw new Exception("Deserialization returned null");
            }
            catch (JsonSerializationException jsex)
            {
                Debug.WriteLine("Deserialization failed:");
                Debug.WriteLine(jsex.Message);
                Debug.WriteLine(jsex.StackTrace);
                throw;
            }

            //if (data == null)
            //{
            //    throw new Exception("Deserilization returned null");
            //}


            //return data ?? throw new Exception("Deserilization returned null");
        }
    }
}
