namespace MonBlog.Models;

public record Article(string Permalink, string Titre, string Content, string ConfidentialData);

public record ArticleOutputContract
{
    public string Permalink { get; }
    public string Titre { get; }
    public string Content { get; }

    public ArticleOutputContract(Article article)
    {
        Permalink = article.Permalink;
        Titre = article.Titre;
        Content = article.Content;
    }
}