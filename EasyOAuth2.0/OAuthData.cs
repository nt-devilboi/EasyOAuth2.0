using EasyOAuth.Extensions;

namespace EasyOAuth;

public class OAuthData // по идей можно сделать internal, если будет в виде либы
{
    public string AuthUri { get; set; }
    public string GetAccessTokenUri { get; set; }

    private readonly Dictionary<string, QueryOAuth> QueryOAuths = new(); 

    public bool Contains(string queryName)
    {
        return QueryOAuths.ContainsKey(queryName);
    }

    public void AddQuery(string queryName, string value, QueryFor queryFor)
    {
        QueryOAuths.Add(queryName, new QueryOAuth(queryName, value, queryFor));
    }

    public IEnumerable<string> GetOAuthRequestQueries()
    {
        return QueryOAuths
            .Where(query => query.Value.Type is QueryFor.CreateRequest or QueryFor.All)
            .Select(query => query.Value.QueryName.AddQuery(query.Value.Value));
    }

    public IEnumerable<string> GetAccessTokenQueries()
    {
        return QueryOAuths
            .Where(query => query.Value.Type is QueryFor.GetAccessToken or QueryFor.All)
            .Select(x => x.Value.QueryName.AddQuery(x.Value.Value));
    }
}