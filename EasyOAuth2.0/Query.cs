namespace EasyOAuth;

public record QueryOAuth
{
    public QueryOAuth(string queryName, string value, QueryFor type)
    {
        QueryName = queryName;
        Value = value;
        Type = type;
    }

    public string QueryName { get; }
    public string Value { get; }
    public QueryFor Type { get; }
}