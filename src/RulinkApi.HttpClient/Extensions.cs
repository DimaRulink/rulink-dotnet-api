namespace RulinkApi.HttpClient;

public static class Extensions
{
    public static string UrlCombine(this string url, string path)
    {
        if (string.IsNullOrEmpty(url))
            return path;
        if (string.IsNullOrEmpty(path))
            return url;
        return $"{url.TrimEnd('/')}/{path.TrimStart('/')}";
    }
}