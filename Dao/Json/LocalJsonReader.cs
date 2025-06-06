using Dao.Api;
using Dao.Repo;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Dao.Json
{
    public class LocalJsonReader : IApi
    {
        private const string JsonBasePath = @"../../../assets/json";

        public async Task<T> GetDataAsync<T>(string endpoint)
        {
            string gender = new FileRepo().GetStoredGender(); // "male" or "female"
            string subfolder = gender;

            string fileName = GetFileNameFromEndpoint(endpoint);
            string fullPath = Path.Combine(JsonBasePath, subfolder, fileName);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"JSON file not found: {fullPath}");

            string content = await File.ReadAllTextAsync(fullPath);

            return JsonConvert.DeserializeObject<T>(content)
                   ?? throw new Exception("Deserialization failed.");
        }

        private string GetFileNameFromEndpoint(string endpoint)
        {
            if (endpoint.Contains("/matches/country"))
            {
                var code = endpoint.Split("fifa_code=").LastOrDefault()?.ToUpper() ?? "UNKNOWN";
                return $"country-matches_{code}.json";
            }
            if (endpoint.Contains("/matches"))
            {
                return "matches.json";
            }
            if (endpoint.Contains("/teams/results"))
            {
                return "results.json";
            }
            if (endpoint.Contains("/teams"))
            {
                return "teams.json";
            }

            throw new Exception("Unsupported endpoint for local JSON mapping.");
        }
    }
}
