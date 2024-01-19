# EasyOAuth2.0

 **EasyOAuth2.0** Help you Get Token From others Authorization Services like: GitHub, Google.

## Getting started

### First Create OAuthConstructor

```cs
var oAuth = OAuths.CreateBuilder();
```
and
### Second Add OAuths
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
### Third Add in Di (for asp.net)
```cs
builder.Services.AddSingleton<IOAuthService, OAuthService>();
builder.Services.AddOAuths(oAuth);
```
### Fourth create request on Auth server
```cs
OAuthService.CreateOAuthRequests(yourState);
```
### Fifth Get Token
```cs
var token = await _OAuthService.GetAccessToken(yourState, AuthServiceCode);
```
