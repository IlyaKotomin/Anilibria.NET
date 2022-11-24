using Anilibria.NET.Helpers.LogSystem;
using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace Anilibria.NET.SubscribingSystem
{
    public class Subscriber
    {
        private WebSocket _webSocket;

        public delegate void TitleRecievedEventHandler(object sender, TitleRecievedEventArgs e);
        public event TitleRecievedEventHandler? OnTitleRecieved;

        public List<Title> SubscribedTitles { get; private set; }

        public List<string> SubscribedGenres { get; private set; }

        public Subscriber()
        {
            _webSocket = new("ws://api.anilibria.tv/v2/ws/");

            _webSocket.MessageReceived += OnMessageReceived;

            SubscribedTitles = new();
            SubscribedGenres = new();

            Logger.Log("Subscriber Created!", LogType.Subscriber, LogReasonContext.Info);
        }

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
        }

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
        }

        public void SubscribeOnTitiles(Title[] titles)
        {
            int[] ids = new int[titles.Length];

            for(int i = 0; i < ids.Length; i++)
                ids[i] = titles[i].Id;

            Logger.Log($"Starting subscribe process (Titles: {string.Join(", ", ids)})", LogType.Subscriber, LogReasonContext.Info);

            foreach (var title in titles)
                SubscribeOnTitle(title);
        }

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
