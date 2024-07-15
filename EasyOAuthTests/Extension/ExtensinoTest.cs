using EasyOAuth.Abstraction;
using EasyOAuth.Constructor;
using EasyOAuth.Extensions;
using EasyOAuthTests.FakeOAuth;

namespace EasyOAuthTests.Extension;

public static class ExtensionTests
{
    public static void AddFakeOAuth(this IRegisterOAuth oAuths, IFakeOAuth fakeOAuth)
    {
        oAuths.AddVk(_ =>
            _.SetScope(fakeOAuth.Scope)
                .SetClientId(fakeOAuth.ClientId)
                .SetClientSecret(fakeOAuth.ClientSecret)
                .SetRedirectUrl(fakeOAuth.RedirectUri));
    }
}