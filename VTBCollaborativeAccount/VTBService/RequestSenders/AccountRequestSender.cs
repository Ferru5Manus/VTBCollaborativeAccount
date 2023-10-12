using System.Text;
using Newtonsoft.Json;
using VTBService.Utils;
using VTBService.Utils.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;
namespace VTBService.RequestSenders;

public class AccountRequestSender
{
    private HttpClient _client;
    public AccountRequestSender(HttpClient client)
    {
        _client = client;
    }
    public async Task<string> AccountConsentsCreateRequest(string url,string customerUserAgent, string apiAuthDate,Guid GUID, string userIpAdress, Guid idempotencyKey)
    {
        
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                Data = new Data()
                {
                    permissoins = new List<string>()
                    {
                        Permissoins.ReadBalances.ToString()
                    },
                    expirationDateTime = DateTime.UtcNow.AddMinutes(10),
                    transactionFromDateTime = DateTime.UtcNow,
                    transactionToDateTime = DateTime.UtcNow.AddMinutes(100)
                },
                Risk=new List<int>()
            }),
            Encoding.UTF8,
            "application/json");
        Console.WriteLine(jsonContent);
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(url),
            Content = jsonContent
        };
        request.Headers.Add("x-customer-user-agent", customerUserAgent);
        request.Headers.Add("x-fapi-auth-date", apiAuthDate);
        request.Headers.Add("x-fapi-interaction-id", GUID.ToString());
        request.Headers.Add("x-fapi-customer-ip-address", userIpAdress);
        request.Headers.Add("x-idempotency-key", idempotencyKey.ToString());
        var response = await _client.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Console.WriteLine(responseBody);
        return responseBody;
    }
    public async Task<string> AccountConsentsGetRequest(string url, string consentId,string customerUserAgent, string apiAuthDate,Guid GUID, string userIpAdress)
    {
        
     
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url+consentId)
        };
        request.Headers.Add("x-customer-user-agent", customerUserAgent);
        request.Headers.Add("x-fapi-auth-date", apiAuthDate);
        request.Headers.Add("x-fapi-interaction-id", GUID.ToString());
        request.Headers.Add("x-fapi-customer-ip-address", userIpAdress);
        var response = await _client.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Console.WriteLine(responseBody);
        return responseBody;
    }
    public async Task<string> AccountConsentsDeleteRequest(string url,string customerUserAgent, string apiAuthDate,Guid GUID, string userIpAdress, string consentId)
    {
       
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(url+consentId)
        };
        request.Headers.Add("x-customer-user-agent", customerUserAgent);
        request.Headers.Add("x-fapi-auth-date", apiAuthDate);
        request.Headers.Add("x-fapi-interaction-id", GUID.ToString());
        request.Headers.Add("x-fapi-customer-ip-address", userIpAdress);
        var response = await _client.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Console.WriteLine(responseBody);
        return responseBody;
    }
    public async Task<string> RetrievalGrant(string url, string consentId,string customerUserAgent, string apiAuthDate,Guid GUID, string userIpAdress )
    {
         
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(url+consentId)
        };
        request.Headers.Add("x-customer-user-agent", customerUserAgent);
        request.Headers.Add("x-fapi-auth-date", apiAuthDate);
        request.Headers.Add("x-fapi-interaction-id", GUID.ToString());
        request.Headers.Add("x-fapi-customer-ip-address", userIpAdress);
        var response = await _client.SendAsync(request);
        var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        Console.WriteLine(responseBody);
        return responseBody;
    }
}