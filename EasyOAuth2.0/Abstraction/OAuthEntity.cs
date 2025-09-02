namespace EasyOAuth.Abstraction;

public abstract class OAuthEntity
{
    public Guid Id { get; set; }
    public string OAuthName { get; set; }
    public string State { get; set; }
}