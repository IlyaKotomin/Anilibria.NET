namespace Anilibria.NET.Helpers.LogSystem
{
    /// <summary>
    /// Event data class with Log data
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        /// <summary>
        /// Already formated log text
        /// </summary>
        public string Log => $"{Time} | {Type} | {LogContent}";


        /// <summary>
        /// Raw log data
        /// </summary>
        public string LogContent { get; private set; }


        /// <summary>
        /// Date of log creation
        /// </summary>
        public DateTime Time { get; private set; }


        /// <summary>
        /// Log type
        /// </summary>
        public LogType Type { get; private set; }


        /// <summary>
        /// Log reason
        /// </summary>
        public LogReasonContext ReasonContext { get; private set; }


        /// <summary>
        /// Creation of Log event data class
        /// </summary>
        /// <param name="content">Log content</param>
        /// <param name="type">Log type</param>
        /// <param name="reasonContext">Log reason</param>
        internal LogEventArgs(string content, LogType type, LogReasonContext reasonContext)
        {
            Time = DateTime.Now;
            LogContent = content;
            Type = type;
            ReasonContext = reasonContext;
        }
    }
}
