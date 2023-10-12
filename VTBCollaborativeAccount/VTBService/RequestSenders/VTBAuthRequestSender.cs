namespace VTBService.RequestSenders;

public class VTBAuthRequestSender
{
    private HttpClient _client;
    public VTBAuthRequestSender(HttpClient client)
    {
        _client = client;
    }
    
}