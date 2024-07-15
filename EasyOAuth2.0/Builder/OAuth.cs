using EasyOAuth.Abstraction;

namespace EasyOAuth.Constructor;


// привет принцип ISP (разделение интерфейсов)
public class OAuths : IRegisterOAuth, IProvideOAuth
{
    private readonly Dictionary<string, IOauthRequests> OAuthRequests = new Dictionary<string, IOauthRequests>();
    public IReadOnlyDictionary<string, IOauthRequests> GetAll => OAuthRequests;
    
    public OAuths AddOAuth(string name, Action<OAuthServiceBuilder> ConfigureOAuth)
    {
        if (name == string.Empty)
        {
            throw new ArgumentException("name is empty");
        }

        if (ConfigureOAuth == null)
        {
            throw new ArgumentNullException(nameof(ConfigureOAuth));
        }

        var ctorOAuth = new OAuthServiceBuilder(new OAuthData());
        ConfigureOAuth(ctorOAuth);
        OAuthRequests.Add(name, ctorOAuth.Build()); // todo: реализовать проверки на то, что запрос может сущестовать и работать.

        return this;
    }

    public IOauthRequests GetOAuth(string name) //todo как по мне было бы приятнее если бы мы возрвщали элемент словаря
    {
        if (!OAuthRequests.TryGetValue(name, out var value))
        {
            throw new ArgumentException($"oauth with name {name} not found");
        }

        return value;
    }

    public static IRegisterOAuth CreateBuilder()
    {
        return new OAuths();
    }
}