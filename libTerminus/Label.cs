using System;
using Gtk;

namespace libTerminus
{
	[System.ComponentModel.ToolboxItem(true)]
	/// <summary>
	/// A expandable Label - class
	/// </summary>
	public partial class Label : Gtk.Bin
	{
		/// <summary>
		/// The Notebook to use
		/// </summary>
		Notebook gnb;
		Widget widg;
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.Label"/> class.
		/// </summary>
		/// <param name='_text'>
		/// _text.
		/// </param>
		/// <param name='_nb'>
		/// _nb.
		/// </param>
		public Label (string _text,ref Notebook _nb,Widget _widg)
		{
			this.Build ();
			label1.Text = _text;
			gnb = _nb;
			widg = _widg;
		}
		protected void OnButton1Clicked (object sender, System.EventArgs e)
		{
			int i = 0;
			foreach(Widget x in gnb.Children)
			{
				if (x == widg)
					cTerminus.CloseTab(gnb,i);
				i++;
			}


		

			//TODO: Here's a bug - a tab will close at every time the current selected tab.
			//cTerminus.CloseTab(gnb,gnb.Page);
		}
	}
}

