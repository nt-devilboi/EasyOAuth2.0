namespace EasyOAuth.Abstraction;

public abstract class StrategyToken
{
    public abstract Task Execute(string token, OAuthEntity data);
}