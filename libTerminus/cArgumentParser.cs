// 
//  cArgumentParser.cs
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

namespace libTerminus
{
	/// <summary>
	/// The argument parser.
	/// </summary>
	public class cArgumentParser
	{
		#region "Member Values or Get/Setters"
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cArgumentParser"/> allowed to run.
		/// </summary>
		/// <value>
		/// <c>true</c> if allowed to run; otherwise, <c>false</c>.
		/// </value>
		public bool AllowedToRun { get; set; }
		/// <summary>
		/// Gets or sets the file to open.
		/// </summary>
		/// <value>
		/// The file to open.
		/// </value>
		public string FileToOpen { get; set; }
		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cArgumentParser"/> class.
		/// </summary>
		/// <param name='_args'>
		/// Arguments.
		/// </param>
		/// <param name='_appVersion'>
		/// App version.
		/// </param>
		public cArgumentParser (string[] _args, string _appVersion)
		{
			AllowedToRun = true;
			for (int i = 0; i < _args.Length; i++) {
				if (_args [i] == "--v" || _args [i] == "--version") {
					Console.WriteLine ("{0} {1}", cTerminus.g_programName, _appVersion);
					AllowedToRun = false;
				} else if (_args [i] == "--h" || _args [i] == "--help") {
					cTerminus.PrintHelpText ();
					AllowedToRun = false;
				} else if (System.IO.File.Exists (_args [i])) {
					FileToOpen = _args [i];
				}else if (_args[i] == "--s" || _args[i] == "--nosyntax"){
					cTerminus.Configuration.useSyntax = false;
				}else if (_args[i] == "--c" || _args[i] == "--shell"){
					//TODO: Feature is still missing.
				} else {
					Console.WriteLine("Unknow Parameter: " + _args[i]);
					AllowedToRun = false;
				}
			}
		}
		/// <summary>
		/// Checks if an argument is member of the args array
		/// </summary>
		/// <returns>
		/// The arguments.
		/// </returns>
		/// <param name='_haystack'>
		/// If set to <c>true</c> arguments.
		/// </param>
		/// <param name='_needle'>
		/// If set to <c>true</c> needle.
		/// </param>
		public bool existsinArgs (string[] _haystack, string _needle)
		{
			bool find = false;

			foreach (string st in _haystack) {
				if (st == _needle) {
					find = true;
					break;
				}	
			}
			return find;
		}
	}
}

