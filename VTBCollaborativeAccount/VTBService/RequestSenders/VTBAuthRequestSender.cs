using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using VTBService.Communicators;
using VTBService.Utils;
using VTBService.Utils.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace VTBService.RequestSenders;

public class VTBAuthRequestSender
{
    private HttpClient _client;
    private ConfigCommunicator _configCommunicator;
    public VTBAuthRequestSender(HttpClient client)
    {
        _client = client;
        _configCommunicator = new ConfigCommunicator();
    }

    public async Task<TokenAuthModel> GetToken()
    {
        var ClientInfo =  await _configCommunicator.GetClient();
        var authenticationString = $"{ClientInfo.ClientId}:{ClientInfo.ClientSecret}";
        var base64String = Convert.ToBase64String(
            System.Text.Encoding.ASCII.GetBytes(authenticationString));

        var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/SomeApi/SomePath");
        requestMessage.Headers.Authorization = 
            new AuthenticationHeaderValue("Basic", base64String);
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                grant_type = "code"
                 
            }),
            Encoding.UTF8,
            "application/json");
        return null;
    }
}