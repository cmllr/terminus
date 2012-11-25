
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
		public string Filename = "Unbekanntes Dokument";
		/// <summary>
		/// The regex history.
		/// </summary>
		public List<string> regexHistory = new List<string> ();
		public List<string> inputHistory = new List<string> ();
		/// <summary>
		/// The index of the input history.
		/// </summary>
		public int inputHistoryIndex = 0;
		/// <summary>
		/// The index of the regex history.
		/// </summary>
		public int regexHistoryIndex = 0;
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="libTerminus.cRegex"/> is saved.
		/// </summary>
		/// <value>
		/// <c>true</c> if saved; otherwise, <c>false</c>.
		/// </value>
		public bool Saved { get; set; }
		public  Gtk.TextView g_resultdisplay ;
		public RegexOptions g_options;
		public libTerminus.ParsingMode g_mode;
		public string g_Expression;
		public string g_DataSource;
		public string g_lastresult = "";
		BackgroundWorker bgw;
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cRegex"/> class.
		/// </summary>
		/// <param name='Filename'>
		/// The filename or "".
		/// </param>
		public cRegex (string Filename)
		{
			try {
				this.Build ();
				this.Filename = Filename;
				
				if (Filename == "")
					this.Filename = "";
				else
					Expression.Buffer.Text = System.IO.File.ReadAllText (Filename);
			
				Expression.Buffer.Changed += delegate {
					if (regexHistory.Contains (Expression.Buffer.Text) == false) {
						regexHistory.Add (Expression.Buffer.Text);
						regexHistoryIndex++;
						Saved = false;
					}
				};
				DataSource.Buffer.Changed += delegate {
					if (inputHistory.Contains (DataSource.Buffer.Text) == false) {
						inputHistory.Add (DataSource.Buffer.Text);
						inputHistoryIndex++;						
					}
				};
				bgw = new BackgroundWorker ();
				bgw.DoWork += HandleDoWork1;
				bgw.WorkerSupportsCancellation = true;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
			}
			
		}

		void HandleDoWork1 (object sender, DoWorkEventArgs e)
		{
			
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
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
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
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
				return "";
			}
		}
		/// <summary>
		/// Save the specified Filename.
		/// </summary>
		/// <param name='Filename'>
		/// If set to <c>true</c> filename.
		/// </param>
		public bool Save (string Filename)
		{
			try {
				if (Filename != "") {
					System.IO.File.WriteAllText (Filename, GetExpressionBuffer ());
					this.Filename = Filename;
					Saved = true;
					return true;
				} 
				return false;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
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
					if (regexHistoryIndex >= 0)
						Expression.Buffer.Text = regexHistory [--regexHistoryIndex];
				} else if (DataSource.HasFocus) {
					if (inputHistoryIndex >= 0)
						DataSource.Buffer.Text = inputHistory [--inputHistoryIndex];
				}
			} catch (Exception ex) {
				//MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Redo this instance.
		/// </summary>
		public void Redo ()
		{
			try {		
				if (Expression.HasFocus) {
					if (regexHistoryIndex + 1 < regexHistory.Count)
						Expression.Buffer.Text = regexHistory [++regexHistoryIndex];
				} else if (DataSource.HasFocus) {
					if (inputHistoryIndex + 1 < inputHistory.Count)
						DataSource.Buffer.Text = inputHistory [++inputHistoryIndex];
				}
			} catch (Exception ex) {
				//MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// Paste this instance.
		/// </summary>
		public void Paste ()
		{
			try {
				if (Expression.HasFocus)
					Expression.Buffer.PasteClipboard (Clipboard.Get (Gdk.Selection.Clipboard));
				else
					DataSource.Buffer.PasteClipboard (Clipboard.Get (Gdk.Selection.Clipboard));
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
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
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
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
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
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
					//g_options = options;
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
				} else {
					MessageBox.Show ("Die Daten enthalten keinen Ausdruck", cTerminus.ProgramName, Gtk.ButtonsType.Ok, Gtk.MessageType.Warning);
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
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
				if (cTerminus.AskForClosing () == ResponseType.Yes) {
					Expression.Buffer.Text = "";
					DataSource.Buffer.Text = "";

				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
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
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
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
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
			}
		}
		public void setExpressionBuffer (string value)
		{
			try {
				Expression.Buffer.Text = value;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
			}
		}
		public void appendExpressionBuffer (string value)
		{
			try {
				string old = Expression.Buffer.Text;
				Expression.Buffer.Text = old + value;
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.ProgramName, ButtonsType.Close, MessageType.Error);
			}
		}
	}
}

