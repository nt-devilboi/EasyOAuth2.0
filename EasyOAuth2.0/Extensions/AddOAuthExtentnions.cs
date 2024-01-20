using EasyOAuth.Abstraction;
using EasyOAuth.ConstructorOauth;
using Microsoft.Extensions.DependencyInjection;

namespace EasyOAuth.Extensions;

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
    
    public static IServiceCollection  AddOAuths(this IServiceCollection services, IRegisterOAuth oAuth)
    {
        services.AddSingleton<IProvideOAuth>(_ => oAuth as IProvideOAuth ?? throw new Exception("OAuth Not Found"));
        return services;
    }
}