namespace EasyOAuthTests.FakeOAuth;

public interface IFakeOAuth
{
    public string Scope { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string RedirectUri { get; set; }
    public string Version { get; set; }
    public string HostServiceOAuth { get; set; }
    public string UriPageOAuth { get; set; }
    public string UriGetAccessToken { get; set; }
    public string ResponseType { get; set; }


    public string GetAuthRequest();
    public string GetAccessToken();
}