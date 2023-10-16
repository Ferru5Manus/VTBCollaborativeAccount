using AuthService.Configs;
using Grpc.Net.Client;

namespace AuthService.Communicators;

public class VTBCommunicator 
{
    private readonly VTB_Service.VTB_ServiceClient _configClient;
    public VTBCommunicator()
    {
        var config = ConfigReader.GetGrpc("vtb").Result;
        
        var channel = GrpcChannel.ForAddress($"http://{config.Host}:{config.Port}");
        _configClient = new VTB_Service.VTB_ServiceClient(channel);
    }

    public async Task<AuthReply> GetAuthUrl()
    {
        return _configClient.GetAuthLink(new AuthRequest());
    }
}