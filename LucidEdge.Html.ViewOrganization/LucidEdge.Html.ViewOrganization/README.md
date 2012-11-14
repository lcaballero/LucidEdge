LucidEdge.Html.ViewOrganization
===============================

ViewOrganization is a library that contains common "base class" code for
web sites.  For instance, `DefaultController` contains an action meant to
render an `IDocument`.


A typical Action might look something like the code below, which uses other
parts of the library, namely the `Styles` and `Scripts` Attributes.

```
	[Styles(
		"~/Content/bootstrap/css/bootstrap.css",
		"~/Content/Styles/Users.css")]
	[Scripts("~/Content/Scripts/jquery-1.8.2.min.js")]
	public ActionResult ReadAll()
	{
		var model = new Model();

		var doc = new AppDocument
		{
			Content = new Page
			{
				Model = model,
				ActiveAction= "ReadAll"
			}
		};

		return Content(doc);
	}
```

