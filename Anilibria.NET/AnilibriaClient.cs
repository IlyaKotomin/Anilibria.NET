using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Anilibria.NET.Models;
using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Anilibria.NET
{
    /// <summary>
    /// Anilibria client
    /// </summary>
    public class AnilibriaClient : IDisposable
    {
        #region Client

        /// <summary>
        /// Http AnilibriaClient
        /// Use it to send GET methods
        /// </summary>
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

            _token = 1234123412341234.ToString();
        }

        public async void Login()
        {
            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/login.php");

            var values = new Dictionary<string, string>()
            {
                {"mail", _login },
                {"passwd", _password }
            };

            var content = new FormUrlEncodedContent(values);
            var cookieJar = new CookieContainer();
            var handler = new HttpClientHandler
            {
                CookieContainer = cookieJar,
                UseCookies = true,
                UseDefaultCredentials = false
            };

            var client = new HttpClient(handler);

            var response = await _httpClient.PostAsync(uri, content);

            response.EnsureSuccessStatusCode();

            var responseCookies = cookieJar.GetCookies(uri);

            foreach (Cookie cookie in responseCookies)
            {
                string cookieName = cookie.Name;
                string cookieValue = cookie.Value;

                Console.WriteLine(cookieName);
                Console.WriteLine(cookieValue);

            }
            //_token = "PRGcION85n9DMDMIafnI4rVaboO5Lcn7";

        }

        public async void Logout()
        {
            var values = new Dictionary<string, string>()
            {
            };

            var content = new FormUrlEncodedContent(values);

            var response = await _httpClient.PostAsync($"{Urls.SITE_ROOT_URL}/public/logout.php", content);
        }

        public void Dispose() => _httpClient.Dispose();
    }
}