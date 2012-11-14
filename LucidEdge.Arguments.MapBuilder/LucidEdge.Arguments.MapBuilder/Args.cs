using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.Arguments.MapBuilder
{
	public class Args
	{
		public virtual object Entry { get; set; }
		public virtual Args Parent { get; protected set; }
		public virtual bool IsRoot { get { return Parent == null; } }

		private bool IsSentry { get; set; }

		public Args()
		{
			Entry = "";
			IsSentry = true;
		}

		public Args this[object entry]
		{
			get
			{
				if (entry == null)
				{
					throw new ArgumentException(
						"Args does not accept entry of null.");
				}

				return
				new Args
				{
					Parent = this,
					Entry = entry,
					IsSentry = false
				};
			}
		}

		public override string ToString()
		{
			return ToString(this);
		}

		private static string ToString(Args curr)
		{
			var root = curr;
			var buff = new StringBuilder();

			while (root != null)
			{
				buff.Insert(0, root.Entry.ToString());

				root = root.Parent;

				if (root != null && !root.IsSentry)
				{
					buff.Insert(0, ".");
				}
			}

			return buff.ToString();
		}
	}
}
