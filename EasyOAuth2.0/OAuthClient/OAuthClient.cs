using System.Net;
using System.Net.Http.Headers;
using EasyOAuth.Abstraction;
using EasyOAuth.Extensions;

namespace EasyOAuth.OAuthClient;

public class OAuthClient(
    IProvideOAuth provideOAuth,
    ITokenLinkRepository tokenLinkRepository)
    : IOAuthClient
{
    public async Task<string?> GetAccessToken(string state, string code)
    {
        var data = await tokenLinkRepository.GetByState(state);
        var request = provideOAuth.GetOAuth(data.OAuthName).CreateGetAccessTokenRequest(code);

        var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        var oAuthResponse = await client.PostAsync(request, null);
        if (oAuthResponse.StatusCode != HttpStatusCode.OK) return null;
        var token = await oAuthResponse.Content.JsonDeserializeAccessToken();

        return token ?? null;
    }

    public async Task<string> GetOAuthRequest(string oAuth, string id)
    {
        var state = GenerateState();
        await tokenLinkRepository.Add(oAuth, state, id);

        return provideOAuth.GetOAuth(oAuth).CreateAuthRequest(state);
    }


    public List<string> GetOAuthsRequests(string state = "")
    {
        var oauthRequestsArray = provideOAuth.GetAll;
        var requestsAuth = new List<string>();


        foreach (var oAuth in oauthRequestsArray)
            requestsAuth.Add(oAuth.Value.CreateAuthRequest($"{oAuth.Key}:{state}"));

        return requestsAuth;
    }


    private string GenerateState()
    {
        return Guid.NewGuid().ToString();
    }
}