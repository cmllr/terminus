// 
//  cDebugger.cs
//  
//  Author:
//       christoph <fury@gtkforum.php-friends.de>
//  
//  Copyright (c) 2012 christoph
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Text.RegularExpressions;
namespace libTerminus
{
	/// <summary>
	/// Debugger class
	/// </summary>
	public class cDebugger
	{
		#region "Member Values or Get/Setters"
		/// <summary>
		/// The g_ expression.
		/// </summary>
		public string g_Expression;
		/// <summary>
		/// The g_ data.
		/// </summary>
		public string g_Data;
		/// <summary>
		/// The g_ result.
		/// </summary>
		public string g_Result;
		/// <summary>
		/// Is the debugger running?
		/// </summary>
		public bool g_IsRunning;
		/// <summary>
		/// The currentresult.
		/// </summary>
		public string g_CurrentResult;
		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cDebugger"/> class.
		/// </summary>
		/// <param name='Expression'>
		/// Expression.
		/// </param>
		/// <param name='Data'>
		/// Data.
		/// </param>
		public cDebugger (string Expression, string Data)
		{
			g_Expression = Expression;
			g_Data = Data;
		}
		/// <summary>
		/// Debug the specified start and end.
		/// </summary>
		/// <param name='start'>
		/// Start.
		/// </param>
		/// <param name='end'>
		/// End.
		/// </param>
		public void Debug (int start, int end)
		{
			g_IsRunning = true;
			int BracketCountRound = count (g_Expression, '(') + count (g_Expression, ')');
			int BracketCountCorned = count (g_Expression, '[') + count (g_Expression, ']');
			int BracketCountOthers = count (g_Expression, '{') + count (g_Expression, '}');
			string ExtractedExpression = g_Expression.Substring (start, end - start);
		
			foreach (Match mt in new Regex(ExtractedExpression).Matches(g_Data))
				g_Result += mt.Value;		
			g_IsRunning = false;
		}
		/// <summary>
		/// Count the specified expression and needle.
		/// </summary>
		/// <param name='expression'>
		/// Expression.
		/// </param>
		/// <param name='needle'>
		/// Needle.
		/// </param>
		public int count (string expression, char needle)
		{
			int results = 0;
			foreach (char c in expression.ToCharArray()) {
				if (c == needle)
					results++;
			}			
			return results;
		}
	}
}

