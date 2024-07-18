namespace EasyOAuth.Abstraction;

public interface IProvideOAuth
{
    public IReadOnlyDictionary<string, IOauthDataFormatter> GetAll { get; }
    public IOauthDataFormatter GetOAuth(string name);
}