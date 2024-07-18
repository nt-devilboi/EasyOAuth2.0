using EasyOAuth.Abstraction;

namespace EasyOAuth.Builder;

// привет принцип ISP (разделение интерфейсов)
public class OAuths : IRegisterOAuth, IProvideOAuth
{
    private readonly Dictionary<string, IOauthDataFormatter> OAuthRequests = new();
    public IReadOnlyDictionary<string, IOauthDataFormatter> GetAll => OAuthRequests;

    public IOauthDataFormatter GetOAuth(string name) //todo как по мне было бы приятнее если бы мы возрвщали элемент словаря
    {
        if (!OAuthRequests.TryGetValue(name, out var value))
            throw new ArgumentException($"oauth with name {name} not found");

        return value;
    }

    public OAuths AddOAuth(string name, Action<OAuthServiceBuilder> ConfigureOAuth)
    {
        if (name == string.Empty) throw new ArgumentException("name is empty");

        if (ConfigureOAuth == null) throw new ArgumentNullException(nameof(ConfigureOAuth));

        var ctorOAuth = new OAuthServiceBuilder(new OAuthData());
        ConfigureOAuth(ctorOAuth);
        OAuthRequests.Add(name,
            ctorOAuth.Build()); // todo: реализовать проверки на то, что запрос может сущестовать и работать.

        return this;
    }

    public static IRegisterOAuth CreateBuilder() => new OAuths();
}