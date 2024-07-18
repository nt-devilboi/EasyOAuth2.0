using System.Net;
using System.Net.Http.Headers;
using EasyOAuth.Abstraction;
using EasyOAuth.Extensions;

namespace EasyOAuth.OAuthClient;

public class OAuthClient : IOAuthClient
{
    private readonly IProvideOAuth _provideOAuth;
    private readonly TokenLinkRepositoryBase _tokenLinkRepository;

    public OAuthClient(IProvideOAuth provideOAuth,
        TokenLinkRepositoryBase tokenLinkRepository)
    {
        _provideOAuth = provideOAuth;
        _tokenLinkRepository = tokenLinkRepository;
    }

    public async Task<string?> GetAccessToken(string state, string code)
    {
        var data = await _tokenLinkRepository.GetByState(state);
        var request = _provideOAuth.GetOAuth(data.OAuthName).CreateGetAccessTokenRequest(code);

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
        await _tokenLinkRepository.Add(oAuth, state, id);

        return _provideOAuth.GetOAuth(oAuth).CreateAuthRequest(state);
    }


    public List<string> GetOAuthsRequests(string state = "")
    {
        var oauthRequestsArray = _provideOAuth.GetAll;
        var requestsAuth = new List<string>();
        

        foreach (var oAuth in oauthRequestsArray)
            // stateLink.Add(oAuth, state, userId);
            requestsAuth.Add(oAuth.Value.CreateAuthRequest($"{oAuth.Key}:{state}"));

        return requestsAuth;
    }


    private string GenerateState()
    {
        return Guid.NewGuid().ToString();
    }
}