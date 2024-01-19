using UlearnTodoTimer.OAuthConstructor;
using UlearnTodoTimer.OAuthConstructor.Extentions;
using UlearnTodoTimer.OAuthConstructor.Interfaces;
using UlearnTodoTimer.OAuthConstructor.Requests;

namespace UlearnTodoTimer.FluetApi.ConstructorOauth;

public class ConstructorOAuthService
{
    private OAuthData _oAuthData;

    internal ConstructorOAuthService(OAuthData oAuthData)
    {
        _oAuthData = oAuthData;
    }
    
    public ConstructorOAuthService SetDisplay(string display)
    {
        _oAuthData.AddQuery(nameof(display).AsSnakeCase(), display, QueryUse.OnlyCreateRequest);
        return new ConstructorOAuthService(_oAuthData);
    }
    
    public ConstructorOAuthService SetVersion(string version)
    {
        _oAuthData.AddQuery(nameof(version).AsSnakeCase(), version,
            QueryUse.OnlyCreateRequest); // по идей можно вынести часть кода, вот этого
        return new ConstructorOAuthService(_oAuthData);
    }
    
    public ConstructorOAuthService SetHostServiceOAuth(string hostServiceOAuth)
    {
        _oAuthData.ServiceOAuth = hostServiceOAuth;
        return new ConstructorOAuthService(_oAuthData);
    }

    public ConstructorOAuthService SetUriPageAuth(string uriAuth)
    {
        _oAuthData.UriAuthorization = uriAuth;
        return new ConstructorOAuthService(_oAuthData);
    }

    public ConstructorOAuthService SetUriGetAccessToken(string uriGetToken)
    {
        _oAuthData.UriGetAccessToken = uriGetToken;
        return new ConstructorOAuthService(_oAuthData);
    }

    public ConstructorOAuthService SetResponseType(string responseType)
    {
        _oAuthData.AddQuery(nameof(responseType).AsSnakeCase(), responseType, QueryUse.OnlyCreateRequest);
        return new ConstructorOAuthService(_oAuthData);
    }

    public ConstructorAppData ConfigureApp()
    {
        return new ConstructorAppData(_oAuthData);
    }

    public IOauthRequests Build()
    {
        if (_oAuthData.ServiceOAuth == string.Empty)
        {
            throw new ArgumentException("Not set Service Authorization");
        }

        if (_oAuthData.UriAuthorization == string.Empty)
        {
            throw new ArgumentException("Not Set uri for Authorization");
        }

        if (_oAuthData.UriGetAccessToken == string.Empty)
        {
            throw new ArgumentException("Not set Uri for Get token");
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