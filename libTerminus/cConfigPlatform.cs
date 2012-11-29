// 
//  cConfigPlatform.cs
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
using System.IO;
namespace libTerminus
{
	/// <summary>
	/// The Config Platform.
	/// </summary>
	/// <exception cref='ApplicationException'>
	/// <see cref="T:System.ApplicationException" /> is the base class for all exceptions defined by applications.
	/// </exception>
	public class cConfigPlatform
	{		
		#region "Member Values or Get/Setters"
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cConfigPlatform"/> ignore case.
		/// </summary>
		/// <value>
		/// <c>true</c> if ignore case; otherwise, <c>false</c>.
		/// </value>
		public bool IgnoreCase { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cConfigPlatform"/> is explicit.
		/// </summary>
		/// <value>
		/// <c>true</c> if explicit; otherwise, <c>false</c>.
		/// </value>
		public bool Explicit { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cConfigPlatform"/> ignore whitespace.
		/// </summary>
		/// <value>
		/// <c>true</c> if ignore whitespace; otherwise, <c>false</c>.
		/// </value>
		public bool IgnoreWhitespace { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cConfigPlatform"/> use syntax.
		/// </summary>
		/// <value>
		/// <c>true</c> if use syntax; otherwise, <c>false</c>.
		/// </value>
		public bool useSyntax { get; set; }
		/// <summary>
		/// Gets or sets the conf file.
		/// </summary>
		/// <value>
		/// The conf file.
		/// </value>
		public string ConfFile { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cConfigPlatform"/> hide text.
		/// </summary>
		/// <value>
		/// <c>true</c> if hide text; otherwise, <c>false</c>.
		/// </value>
		public bool HideText { get; set; }
		/// <summary>
		/// Gets or sets the language.
		/// </summary>
		/// <value>
		/// The language.
		/// </value>
		public string Language { get; set; }
		/// <summary>
		/// Gets or sets the theme.
		/// </summary>
		/// <value>
		/// The theme.
		/// </value>
		public string Theme {get;set;}
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cConfigPlatform"/> reduce syntax changing.
		/// </summary>
		/// <value>
		/// <c>true</c> if reduce syntax changing; otherwise, <c>false</c>.
		/// </value>
		public bool ReduceSyntaxChanging {get;set;}
		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cConfigPlatform"/> class.
		/// </summary>
		/// <param name='_confFileName'>
		/// Conf file name.
		/// </param>
		/// <exception cref='ApplicationException'>
		/// <see cref="T:System.ApplicationException" /> is the base class for all exceptions defined by applications.
		/// </exception>
		public cConfigPlatform (string _confFileName)
		{
			try {
				//set the config member
				ConfFile = _confFileName;
				//Get the values using an regular expression.
				String rgx = @"ExplicitCapture;(?<ec>[a-z]*)\nIgnoreCase;(?<ic>[a-z]*)\nIgnoreWhitespace;(?<iw>[a-z]*)\nUseSyntax;(?<useSyntax>[a-z]*)\nHideText;(?<hide>[a-z]*)\nLanguage;(?<language>[a-z]*)\nTheme;(?<theme>[a-z]*)\nreducesyntaxchanging;(?<reducesyntaxchanging>[a-z]*)";
				Regex _rgx = new Regex (rgx, RegexOptions.IgnoreCase);

				MatchCollection matches = _rgx.Matches (File.ReadAllText (_confFileName));
				foreach (Match mt in matches) {
					Explicit = Boolean.Parse (mt.Groups ["ec"].Value);
					IgnoreCase = Boolean.Parse (mt.Groups ["ic"].Value);
					IgnoreWhitespace = Boolean.Parse (mt.Groups ["iw"].Value);
					useSyntax = Boolean.Parse (mt.Groups ["useSyntax"].Value);
					HideText = Boolean.Parse (mt.Groups ["hide"].Value);
					Language = mt.Groups ["language"].Value;
					Theme = mt.Groups["theme"].Value;
					ReduceSyntaxChanging = Boolean.Parse(mt.Groups["reducesyntaxchanging"].Value);
				}
			} catch (Exception ex) {
				throw new ApplicationException ("Exception due incorrect config file", ex);
			}
		}
		/// <summary>
		/// Display this instance.
		/// </summary>
		public string Display ()
		{
			return "";
		}
		/// <summary>
		/// Save the content of the config file
		/// </summary>
		public void Save ()
		{		
			File.WriteAllText (ConfFile, String.Format ("ExplicitCapture;{0}\nIgnoreCase;{1}\nIgnoreWhitespace;{2}\nUseSyntax;{3}\nHideText;{4}\nLanguage;{5}\nTheme;{6}\nreducesyntaxchanging;{7}", Explicit, IgnoreCase, IgnoreWhitespace, useSyntax, HideText, Language,Theme,ReduceSyntaxChanging));
		}
	}
}

