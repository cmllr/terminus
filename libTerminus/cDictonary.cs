//
//  cDictonary.cs
//
//  Author:
//       christoph <fury@gtkforum.php-friends.de>
//
//  Copyright (c) 2013 christoph
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
using System.Collections.Generic;
using System.IO;
namespace libTerminus
{
	public class cDictonary
	{
		public string g_TranslationFileName { get; set; }
		public Dictionary<string,string> Values { get; set; }
		public cDictonary (string _TranslationFileName)
		{
			g_TranslationFileName = _TranslationFileName;
			foreach (string st in File.ReadAllLines(_TranslationFileName)) {
				string[] p_separated = st.Split (new char[] {';'});
				if (Values.ContainsKey (p_separated [0]) == false) {
					Values.Add (p_separated [0], p_separated [1]);
				}
			}
		}
		public String getValue (string _description, bool _explicit)
		{
			if (_explicit == false) {
				foreach (KeyValuePair<string,string> kvp in Values) {
					if (kvp.Key.ToLower ().Contains (_description.ToLower ())) {
						return kvp.Value;
					}
				}
			} else {
				if (Values.ContainsKey (_description))
					return Values [_description];
				else
					return "-1";
			}
			return "-1";
		}
	}
}

