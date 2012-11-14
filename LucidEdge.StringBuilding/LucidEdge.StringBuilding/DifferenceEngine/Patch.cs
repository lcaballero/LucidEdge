using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LucidEdge.StringBuilding.DifferenceEngine
{
	/**
	 * Class representing one patch operation.
	 */
	public class Patch
	{
		public List<Diff> diffs = new List<Diff>();
		public int start1;
		public int start2;
		public int length1;
		public int length2;

		/**
		 * Emmulate GNU diff's format.
		 * Header: @@ -382,8 +481,9 @@
		 * Indicies are printed as 1-based, not 0-based.
		 * @return The GNU diff string.
		 */
		public override string ToString()
		{
			string coords1, coords2;
			if (this.length1 == 0)
			{
				coords1 = this.start1 + ",0";
			}
			else if (this.length1 == 1)
			{
				coords1 = Convert.ToString(this.start1 + 1);
			}
			else
			{
				coords1 = (this.start1 + 1) + "," + this.length1;
			}
			if (this.length2 == 0)
			{
				coords2 = this.start2 + ",0";
			}
			else if (this.length2 == 1)
			{
				coords2 = Convert.ToString(this.start2 + 1);
			}
			else
			{
				coords2 = (this.start2 + 1) + "," + this.length2;
			}
			StringBuilder text = new StringBuilder();
			text.Append("@@ -").Append(coords1).Append(" +").Append(coords2)
				.Append(" @@\n");
			// Escape the body of the patch with %xx notation.
			foreach (Diff aDiff in this.diffs)
			{
				switch (aDiff.operation)
				{
					case Operation.INSERT:
						text.Append('+');
						break;
					case Operation.DELETE:
						text.Append('-');
						break;
					case Operation.EQUAL:
						text.Append(' ');
						break;
				}

				text.Append(HttpUtility.UrlEncode(aDiff.text,
					new UTF8Encoding()).Replace('+', ' ')).Append("\n");
			}

			return DiffMatchPatch.unescapeForEncodeUriCompatability(
				text.ToString());
		}
	}
}
