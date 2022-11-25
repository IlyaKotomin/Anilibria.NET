using Anilibria.NET.Models.TitleModel;
using Anilibria.NET.Models.TitleModel.PlayerModel;
using Anilibria.NET.Models.TitleModel.TorrentsModel;
using Anilibria.NET.Models.TitleModel.PostersModel;
using Anilibria.NET.Client;
using Anilibria.NET.SubscribingSystem;
using Anilibria.NET.Helpers.LogSystem;
using System.Linq.Expressions;

namespace Anilibria.NET.ConsolePlayground
{
    class Programm
    {
        public static void Main(string[] args) => new Programm().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            Title title = await AnilibriaAPI.GetRandomTitleAsync();

            Thread.Sleep(-1);
        }

        private void OnLogRecieved(LogEventArgs args) => Console.WriteLine(args.Log);

        private static void OnNewTitleRecieved(object sender, TitleRecievedEventArgs e)
        {
            Console.WriteLine(e.Title!.Name);

            File.WriteAllText(e.Title.Code + ".txt", e.Title.Name);
        }
    }
}