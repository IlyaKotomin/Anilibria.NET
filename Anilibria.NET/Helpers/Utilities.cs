using Anilibria.NET.Helpers.LogSystem;
using Newtonsoft.Json;

namespace Anilibria.NET.Helpers
{
    /// <summary>
    /// Utilities to deserialize JSONs to Anilibria.NET objects
    /// </summary>
    internal class Utilities
    {
        /// <summary>
        /// Helper to deserialize JSON object to C# object from API
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="httpClient">HttpClent which will receive json</param>
        /// <param name="rootUrl">Root url to API</param>
        /// <returns><see cref="object"/></returns>
        internal static async Task<TOutput> GetData<TOutput>(HttpClient httpClient, string rootUrl)
        {
            var json = await httpClient.GetStringAsync(rootUrl);

            var result = JsonConvert.DeserializeObject<TOutput>(json);

            Logger.Log($"Created Class {typeof(TOutput).Name}", LogType.JsonDeserializer, LogReasonContext.Info);

            return result;
        }


        /// <summary>
        /// Helper to deserialize JSON sub-object to C# object from API
        /// </summary>
        /// <typeparam name="TOutput">Output object like <see cref="Models.TitleModel.Title"/></typeparam>
        /// <param name="jsonObjectName"></param>
        /// <param name="rootUrl"></param>
        /// <param name="httpClient"></param>
        /// <returns><see cref="object"/></returns>
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
