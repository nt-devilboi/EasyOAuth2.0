using EasyOAuth.Abstraction;

namespace EasyOAuth.Requests;

internal class OAuthRequests : IOauthRequests
{
    private readonly OAuthData _auth;

    public OAuthRequests(OAuthData auth)
    {
        _auth = auth;
    }

    //Todo: можно немного порефакторить
    public string CreateAuthRequest(string state)
        => $"{_auth.AuthUri}?{"state".AddQuery(state)}&{string.Join("&", _auth.GetOAuthRequestQueries())}";
    
    public string CreateGetAccessTokenRequest(string code)
        => $"{_auth.GetAccessTokenUri}?{"code".AddQuery(code)}&{string.Join("&", _auth.GetAccessTokenQueries())}";
}