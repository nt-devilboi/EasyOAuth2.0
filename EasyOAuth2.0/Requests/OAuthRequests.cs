using EasyOAuth.Abstraction;

namespace EasyOAuth.Requests;

internal class OAuthRequests : IOauthRequests
{
    private readonly OAuthData _oAuthData;

    public OAuthRequests(OAuthData oAuthData)
    {
        _oAuthData = oAuthData;
    }
    
    //Todo: можно немного порефакторить
    public string CreateAuthRequest(string state)
    {
        var auth = _oAuthData.Get("auth_uri");
        return $"{auth}?"
               + "state".AddQueryValue(state) + "&"
               + string.Join("&", _oAuthData.GetOAuthRequestQueries()).TrimEnd('&'); //todo: don't sure that need use "TrimEnd" 
    }

    public string CreateGetAccessTokenRequest(string code)
    {
        var getTokenUri = _oAuthData.Get("get_token_uri");
        return $"{getTokenUri}?" 
               + "code".AddQueryValue(code) + "&" 
               + string.Join("&", _oAuthData.GetAccessTokenQueries()).TrimEnd('&');
    }
}