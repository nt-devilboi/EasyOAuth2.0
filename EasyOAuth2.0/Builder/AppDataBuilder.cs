namespace EasyOAuth.Constructor;

public class OAuthAppDataBuilder // todo: naming so strange
{
    private OAuthData _oAuthData;

    internal OAuthAppDataBuilder(OAuthData oAuthData)
    {
        _oAuthData = oAuthData;
    }
    
    public OAuthAppDataBuilder SetScope(string scope)
    {
        _oAuthData.AddQuery(nameof(scope), scope, QueryUse.OnlyCreateRequest);
        return new OAuthAppDataBuilder(_oAuthData);
    }
    
    public OAuthAppDataBuilder SetClientId(string clientId)
    {
        _oAuthData.AddQuery(nameof(clientId).AsSnakeCase(), clientId, QueryUse.All);
        return new OAuthAppDataBuilder(_oAuthData);
    }
    
    public OAuthAppDataBuilder SetClientSecret(string clientSecret)
    {
        _oAuthData.AddQuery(nameof(clientSecret).AsSnakeCase(), clientSecret, QueryUse.OnlyGetAccessToken);
        return new OAuthAppDataBuilder(_oAuthData);
    }
    
    public OAuthAppDataBuilder SetRedirectUrl(string redirectUri)
    {
        _oAuthData.AddQuery(nameof(redirectUri).AsSnakeCase(), redirectUri, QueryUse.All);
        return new OAuthAppDataBuilder(_oAuthData);
    }
    
    public OAuthAppDataBuilder SetCustomQuery(string nameQuery, string value, QueryUse queryUse)
    {
        _oAuthData.AddQuery(nameQuery, value, queryUse);
        return new OAuthAppDataBuilder(_oAuthData);
    }
}