using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

// ReSharper disable once CheckNamespace
namespace Xunit;

// ReSharper disable once ClassNeverInstantiated.Global
public partial class Assert
{
    public static void HtmlContainsAt(string expectedInnerText, string documentContent, string cssSelector)
    {
        var html = new HtmlDocument();
        html.LoadHtml(documentContent);

        var selected = html.DocumentNode.QuerySelectorAll(cssSelector);
        Assert.Contains(selected, node => node.InnerText == expectedInnerText);
    }

    public static void HtmlAttributeHasValue(string expectedValue, string documentContent, string cssSelector, string attributeName)
    {
        var html = new HtmlDocument();
        html.LoadHtml(documentContent);

        var selected = html.DocumentNode.QuerySelectorAll(cssSelector);
        Assert.Contains(selected, node => node.GetAttributeValue(attributeName, string.Empty) == expectedValue);
    }

    public static void CountChildrenOfType(
        ushort expectedNumber, 
        Stream documentStream, 
        string parentSelector, 
        string childType)
    {
        var html = new HtmlDocument();
        html.Load(documentStream);

        var selected = html.DocumentNode.QuerySelector(parentSelector);
        Equal(expectedNumber, selected.ChildNodes.Count(child => child.Name == childType));
    }
}