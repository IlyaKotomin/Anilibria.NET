using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json;
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
        }

        public async Task SubscribeOnTitle(Title title)
        {
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

        public async Task SubscribeOnGenres(string[] genres)
        {
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

        public async Task SubscribeOnTitiles(Title[] titles)
        {
            foreach (var title in titles)
                await SubscribeOnTitle(title);
        }

        public async Task SubscribeOnNew()
        {
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
            if (e.Message.Contains("\"subscribe\":") || e.Message.Contains("\"connection\":"))
                return;

            if (e.Message.Contains("\"error\":"))
                throw new Exception("Something went wrong!");

            Title title = JsonConvert.DeserializeObject<Title>(e.Message)!;


            if (OnTitleRecieved != null)
                OnTitleRecieved(this, new TitleRecievedEventArgs() { Title = title });

            Console.WriteLine(title.Name);
        }
    }
}
