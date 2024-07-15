namespace EasyOAuth.Abstraction;

public abstract class IStrategyToken
{
    public abstract Task Execute(string token, OAuthEntity data);
}