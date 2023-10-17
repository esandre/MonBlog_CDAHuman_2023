using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

// ReSharper disable once CheckNamespace
namespace Xunit;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Assert
{
    public static void HtmlContainsAt(string expectedInnerText, Stream documentStream, string cssSelector)
    {
        var html = new HtmlDocument();
        html.Load(documentStream);

        var selected = html.DocumentNode.QuerySelector("body>h1");
        Contains(expectedInnerText, selected.InnerText);
    }
}