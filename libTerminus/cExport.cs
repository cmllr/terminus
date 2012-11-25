// 
//  cExport.cs
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
using Gtk;

namespace libTerminus
{
	/// <summary>
	/// Export class for exporting the values to different filetypes
	/// </summary>
	public static class cExport
	{
		/// <summary>
		/// Exports to CSV.
		/// </summary>
		/// <returns>
		/// true if it worked; false if failed
		/// </returns>
		/// <param name='_pattern'>
		/// The pattern value
		/// </param>
		/// <param name='_source'>
		/// The used source value
		/// </param>
		/// <param name='_results'>
		/// The result of this pattern with the used source
		/// </param>
		public static bool exportToCSV (string _pattern, string _source, string _results)
		{
			try {
				string _path = "";
				if (_pattern != "" && _source != "" && _results != "") {
					_path = cTerminus.ShowSaveDialog (null, "CSV", "*.csv");
					string content = "";
					content += "Pattern;Data;Results";
					
					string[] resultarray = _results.Split(new char[] {'\n'});
					content += "\n" + _pattern + ";" + _source + ";" + resultarray[0] + "\n";
					for (int i = 1; i < resultarray.Length- 1; i++)
					{
						content += ";;" + resultarray[i] +"\n";
					}
					System.IO.File.WriteAllText (_path, content);
					return true;					
				} else {
					MessageBox.Show ("Beim Export ins *.csv - Format ist ein Fehler aufgetreten", "Fehler", ButtonsType.Ok, MessageType.Error);
					return false;
				}
			} catch (Exception ex){
				return false;
			}
		}
		/// <summary>
		/// Exports to text.
		/// </summary>
		/// <returns>
		/// true if it worked; false if failed
		/// </returns>
		/// <param name='_pattern'>
		/// The pattern value
		/// </param>
		/// <param name='_source'>
		/// The used source value
		/// </param>
		/// <param name='_results'>
		/// The result of this pattern with the used source
		/// </param>
		public static bool exportToText (string _pattern, string _source, string _results)
		{
			try {
				string _path;
				if (_pattern != "" && _source != "" && _results != "") {
					_path = cTerminus.ShowSaveDialog (null, "Textdateien", "*.txt");
					string content = "";
					content += "----Pattern----\n" + _pattern + "\n";
					content += "----Data:----\n" + _source + "\n";
					content += "----Results----\n";
					content += _results;
					System.IO.File.WriteAllText (_path, content);
					return true;					
				} else {
					MessageBox.Show ("Beim Export ins *.txt - Format ist ein Fehler aufgetreten", "Fehler", ButtonsType.Ok, MessageType.Error);
					return false;
				}
			} catch {
				return false;
			}
		}
		/// <summary>
		/// Exports to hypertext.
		/// </summary>
		/// <returns>
		/// true if it worked; false if failed
		/// </returns>
		/// <param name='_pattern'>
		/// The pattern value
		/// </param>
		/// <param name='_source'>
		/// The used source value
		/// </param>
		/// <param name='_results'>
		/// The result of this pattern with the used source
		/// </param>
		public static bool exportToHypertext (string _pattern, string _source, string _results)
		{
			try {
				string _path;
				if (_pattern != "" && _source != "" && _results != "") {
					_path = cTerminus.ShowSaveDialog (null, "Textdateien", "*.html");
					string content = "";
					//begin of html file
					
					content += @"<html><head><title>Export</title><meta http-equiv='content-type' content='text/html; charset=ISO-8859-1'><META NAME='Generator' CONTENT='" + cTerminus.g_programName + "'></head><body>";
					content += @"<h2>Pattern</h2>";
					content += _pattern + "<p>";
					content += @"<h2>Data</h2>";
					content += _source + "<p>";
					content += @"<h2>Results</h2>";
					content += _results.Replace("\n","<p>") + "<p>";
					content += @"</body></html>";
					System.IO.File.WriteAllText (_path, content,System.Text.Encoding.Default);
					return true;					
				} else {
					MessageBox.Show ("Beim Export ins *.txt - Format ist ein Fehler aufgetreten", "Fehler", ButtonsType.Ok, MessageType.Error);
					return false;
				}
			} catch {
				return false;
			}
		}
	}
}

