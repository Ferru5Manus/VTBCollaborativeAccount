using Newtonsoft.Json;

namespace ConfigService.Configs;

public class UrlConfig
{
    [JsonProperty("RequestName")]
    public string RequestName { get; private set; }
    [JsonProperty("Url")]
    public string Url{ get; private set; }
}