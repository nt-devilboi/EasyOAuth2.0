GetBuilder
```cs
var oAuth = OAuths.CreateBuilder();
```
and
AddOauts
```cs

oAuth.AddOAuth("GitHub", _ =>
{
    _.SetUriPageAuth("login/oauth/authorize")
        .SetUriGetAccessToken("login/oauth/access_token")
        .SetHostServiceOAuth("https://github.com")
        .ConfigureApp()
        .SetRedirectUrl("http://localhost:5128/OAuth/Bot")
        .SetClientSecret("cce83e71b1bcba85fa5493c74fca25e93ec1fb3b")
        .SetClientId("08f51cb49cd389a89b6f");
});
```
after 
```cs
builder.Services.AddSingleton<IOAuthService, OAuthService>();
builder.Services.AddOAuths(oAuth);
```
GetRequestsFor Authorization
```cs
OAuthService.CreateOAuthRequests(yourState);
```
And Just Take Token
```cs
var token = await _OAuthService.GetAccessToken(yourState, AuthServiceCode);
```
