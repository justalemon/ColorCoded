using Newtonsoft.Json;

namespace ColorCoded
{
    /// <summary>
    /// The configuration of ColorCoded.
    /// </summary>
    public class Configuration
    {
        [JsonProperty("saturation_ds4")]
        public float SaturationDS4 { get; set; } = 1.3f;
        [JsonProperty("wanted_delay")]
        public int WantedDelay { get; set; } = 250;
    }
}
