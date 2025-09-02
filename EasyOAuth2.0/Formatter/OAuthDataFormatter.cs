using EasyOAuth.Abstraction;
using EasyOAuth.Extensions;

namespace EasyOAuth.Formatter;

internal class OAuthDataFormatter(OAuthData auth) : IOauthDataFormatter
{
    public string CreateAuthRequest(string state)
    {
        return $"{auth.AuthUri}?{"state".AddQuery(state)}&{string.Join("&", auth.GetOAuthRequestQueries())}";
    }

    public string CreateGetAccessTokenRequest(string code)
    {
        return $"{auth.GetAccessTokenUri}?{"code".AddQuery(code)}&{string.Join("&", auth.GetAccessTokenQueries())}";
    }
}