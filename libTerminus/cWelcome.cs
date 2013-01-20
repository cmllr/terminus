//
//  cWelcome.cs
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
using WebKit;
namespace libTerminus
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class cWelcome : Gtk.Bin
	{
		WebView g_WebView = new WebView ();
		public cWelcome ()
		{
			this.Build ();
			this.Add (g_WebView);
			g_WebView.Open (new cPathEnvironment ().const_program_license.Replace ("License", "Welcome.html"));
		}
	
	}
}

