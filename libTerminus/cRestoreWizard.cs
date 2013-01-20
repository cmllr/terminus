//  cRestoreWizard.cs - Restore not saved phrases
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
using Gtk;
namespace libTerminus
{
	public partial class cRestoreWizard : Gtk.Window
	{
		ListStore g_regexList;
		string g_selection;
		public cRestoreWizard () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			appendColumns ();
			foreach (int i in new cRevertData().getDays(calendar2.Month +1))
				calendar2.MarkDay ((uint)i);
			hscale1.ValueChanged += OnHscale2ValueChanged;
			calendar2.MonthChanged += delegate {
				calendar2.ClearMarks ();
				foreach (int i in new cRevertData().getDays(calendar2.Month +1))
					calendar2.MarkDay ((uint)i);
			};
			treeview1.CursorChanged += HandleCursorChanged;
		}
		void HandleCursorChanged (object sender, EventArgs e)
		{
			try {
				TreeSelection selection = (sender as TreeView).Selection;
				TreeModel model;
				TreeIter iter;
				if (selection.GetSelected (out model, out iter) && model.GetValue (iter, 3) != "") {
					g_selection = (model.GetValue (iter, 0).ToString ());
				}
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		protected void OnButton1Clicked (object sender, EventArgs e)
		{
			List<string> values = new List<string> ();
			values = new cRevertData ().getRestoredData (calendar2.Date.ToShortDateString (), this.hscale1.Value.ToString (), this.hscale2.Value.ToString ());		
			_appendItems (values);
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
			

				g_regexList = new ListStore (typeof(string), typeof(string));


				TreeViewColumn ausdruck = new TreeViewColumn ();
				ausdruck.Title = "Ausdruck";
				ausdruck.PackStart (new CellRendererText (), true);
				ausdruck.SetAttributes (ausdruck.CellRenderers [0], "text", 0);


				TreeViewColumn datum = new TreeViewColumn ();
				datum.Title = "Datum";
				datum.PackStart (new CellRendererText (), true);
				datum.SetAttributes (datum.CellRenderers [0], "text", 1);

				treeview1.Model = g_regexList;
				treeview1.AppendColumn (ausdruck);
				treeview1.AppendColumn (datum);

			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		/// <summary>
		/// _appends the items.
		/// </summary>
		public void _appendItems (List<string> _list)
		{
			try {
				g_regexList.Clear ();
				foreach (string f in _list) {									
					g_regexList.AppendValues (f, calendar2.Date.ToShortDateString ());
				}	
				
			} catch (Exception ex) {
				MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
			}
		}
		protected void OnHscale2ValueChanged (object sender, EventArgs e)
		{
			try {
				button1.Label = "Suchen (" + calendar2.Date.DayOfWeek.ToString () + ", der " + calendar2.Date.ToShortDateString () + " von " + hscale1.Value.ToString () + " bis " + hscale2.Value.ToString () + " Uhr).";
			} catch {
				button1.Label = "Suchen";
			}
		}
		protected void OnTogglebutton1Clicked (object sender, EventArgs e)
		{
			try {
				Gtk.Clipboard clipboard = Gtk.Clipboard.Get (Gdk.Atom.Intern ("CLIPBOARD", false));
				
				string content = g_selection;
				clipboard.SetText (content);
			} catch {
				
			}
		}
	}
}

