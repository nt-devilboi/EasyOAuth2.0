namespace EasyOAuth.Abstraction;

public abstract class TokenLinkRepositoryBase
{
    public abstract Task Add(string Oauth, string state, string id);
    public abstract Task<OAuthEntity> GetByExtraData(string extraData);
    public abstract Task<OAuthEntity> GetByState(string state);
    public abstract Task Remove(OAuthEntity oAuthEntity);
}