namespace Anilibria.NET.Helpers.LogSystem
{
    /// <summary>
    /// Static class that is used to log what is happening in the library
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Event Handler for logs
        /// </summary>
        /// <param name="args">Arguments for log</param>
        public delegate void LogEventHandler(LogEventArgs args);


        /// <summary>
        /// Log event handler
        /// </summary>
        public static event LogEventHandler? OnLog;


        /// <summary>
        /// Logging method for developers. You can create a log and specify the reason (<see cref="LogReasonContext"/>)
        /// as well as its type (<see cref="LogType"/>)
        /// </summary>
        /// <param name="content">Text which will be logged</param>
        /// <param name="type">Type of log</param>
        /// <param name="reasonContext">Reason of log</param>
        internal static void Log(string content,
                            LogType type = LogType.Application,
                            LogReasonContext reasonContext = LogReasonContext.None)
        {
            if (OnLog != null)
                OnLog(new(content, type, reasonContext));
        }


        /// <summary>
        /// Logging method for users of library. You can create a log and specify the reason (<see cref="LogReasonContext"/>)
        /// </summary>
        /// <param name="text">Text which will be logged</param>
        /// <param name="reasonContext">Reason of log</param>
        public static void Log(string text, LogReasonContext reasonContext)
        {
            if (OnLog != null)
                OnLog(new(text, LogType.Application, reasonContext));
        }
    }
}
