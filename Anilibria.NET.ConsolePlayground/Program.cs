using Newtonsoft.Json;
using System.Net.Http;
using Anilibria.NET.Models.Title;

namespace Anilibria.NET.ConsolePlayground
{
    class Programm
    {
        public async static Task Main(string[] args)
        {
            Console.WriteLine("STARTED\n\n");


            HttpClient client = new HttpClient();

            var json = await client.GetStringAsync("https://api.anilibria.tv/v2/getTitle?id=8859&playlist_type=array");
            Title title = JsonConvert.DeserializeObject<Title>(json);

            System.Threading.Thread.Sleep(-1);
        }


    }
}
