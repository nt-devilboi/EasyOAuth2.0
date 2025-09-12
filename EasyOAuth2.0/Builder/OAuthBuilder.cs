using EasyOAuth.Abstraction;
using EasyOAuth.Extensions;
using EasyOAuth.Formatter;

namespace EasyOAuth.Builder;

public class OAuthServiceBuilder
{
    private readonly OAuthData _oAuthData;

    internal OAuthServiceBuilder(OAuthData oAuthData)
    {
        _oAuthData = oAuthData;
    }

    public OAuthServiceBuilder SetDisplay(string display)
    {
        _oAuthData.AddQuery(nameof(display).AsSnakeCase(), display, QueryFor.CreateRequest);
        return new OAuthServiceBuilder(_oAuthData);
    }

    public OAuthServiceBuilder SetVersion(string version)
    {
        _oAuthData.AddQuery(nameof(version).AsSnakeCase(), version,
            QueryFor.CreateRequest); // по идей можно вынести часть кода, вот этого
        return new OAuthServiceBuilder(_oAuthData);
    }


    public OAuthServiceBuilder SetUriPageAuth(string authUri)
    {
        _oAuthData.AuthUri = authUri;
        return new OAuthServiceBuilder(_oAuthData);
    }


    public OAuthServiceBuilder SetUriGetAccessToken(string getTokenUri)
    {
        _oAuthData.GetAccessTokenUri = getTokenUri;
        return new OAuthServiceBuilder(_oAuthData);
    }

    public OAuthServiceBuilder SetResponseType(string responseType)
    {
        _oAuthData.AddQuery(nameof(responseType).AsSnakeCase(), responseType, QueryFor.CreateRequest);
        return new OAuthServiceBuilder(_oAuthData);
    }

    public OAuthAppDataBuilder ConfigureApp()
    {
        return new OAuthAppDataBuilder(_oAuthData);
    }

    public IOauthDataFormatter Build()
    {
        if (string.IsNullOrEmpty(_oAuthData.AuthUri)) throw new ArgumentException($"Not set host Service Authorization for request: {_oAuthData.AuthUri}");

        if (string.IsNullOrEmpty(_oAuthData.GetAccessTokenUri))
            throw new ArgumentException($"Not set Service Authorization for request: {_oAuthData.AuthUri}");

        if (!_oAuthData.Contains("client_id")) throw new ArgumentException($"Not Set client id for request: {_oAuthData.AuthUri}");

        if (!_oAuthData.Contains("client_secret")) throw new ArgumentException($"Not set client secret for request: {_oAuthData.AuthUri}");

        var oAuth = new OAuthDataFormatter(_oAuthData);

        return oAuth;
    }
}