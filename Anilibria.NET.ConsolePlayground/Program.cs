using Anilibria.NET.Models.TitleModel;
using Anilibria.NET.Models.TitleModel.PlayerModel;
using Anilibria.NET.Models.TitleModel.TorrentsModel;
using Anilibria.NET.Models.TitleModel.PostersModel;
using Anilibria.NET.SubscribingSystem;

namespace Anilibria.NET.ConsolePlayground
{
    class Programm
    {
        public static void Main(string[] args) => new Programm().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            Subscriber subscriber = new();
            subscriber.SubscribeOnNew();

            subscriber.OnTitleRecieved += OnNewTitleRecieved;



            Thread.Sleep(-1);
        }

        private static void OnNewTitleRecieved(object sender, TitleRecievedEventArgs e)
        {
            Console.WriteLine(e.Title!.Name);
        }
    }
}
