Generates this class:

- Load the Assembly and find all the Types.
	- Of the Types find the types that Inherit from Mvc.Controller
	- Find the Actions where the [Scripts, Styles] attribute is used.
	- Takes all the Paths from those attributes and combine them into a
		single file for the action.
	- Create a file in the form of /Controller/Action.combined.js
	- Write to:
			/CombinedJss/Controller/Action.combined.js
			/CombinedCss/Controller/Action.combined.css
	- Map the paths for resources in the form of:
			/Resource/Map/[key]/Content/CombinedJs/Controller/Action.combined.js
			/Resource/Map/[key]/Content/CombinedCss/Controller/Action.combined.css

<combined-resources>
	<caches>
		<cache>
			<assets>
				<asset-path>~/Content/Scripts/Packages/Controller/Action.css.package</asset-path>
			</assets>
			<action-path>~/Controller/Action/</action-path>
			<hash>[some-key]</hash>
			<combined-source>
/* Full text of the combined files. */
var a1 = true;
var b1 = true;
			</combined-source>
		</cache>
	</caches>
</combined-resources>