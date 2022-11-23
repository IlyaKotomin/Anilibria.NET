using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Anilibria.NET.Models;
using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json.Linq;
using System.Net;
using static System.Collections.Specialized.BitVector32;

namespace Anilibria.NET
{
    /// <summary>
    /// Anilibria client
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
        }

        public async Task LoginAsync()
        {
            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/login.php");

            var values = new Dictionary<string, string>()
            {
                {"mail", _login },
                {"passwd", _password }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await _httpClient.PostAsync(uri, content);

            string json = await response.Content.ReadAsStringAsync();

            var jObject = JObject.Parse(json);

            string key = jObject["key"]!.ToString();

            if (key == "success")
            {
                _token = jObject["sessionId"]!.ToString();
            }
            else if (key == "authorized")
            {
                return;
            }
            else if (key == "invalidUser")
            {
                throw new Exception("Login error! Invalid User!");
            }
        }

        public async Task LogoutAsync()
        {
            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/login.php");

            var values = new Dictionary<string, string>()
            {
                {"mail", _login },
                {"passwd", _password }
            };

            var content = new FormUrlEncodedContent(values);

            await _httpClient.PostAsync(uri, content);

            _token = "";
        }

        public async Task<Title[]> GetFavoriteTitles() =>
            await Utilities.GetData<Title[]>(_httpClient, Urls.GetFavoriteTitles(_token).AbsoluteUri);

        public async Task DeleteFavoriteAsync(Title title)
        {
            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/api/index.php");

            var values = new Dictionary<string, string>()
            {
                {"query", "favorites" },
                {"id", title.Id.ToString() },
                {"action", "delete" },
            };

            var content = new FormUrlEncodedContent(values);

            await _httpClient.PostAsync(uri, content);
        }

        public async Task AddFavoriteAsync(Title title)
        {
            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/api/index.php");

            var values = new Dictionary<string, string>()
            {
                {"query", "favorites" },
                {"id", title.Id.ToString() },
                {"action", "add" },
            };

            var content = new FormUrlEncodedContent(values);

            await _httpClient.PostAsync(uri, content);
        }

        public void Dispose() => _httpClient.Dispose();
    }
}