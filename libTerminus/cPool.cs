//  cPool.cs - A kind of snippet pool 
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
using System.Data;
using Mono.Data.Sqlite;
namespace libTerminus
{
	/// <summary>
	/// The pool widgets provides a list of snippets
	/// </summary>
	[System.ComponentModel.ToolboxItem(true)]
	public partial class cPool : Gtk.Bin
	{		
		Notebook g_notebook; // the calling notebook to get a new tab page including this widget
		ListStore g_regexList; // A liststore which should contain the items
		string g_selectedPath; // the current selction 
		string g_selection;   // ^ together with the path
		string g_name; 		  // see one/ two above
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cPool"/> class.
		/// </summary>
		/// <param name='_nb'>
		/// _nb.
		/// </param>
		public cPool (ref Notebook _nb)
		{
			this.Build ();
			cTerminus.isLibTabOpen = true;
			appendColumns ();
			appendItems ();
			g_notebook = _nb;
			treeview1.CursorChanged += HandleCursorChanged;
		}

		void HandleCursorChanged (object sender, EventArgs e)
		{
			try {
				TreeSelection selection = (sender as TreeView).Selection;
				TreeModel model;
				TreeIter iter;
				if (selection.GetSelected (out model, out iter) && model.GetValue (iter, 3) != "") {
					g_selectedPath = (model.GetValue (iter, 3).ToString ());
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		
		
		/// <summary>
		/// Appends the columns.
		/// </summary>
		public void appendColumns ()
		{
			try {
				try {
					for (int i = 0; i < treeview1.Columns.Length; i++)
						treeview1.RemoveColumn (treeview1.Columns [i]);
				} catch {
				}
				TreeViewColumn ausdruck = new TreeViewColumn ();
				ausdruck.Title = "Ausdruck";
				TreeViewColumn titel = new TreeViewColumn ();
				titel.Title = "Titel";
				TreeViewColumn description = new TreeViewColumn ();
				description.Title = "Beschreibung";
				treeview1.AppendColumn (ausdruck);
				treeview1.AppendColumn (titel);
				treeview1.AppendColumn (description);
				//treeview1.AppendColumn (new TreeViewColumn () {Title = "Pfad" });
				g_regexList = new ListStore (typeof(string), typeof(string), typeof(string), typeof(string));
				treeview1.Model = g_regexList;
				ausdruck.PackStart (new CellRendererText (), true);
				titel.PackStart (new CellRendererText (), true);
				description.PackStart (new CellRendererText (), true);
				ausdruck.SetAttributes (ausdruck.CellRenderers [0], "text", 0);
				//treeview1.Columns [3].PackStart (new CellRendererText (), true);
				//treeview1.Columns [3].SetAttributes (treeview1.Columns [3].CellRenderers [0], "text", 3);
				titel.SetAttributes (titel.CellRenderers [0], "text", 1);
				description.SetAttributes (description.CellRenderers [0], "text", 2);
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// _appends the items.
		/// </summary>
		public void _appendItems ()
		{
			try {
				string[] files = System.IO.Directory.GetFiles (new cPathEnvironment ().const_examples_directory, "*.rgx");
				foreach (string f in files) {
					string[] inh = System.IO.File.ReadAllLines (f);
					string vorschau = "";
					for (int i = 0; i < inh[2].Length && vorschau.Length < 11; i++)
						vorschau += inh [2] [i].ToString ();
				
					g_regexList.AppendValues (vorschau, inh [0], inh [1], f);
				}	
			 
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}

		/// <summary>
		/// Appends the items.
		/// </summary>
		public void appendItems ()
		{
			IDbConnection dbcon;
			try {				
				//TODO: this is linux only.
				string connectionString = "URI=file:" + new cPathEnvironment ().const_examples_directory + "/Library.db";
				//MessageBox.Show (connectionString, "", ButtonsType.None, MessageType.Info, null);
			
				dbcon = (IDbConnection)new SqliteConnection (connectionString);
				dbcon.Open ();
				IDbCommand dbcmd = dbcon.CreateCommand ();
				string sql = "SELECT Title,Phrase,Description " + "FROM phrases";
				dbcmd.CommandText = sql;
				IDataReader reader = dbcmd.ExecuteReader ();
				while (reader.Read()) {				
					g_regexList.AppendValues (reader.GetString (1), reader.GetString (0), reader.GetString (2));
				}
				// clean up
				reader.Close ();
				reader = null;
				dbcmd.Dispose ();
				dbcmd = null;
				
			 
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			} finally {
				dbcon.Close ();
				dbcon = null;
			}
		}
		/// <summary>
		/// Deletes the item.
		/// </summary>
		public void deleteItem ()
		{
			IDbConnection dbcon;
			try {			

				if (g_name != "" || g_name != string.Empty || g_name != null) {
					if (MessageBox.Show ("Sind Sie sich sicher, das Element zu löschen?", "Bestätigung erforderlich", ButtonsType.YesNo, MessageType.Question, null) == ResponseType.Yes) {
						string connectionString = "URI=file:" + new cPathEnvironment ().const_examples_directory + new cPathEnvironment ().const_path_separator + "Library.db";
						dbcon = (IDbConnection)new SqliteConnection (connectionString);
						dbcon.Open ();
						IDbCommand dbcmd = dbcon.CreateCommand ();
						string sql = "Delete " + " FROM phrases WHERE Title = \"" + g_name + "\"";
						dbcmd.CommandText = sql;
						int res = dbcmd.ExecuteNonQuery ();
						appendColumns ();
						appendItems ();
						dbcmd.Dispose ();
						dbcmd = null;
					}
				} else {
					MessageBox.Show ("Fehler: Sie müssen ein Element auswählen, um es zu Löschen!", "Fehler: Keine Auswahl getroffen", Gtk.ButtonsType.Ok, MessageType.Error, null);
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			} finally {
				dbcon.Close ();
				dbcon = null;
			}
		}
		protected void OnButton2Clicked (object sender, EventArgs e)
		{
			try {
				cTerminus.AddTab (g_notebook, "");
				cTerminus.setExpressionofTab (g_notebook, g_notebook.Page, g_selection);				
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}	
		protected void OnButton1Clicked (object sender, EventArgs e)
		{
			try {
				//cTerminus.setExpressionofTab (notebook, notebook.Page, System.IO.File.ReadAllLines (selectedpath) [2], true);
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}	

		protected void OnButton3Clicked (object sender, EventArgs e)
		{
			try {
				Gtk.Clipboard clipboard = Gtk.Clipboard.Get (Gdk.Atom.Intern ("CLIPBOARD", false));

				string content = g_selection;
				clipboard.SetText (content);
			} catch {

			}
		}		

		protected void OnTreeview1CursorChanged (object sender, EventArgs e)
		{
			try {			
				TreeSelection _selection = (sender as TreeView).Selection;
				TreeModel model;
				TreeIter iter;
				if (_selection.GetSelected (out model, out iter)) {
					g_selection = model.GetValue (iter, 0).ToString ();
					g_name = model.GetValue (iter, 1).ToString ();
				}

			} catch {
			}
		}
		protected void OnButton4Clicked (object sender, EventArgs e)
		{
			try {
				if (g_name != null && g_name != "") {
					deleteItem ();
				}
			} catch {
			}
		}





	}
}

