// 
//  cTerminus.cs
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
using Gdk;
using Gtk;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Diagnostics;
namespace libTerminus
{
	/// <summary>
	/// Parsing mode.
	/// </summary>
	public enum ParsingMode
	{
		All,
		OnlyGroups,
		OnlyRegular,
	}
	/// <summary>
	/// Log method.
	/// </summary>
	public enum LogMethod
	{
		File,
		Logs,
		DataBase,
	}
	/// <summary>
	/// Log level.
	/// </summary>
	public enum LogLevel
	{
		Critical,
		Warning,
	}
	/// <summary>
	/// Export type.
	/// </summary>
	public enum ExportType
	{
		Text,
		CSV,
		HTML,
	}
	/// <summary>
	/// The cTerminus class is the main core of the program.
	/// </summary>
	public static class cTerminus
	{
		/// <summary>
		/// The name of the program.
		/// </summary>
		public static string g_programName = "Terminus";	
		/// <summary>
		/// The program version.
		/// </summary>
		public static Version g_programVersion = new Version (0, 0, 0, 0);
		/// <summary>
		/// The time back machine.
		/// </summary>
		public static cTimeBack TimeBackMachine = new cTimeBack ();
		/// <summary>
		/// The last result time span.
		/// </summary>
		public static TimeSpan g_lastResultTimeSpan;
		/// <summary>
		/// The list of opened files
		/// </summary>
		public static List<string> g_files = new List<string> ();
		/// <summary>
		/// Determines, if the program is ready or not.
		/// </summary>
		public	static bool g_isReady;
		/// <summary>
		/// The log method which is used.
		/// </summary>
		public static LogMethod g_LogMethodUsed = LogMethod.File;
		/// <summary>
		/// Enable Syntax yes or no.
		/// </summary>
		public static bool g_enableSyntax;
		/// <summary>
		/// The disable.
		/// </summary>
		public static bool disable;
		/// <summary>
		/// is config tab open.
		/// </summary>
		public static bool isConfigTabOpen;
		/// <summary>
		/// The index of the config tab.
		/// </summary>
		public static int ConfigTabIndex;
		/// <summary>
		/// is lib tab <see cref="libTerminus.cPool"/> isopen.
		/// </summary>
		public static bool isLibTabOpen;
		/// <summary>
		/// The index of the lib tab.
		/// </summary>
		public static int LibTabIndex;
		/// <summary>
		/// The current regex unique ID.
		/// </summary>
		public static string CurrentRegexUniqueID;
		/// <summary>
		/// The configuration.
		/// </summary>
		public static cConfigPlatform Configuration = new cConfigPlatform (new cPathEnvironment ().const_settings_path);
		/// <summary>
		/// Adds a new tab to the given notebook
		/// </summary>
		/// <param name='_nb'>
		/// The notebook.
		/// </param>
		/// <param name='_filename'>
		/// The filename. If you have a filename, use it. If you don't have a filename, use "" instead.
		/// </param>
		public static void AddTab (Notebook _nb, string _filename)
		{
			try {
				string FileName;
				if (System.IO.File.Exists (_filename))
					FileName = new System.IO.FileInfo (_filename).Name;
				else
					FileName = "";
				_nb.AppendPage (new libTerminus.cRegex (_filename), new Label ("Neuer Ausdruck", ref _nb));
				_nb.ShowAll ();			
				_nb.Page = _nb.NPages - 1;
				g_files.Add (_filename);
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Adds the config tab.
		/// </summary>
		/// <param name='_nb'>
		/// Nb.
		/// </param>
		public static void addConfigTab (Notebook _nb)
		{
			try {
				if (isConfigTabOpen != true) {
					_nb.AppendPage (new libTerminus.cConfig (Configuration), new Label ("Einstellungen", ref _nb));
					_nb.ShowAll ();			
					_nb.Page = _nb.NPages - 1;
					ConfigTabIndex = _nb.Page;
				} else {
					_nb.Page = ConfigTabIndex;
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Adds the library tab.
		/// </summary>
		/// <param name='_nb'>
		/// Nb.
		/// </param>
		public static void addLibraryTab (Notebook _nb)
		{
			try {
				if (isLibTabOpen != true) {
					_nb.AppendPage (new libTerminus.cPool (ref _nb), new Label ("Bibliothek", ref _nb));
					_nb.ShowAll ();			
					_nb.Page = _nb.NPages - 1;
					LibTabIndex = _nb.Page;
				} else {
					_nb.Page = LibTabIndex;
					
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Closes the tab of the notebook and removes it from the 	<see cref="cTerminus.Files"/> List.
		/// </summary>
		/// <param name='_nb'>
		/// The notebook
		/// </param>
		/// <param name='_index'>
		/// The index of the current page, which should be deleted.
		/// </param>
		public static void CloseTab (Notebook _nb, int _index)
		{
			try {
				if (((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).Saved) {			
					_nb.RemovePage (_index);		
					g_files.RemoveAt (_index);
				} else if (((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).GetExpressionBuffer () == "") {
					_nb.RemovePage (_index);		
					g_files.RemoveAt (_index);
				} else {
					if (AskForClosingLastTab () == ResponseType.Yes) {
						_nb.RemovePage (_index);		
						g_files.RemoveAt (_index);
					}
				}
			} catch (Exception ex) {

				if (_nb.GetNthPage (_nb.Page) is cConfig) {
					cTerminus.isConfigTabOpen = false;
					cTerminus.ConfigTabIndex = -1;
				} else if (_nb.GetNthPage (_nb.Page) is cPool) {
					cTerminus.isLibTabOpen = false;
					LibTabIndex = -1;
				}

				//Remove the tab
				_nb.RemovePage (_index);

			}
		}
		/// <summary>
		/// Adds the tab from file.
		/// </summary>
		/// <param name='_nb'>
		/// The notebook.
		/// </param>
		public static void AddTabFromFile (Notebook _nb)
		{
			try {
				string FileNameNew;
				FileNameNew = ShowOpenDialog ();
				if (System.IO.File.Exists (FileNameNew)) {
					//FileName = FileNameNew;	//Fixme: If nothing happens, change this comment.			
					_nb.AppendPage (new libTerminus.cRegex (FileNameNew), new Label (new FileInfo (FileNameNew).Name, ref _nb));
					_nb.ShowAll ();			
					g_files.Add (FileNameNew);
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Adds the tab from file. Use this method only if you want to save a file to a new filename.
		/// </summary>
		/// <param name='_nb'>
		/// The notebook.
		/// </param>
		/// <param name='_fileNameNew'>
		/// The new Filename
		/// </param>
		/// <param name='_pageindex'>
		/// The index of the page.
		/// </param>
		public static void AddTabFromFile (Notebook _nb, string _fileNameNew, int _pageindex)
		{
			try {
				if (System.IO.File.Exists (_fileNameNew)) {
					//FileName = FileNameNew;	//Fixme: If nothing happens, change this comment.			

					_nb.InsertPage (new libTerminus.cRegex (_fileNameNew), new Label (new FileInfo (_fileNameNew).Name, ref _nb), _pageindex);
					_nb.ShowAll ();			
					g_files.Add (_fileNameNew);
				} else {
					
					_nb.InsertPage (new libTerminus.cRegex (""), new Label ("Neuer Ausdruck", ref _nb), _pageindex);
					_nb.ShowAll ();			
					g_files.Add (_fileNameNew);
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}

		}
		/// <summary>
		/// Gets the name of the current file.
		/// </summary>
		/// <returns>
		/// The file name.
		/// </returns>
		/// <param name='_nb'>
		/// The notebook
		/// </param>
		/// <param name='_index'>
		/// The current page index of the notebook.
		/// </param>
		public static string getFileName (Notebook _nb, int _index)
		{
			try {
				return ((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).g_filename;
				//return Files [index];
			} catch (IndexOutOfRangeException ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return "";
			}			
		}
		/// <summary>
		/// Gets the expression of tab.
		/// </summary>
		/// <returns>
		/// The buffer content of the expression of the cRegex - Tab. Or if any errors appeared - "".
		/// </returns>
		/// <param name='_nb'>
		/// The notebook.
		/// </param>
		/// <param name='_Index'>
		/// The current page index.
		/// </param>
		public static string getExpressionofTab (Notebook _nb, int _Index)
		{
			try {
				return ((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).GetExpressionBuffer ();
			} catch {
				return "";
			}
		}
		/// <summary>
		/// Sets the expressionof tab.
		/// </summary>
		/// <param name='_nb'>
		/// Nb.
		/// </param>
		/// <param name='_index'>
		/// Index.
		/// </param>
		/// <param name='_content'>
		/// Content.
		/// </param>
		public static void setExpressionofTab (Notebook _nb, int _index, string _content, bool _append = false)
		{
			try {
				if (_append == false)
					((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).setExpressionBuffer (_content);
				else
					((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).appendExpressionBuffer (_content);
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, "", ButtonsType.Ok, MessageType.Error);
			}
		}
		/// <summary>
		/// Gets the data source of the tab. see <see cref="cTerminus.getExpressionofTab"/> for details.
		/// </summary>
		/// <returns>
		/// The data sourceof tab.
		/// </returns>
		/// <param name='_nb'>
		/// Nb.
		/// </param>
		/// <param name='_index'>
		/// Index.
		/// </param>
		public static string getDataSourceofTab (Notebook _nb, int _Index)
		{
			try {
				return ((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).GetDataSourceBuffer ();
			} catch {
				return "";
			}			
		}
		/// <summary>
		/// Gets the title.
		/// </summary>
		/// <returns>
		/// The title.
		/// </returns>
		/// <param name='_nb'>
		/// Notebook
		/// </param>
		/// <param name='_Index'>
		/// Index of the current page.
		/// </param>
		public static string getTitle (Notebook _nb, int _Index)
		{
			try {
				//MessageBox.Show (((libTerminus.cRegex)_nb.GetNthPage (nb.Page)).Saved.ToString (), "", ButtonsType.None, MessageType.Other);
				if (((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).g_filename == "")
					return g_programName;
				else {
					if (((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).Saved)
						return ((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).g_filename + " - " + g_programName;
					else
						return ((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).g_filename + "* - " + g_programName;
				}
					
			} catch (Exception ex) {
				//MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
				return g_programName + " ";
				;
			}
		}

		/// <summary>
		/// Save the specified nb, Index and Filename.
		/// </summary>
		/// <param name='_nb'>
		/// Nb.
		/// </param>
		/// <param name='_Index'>
		/// Index.
		/// </param>
		/// <param name='_Filename'>
		/// Filename.
		/// </param>
		public static void Save (Notebook _nb, int _Index, string _Filename)
		{
			try {
				if (_Filename != "" && disable != true) {
					((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).Save (_Filename);
					int current = _nb.Page;
					string data = ((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).GetDataSourceBuffer ();
					_nb.Remove (_nb.GetNthPage (_nb.Page));
					AddTabFromFile (_nb, _Filename, current);
					_nb.Page = current;
					((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).Saved = true;
					((libTerminus.cRegex)_nb.GetNthPage (_nb.Page)).setDataBuffer (data);


				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Shows the save dialog.
		/// </summary>
		/// <returns>
		/// The save dialog.
		/// </returns>
		/// <param name='dlg'>
		/// Parent [obsolet]
		/// </param>
		public static string ShowSaveDialog (Gtk.Dialog dlg, string FilterName = "Regex - Projekte", string FilterContent = "*.rgx")
		{
			try {
				Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog ("Wählen Sie den Speicherort", null, FileChooserAction.Save, "Abbrechen", ResponseType.Cancel, "Speichern", ResponseType.Accept);
				FileFilter flt = new FileFilter ();
				if (FilterContent == "*.rgx") {
					flt.Name = "Regex - Projekte";
					flt.AddPattern ("*.rgx");
				} else {
					flt.Name = FilterName;
					flt.AddPattern (FilterContent);
				}
				fc.Filter = flt;	
				string filename = "";
				fc.SetCurrentFolder (new libTerminus.cPathEnvironment ().const_start_path);
				
				//Run the Dialog
				if (fc.Run () == (int)ResponseType.Accept) {
				
					filename = fc.Filename;
				
				}		
				fc.Destroy ();
				return filename;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return "";
			}
		}
		/// <summary>
		/// Shows the open dialog.
		/// </summary>
		/// <returns>
		/// The filename.
		/// </returns>
		public static string ShowOpenDialog ()
		{
			try {
				Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog ("Choose the file to open", null, FileChooserAction.Open, "Abbrechen", ResponseType.Cancel, "Öffnen", ResponseType.Accept);
				FileFilter flt = new FileFilter ();
				flt.Name = "Regex - Projekte";
				flt.AddPattern ("*.rgx");
				fc.Filter = flt;
				//fc.CurrentFolder = n
				fc.SetCurrentFolder (new libTerminus.cPathEnvironment ().const_start_path);
				string filename = "";
				//run the Dialog
				if (fc.Run () == (int)ResponseType.Accept) {
					filename = fc.Filename;
				}		
				fc.Destroy ();
				return filename;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return "";
			}
		}
		/// <summary>
		/// Undo the specified notebook - page
		/// </summary>
		/// <param name='nb'>
		/// Nb.
		/// </param>
		public static void undo (Notebook nb)
		{
			try {
				((libTerminus.cRegex)nb.GetNthPage (nb.Page)).Undo ();
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Shows the about dialog.
		/// </summary>
		/// <param name='ProgramVersion'>
		/// Program version.
		/// </param>
		/// <param name='wind'>
		/// The Parent windows
		/// </param>
		public static void showAboutDialog (Version ProgramVersion, Gdk.Window wind)
		{			
			try {
				AboutDialog about = new AboutDialog ();
				about.ProgramName = g_programName;
				about.ParentWindow = wind.Toplevel;
				about.Website = "about:blank";
				about.Comments = "Erstellen und Testen Sie schnell und einfach reguläre Ausdrücke mit der verbesserten Version von Phrasis.Studio";
				//if (Environment.OSVersion.Platform == PlatformID.MacOSX || Environment.OSVersion.Platform == PlatformID.Unix)
				about.Comments += "\nPlattform: " + getDistribution ();

				about.Version = ProgramVersion.ToString ().Replace (".0", "") + "_nightly";
				about.Logo = new Gdk.Pixbuf (new cPathEnvironment ().const_program_image, 64, 64, true);				
				about.Icon = new Gdk.Pixbuf (new cPathEnvironment ().const_program_image, 64, 64, true);	
				about.Title = "Info über das Programm";
				about.Website = "";
				//Icon: http://commons.wikimedia.org/wiki/File:Torchlight_apply.png

				about.License = System.IO.File.ReadAllText (new cPathEnvironment ().const_data_dir + "Boot/Texts/License", System.Text.Encoding.UTF8);
				about.WrapLicense = true;
				about.Copyright = "Programmicon: \"Torchlight\"; http://kde-look.org/content/show.php?content=26378 lizensiert unter LGPL";
				
				about.Copyright += "\nCopyright 2012 (c) Terminus Entwickler";		
				about.SetPosition (WindowPosition.Center);
				

				about.Run ();
				about.Destroy ();
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Prints the help text to the console
		/// </summary>
		public static void PrintHelpText ()
		{
			try {
				Console.WriteLine ("--v | --version - Prints the version. \n--h | --help - Prints this message.\n<filename> - Opens an existing file");
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Asks for closing.
		/// </summary>
		/// <returns>
		/// A responseType - Objekt containing the answer.
		/// </returns>
		public static ResponseType AskForClosing ()
		{
			try {
				return MessageBox.Show ("Möchten Sie wirklich beenden?", g_programName, ButtonsType.YesNo, MessageType.Question);
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return ResponseType.None;
			}
		}
		/// <summary>
		/// Asks for closing last tab.
		/// </summary>
		/// <returns>
		/// The for closing last tab.
		/// </returns>
		public static ResponseType AskForClosingLastTab ()
		{
			try {
				return MessageBox.Show ("Möchten Sie den Ausdruck wirklich schließen? Alle Änderungen daran gehen verloren.", g_programName, ButtonsType.YesNo, MessageType.Question);
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return ResponseType.None;
			}
		}
		/// <summary>
		/// Asks for clear.
		/// </summary>
		/// <returns>
		/// The for clear.
		/// </returns>
		public static ResponseType AskForClear ()
		{
			try {
				return MessageBox.Show ("Möchten Sie wirklich leeren", g_programName, ButtonsType.YesNo, MessageType.Question);
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return ResponseType.None;
			}
		}
		/// <summary>
		/// Gets the distribution.
		/// </summary>
		/// <returns>
		/// The distribution.
		/// </returns>
		public static string getDistribution ()
		{
			try {
				return ReadSTDOutput ("lsb_release", "--d").Replace ("Description:", "").Trim ();
			} catch {
				try {
					return ReadSTDOutput ("uname", "-o");
				} catch {					
					return "Unknown Operating System or Windows";
				}
			}
		}	
		/// <summary>
		/// Reads the STD output.
		/// </summary>
		/// <returns>
		/// The STD output.
		/// </returns>
		/// <param name='fileName'>
		/// File name.
		/// </param>
		/// <param name='arguments'>
		/// Arguments.
		/// </param>
		static string ReadSTDOutput (string fileName, string arguments)
		{
			Process process = new Process ();
	
			process.StartInfo.FileName = fileName;
			process.StartInfo.Arguments = arguments;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
	
			process.Start ();
	
			string DefaultOutput = process.StandardOutput.ReadToEnd ();
	
			process.Close ();
	
			return DefaultOutput;
		}
		/// <summary>
		/// Gets the build info.
		/// </summary>
		/// <returns>
		/// The build info.
		/// </returns>
		public static string getBuildInfo ()
		{
			return System.IO.File.ReadAllText (new cPathEnvironment ().const_data_dir + "build.log");
		}
	

	}
	
	
}

