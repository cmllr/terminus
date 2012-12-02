//
//  cShell.cs
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
	public class cShell
	{
		public string Phrase {get;set;}
		public RegexOptions Options {get;set;}
		public string Data  {get;set;}
		public ParsingMode Mode {get;set;}
		public cShell ()
		{
			runShell();
		}
		public void runShell()
		{
			string eingabe;
			do
			{
				Console.Write(">");
				eingabe = Console.ReadLine();
				Work(eingabe);
			}while (eingabe != "exit");
		}
		public void Work(string _command)
		{
			if (_command.Contains ("setphrase"))
			{
				string pattern = @"setphrase\s*(?<phrase>.*)";
				Regex rgx = new Regex(pattern);
				Phrase = rgx.Match(_command).Groups["phrase"].Value;
				Console.WriteLine("Set phrase \""+ Phrase + "\".");
			}
			else if (_command.Contains("getphrase"))
			{
				Console.WriteLine("Current phrase: \"" + Phrase + "\".");
			}
			else if (_command.Contains("setoptions"))
			{
				string pattern = @"setoptions\s*(?<options>.*)";
				Regex rgx = new Regex(pattern);
				string result  = rgx.Match(_command).Groups["options"].Value;

				foreach(RegexOptions rgxvalue in Enum.GetValues(typeof(RegexOptions)))
				{
					if (result.Contains(rgxvalue.ToString()))
					{
						Options = Options | rgxvalue;
					}
				}
			}
			else if (_command.Contains("setmode"))
			{
				string pattern = @"setmode\s*(?<mode>.*)";
				Regex rgx = new Regex(pattern);
				string result  = rgx.Match(_command).Groups["mode"].Value;
				
				foreach(ParsingMode rgxvalue in Enum.GetValues(typeof(ParsingMode)))
				{
					if (result.Contains(rgxvalue.ToString()))
					{
						Mode = Mode | rgxvalue;
					}
				}
			}
			else if (_command.Contains("getmode"))
			{
				Console.WriteLine(Mode.ToString());
			}
			else if (_command.Contains("getoptions"))
			{
				Console.WriteLine(Options.ToString());
			}
			else if (_command.Contains("removeoption"))
			{
				string pattern = @"removeoption\s*(?<option>.*)";
				Regex rgx = new Regex(pattern);
				string result  = rgx.Match(_command).Groups["option"].Value;
				RegexOptions _tmp = RegexOptions.None;
				foreach (RegexOptions opt in Enum.GetValues(typeof(RegexOptions)))
			    {
					if (result != opt.ToString())
					{
						string used = Options.ToString();
						//Console.WriteLine(used + ";" + opt.ToString());
						if (used.Contains(opt.ToString()))
							_tmp = _tmp | opt;
					}
				}
				Options = _tmp;
			}
			else if (_command.Contains("removemode"))
		    {
				string pattern = @"removemode\s*(?<option>.*)";
				Regex rgx = new Regex(pattern);
				string result  = rgx.Match(_command).Groups["option"].Value;
				//	Options = Options & (RegexOptions)Enum.Parse(typeof(RegexOptions),result);
				ParsingMode _tmp = ParsingMode.All;
				foreach (ParsingMode opt in Enum.GetValues(typeof(ParsingMode)))
				{
					if (result != opt.ToString())
					{
						string used = Mode.ToString();
						//Console.WriteLine(used + ";" + opt.ToString());
						if (used.Contains(opt.ToString()))
							_tmp = _tmp | opt;
					}
				}
				Mode = _tmp;
			}
			else if (_command.Contains("setdata"))
			{
				string pattern = @"setdata\s*(?<data>.*)";
				Regex rgx = new Regex(pattern);
				string result  = rgx.Match(_command).Groups["data"].Value;
				if (System.IO.File.Exists(result))
					Data = System.IO.File.ReadAllText(result,System.Text.Encoding.Default);
				else
					Data = result;
			}
			else if (_command.Contains("getdata"))
			{
				Console.WriteLine("----------------------------DATA--------------------------");
				Console.WriteLine(Data);
				Console.WriteLine("----------------------------DATA--------------------------");
			}
			else if (_command.Contains("listmodes"))
			{
				foreach (ParsingMode opt in Enum.GetValues(typeof(ParsingMode)))
				{
					Console.WriteLine(opt.ToString());
				}
			}
			else if (_command.Contains("listoptions"))
			{
				foreach(RegexOptions opt in Enum.GetValues(typeof(RegexOptions)))
				{
					Console.WriteLine(opt.ToString());
				}
			}
			else if (_command.Contains("parse"))
			{
				Regex neu = new Regex(Phrase,Options);
				if (neu.IsMatch(Data) == false)
					Console.WriteLine("No Matches!");
				else
				{
					int count = 0;
					string result ="";
					foreach (Match mt in neu.Matches(Data)) {
						result += "[" + count + "] " + mt.Value + "\n";
						count++;
						for (int i = 0; i < mt.Groups.Count; i++) {
							if (result.Contains ("[" + neu.GetGroupNames () [i] + "] " + mt.Groups [i].Value) == false)
								result += "-> [" + neu.GetGroupNames () [i] + "] " + mt.Groups [i].Value + "\n"; 
						}
					}
					Console.WriteLine(result);
				}
			}
			else if (_command.Contains("help"))
			{
				Console.WriteLine(cTerminus.g_programName + " help");
				Console.WriteLine("setphrase - set the regular expression to parse");
				Console.WriteLine("getphrase - print the regular expression to parse");
				Console.WriteLine("setoptions - set the RegexOptions - enumeration values");
				Console.WriteLine("setmode - set the ParsingMode - enumeration values");
				Console.WriteLine("getmode - list the currently used values for parsing modes");
				Console.WriteLine("getoptions - list the currently used values for regex options");
				Console.WriteLine("removeoption - remove a >single< option");
				Console.WriteLine("removemode - removes a mode");
				Console.WriteLine("setdata - set the data for parsing, if the file does exist, the content of the file is used");
				Console.WriteLine("getdata - print the data");
				Console.WriteLine("listmodes - list the avaiable modes");
				Console.WriteLine("listoptions - list the avaiable regex options");
				Console.WriteLine("parse - run the Parser");
			}
		}
	}
}

