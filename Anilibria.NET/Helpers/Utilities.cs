using Anilibria.NET.Helpers.LogSystem;
using Newtonsoft.Json;
using System.Net.Http;

namespace Anilibria.NET.Helpers
{
    internal class Utilities
    {
        internal static async Task<TOutput> GetData<TOutput>(HttpClient httpClient, string rootUrl)
        {
            var json = await httpClient.GetStringAsync(rootUrl);

            var result = JsonConvert.DeserializeObject<TOutput>(json);

            Logger.Log($"Created Class {typeof(TOutput).Name}", LogType.JsonDeserializer, LogReasonContext.Info);

            return result;
        }

        internal static async Task<TOutput> GetSubClassData<TOutput>(string jsonObjectName, string rootUrl, HttpClient httpClient)
        {
            var json = await httpClient.GetStringAsync(rootUrl);

            json = json.Remove(0, 4 + jsonObjectName.Length); //removing first simbols: {"jsonObjectName":
            json = json[..^1]; //removeing last simbol: }

            var result = JsonConvert.DeserializeObject<TOutput>(json);

            Logger.Log($"Created SubClass {typeof(TOutput).Name}", LogType.JsonDeserializer, LogReasonContext.Info);

            return result;
        }
    }
}
