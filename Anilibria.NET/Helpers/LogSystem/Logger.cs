using Anilibria.NET.SubscribingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Helpers.LogSystem
{
    public static class Logger
    {
        public delegate void LogEventHandler(LogEventArgs args);
        public static event LogEventHandler? OnLog;
        public static void Log(string content,
                            LogType type = LogType.Application,
                            LogReasonContext reasonContext = LogReasonContext.None)
        {
            if (OnLog != null)
                OnLog(new(content, type, reasonContext));
        }
    }
}
