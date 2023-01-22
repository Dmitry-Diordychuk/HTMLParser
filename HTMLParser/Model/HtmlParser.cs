using System.Collections;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Linq;

namespace HTMLParser.Model;

public class HtmlParser
{
	private readonly HtmlDocument _htmlDoc;
	
	public HtmlParser(string html)
	{
		_htmlDoc = new HtmlDocument();
		_htmlDoc.LoadHtml(html);
	}

	public string[] Parse(IEnumerable<HtmlElement> elements, HtmlAttribute attribute)
	{
		string xpath = GenerateXPath(elements);
		return _htmlDoc.DocumentNode
			.SelectNodes(xpath)
			.Where(x => x.Attributes.Contains(attribute.Name))
			.Select(x => x.Attributes[attribute.Name].Value)
			.ToArray();
	}

	public string[] Parse(IEnumerable<HtmlElement> elements)
	{
		string xpath = GenerateXPath(elements);
		return _htmlDoc.DocumentNode
			.SelectNodes(xpath)
			.Select(x => x.InnerText)
			.ToArray();
	}

	private string GenerateXPath(IEnumerable<HtmlElement> elements)
	{
		return "/" + elements.Select(x => x.Name).Aggregate((s, s1) => s + s1);
	}
}