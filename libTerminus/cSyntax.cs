//
//  cSyntax.cs
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
using Gdk;
namespace libTerminus
{
	public class cSyntax
	{
		public string g_noneColorDescription {get;set;}
		public string g_colorCorrectDescription {get;set;}
		public string g_edgedBracketsColorDescription {get;set;}
		public string g_roundBracketsColorDescription {get;set;}
		public string g_otherBracketsColorDescription {get;set;}
		public string g_constantColorDescription {get;set;}
		public string g_QuantifierColorDescription {get;set;}
		public string g_BackGroundColor {get;set;}
		public cSyntax (string _scheme, ref Gtk.TextView _textview,bool _onlybackground)
		{
			//TODO: Create example scheme

			string[] content = System.IO.File.ReadAllLines(_scheme);
			g_noneColorDescription = content[0].Split(new char[] {';'})[1];
			g_colorCorrectDescription = content[1].Split(new char[] {';'})[1];
			g_edgedBracketsColorDescription = content[2].Split(new char[] {';'})[1];
			g_roundBracketsColorDescription = content[3].Split(new char[] {';'})[1];
			g_otherBracketsColorDescription = content[4].Split(new char[] {';'})[1];
			g_constantColorDescription = content[5].Split(new char[] {';'})[1];
			g_QuantifierColorDescription = content[6].Split(new char[] {';'})[1];
			g_BackGroundColor = content[7].Split(new char[] {';'})[1];
			if (_onlybackground == false){
			TextTag tagnone = new TextTag ("nosyntax");
			Gdk.Color nonecolor = new Gdk.Color();
			Gdk.Color.Parse (g_noneColorDescription, ref nonecolor);
			tagnone.ForegroundGdk = nonecolor;				
			_textview.Buffer.TagTable.Add (tagnone);
			TextTag tagcorrect = new TextTag ("backslashliteral");
			Gdk.Color colorcorrect= new Gdk.Color();
			Gdk.Color.Parse (g_colorCorrectDescription, ref colorcorrect);
			tagcorrect.ForegroundGdk = colorcorrect;
			tagcorrect.FontDesc = getBold ();
			_textview.Buffer.TagTable.Add (tagcorrect);
			TextTag edgedBrackets = new TextTag ("edgedBrackets");
			Gdk.Color coloredgetBrackets = new Gdk.Color();
			Gdk.Color.Parse (g_edgedBracketsColorDescription, ref coloredgetBrackets);
			edgedBrackets.ForegroundGdk = coloredgetBrackets;
			_textview.Buffer.TagTable.Add (edgedBrackets);
			TextTag roundBrackets = new TextTag ("roundBrackets");
			Gdk.Color colorroundbrackets = new Gdk.Color();
			Gdk.Color.Parse (g_roundBracketsColorDescription, ref colorroundbrackets);
			roundBrackets.ForegroundGdk = colorroundbrackets;
			_textview.Buffer.TagTable.Add (roundBrackets);
			TextTag otherBrackets = new TextTag ("otherBrackets");
			Gdk.Color otherBracketsColor= new Gdk.Color();
			Gdk.Color.Parse (g_otherBracketsColorDescription, ref otherBracketsColor);
			otherBrackets.ForegroundGdk = otherBracketsColor;
			otherBrackets.FontDesc = getBold();
			_textview.Buffer.TagTable.Add (otherBrackets);
			TextTag constant = new TextTag ("constant");
			Gdk.Color constantcolor= new Gdk.Color();
			Gdk.Color.Parse (g_constantColorDescription, ref constantcolor);
			constant.ForegroundGdk = constantcolor;
			_textview.Buffer.TagTable.Add (constant);
			TextTag quantifier = new TextTag ("quantifier");
			Gdk.Color quantifiercolor= new Gdk.Color();
			Gdk.Color.Parse (g_QuantifierColorDescription, ref quantifiercolor);
			quantifier.ForegroundGdk = quantifiercolor;
			Gdk.Color backgroundcolor= new Gdk.Color();
			Gdk.Color.Parse(g_BackGroundColor,ref backgroundcolor);
			_textview.ModifyBase(StateType.Normal,backgroundcolor);
			_textview.Buffer.TagTable.Add (quantifier);
			}
			else
			{
				Gdk.Color backgroundcolor = new Gdk.Color();
				Gdk.Color.Parse(g_BackGroundColor,ref backgroundcolor);
				_textview.ModifyBase(StateType.Normal,backgroundcolor);
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

	}
}

