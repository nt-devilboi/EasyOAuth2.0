using EasyOAuth.Abstraction;
using EasyOAuth.Requests;

namespace EasyOAuth.Constructor;

public class OAuthServiceBuilder
{
    private OAuthData _oAuthData;

    internal OAuthServiceBuilder(OAuthData oAuthData)
    {
        _oAuthData = oAuthData;
    }
    
    public OAuthServiceBuilder SetDisplay(string display)
    {
        _oAuthData.AddQuery(nameof(display).AsSnakeCase(), display, QueryUse.OnlyCreateRequest);
        return new OAuthServiceBuilder(_oAuthData);
    }
    
    public OAuthServiceBuilder SetVersion(string version)
    {
        _oAuthData.AddQuery(nameof(version).AsSnakeCase(), version,
            QueryUse.OnlyCreateRequest); // по идей можно вынести часть кода, вот этого
        return new OAuthServiceBuilder(_oAuthData);
    }
    

    public OAuthServiceBuilder SetUriPageAuth(string authUri)
    {
        _oAuthData.AddQuery(nameof(authUri).AsSnakeCase(), authUri, QueryUse.OnlyCreateRequest);
        return new OAuthServiceBuilder(_oAuthData);
    }
  

    public OAuthServiceBuilder SetUriGetAccessToken(string getTokenUri)
    {
        _oAuthData.AddQuery(nameof(getTokenUri).AsSnakeCase(), getTokenUri, QueryUse.OnlyCreateRequest);
        return new OAuthServiceBuilder(_oAuthData);
    }

    public OAuthServiceBuilder SetResponseType(string responseType)
    {
        _oAuthData.AddQuery(nameof(responseType).AsSnakeCase(), responseType, QueryUse.OnlyCreateRequest);
        return new OAuthServiceBuilder(_oAuthData);
    }

    public OAuthAppDataBuilder ConfigureApp()
    {
        return new OAuthAppDataBuilder(_oAuthData);
    }

    public IOauthRequests Build()
    {
        if (!_oAuthData.Contains("auth_uri"))
        {
            throw new ArgumentException("Not set Service Authorization");
        }

        if (!_oAuthData.Contains("get_token_uri"))
        {
            throw new ArgumentException("Not set Service Authorization");
        }
        
        if (!_oAuthData.Contains("client_id"))
        {
            throw new ArgumentException("Not Set client id");
        }

        if (!_oAuthData.Contains("client_secret"))
        {
            throw new ArgumentException("Not set client secret");
        }

        var oAuth = new OAuthRequests(_oAuthData);

        return oAuth;
    }

   
}