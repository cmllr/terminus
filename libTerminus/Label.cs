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
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.Label"/> class.
		/// </summary>
		/// <param name='_text'>
		/// _text.
		/// </param>
		/// <param name='_nb'>
		/// _nb.
		/// </param>
		public Label (string _text,ref Notebook _nb)
		{
			this.Build ();
			label1.Text = _text;
			//label1.ButtonPressEvent += HandleButtonPressEvent;
			gnb = _nb;
		}
		

		void HandleButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
		{
			MessageBox.Show ("test", "test", Gtk.ButtonsType.Close, Gtk.MessageType.Question);
		}


		protected void OnButton1Clicked (object sender, System.EventArgs e)
		{
			//int pre =  gnb.NPages;
			cTerminus.CloseTab(gnb,gnb.Page);
		}
	}
}

