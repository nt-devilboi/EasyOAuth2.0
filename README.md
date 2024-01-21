# EasyOAuth2.0

 **EasyOAuth2.0** Help you Get Token From others Authorization Services like: GitHub, Google.

## Getting started

### First Create OAuthConstructor

```cs
var oAuths = OAuths.CreateBuilder();
```
and
### Second Add OAuths
```cs

oAuths.AddOAuth("GitHub", _ =>
{
    _.SetUriPageAuth("login/oauth/authorize")
        .SetUriGetAccessToken("login/oauth/access_token")
        .SetHostServiceOAuth("https://github.com")
        .ConfigureApp()
        .SetRedirectUrl("YourUrl")
        .SetClientSecret("YourClientSecret")
        .SetClientId("YourClientId");
});
```
### Third Add in Di (for asp.net)
```cs
builder.Services.AddSingleton<IOAuthService, OAuthService>();
builder.Services.AddOAuths(oAuths);
```
### Fourth create request on Auth server
```cs
OAuthService.CreateOAuthRequests(yourState);
```
### Fifth Get Token
```cs
var token = await _OAuthService.GetAccessToken(yourState, AuthServiceCode);
```
