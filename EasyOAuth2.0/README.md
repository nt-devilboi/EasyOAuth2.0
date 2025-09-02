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
oAuths.AddOAuth("google", _ =>
    _.SetUriPageAuth("https://accounts.google.com/o/oauth2/v2/auth")
        .SetUriGetAccessToken("https://oauth2.googleapis.com/token")
        .SetResponseType("code")
        .ConfigureApp()
        .SetClientId(Environment.GetEnvironmentVariable("CLIENT_ID") ?? string.Empty)
        .SetClientSecret(Environment.GetEnvironmentVariable("CLIENT_SECRET") ?? string.Empty)
        .SetScope("email")
        .SetRedirectUrl("http://localhost:5128/api/oauth") // only use this now
        .SetCustomQuery("grant_type", "authorization_code", QueryFor.GetAccessToken))
;
```

### Third Add in Di (for asp.net)

```cs
builder.Services.AddOAuths<OAuthEntity,RepositoryOauth, StrategyToken>(oAuths);
```

where OAuthEntity,RepositoryOauth, StrategyToken you must make implementation

### now is work ONLY Telegram bot or you must take requests by myself

example is here
https://github.com/nt-devilboi/TelegramBot/tree/dev/TgBot
