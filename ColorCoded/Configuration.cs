using Newtonsoft.Json;

namespace ColorCoded
{
    /// <summary>
    /// The configuration of ColorCoded.
    /// </summary>
    public class Configuration
    {
        [JsonProperty("wanted_delay")]
        public int WantedDelay { get; set; } = 250;
    }
}
