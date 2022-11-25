using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.Configurations
{
    /// <summary>
    /// Information about blocking state in russia and www.wakanim.tv
    /// </summary>
    public class BlockedConfiguration
    {
        /// <summary>
        /// Blocking state in Russia
        /// </summary>
        [JsonProperty("blocked")] public bool IsBlockedInRussia { get; private set; }


        /// <summary>
        /// Blocking state on www.wakanim.tv
        /// </summary>
        [JsonProperty("bakanim")] public bool IsBlockedByWakanim { get; private set; }


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns><see cref="IsBlockedInRussia"/> as <see cref="string"/></returns>
        public override string ToString() => IsBlockedInRussia.ToString();
    }
}
