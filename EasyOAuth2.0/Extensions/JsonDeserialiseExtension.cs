using System.Text.Json;
using Newtonsoft.Json;

namespace EasyOAuth;

public static class JsonDeserializeExtension
{
    public static async Task<T?> JsonDeserialize<T>(this HttpContent httpContent)
    {
        var dataJson = await httpContent.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(dataJson);
    }
    
    public static async Task<string?> JsonDeserializeAccessToken(this HttpContent httpContent)
    {
        var dataJson = await httpContent.ReadAsStringAsync();
        
        var x = JsonDocument.Parse(dataJson).RootElement;
        var token = x.GetProperty("access_token").GetString();

        return token;
    }
}