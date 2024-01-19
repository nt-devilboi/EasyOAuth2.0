using EasyOAuth2._0.OAuthConstructor.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using UlearnTodoTimer.FluetApi.ConstructorOauth;
using UlearnTodoTimer.OAuthConstructor.Interfaces;

namespace EasyOAuth2._0.OAuthConstructor.Extentions;

public static class AddOAuthExtensions
{
    public static void  AddVk(this IRegisterOAuth registerOAuth, Action<ConstructorAppData> action)
    {
        Action<ConstructorOAuthService> configureOAuth = auth =>
        {
            auth.SetHostServiceOAuth("https://oauth.vk.com")
                .SetUriPageAuth("authorize")
                .SetUriGetAccessToken("access_token")
                .SetResponseType("code")
                .SetVersion("5.131");
            
            action(auth.ConfigureApp());
        };

        registerOAuth.AddOAuth("vk", configureOAuth);
    }
    
    public static IServiceCollection  AddOAuths(this IServiceCollection services, IRegisterOAuth OAuth)
    {
        services.AddSingleton<IProvideOAuth>(_ => OAuth as IProvideOAuth ?? throw new Exception("OAuth Not Found"));
        return services;
    }
}