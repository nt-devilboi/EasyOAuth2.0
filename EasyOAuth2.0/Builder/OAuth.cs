using EasyOAuth.Abstraction;

namespace EasyOAuth.Builder;

// привет принцип ISP (разделение интерфейсов)
public class OAuths(string redirect) : IRegisterOAuth, IProvideOAuth
{
    private readonly Dictionary<string, IOauthDataFormatter> _oAuthRequests = new();
    public IReadOnlyDictionary<string, IOauthDataFormatter> GetAll => _oAuthRequests;
    public string RedirectUri { get; } = redirect;
    
    public IOauthDataFormatter
        GetOAuth(string name) //todo как по мне было бы приятнее если бы мы возрвщали элемент словаря
    {
        if (!_oAuthRequests.TryGetValue(name, out var value))
            throw new ArgumentException($"oauth with name {name} not found");

        return value;
    }


    public OAuths AddOAuth(string name, Action<OAuthServiceBuilder> ConfigureOAuth)
    {
        if (name == string.Empty) throw new ArgumentException("name is empty");

        if (ConfigureOAuth == null) throw new ArgumentNullException(nameof(ConfigureOAuth));

        var ctorOAuth = new OAuthServiceBuilder(new OAuthData());
        ConfigureOAuth(ctorOAuth);
        _oAuthRequests.Add(name,
            ctorOAuth.Build()); // todo: реализовать проверки на то, что запрос может сущестовать и работать.

        return this;
    }

    public static IRegisterOAuth CreateBuilder(string redirectUri)
    {
        return new OAuths(redirectUri);
    }
}