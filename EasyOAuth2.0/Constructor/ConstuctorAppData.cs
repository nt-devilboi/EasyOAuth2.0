using EasyOAuth;

namespace EasyOAuth.ConstructorOauth;

public class ConstructorAppData
{
    private OAuthData _oAuthData;

    internal ConstructorAppData(OAuthData oAuthData)
    {
        _oAuthData = oAuthData;
    }
    
    public ConstructorAppData SetScope(string scope)
    {
        _oAuthData.AddQuery(nameof(scope), scope, QueryUse.OnlyCreateRequest);
        return new ConstructorAppData(_oAuthData);
    }
    
    public ConstructorAppData SetClientId(string clientId)
    {
        _oAuthData.AddQuery(nameof(clientId).AsSnakeCase(), clientId, QueryUse.All);
        return new ConstructorAppData(_oAuthData);
    }
    
    public ConstructorAppData SetClientSecret(string clientSecret)
    {
        _oAuthData.AddQuery(nameof(clientSecret).AsSnakeCase(), clientSecret, QueryUse.OnlyGetAccessToken);
        return new ConstructorAppData(_oAuthData);
    }
    
    public ConstructorAppData SetRedirectUrl(string redirectUri)
    {
        _oAuthData.AddQuery(nameof(redirectUri).AsSnakeCase(), redirectUri, QueryUse.All);
        return new ConstructorAppData(_oAuthData);
    }
    
    public ConstructorAppData SetCustomQuery(string nameQuery, string value, QueryUse queryUse)
    {
        _oAuthData.AddQuery(nameQuery, value, queryUse);
        return new ConstructorAppData(_oAuthData);
    }
}