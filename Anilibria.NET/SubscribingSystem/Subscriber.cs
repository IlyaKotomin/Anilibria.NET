using Anilibria.NET.Helpers.LogSystem;
using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocket4Net;

namespace Anilibria.NET.SubscribingSystem
{
    /// <summary>
    /// This class is needed in order to subscribe to titles
    /// </summary>
    public class Subscriber
    {
        /// <summary>
        /// Websocket that receives titles and subscribes to them
        /// </summary>
        private WebSocket _webSocket;



        /// <summary>
        /// Title get handler 
        /// </summary>
        /// <param name="sender">The object that was notified when updating the title subscription</param>
        /// <param name="e">Arguments received during notification</param>
        public delegate void TitleRecievedEventHandler(object sender, TitleRecievedEventArgs e);



        /// <summary>
        /// An event that is called when a title update is received
        /// </summary>
        public event TitleRecievedEventHandler? OnTitleRecieved;



        /// <summary>
        /// Titles to which the client is subscribed
        /// </summary>
        public List<Title> SubscribedTitles { get; private set; }



        /// <summary>
        /// Genres to which the client is subscribed
        /// </summary>
        public List<string> SubscribedGenres { get; private set; }



        /// <summary>
        /// This class is needed in order to subscribe to titles
        /// </summary>
        public Subscriber()
        {
            _webSocket = new("ws://api.anilibria.tv/v2/ws/");

            _webSocket.MessageReceived += OnMessageReceived;

            SubscribedTitles = new();
            SubscribedGenres = new();

            Logger.Log("Subscriber Created!", LogType.Subscriber, LogReasonContext.Info);
        }



        /// <summary>
        /// Title subscription
        /// </summary>
        /// <param name="title">The title to which the subscription will be made</param>
        public async void SubscribeOnTitle(Title title)
        {
            Logger.Log($"Starting subscribe process (Title: {title.Code} | {title.Id})", LogType.Subscriber, LogReasonContext.Info);

            await _webSocket.OpenAsync();

            string message = @"{
	                                ""subscribe"": {
		                                            ""id"": 9999
	                                },
	                                ""remove"": ""player,torrents,posters""
                                }";

            message = message.Replace("9999", title.Id.ToString());

            _webSocket.Send(message);

            SubscribedTitles.Add(title);
        }



        /// <summary>
        /// Subscription on titles with specific genres
        /// </summary>
        /// <param name="genres">The title to which the subscription will be made</param>
        public async void SubscribeOnGenres(string[] genres)
        {
            Logger.Log($"Starting subscribe process (Titles by genres: {string.Join(", ", genres)})", LogType.Subscriber, LogReasonContext.Info);

            await _webSocket.OpenAsync();

            string message = @"{
	                                ""subscribe"": {
		                                            ""genres"": ""9999""
	                                },
	                                ""remove"": ""player,torrents,posters""
                                }";

            message = message.Replace("9999", string.Join(',', genres));

            _webSocket.Send(message);

            SubscribedGenres.AddRange(genres);
        }



        /// <summary>
        /// Titles subscription
        /// </summary>
        /// <param name="titles">The titles to which the subscription will be made</param>
        public void SubscribeOnTitiles(Title[] titles)
        {
            int[] ids = new int[titles.Length];

            for(int i = 0; i < ids.Length; i++)
                ids[i] = titles[i].Id;

            Logger.Log($"Starting subscribe process (Titles: {string.Join(", ", ids)})", LogType.Subscriber, LogReasonContext.Info);

            foreach (var title in titles)
                SubscribeOnTitle(title);
        }



        /// <summary>
        /// Subscription on new titles for this year
        /// </summary>
        public async void SubscribeOnNew()
        {
            Logger.Log($"Starting subscribe process (New Titles)", LogType.Subscriber, LogReasonContext.Info);

            await _webSocket.OpenAsync();

            string message = @"{
	                                ""subscribe"": {
		                                            ""season"": {
                                                                ""year"": 9999
                                                    }
	                                },
	                                ""remove"": ""player,torrents,posters""
                                }";

            message = message.Replace("9999", DateTime.Now.Year.ToString());

            _webSocket.Send(message);
        }



        /// <summary>
        /// Event handler called when a message is received from the websocket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void OnMessageReceived(object? sender, MessageReceivedEventArgs e)
        {
            if (e.Message.Contains("\"connection\":"))
            {
                Logger.Log($"Connected to server!)", LogType.Subscriber, LogReasonContext.Info);
                return;
            }

            if (e.Message.Contains("\"subscribe\":"))
            {
                Logger.Log($"Subscribed to title(s)!)", LogType.Subscriber, LogReasonContext.Info);
                return;
            }

            if (e.Message.Contains("\"error\":"))
            {
                Logger.Log($"ERROR!)", LogType.Subscriber, LogReasonContext.Error);
                throw new Exception("Something went wrong!");
            }

            JObject jObject = new JObject(e.Message);

            Title title = JsonConvert.DeserializeObject<Title>(jObject["title_update.title"]!.ToString())!;

            if (OnTitleRecieved != null)
                OnTitleRecieved(this, new TitleRecievedEventArgs(title));
        }
    }
}
