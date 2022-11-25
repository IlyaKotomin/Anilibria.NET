using Anilibria.NET.Helpers.LogSystem;
using Anilibria.NET.Models.TitleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.SubscribingSystem
{
    /// <summary>
    /// Arguments that you will receive after subscribing through the Subscriber class
    /// </summary>
    public class TitleRecievedEventArgs : EventArgs
    {
        /// <summary>
        /// Title in args
        /// </summary>
        public Title? Title { get; private set; }



        /// <summary>
        /// Arguments that you will receive after subscribing through the Subscriber class
        /// </summary>
        /// <param name="title">Title to save</param>
        public TitleRecievedEventArgs(Title title)
        {
            Title = title;

            Logger.Log($"Reacieved new title ({Title.Code} | {Title.Id})!)", LogType.Subscriber, LogReasonContext.Info);
        }
    }
}
