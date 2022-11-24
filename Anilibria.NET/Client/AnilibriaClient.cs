using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Anilibria.NET.Models;
using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json.Linq;
using Anilibria.NET.Helpers;
using Anilibria.NET.Helpers.LogSystem;

namespace Anilibria.NET.Client
{
    /// <summary>
    /// AnilibriaAPI client
    /// </summary>
    public class AnilibriaClient : IDisposable
    {
        #region Client
        private readonly HttpClient _httpClient;

        private readonly string _login;

        private readonly string _password;

        private string _token;

        public string Token => _token;

        #endregion

        public AnilibriaClient(string login, string password)
        {
            _login = login;
            _password = password;

            _httpClient = new HttpClient();

            _token = "";

            Logger.Log("Client Created!", LogType.AnilibriaClient, LogReasonContext.Info);
        }

        public async Task LoginAsync()
        {
            Logger.Log($"Logging in.. (User: {_login} | Password : {_password})", LogType.AnilibriaClient, LogReasonContext.Info);

            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/login.php");

            var values = new Dictionary<string, string>()
            {
                {"mail", _login },
                {"passwd", _password }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await _httpClient.PostAsync(uri, content);

            var jObject = JObject.Parse(await response.Content.ReadAsStringAsync());

            string key = jObject["key"]!.ToString();

            switch (key)
            {
                case "success":
                    Logger.Log($"Loggined! User: {_login}", LogType.AnilibriaClient, LogReasonContext.Info);
                    _token = jObject["sessionId"]!.ToString();
                    Logger.Log($"Token Added! Token: {Token}", LogType.AnilibriaClient, LogReasonContext.Info);
                    break;
                case "authorized":
                    Logger.Log("ALREADY authorized!", LogType.AnilibriaClient, LogReasonContext.Warning);
                    return;
                case "invalidUser":
                    Logger.Log("Login ERROR! Invalid User!", LogType.AnilibriaClient, LogReasonContext.Error);
                    throw new Exception("Login error! Invalid User!");
            }
        }

        public async Task LogoutAsync()
        {
            Logger.Log($"Logging Out Process Started! User: {_login}", LogType.AnilibriaClient, LogReasonContext.Info);

            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/login.php");

            var values = new Dictionary<string, string>()
            {
                {"mail", _login },
                {"passwd", _password }
            };

            var content = new FormUrlEncodedContent(values);

            await _httpClient.PostAsync(uri, content);

            _token = "";

            Logger.Log($"Logged Out! User: {_login}", LogType.AnilibriaClient, LogReasonContext.Info);
        }

        public async Task<Title[]> GetFavoriteTitles()
        {
            Logger.Log($"Getting Favorite Titles.. User: {_login}", LogType.AnilibriaClient, LogReasonContext.Info);

            var titles =await Utilities.GetData<Title[]>(_httpClient, Urls.GetFavoriteTitles(_token).AbsoluteUri);

            string[] names = new string[titles.Length];

            foreach (var title in titles)
                Logger.Log($"Got Favorite Title from {_login}: {title.Name} | {title.Id}", LogType.AnilibriaClient, LogReasonContext.Info);


            return titles;
        }
        public async Task AddFavoriteAsync(Title title)
        {
            Logger.Log($"Starting adding to favorite {title.Code} | {title.Id}!", LogType.AnilibriaClient, LogReasonContext.Info);

            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/api/index.php");

            var values = new Dictionary<string, string>()
            {
                {"query", "favorites" },
                {"id", title.Id.ToString() },
                {"action", "add" },
            };

            var content = new FormUrlEncodedContent(values);

            await _httpClient.PostAsync(uri, content);

            Logger.Log($"Added to favorite {title.Code} | {title.Id}!", LogType.AnilibriaClient, LogReasonContext.Info);

        }

        public async Task DeleteFavoriteAsync(Title title)
        {
            Logger.Log($"Starting deleting from to favorite {title.Code} | {title.Id}!", LogType.AnilibriaClient, LogReasonContext.Info);

            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/api/index.php");

            var values = new Dictionary<string, string>()
            {
                {"query", "favorites" },
                {"id", title.Id.ToString() },
                {"action", "delete" },
            };

            var content = new FormUrlEncodedContent(values);

            await _httpClient.PostAsync(uri, content);

            Logger.Log($"Deleted from favorite {title.Code} | {title.Id}!", LogType.AnilibriaClient, LogReasonContext.Info);
        }

        public void Dispose()
        {
            Logger.Log("Http Client is Disposing!", LogType.AnilibriaClient, LogReasonContext.Warning);

            _httpClient.Dispose();

            Logger.Log("Http Client was Disposed!", LogType.AnilibriaClient, LogReasonContext.Warning);
        }
    }
}