using System.Reflection;
using EasyOAuth.Abstraction;
using EasyOAuth.Constructor;
using Microsoft.Extensions.DependencyInjection;

namespace EasyOAuth.Extensions;

public static class AddOAuthExtensions
{
    public static void AddVk(this IRegisterOAuth registerOAuth, Action<OAuthAppDataBuilder> action)
    {
        Action<OAuthServiceBuilder> configureOAuth = auth =>
        {
            auth
                .SetUriPageAuth(
                    "https://oauth.vk.com/authorize") //todo: явно https можно здесь не учитывать. upd так то нжуно 
                .SetUriGetAccessToken("https://oauth.vk.com/access_token")
                .SetResponseType("code")
                .SetVersion("5.131");

            action(auth.ConfigureApp());
        };

        registerOAuth.AddOAuth("vk", configureOAuth);
    }

    public static IServiceCollection AddOAuths<T, TRepository, TStrategy>(this IServiceCollection services,
        IRegisterOAuth oAuth)
        where T : OAuthEntity
        where TRepository : TokenLinkRepositoryBase
        where TStrategy : IStrategyToken
    {
        services.AddScoped<TokenLinkRepositoryBase, TRepository>();
        services.AddSingleton<IProvideOAuth>(_ => oAuth as IProvideOAuth ?? throw new Exception("OAuth Not Found"));
        services.AddMvc().AddApplicationPart(Assembly.GetAssembly(typeof(AuthController)));
        services.AddSingleton<IStrategyToken, TStrategy>();
        services.AddScoped<IOAuthClient, OAuthClient.OAuthClient>();
        return services;
    }
}