using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Helpers.LogSystem
{
    public class LogEventArgs : EventArgs
    {
        public string Log => $"{Time} | {Type} | {LogContent}";

        public string LogContent { get; private set; }

        public DateTime Time { get; private set; }

        public LogType Type { get; private set; }

        public LogReasonContext ReasonContext { get; private set; }

        public LogEventArgs(string content, LogType type, LogReasonContext reasonContext)
        {
            Time = DateTime.Now;
            LogContent = content;
            Type = type;
            ReasonContext = reasonContext;
        }
    }
}
