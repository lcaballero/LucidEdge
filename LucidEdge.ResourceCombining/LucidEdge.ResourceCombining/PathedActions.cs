using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using LucidEdge.Html.ViewOrganization.Controllers.ActionFilters;



namespace LucidEdge.ResourceCombining
{
	public class PathedActions
	{
		public Type Controller { get; set; }
		public Type PathedType { get; set; }
		public MethodInfo Method { get; set; }
		public ResourceCollectionAttribute PathedAttribute { get; set; }

		public List<string> Paths
		{
			get
			{
				return
				PathedAttribute == null
					? new List<string>()
					: PathedAttribute.Paths;
			}
		}

		public string ActionPath
		{
			get
			{
				return
				Controller == null || Method == null
					? ""
					: string.Format("~/{0}/{1}", Controller.Name, Method.Name);
			}
		}
	}
}
