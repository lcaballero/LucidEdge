LucidEdge.Html v0.0.1
=====================

This project is a library of extensions that produce Html Parts (Elements, Fragments, Text Nodes).

Example:
--------

```C#
public IHtml RenderDocument(IHtml content)
{
	return
	"html".Add(
		"head".Add(
			"title".Add("Title")
		"body".Add(
			"div".Add(
				"h1".Add("The first header"),
				"a".Attr("href", "http://www.google.com"))
			content)));
}
```

```C#
public IHtml RenderNav(params string[] items)
{
	return
	"ul".Add(
		items.Select(
			s => "li".Add(s)));
}
```
