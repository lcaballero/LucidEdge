using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LucidEdge.StringBuilding.DifferenceEngine
{
	/**
	 * Class representing one diff operation.
	 */
	public class Diff
	{
		public Operation operation;

		// One of: INSERT, DELETE or EQUAL.
		public string text;

		// The text associated with this diff operation.

		/**
		 * Constructor.  Initializes the diff with the provided values.
		 * @param operation One of INSERT, DELETE or EQUAL.
		 * @param text The text being applied.
		 */
		public Diff(Operation operation, string text)
		{
			// Construct a diff with the specified operation and text.
			this.operation = operation;
			this.text = text;
		}

		/**
		 * Display a human-readable version of this Diff.
		 * @return text version.
		 */
		public override string ToString()
		{
			string prettyText = this.text.Replace('\n', '\u00b6');
			return "Diff(" + this.operation + ",\"" + prettyText + "\")";
		}

		/**
		 * Is this Diff equivalent to another Diff?
		 * @param d Another Diff to compare against.
		 * @return true or false.
		 */
		public override bool Equals(Object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Diff return false.
			Diff p = obj as Diff;
			if ((System.Object)p == null)
			{
				return false;
			}

			// Return true if the fields match.
			return p.operation == this.operation && p.text == this.text;
		}

		public bool Equals(Diff obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// Return true if the fields match.
			return obj.operation == this.operation && obj.text == this.text;
		}

		public override int GetHashCode()
		{
			return text.GetHashCode() ^ operation.GetHashCode();
		}
	}
}
