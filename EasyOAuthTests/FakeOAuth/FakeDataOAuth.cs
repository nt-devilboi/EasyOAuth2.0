namespace EasyOAuthTests.FakeOAuth;

public class FakeDataOAuthVk : IFakeOAuth
{
    public string Scope { get; set; } = "friends";
    public string ClientId { get; set; } = "1534";
    public string ClientSecret { get; set; } = "2132f2";
    public string RedirectUri { get; set; } = "pornhub.com";
    public string Version { get; set; } = "5.311";
    public string HostServiceOAuth { get; set; } = "https://oauth.vk.com";
    public string UriPageOAuth { get; set; } = "authorize";
    public string UriGetAccessToken { get; set; } = "access_token";
    public string ResponseType { get; set; } = "code";
    
    public string GetAuthRequest()
    {
        return "https://oauth.vk.com/authorize?scope=friends&Client";
    }

    public string GetAccessToken()
    {
        throw new NotImplementedException();
    }
}


