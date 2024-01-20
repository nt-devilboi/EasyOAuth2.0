using EasyOAuth.ConstructorOauth;

namespace EasyOAuth.Abstraction;

public interface IRegisterOAuth
{
    public OAuths AddOAuth(string name, Action<ConstructorOAuthService> ConfigureOAuth);
}
