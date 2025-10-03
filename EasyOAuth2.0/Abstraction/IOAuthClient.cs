using Microsoft.AspNetCore.Mvc;

namespace EasyOAuth.Abstraction;

public interface IOAuthClient
{
    public Task<string?> GetAccessToken(string state, string code);

    public Task<string> GetOAuthRequest(string OAuth, string id);

    public List<string> GetOAuthsRequests(string state = "");

    public RedirectResult GetRedirectUrl();
}