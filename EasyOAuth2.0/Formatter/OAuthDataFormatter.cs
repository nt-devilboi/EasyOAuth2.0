using EasyOAuth.Abstraction;
using EasyOAuth.Extensions;

namespace EasyOAuth.Formatter;

internal class OAuthDataFormatter : IOauthDataFormatter
{
    private readonly OAuthData _auth;

    public OAuthDataFormatter(OAuthData auth)
    {
        _auth = auth;
    }

    public string CreateAuthRequest(string state)
    {
        return $"{_auth.AuthUri}?{"state".AddQuery(state)}&{string.Join("&", _auth.GetOAuthRequestQueries())}";
    }

    public string CreateGetAccessTokenRequest(string code)
    {
        return $"{_auth.GetAccessTokenUri}?{"code".AddQuery(code)}&{string.Join("&", _auth.GetAccessTokenQueries())}";
    }
}