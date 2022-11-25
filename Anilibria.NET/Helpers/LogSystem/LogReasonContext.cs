namespace Anilibria.NET.Helpers.LogSystem
{
    /// <summary>
    /// Type of reason why the log created
    /// </summary>
    public enum LogReasonContext
    {
        /// <summary>
        /// Reason was ingotmation
        /// </summary>
        Info,


        /// <summary>
        /// Reason was warning
        /// </summary>
        Warning,


        /// <summary>
        /// Reason was error
        /// </summary>
        Error,


        /// <summary>
        /// There wasn`t any reason for log
        /// </summary>
        None
    }
}