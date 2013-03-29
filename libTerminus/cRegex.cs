//  cRegex.cs - The widget which displays the expression and the data
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Gtk;

namespace libTerminus
{
	/// <summary>
	/// The control which is added to the tabpages.
	/// </summary>
	[System.ComponentModel.ToolboxItem(true)]
	public partial class cRegex : Gtk.Bin
	{
		/// <summary>
		/// The default filename.
		/// </summary>
		public string g_filename = "Unbekanntes Dokument";
		/// <summary>
		/// The regex history.
		/// </summary>
		public List<string> g_regexHistory = new List<string> ();
		/// <summary>
		/// The input history.
		/// </summary>
		public List<string> g_inputHistory = new List<string> ();
		/// <summary>
		/// The index of the input history.
		/// </summary>
		public int g_inputHistoryIndex = 0;
		/// <summary>
		/// The index of the regex history.
		/// </summary>
		public int g_regexHistoryIndex = 0;
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cRegex"/> is saved.
		/// </summary>
		/// <value>
		/// <c>true</c> if saved; otherwise, <c>false</c>.
		/// </value>
		public bool Saved { get; set; }		
		/// <summary>
		/// The GTK.TextView which should contain the result
		/// </summary>
		public  Gtk.TextView g_resultdisplay ; 
		/// <summary>
		/// The used regex options
		/// </summary>
		public RegexOptions g_options;
		public libTerminus.ParsingMode g_mode;
		public string g_Expression;
		public string g_DataSource;
		public string g_lastresult = "";
		public string g_UniqueID;
		int step = 0;
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cRegex"/> class.
		/// </summary>
		/// <param name='_filename'>
		/// The filename or "".
		/// </param>
		public cRegex (string _filename) : this()
		{
		
			try {
				this.Build ();
				setTags (ref Expression, ref DataSource);
				this.g_filename = _filename;
				
				if (_filename == "")
					this.g_filename = "";
				else
					Expression.Buffer.Text = System.IO.File.ReadAllText (_filename);
			
				//Append needed Events
				Expression.Buffer.Changed += delegate {
					addToExpressionHistory ();
				};
				DataSource.Buffer.Changed += delegate {
					addToDataHistory ();
				};
				Expression.KeyReleaseEvent += delegate {
					cTerminus.MarkSyntax (ref Expression);
				};
				//Start Marking the Syntax
				cTerminus.MarkSyntax (ref Expression);
			} catch (Exception ex) {
				//TODO: Here is eventually a bug.
				//MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
			this.Saved = true;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cRegex"/> class.
		/// </summary>
		cRegex ()
		{
			g_UniqueID = DateTime.Now.Year.ToString () + DateTime.Now.Month.ToString () + DateTime.Now.Day.ToString () + DateTime.Now.Hour.ToString () + DateTime.Now.Minute.ToString () + DateTime.Now.Second.ToString () + DateTime.Now.Millisecond.ToString ();
		}
		/// <summary>
		/// Adds to expression history.
		/// </summary>
		void addToExpressionHistory ()
		{
			if (g_regexHistory.Contains (Expression.Buffer.Text) == false) {
				g_regexHistory.Add (Expression.Buffer.Text);
				g_regexHistoryIndex++;
				Saved = false;
				try {
					if (Expression.Buffer.Text.Contains ("\n") == false) {
						if (cTerminus.Configuration.ReduceSyntaxChanging) {
							if (step == 5) {
								cTerminus.MarkSyntax (ref Expression);
								step = 0;
							} else {
								step++;
							}	
						} else
							cTerminus.MarkSyntax (ref Expression);
					}
				} catch {
				}
				
			}
		}
		/// <summary>
		/// Adds to data history.
		/// </summary>
		void addToDataHistory ()
		{
			if (g_inputHistory.Contains (DataSource.Buffer.Text) == false) {
				g_inputHistory.Add (DataSource.Buffer.Text);
				g_inputHistoryIndex++;
			}
		}
		/// <summary>
		/// Gets the expression buffer.
		/// </summary>
		/// <returns>
		/// The expression buffer.
		/// </returns>
		public string GetExpressionBuffer ()
		{
			try {
				return 	Expression.Buffer.Text;
			} catch (Exception ex) {
				return "";
			}
		}
		/// <summary>
		/// Gets the data source buffer.
		/// </summary>
		/// <returns>
		/// The data source buffer.
		/// </returns>
		public string GetDataSourceBuffer ()
		{
			try {
				return DataSource.Buffer.Text;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return "";
			}
		}
		/// <summary>
		/// Save the specified Filename.
		/// </summary>
		/// <param name='Filename'>
		/// If set to <c>true</c> filename.
		/// </param>
		public bool Save (string Filename, bool save = true)
		{
			try {
				if (Filename != "") {
					System.IO.File.WriteAllText (Filename, GetExpressionBuffer ());
					if (save)
						this.g_filename = Filename;
					if (save)
						Saved = true;
					return true;
				} 
				return false;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return false;
			}
		}
		/// <summary>
		/// Undo this instance.
		/// </summary>
		public void Undo ()
		{
			try {
				if (Expression.HasFocus) {
					if (g_regexHistoryIndex >= 0) {
						Expression.Buffer.Text = g_regexHistory [--g_regexHistoryIndex];
						cTerminus.MarkSyntax (ref Expression);
					}
				} else if (DataSource.HasFocus) {
					if (g_inputHistoryIndex >= 0)
						DataSource.Buffer.Text = g_inputHistory [--g_inputHistoryIndex];
				}
			} catch {			
			}
		}
		/// <summary>
		/// Redo this instance.
		/// </summary>
		public void Redo ()
		{
			try {		
				if (Expression.HasFocus) {
					if (g_regexHistoryIndex + 1 < g_regexHistory.Count) {
						Expression.Buffer.Text = g_regexHistory [++g_regexHistoryIndex];
						cTerminus.MarkSyntax (ref Expression);
					}
				} else if (DataSource.HasFocus) {
					if (g_inputHistoryIndex + 1 < g_inputHistory.Count)
						DataSource.Buffer.Text = g_inputHistory [++g_inputHistoryIndex];
				}

			} catch {

			}
		}
		/// <summary>
		/// Paste this instance.
		/// </summary>
		public void Paste ()
		{
			try {
				if (Expression.HasFocus) {
					Expression.Buffer.PasteClipboard (Clipboard.Get (Gdk.Selection.Clipboard));
					cTerminus.MarkSyntax (ref Expression);
				} else
					DataSource.Buffer.PasteClipboard (Clipboard.Get (Gdk.Selection.Clipboard));
			} catch {

			}
		}
		/// <summary>
		/// Copy this instance.
		/// </summary>
		public void Copy ()
		{
			try {
				if (Expression.HasFocus)
					Expression.Buffer.CopyClipboard (Clipboard.Get (Gdk.Selection.Clipboard));
				else
					DataSource.Buffer.CopyClipboard (Clipboard.Get (Gdk.Selection.Clipboard));
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Cut this instance.
		/// </summary>
		public void cut ()
		{
			try {
				if (Expression.HasFocus)
					Expression.Buffer.CutClipboard (Clipboard.Get (Gdk.Selection.Clipboard), true);
				else
					DataSource.Buffer.CutClipboard (Clipboard.Get (Gdk.Selection.Clipboard), true);
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Parse the specified resultdisplay, options and mode.
		/// </summary>
		/// <param name='resultdisplay'>
		/// An Gtk.TextView which should contains the result.
		/// </param>
		/// <param name='options'>
		/// Options.
		/// </param>
		/// <param name='mode'>
		/// Mode.
		/// </param>
		public void parse (ref Gtk.TextView resultdisplay, RegexOptions options, libTerminus.ParsingMode mode)
		{
			try {
				DateTime _Begin = DateTime.Now;
				//BackgroundWorker bgw = new BackgroundWorker ();
				//bgw.DoWork += HandleDoWork;
				string result = "";
				bool success;
				string dataSource = DataSource.Buffer.Text;
				string expression = Expression.Buffer.Text;
				//if (bgw.IsBusy)
				//bgw.CancelAsync ();
				if (dataSource != "" && expression != "") {
			
					//bgw.RunWorkerAsync ();
					//this.g_DataSource = DataSource.Buffer.Text;
					//this.g_Expression = Expression.Buffer.Text;
					//TODO: If any bug appears, comment this line
					g_options = options;
					//g_mode = mode;
					//g_resultdisplay = resultdisplay;
					Regex rgx = new Regex (expression, options);
					success = rgx.IsMatch (dataSource);
					int count = 0;
					if (mode == ParsingMode.All) {
						foreach (Match mt in rgx.Matches(dataSource)) {
							result += "[" + count + "] " + mt.Value + "\n";
							count++;
							for (int i = 0; i < mt.Groups.Count; i++) {
								if (result.Contains ("[" + rgx.GetGroupNames () [i] + "] " + mt.Groups [i].Value) == false)
									result += "-> [" + rgx.GetGroupNames () [i] + "] " + mt.Groups [i].Value + "\n"; 
							}
						}
					} else if (mode == ParsingMode.OnlyGroups) {
						foreach (Match mt in rgx.Matches(dataSource)) {
							for (int i = 0; i < mt.Groups.Count; i++) {
								if (result.Contains ("[" + rgx.GetGroupNames () [i] + "] " + mt.Groups [i].Value) == false)
									result += "-> [" + rgx.GetGroupNames () [i] + "] " + mt.Groups [i].Value + "\n"; 
							}
						}
					} else if (mode == ParsingMode.OnlyRegular) {
						foreach (Match mt in rgx.Matches(dataSource)) {
							result += "[" + count + "] " + mt.Value + "\n";
							count++;
						}
					}
					//new MessageBox().Show(expression + ";" + dataSource + ";" + result  + success.ToString(),"",Gtk.ButtonsType.Close,Gtk.MessageType.Info);
					resultdisplay.Buffer.Text = result;
					g_lastresult = result;
					DateTime _End = DateTime.Now;
					cTerminus.g_lastResultTimeSpan = _End - _Begin;
					if (cTerminus.enableDataBase)
						new cRevertData ().setRestoredData (DateTime.Now, expression, "");
				} else {
					MessageBox.Show ("Die Daten enthalten keinen Ausdruck", cTerminus.g_programName, Gtk.ButtonsType.Ok, Gtk.MessageType.Warning);
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}

		void HandleDoWork (object sender, DoWorkEventArgs e)
		{
			string expression = g_Expression;
			string dataSource = g_DataSource;
			bool success = false;
			string result = "";
			Regex rgx = new Regex (g_Expression, g_options);
			success = rgx.IsMatch (dataSource);
			int count = 0;
			if (g_mode == ParsingMode.All) {
				foreach (Match mt in rgx.Matches(dataSource)) {
					result += "[" + count + "] " + mt.Value + "\n";
					count++;
					for (int i = 0; i < mt.Groups.Count; i++) {
						if (result.Contains ("[" + rgx.GetGroupNames () [i] + "] " + mt.Groups [i].Value) == false)
							result += "-> [" + rgx.GetGroupNames () [i] + "] " + mt.Groups [i].Value + "\n"; 
					}
				}
			} else if (g_mode == ParsingMode.OnlyGroups) {
				foreach (Match mt in rgx.Matches(dataSource)) {
					for (int i = 0; i < mt.Groups.Count; i++) {
						if (result.Contains ("[" + rgx.GetGroupNames () [i] + "] " + mt.Groups [i].Value) == false)
							result += "-> [" + rgx.GetGroupNames () [i] + "] " + mt.Groups [i].Value + "\n"; 
					}
				}
			} else if (g_mode == ParsingMode.OnlyRegular) {
				foreach (Match mt in rgx.Matches(dataSource)) {
					result += "[" + count + "] " + mt.Value + "\n";
					count++;
				}
			}
			g_lastresult = result;
		}
		/// <summary>
		/// Clear Expression an DataSource.
		/// </summary>
		public void Clear ()
		{
			try {
				Expression.Buffer.Text = "";
				DataSource.Buffer.Text = "";
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Gets the buffer.
		/// </summary>
		/// <returns>
		/// The buffer.
		/// </returns>
		public TextView getBuffer ()
		{
			try {
				return 	Expression;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return null;
			}
		}
	
		/// <summary>
		/// Sets the data buffer.
		/// </summary>
		/// <param name='Value'>
		/// Value.
		/// </param>
		public void setDataBuffer (string Value)
		{
			try {
				DataSource.Buffer.Text = Value;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Sets the expression buffer.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
		public void setExpressionBuffer (string value)
		{
			try {
				Expression.Buffer.Text = value;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Appends the expression buffer.
		/// </summary>
		/// <param name='value'>
		/// Value.
		/// </param>
		public void appendExpressionBuffer (string value)
		{
			try {
				string old = Expression.Buffer.Text;
				Expression.Buffer.Text = old + value;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}

		/// <summary>
		/// Gets the bold.
		/// </summary>
		/// <returns>
		/// The bold.
		/// </returns>/
		public static Pango.FontDescription getBold ()
		{
			Pango.FontDescription fdsc = new Pango.FontDescription ();
			fdsc.Weight = Pango.Weight.Bold;
			return fdsc;
		}
		/// <summary>
		/// Sets the tags.
		/// </summary>
		/// <param name='_textview'>
		/// _textview.
		/// </param>
		public static void setTags (ref TextView _textview, ref TextView _data)
		{
			try {
				//string path = new cPathEnvironment().const_settings_path.Replace("Program.cfg" ,"ColorShemes" + new cPathEnvironment().const_path_separator + cTerminus.Configuration.Theme + ".config") ;
				string path = new cPathEnvironment ().const_shemes_path + cTerminus.Configuration.Theme + ".config"; 
				//Console.WriteLine (path); 
				/*	if (new cPathEnvironment ().const_settings_path.Contains ("Program.cfg"))
					path = new cPathEnvironment ().const_settings_path.Replace ("Program.cfg", "ColorShemes" + new cPathEnvironment ().const_path_separator + cTerminus.Configuration.Theme + ".config");
				else
					path = @"/usr/share/terminus/Boot/Config/ColorShemes/" + cTerminus.Configuration.Theme + ".config";*/
				new cSyntax (path, ref _textview, false);
				if (_data != null)
					new cSyntax (path, ref _data, true);
			} catch {
			
				TextTag tagnone = new TextTag ("nosyntax");
				Gdk.Color nonecolor;
				Gdk.Color.Parse ("black", ref nonecolor);
				tagnone.ForegroundGdk = nonecolor;				
				_textview.Buffer.TagTable.Add (tagnone);
				TextTag tagcorrect = new TextTag ("backslashliteral");
				Gdk.Color colorcorrect;
				Gdk.Color.Parse ("darkblue", ref colorcorrect);
				tagcorrect.ForegroundGdk = colorcorrect;
				tagcorrect.FontDesc = getBold ();
				_textview.Buffer.TagTable.Add (tagcorrect);
				TextTag edgedBrackets = new TextTag ("edgedBrackets");
				Gdk.Color coloredgetBrackets;
				Gdk.Color.Parse ("darkred", ref coloredgetBrackets);
				edgedBrackets.ForegroundGdk = coloredgetBrackets;
				_textview.Buffer.TagTable.Add (edgedBrackets);
				TextTag roundBrackets = new TextTag ("roundBrackets");
				Gdk.Color colorroundbrackets;
				Gdk.Color.Parse ("darkviolet", ref colorroundbrackets);
				roundBrackets.ForegroundGdk = colorroundbrackets;
				_textview.Buffer.TagTable.Add (roundBrackets);
				TextTag otherBrackets = new TextTag ("otherBrackets");
				Gdk.Color otherBracketsColor;
				Gdk.Color.Parse ("darkgreen", ref otherBracketsColor);
				otherBrackets.ForegroundGdk = otherBracketsColor;
				_textview.Buffer.TagTable.Add (otherBrackets);
				TextTag constant = new TextTag ("constant");
				Gdk.Color constantcolor;
				Gdk.Color.Parse ("darkgrey", ref constantcolor);
				constant.ForegroundGdk = constantcolor;
				_textview.Buffer.TagTable.Add (constant);
				TextTag quantifier = new TextTag ("quantifier");
				Gdk.Color quantifiercolor;
				Gdk.Color.Parse ("chocolate2", ref quantifiercolor);
				quantifier.ForegroundGdk = quantifiercolor;
				_textview.Buffer.TagTable.Add (quantifier);
				MessageBox.Show ("Fehler beim Laden des Schema's.\nEs wurde das Standardschema geladen.", "Fehler", ButtonsType.Close, MessageType.Warning, null);
			}
		}


	}
}

