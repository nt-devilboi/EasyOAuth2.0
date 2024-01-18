using System.Net;
using System.Net.Http.Headers;
using UlearnTodoTimer.OAuthConstructor.Extentions;
using UlearnTodoTimer.OAuthConstructor.Interfaces;

namespace UlearnTodoTimer.OAuthConstructor;

public class OAuthService : IOAuthService
{
    private readonly IProvideOAuth _provideOAuth;
    /*private readonly IBdStates();*/ // как варинат сделать интерфес с бд, а пусть саму бд создают уже у себя, нужно только интерфес настроить или абстрактынй класс
    public OAuthService(IProvideOAuth provideOAuth)
    {
        _provideOAuth = provideOAuth;
    }

    public async Task<string?> GetAccessToken(string state, string code)
    {
        var oAuthName = state.Split(':')[0]; //todo: придумать проверку state. имея есть выше.
        var request = _provideOAuth.GetOAuth(state).CreateGetAccessTokenRequest(code);

        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        var oAuthResponse =  await client.PostAsync(request, null);
        if (oAuthResponse.StatusCode != HttpStatusCode.OK) return null;
        var token = await oAuthResponse.Content.JsonDeserializeAccessToken();
        
        return token ?? null;
    }

    public  List<string> CreateOAuthRequests(string state = "")
    {
        var oauthRequestsArray = _provideOAuth.GetAll;
        var requestsAuth = new List<string>();

        foreach (var oAuth in oauthRequestsArray)
        {
            requestsAuth.Add(oAuth.Value.CreateAuthRequest($"{oAuth.Key}:{state}"));
        }

        return requestsAuth;
    }
}