using Grpc.Net.Client;
using VTBService.Configs;

namespace VTBService.Communicators;

public class ConfigCommunicator : Config.ConfigClient
{
    private readonly Config.ConfigClient _configClient;
    public ConfigCommunicator()
    {
        var config = ConfigReader.GetGrpc("config").Result;
        
        var channel = GrpcChannel.ForAddress($"http://{config.Host}:{config.Port}");
        _configClient = new Config.ConfigClient(channel);
    }

    public async Task<UrlReply> GetUrl(string RequestName)
    {
        return _configClient.GetUrl(new UrlRequest(){UrlName = RequestName});
    }

    public async Task<ClientReply> GetClient()
    {
        return _configClient.GetClientInfo(new ClientRequest());
    }
}