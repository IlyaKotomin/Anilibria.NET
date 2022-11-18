using Newtonsoft.Json;
using System.Net.Http;

namespace Anilibria.NET
{
    internal class Utilities
    {
        internal static async Task<TOutput> GetData<TOutput>(HttpClient httpClient, string rootUrl)
        {
            var json = await httpClient.GetStringAsync(rootUrl);

            if (json == "[]")
                throw new Exception("NO DATA HERE");

            return JsonConvert.DeserializeObject<TOutput>(json);
        }

        internal static async Task<TOutput> GetSubClassData<TOutput>(string jsonObjectName, string rootUrl, HttpClient httpClient)
        {
            var json = await httpClient.GetStringAsync(rootUrl);

            json = json.Remove(0, 4 + jsonObjectName.Length); //removing first simbols: {"jsonObjectName":
            json = json[..^1]; //removeing last simbol: }

            return JsonConvert.DeserializeObject<TOutput>(json);
        }
    }
}
