namespace EasyOAuth.Abstraction;

public interface IOauthDataFormatter
{
    public string CreateAuthRequest(string state);
    public string CreateGetAccessTokenRequest(string code);
}