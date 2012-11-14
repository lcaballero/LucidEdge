namespace LucidEdge.ResourceCombining
{
	/// <summary>
	/// The parsed data of a command line.  The command line would control things like
	/// the location of the input WebAppDll, the WebAppRoot, the output location for
	/// Script or Styles.
	/// 
	/// --web-app-dll					bin/debug/file.dll
	/// --web-app-root					application root to resolve ~/
	/// --scripts-output-directory		/Content/CombinedScripts/
	/// --styles-output-directory		/Content/CombinedStyles/
	/// --closure-compile				turn on closure javascript compiling
	/// --keys-file						C# file to generate with looks
	/// --combined-css-extention		Defaults to something like .combined.css
	/// --combined-js-extention			Defaults to something like .combined.js
	/// </summary>
	public class Flags
	{
		/// <summary>
		/// Location of the Web App DLL that is decorated with [Scripts], [Styles],
		/// [JavaScriptPackage], [StyleSheetPackage].
		/// </summary>
		public string WebAppDll { get; set; }

		/// <summary>
		/// Directory where the web app will be served from, and which resolves to ~/.
		/// </summary>
		public string WebAppRoot { get; set; }

		/// <summary>
		/// Directory where combined script files will be output
		/// (~/Content/CombinedScripts/) typically in this format
		/// ~/Content/CombinedScripts/Controller/Action.combined.js
		/// </summary>
		public string ScriptsOutputDirectory { get; set; }

		/// <summary>
		/// Directory where combined script files will be output 
		/// (~/Content/CombinedStyles/) typically in this
		/// format ~/Content/CombinedStyles/Controller/Action.combined.css
		/// </summary>
		public string StylesOutputDirectory { get; set; }
	}
}
