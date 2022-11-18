using Newtonsoft.Json;
using System.Net.Http;
using Anilibria.NET.Models.Title;
using Anilibria.NET.Models.Title.PlayerModel;
using Anilibria.NET.Models.Title.TorrentsModel;
using Anilibria.NET.Models.Title.PostersModel;

namespace Anilibria.NET.ConsolePlayground
{
    class Programm
    {
        public async static Task Main(string[] args)
        {
            Title title = await Anilibria.GetTitleAsync("tate-no-yuusha-no-nariagari");

            Torrent torrent = await title.GetTorrentAsync(true, true);

            Player player = await title.GetPlayerAsync();

            Posters posters = await title.GetPostersAsync();

            System.Threading.Thread.Sleep(-1);
        }
    }
}
