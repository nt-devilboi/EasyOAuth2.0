using EasyOAuth.Extensions;

namespace EasyOAuth;

internal class OAuthData // по идей можно сделать internal, если будет в виде либы
{
    private readonly Dictionary<string, QueryOAuth> QueryOAuths = new();
    public string AuthUri { get; set; }
    public string GetAccessTokenUri { get; set; }

    public bool Contains(string queryName)
    {
        return QueryOAuths.TryGetValue(queryName, out var value) && !string.IsNullOrEmpty(value.Value);
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