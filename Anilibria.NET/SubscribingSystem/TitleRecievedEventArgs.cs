using Anilibria.NET.Helpers.LogSystem;
using Anilibria.NET.Models.TitleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.SubscribingSystem
{
    public class TitleRecievedEventArgs : EventArgs
    {
        public Title? Title { get; private set; }

        public TitleRecievedEventArgs(Title title)
        {
            Title = title;

            Logger.Log($"Reacieved new title ({Title.Code} | {Title.Id})!)", LogType.Subscriber, LogReasonContext.Info);
        }
    }
}
