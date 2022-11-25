using Anilibria.NET.Helpers;
using Anilibria.NET.Helpers.LogSystem;
using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json.Linq;

namespace Anilibria.NET.Client
{
    /// <summary>
    /// AnilibriaAPI client (User)
    /// </summary>
    public class AnilibriaClient : IDisposable
    {
        #region Client


        /// <summary>
        /// Http client which will get and post data
        /// </summary>
        private readonly HttpClient _httpClient;


        /// <summary>
        /// User login
        /// </summary>
        private readonly string _login;


        /// <summary>
        /// User password
        /// </summary>
        private readonly string _password;


        /// <summary>
        /// User token
        /// </summary>
        public string Token { get; private set; }


        /// <summary>
        /// Is user loggined
        /// </summary>
        public bool LoggedIn { get; private set; }

        #endregion


        /// <summary>
        /// Creation of AnilibriaAPI client
        /// </summary>
        /// <param name="login">User login (user name or email)</param>
        /// <param name="password">Password password</param>
        public AnilibriaClient(string login, string password)
        {
            _login = login;
            _password = password;

            _httpClient = new HttpClient();

            Token = "";

            LoggedIn = false;

            Logger.Log("Client Created!", LogType.AnilibriaClient, LogReasonContext.Info);
        }


        #region Methods


        /// <summary>
        /// Async loging in anilibria.tv
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AnilibriaInvalidUserException">Invalid user login or password</exception>
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
                    Logger.Log($"LoggedIn! User: {_login}", LogType.AnilibriaClient, LogReasonContext.Info);
                    LoggedIn = true;
                    Token = jObject["sessionId"]!.ToString();
                    Logger.Log($"Token Added! Token: {Token}", LogType.AnilibriaClient, LogReasonContext.Info);
                    break;
                case "authorized":
                    Logger.Log("ALREADY authorized!", LogType.AnilibriaClient, LogReasonContext.Warning);
                    return;
                case "invalidUser":
                    Logger.Log("Login ERROR! Invalid User!", LogType.AnilibriaClient, LogReasonContext.Error);
                    throw new AnilibriaInvalidUserException(_login, _password);
            }
        }


        /// <summary>
        /// Async loging outing anilibria.tv
        /// </summary>
        /// <returns></returns>
        public async Task LogoutAsync()
        {
            if (!LoggedIn)
            {
                Logger.Log("User didnt logged in yet!", LogType.AnilibriaClient, LogReasonContext.Warning);
                return;
            }

            Logger.Log($"Logging Out Process Started! User: {_login}", LogType.AnilibriaClient, LogReasonContext.Info);

            var uri = new Uri($"{Urls.SITE_ROOT_URL}/public/login.php");

            var values = new Dictionary<string, string>()
            {
                {"mail", _login },
                {"passwd", _password }
            };

            var content = new FormUrlEncodedContent(values);

            await _httpClient.PostAsync(uri, content);

            Token = "";

            Logger.Log($"Logged Out! User: {_login}", LogType.AnilibriaClient, LogReasonContext.Info);
        }


        /// <summary>
        /// Returns list of favorite titles of user
        /// </summary>
        /// <returns>List of favorite titles of user</returns>
        public async Task<Title[]> GetFavoriteTitles()
        {
            if(!LoggedIn)
            {
                Logger.Log("User didnt log in yet", LogType.AnilibriaClient, LogReasonContext.Error);
                return null;
            }

            Logger.Log($"Getting Favorite Titles.. User: {_login}", LogType.AnilibriaClient, LogReasonContext.Info);

            var titles =await Utilities.GetData<Title[]>(_httpClient, Urls.GetFavoriteTitles(Token).AbsoluteUri);

            string[] names = new string[titles.Length];

            foreach (var title in titles)
                Logger.Log($"Got Favorite Title from {_login}: {title.Name} | {title.Id}", LogType.AnilibriaClient, LogReasonContext.Info);


            return titles;
        }


        /// <summary>
        /// Adding title in favorites
        /// </summary>
        /// <param name="title">Title which will be added into the Favorite</param>
        /// <returns></returns>
        public async Task AddFavoriteAsync(Title title)
        {
            if (!LoggedIn)
            {
                Logger.Log($"Failed to add title in favorites! User {_login} didnt log in yet",
                           LogType.AnilibriaClient,
                           LogReasonContext.Error);
                return;
            }

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


        /// <summary>
        /// Deleting title from favorites
        /// </summary>
        /// <param name="title">Title to delete</param>
        /// <returns></returns>
        public async Task DeleteFavoriteAsync(Title title)
        {
            if (!LoggedIn)
            {
                Logger.Log($"Failed to delete title from favorites! User {_login} didnt log in yet",
                           LogType.AnilibriaClient,
                           LogReasonContext.Error);
                return;
            }

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


        /// <summary>
        /// Disposing of anilibria client
        /// </summary>
        public void Dispose()
        {
            Logger.Log("Http Client is Disposing!", LogType.AnilibriaClient, LogReasonContext.Warning);

            _httpClient.Dispose();

            Logger.Log("Http Client was Disposed!", LogType.AnilibriaClient, LogReasonContext.Warning);
        }

        #endregion

    }
}