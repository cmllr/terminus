// 
//  cConfig.cs
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
	[System.ComponentModel.ToolboxItem(true)]
	/// <summary>
	/// The Configuration - Class, which provides a GTK - Widget for use as a config dialog
	/// </summary>
	public partial class cConfig : Gtk.Bin
	{
		public cConfig (cConfigPlatform _cfgPlatform)
		{
			this.Build ();
			//First, tell the Terminus - Thread that a config tab is open
			cTerminus.isConfigTabOpen = true;
			//Set the values checked/not checked 
			this.IgnoreCase.Active = _cfgPlatform.IgnoreCase;
			this.IgnorePatternWhitespace.Active = _cfgPlatform.IgnoreWhitespace;
			this.ExplicitCapture.Active = _cfgPlatform.Explicit;
			this.SyntaxEnabled.Active = _cfgPlatform.useSyntax;
			DisplayStyle.Active = _cfgPlatform.HideText;
			reduce.Active = _cfgPlatform.ReduceSyntaxChanging;
			//set the events to change the values in the main config class
			IgnoreCase.Toggled += delegate {
				cTerminus.Configuration.IgnoreCase = IgnoreCase.Active;
			};
			IgnorePatternWhitespace.Toggled += delegate {
				cTerminus.Configuration.IgnoreWhitespace = IgnorePatternWhitespace.Active;
			};
			ExplicitCapture.Toggled += delegate {
				cTerminus.Configuration.Explicit = ExplicitCapture.Active;
			};
			SyntaxEnabled.Toggled += delegate {
				cTerminus.Configuration.useSyntax = SyntaxEnabled.Active;
			};
			DisplayStyle.Toggled += delegate {
				cTerminus.Configuration.HideText = DisplayStyle.Active;
			};
			reduce.Toggled += delegate {
				cTerminus.Configuration.ReduceSyntaxChanging = reduce.Active;
			};
			string path;
			if (new cPathEnvironment().const_settings_path.Contains("Program.cfg"))
				 path = new cPathEnvironment().const_settings_path.Replace("Program.cfg" ,"ColorShemes" + new cPathEnvironment().const_path_separator) ;
			else
				path =  @"/usr/share/terminus/Boot/Config/ColorShemes/";
			int i = 0;
			foreach (string st in System.IO.Directory.GetFiles(path,"*.config")){
				combobox2.InsertText(i,new System.IO.FileInfo(st).Name.Replace(".config","")); 
				if (st.Contains(cTerminus.Configuration.Theme))
				{
					Gtk.TreeIter iter;
					combobox2.Active = i;
					combobox2.Model.IterNthChild (out iter, i);
					combobox2.SetActiveIter (iter);
				}
				i++;
			}

			combobox2.Changed += delegate(object sender, EventArgs e) {
				Gtk.TreeIter iter;
				if (((Gtk.ComboBox)sender).GetActiveIter(out iter)){
					cTerminus.Configuration.Theme = (string) ((Gtk.ComboBox)sender).Model.GetValue (iter, 0);//new System.IO.FileInfo( ((string) ((Gtk.ComboBox)sender).Model.GetValue (iter, 0))).Name.Replace(".config","");
				}
			};
		}

		protected void OnButton1Clicked (object sender, EventArgs e)
		{
			if (MessageBox.Show("Möchten Sie die Ausdrücke wirklich löschen? Diese können <b>nicht</b> wiederhergestellt werden!","Bestätigen",Gtk.ButtonsType.YesNo,Gtk.MessageType.Question,null) == Gtk.ResponseType.Yes)
			new cRevertData().Clear();
		}
	}
}

