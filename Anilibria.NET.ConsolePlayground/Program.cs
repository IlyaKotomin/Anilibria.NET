using Newtonsoft.Json;
using System.Net.Http;
using Anilibria.NET.Models.TitleModel;
using Anilibria.NET.Models.TitleModel.PlayerModel;
using Anilibria.NET.Models.TitleModel.TorrentsModel;
using Anilibria.NET.Models.TitleModel.PostersModel;

namespace Anilibria.NET.ConsolePlayground
{
    class Programm
    {
        public async static Task Main(string[] args)
        {
            var title = await Anilibria.GetRandomTitleAsync();

            System.Threading.Thread.Sleep(-1);
        }
    }
}
