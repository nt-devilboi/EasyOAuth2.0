namespace EasyOAuth.Abstraction;

public interface IConstructorAppData
{
    public IConstructorAppData SetRedirectUrl(string redirectUri);
    public IConstructorAppData SetClientSecret(string clientSecret);
    public IConstructorAppData SetClientId(string clientId);
    public IConstructorAppData SetScope(string scope);
}