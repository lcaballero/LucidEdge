using System;
using System.Linq;
using System.Reflection;
using LucidEdge.Html.ViewOrganization.Controllers.ActionFilters;
using LucidEdge.Html.ViewOrganization.Rendering;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;


namespace LucidEdge.ResourceCombining
{
	/// <summary>
	/// - Load the Assembly and find all the Types.
	/// 
	///		- Of the Types find the types that Inherit from Mvc.Controller
	///		- Find the Actions where the [Scripts, Styles] attribute is used.
	///		- Takes all the Paths from those attributes and combine them into a
	///			single file for the action.
	///
	///		/Sites/Web-App-Root/							-- where the web-app dll is at.
	///		/Sites/Web-App-Root/Content/					-- where scripts and styles are kept.
	///		/Sites/Web-App-Root/Content/CombinedScripts/	-- where combined files are output.
	///		/Sites/Web-App-Root/Content/CombinedStyles/		-- where combined files are output.
	///		
	///		~/												-- resolves to: /Sites/Web-App-Root/
	///		~/Content/Scripts/jquery-1.7.1.js
	///			-- resolves to:
	///		/Sites/Web-App-Root/Content/Scripts/jquery-1.7.1.js
	///		
	///		~/Content/Package/Controller/Action.combined.js
	///			-- resolves to: 
	///		/Sites/Web-App-Root/Content/Package/Controller/Action.combined.js
	/// </summary>
	public class Program
	{
		public static void Main(string[] args)
		{
		}

		private static void Test1()
		{
			InitializeResolver(CreateFlags());

			var paths = new List<string>
			{
				@"~/Content/Scripts/jquery-1.7.2.min.js",
				@"~/Content/Scripts/jquery-url-parse.js",
				@"~/Content/Scripts/string.extensions.js",
			};

			var full_paths = paths.Select(p => p.ResolveUrl()).ToList();
			var hashed = paths.NamesAndTimes();

			Console.WriteLine(hashed);
		}

		private static void Fox()
		{
			var flags = CreateFlags();
			InitializeResolver(flags);

			var resource_attributes = Assembly.LoadFile(flags.WebAppDll);

			var cr = new ContentResolver { ContentDir = flags.WebAppRoot };

			resource_attributes
				.FindControllers()
				.FindAttributes<ScriptsAttribute>()
				.CombineFiles(cr);
		}

		public static Flags CreateFlags()
		{
			return
			new Flags
			{
				WebAppDll = @"C:\Site\CS_Projects\GurpsCharacterSheet\bin\GurpsCharacterSheet.dll",
				WebAppRoot = @"C:\Site\CS_Projects\GurpsCharacterSheet\",
				ScriptsOutputDirectory = @"C:\Site\CS_Projects\GurpsCharacterSheet\Content\CombinedScripts\",
				StylesOutputDirectory = @"C:\Site\CS_Projects\GurpsCharacterSheet\Content\CombinedStyles\"
			};
		}

		public static void InitializeResolver(Flags f)
		{
			UrlResolver.HrefResolver =
				new Lazy<IPathResolver>(
					() =>
					new ContentResolver
					{
						ContentDir = f.WebAppRoot
					});
		}
	}
}
