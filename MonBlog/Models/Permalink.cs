using System.Text.RegularExpressions;

namespace MonBlog.Models;

public record Permalink
{
    private static readonly Regex PermalinkRegex = new ("^[0-9a-z-]{6,64}$");
    public string Value { get; }

    public Permalink(string rawValue)
    {
        if (!PermalinkRegex.IsMatch(rawValue)) 
            throw new ArgumentException("Ce n'est pas un permalien valide !", nameof(rawValue));

        if(rawValue.Contains("--"))
            throw new ArgumentException("Ce n'est pas un permalien valide !", nameof(rawValue));

        Value = rawValue;
    }
}