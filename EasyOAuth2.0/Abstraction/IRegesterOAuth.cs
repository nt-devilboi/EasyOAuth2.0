using EasyOAuth.Constructor;

namespace EasyOAuth.Abstraction;

public interface IRegisterOAuth
{
    public OAuths AddOAuth(string name, Action<OAuthServiceBuilder> ConfigureOAuth);
}
