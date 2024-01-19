using UlearnTodoTimer.FluetApi.ConstructorOauth;

namespace EasyOAuth2._0.OAuthConstructor.Interfaces;

public interface IRegisterOAuth
{
    public OAuths AddOAuth(string name, Action<ConstructorOAuthService> ConfigureOAuth);
}
