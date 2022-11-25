namespace Anilibria.NET.Helpers.LogSystem
{
    /// <summary>
    /// Type of log
    /// </summary>
    public enum LogType
    {
        /// <summary>
        /// Log from custom application
        /// </summary>
        Application,

        /// <summary>
        /// Log from Anilibria client
        /// </summary>
        AnilibriaClient,

        /// <summary>
        /// Log from Anilibria static client
        /// </summary>
        AnilibriaStaticClient,

        /// <summary>
        /// Log rom subscriber
        /// </summary>
        Subscriber,

        /// <summary>
        /// Log from Json deserializer
        /// </summary>
        JsonDeserializer,
    }
}