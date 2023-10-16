using Grpc.Core;
using VTBService.Communicators;
using VTBService.Utils.AntiCsrf;

namespace VTBService.Services;

public class VTBService : VTB_Service.VTB_ServiceBase
{
    private ConfigCommunicator _configCommunicator;

    public VTBService(ConfigCommunicator configCommunicator)
    {
        _configCommunicator = configCommunicator;
    }
    public async override Task<AuthReply> GetAuthLink(AuthRequest request, ServerCallContext context)
    {
        AntiCsrfGenerator generator = new AntiCsrfGenerator();
        var Url = await _configCommunicator.GetUrl("Authorization");
        var ClientInfo = await _configCommunicator.GetClient();
        
        return await Task.FromResult(new AuthReply()
        {
            Url = Url.Url+"?clientId="+ClientInfo.ClientId.ToString()+"&response_type=code"+"&state="+generator.GenerateToken(ClientInfo.ClientId,ClientInfo.ClientSecret)+"&redirect_uri="+_configCommunicator.GetUrl("AuthRedirect")+"&scope=patronymic+gender+openid+surname+name+mainMobilePhone+email+account"
        });
    }
}