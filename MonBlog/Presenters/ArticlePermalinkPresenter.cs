using MonBlog.Models;

namespace MonBlog.Presenters;

internal record ArticlePermalinkPresenter
{
    public string Html { get; }

    public ArticlePermalinkPresenter(Article articleToPresent)
    {
        Html = $"<li><a href=\"/articles/{articleToPresent.Permalink}\">{articleToPresent.Titre}</a></li>";
    }
}