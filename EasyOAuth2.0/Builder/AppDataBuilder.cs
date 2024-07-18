using EasyOAuth.Extensions;

namespace EasyOAuth.Builder;

public class OAuthAppDataBuilder // todo: naming so strange
{
    private readonly OAuthData _oAuthData;

    internal OAuthAppDataBuilder(OAuthData oAuthData)
    {
        _oAuthData = oAuthData;
    }

    public OAuthAppDataBuilder SetScope(string scope)
    {
        _oAuthData.AddQuery(nameof(scope), scope, QueryFor.CreateRequest);
        return new OAuthAppDataBuilder(_oAuthData);
    }

    public OAuthAppDataBuilder SetClientId(string clientId)
    {
        _oAuthData.AddQuery(nameof(clientId).AsSnakeCase(), clientId, QueryFor.All);
        return new OAuthAppDataBuilder(_oAuthData);
    }

    public OAuthAppDataBuilder SetClientSecret(string clientSecret)
    {
        _oAuthData.AddQuery(nameof(clientSecret).AsSnakeCase(), clientSecret, QueryFor.GetAccessToken);
        return new OAuthAppDataBuilder(_oAuthData);
    }

    public OAuthAppDataBuilder SetRedirectUrl(string redirectUri)
    {
        _oAuthData.AddQuery(nameof(redirectUri).AsSnakeCase(), redirectUri, QueryFor.All);
        return new OAuthAppDataBuilder(_oAuthData);
    }

    public OAuthAppDataBuilder SetCustomQuery(string nameQuery, string value, QueryFor queryFor)
    {
        _oAuthData.AddQuery(nameQuery, value, queryFor);
        return new OAuthAppDataBuilder(_oAuthData);
    }
}