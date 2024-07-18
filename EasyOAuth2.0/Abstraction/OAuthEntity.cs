namespace EasyOAuth.Abstraction;

public abstract class OAuthEntity
{
    public string OAuthName { get; set; }
    public string State { get; set; }
}