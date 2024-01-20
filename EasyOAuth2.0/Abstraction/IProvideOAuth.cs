namespace EasyOAuth.Abstraction;


public interface IProvideOAuth
{
    public IOauthRequests GetOAuth(string name);

    public IReadOnlyDictionary<string, IOauthRequests> GetAll { get; }
    
    
}