using System.Text.RegularExpressions;

namespace MonBlog.Models;

public record Permalink
{
    private static readonly Regex PermalinkRegex = new ("^[a-z0-9-]{2,36}$");

    public Permalink(string Value)
    {
        if (!PermalinkRegex.IsMatch(Value))
            throw new ArgumentOutOfRangeException(nameof(Value),
                "Un permalien fait de 2 à 36 caractères, seulement des lettres minuscules, des chiffres et des tirets (-)");

        this.Value = Value;
    }

    public string Value { get; }
}