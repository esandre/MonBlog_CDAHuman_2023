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

        var selected = html.DocumentNode.QuerySelector(cssSelector);
        Contains(expectedInnerText, selected.InnerText);
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