using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LucidEdge.SimpleLineParser
{
	/// <summary>
	/// Functions for parsing text and files of lines that follow this format
	/// 
	/// # Lines that start with '#' are comments
	/// And lines that don't are considered source lines, and
	/// 
	/// empty lines are consider non-essential and not returned by parse methods.
	/// 
	/// </summary>
	public static class LinesReader
	{
		/// <summary>
		/// Takes the path reads the lines from the file and parses them so that
		/// only lines that are not comment lines (starting with #) and empty lines
		/// (those with only whitespace) are filtered from the output enumerable.
		/// </summary>
		/// <param name="text">
		/// A text file to open, read the lines and parse.
		/// </param>
		/// <returns>
		/// The lines of the file minus comments and empty lines.
		/// </returns>
		public static IEnumerable<string> Parse(TextReader text)
		{
			return
			ReadLines(text).Where(s => !s.IsCommentLine() && !s.IsEmptyLine());
		}

		/// <summary>
		/// Takes the path reads the lines from the file and parses them so that
		/// only lines that are not comment lines (starting with #) and empty lines
		/// (those with only whitespace) are filtered from the output enumerable.
		/// </summary>
		/// <param name="text">
		/// A text file to open, read the lines and parse.
		/// </param>
		/// <returns>
		/// The lines of the file minus comments and empty lines.
		/// </returns>
		public static IEnumerable<string> Parse(string text)
		{
			return
			ToLines(text).Where(s => !s.IsCommentLine() && !s.IsEmptyLine());
		}

		/// <summary>
		/// Turns the given text into an IEnumerable of lines which can be
		/// further processed to determine if they are comments or empty lines, etc.
		/// </summary>
		/// <param name="text">
		/// Contents of a file or simply a string in a line entry fashion.
		/// </param>
		/// <returns>
		/// An enumeration of lines found in the text.
		/// </returns>
		public static IEnumerable<string> ToLines(this string text)
		{
			StringReader wr = new StringReader(text);
			return ReadLines(wr);
		}

		/// <summary>
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static IEnumerable<string> ReadLines(string path)
		{
			if (!File.Exists(path))
			{
				return new List<string>();
			}

			using (TextReader tr = new StreamReader(path))
			{
				return ReadLines(tr);
			}
		}

		/// <summary>
		/// Reads over the TextReader, and produces lines of text.
		/// </summary>
		/// <param name="tr">
		/// A TextReader over a string or file, etc.
		/// </param>
		/// <returns>
		/// All (unfiltered) lines found by iterating the lines
		/// from the text reader.
		/// </returns>
		public static IEnumerable<string> ReadLines(TextReader tr)
		{
			string line = null;

			while ((line = tr.ReadLine()) != null)
			{
				yield return line;
			}
		}

		/// <summary>
		/// Determines if the line is empty, iff the string contains whitespace
		/// and those white space characters are not line termination characters.
		/// </summary>
		/// <param name="s">
		/// 
		/// </param>
		/// <returns></returns>
		public static bool IsEmptyLine(this string s)
		{
			return s != null && (s == "" || s.All(c => char.IsWhiteSpace(c) && c != '\n' && c != '\r'));
		}

		/// <summary>
		/// Determines if the line is a comment, which is to say that the first non-whitespace
		/// character on the line is # characters.
		/// </summary>
		/// <param name="s">
		/// A line that is possibly a comment line.
		/// </param>
		/// <returns>
		/// truee if the first non-whitespace character is the #.
		/// </returns>
		public static bool IsCommentLine(this string s)
		{
			return
			!string.IsNullOrEmpty(s)
			&& s.SkipWhile(c => char.IsWhiteSpace(c))
				.Take(1)
				.Cast<char?>()
				.All(c => c.HasValue && c.Value == '#');
		}
	}
}
