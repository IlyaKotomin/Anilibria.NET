using Newtonsoft.Json;

namespace Anilibria.NET
{
    public class Utilities
    {
        public static async Task<TOutput> GetData<TOutput>(HttpClient httpClient, string rootUrl)
        {
            var json = await httpClient.GetStringAsync(rootUrl);
            return JsonConvert.DeserializeObject<TOutput>(json);
        }
    }
}
