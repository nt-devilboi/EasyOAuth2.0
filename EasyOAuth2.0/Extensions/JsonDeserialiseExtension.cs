using System.Text.Json;

namespace EasyOAuth.Extensions;

public static class JsonDeserializeExtension
{
    public static async Task<string?> JsonDeserializeAccessToken(this HttpContent httpContent)
    {
        var dataJson = await httpContent.ReadAsStringAsync();

        var x = JsonDocument.Parse(dataJson).RootElement;
        var token = x.GetProperty("access_token").GetString();

        return token;
    }
}