using Grpc.Core;

namespace AuthDatabaseService.Services;

public class AuthDbService : AuthDb.AuthDbBase
{
    public override Task<InitiateAuthReply> InintiateAuth(InitiateAuthRequest request, ServerCallContext context)
    {
        
    }
}