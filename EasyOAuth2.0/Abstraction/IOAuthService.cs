namespace EasyOAuth.Abstraction;

public interface IOAuthService
{
    public  Task<string?> GetAccessToken(string state, string code);

    public List<string> CreateOAuthRequests(string state = "");
}