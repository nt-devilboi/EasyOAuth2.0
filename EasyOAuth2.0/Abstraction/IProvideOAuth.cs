namespace EasyOAuth.Abstraction;

public interface IProvideOAuth
{
    public IReadOnlyDictionary<string, IOauthRequests> GetAll { get; }
    public IOauthRequests GetOAuth(string name);
}