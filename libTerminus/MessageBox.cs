using System;
using Gtk;
using System.Reflection;
using System.Diagnostics;
namespace  libTerminus
{
	/// <summary>
	/// The MessageBox - Class tries to get the feel - alike of the good old MessageBox - Class of the .NET Framework
	/// </summary>
	public static class MessageBox
	{
		/// <summary>
		/// Show the specified text, caption, _Buttons and _Type.
		/// </summary>
		/// <param name='text'>
		/// Text.
		/// </param>
		/// <param name='caption'>
		/// Caption.
		/// </param>
		/// <param name='_Buttons'>
		/// The Buttons of the MessageDialog
		/// </param>
		/// <param name='_Type'>
		/// The Type of the MessageDialog.
		/// </param>
		public static ResponseType Show (string text, string caption, ButtonsType _Buttons = ButtonsType.Ok, MessageType _Type = MessageType.Info,Gdk.Window parent = null)
		{
			if (text.Contains ("not set")) {
				cLogger.Log (text, new StackTrace ().GetFrame (0).GetMethod ().Name);				
				return ResponseType.None;
			} else {
				MessageDialog md = new MessageDialog (null, DialogFlags.Modal, _Type, _Buttons, text);
				if (parent != null)
				md.ParentWindow = parent;
				md.Title = caption;				
				ResponseType result = (ResponseType)md.Run ();
				md.Destroy ();
				return result;
			}	
		}		
	}
}