using Newtonsoft.Json;

namespace ConfigService.Configs;

public class DbConfig
{
    [JsonProperty("ServiceName")]
    public string ServiceName { get; private set; }
    [JsonProperty("Server")]
    public string Server{ get; private set; }
    [JsonProperty("User")]
    public string User { get; private set; }
    [JsonProperty("Password")]
    public string Password { get; private set; }
    [JsonProperty("DatabaseName")] 
    public string DatabaseName { get; private set; }
}