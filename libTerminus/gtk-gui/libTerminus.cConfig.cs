
// This file has been generated by the GUI designer. Do not modify.
namespace libTerminus
{
	public partial class cConfig
	{
		private global::Gtk.Frame frame1;
		private global::Gtk.Alignment GtkAlignment;
		private global::Gtk.VBox vbox3;
		private global::Gtk.CheckButton IgnoreCase;
		private global::Gtk.CheckButton ExplicitCapture;
		private global::Gtk.CheckButton IgnorePatternWhitespace;
		private global::Gtk.CheckButton SyntaxEnabled;
		private global::Gtk.HBox hbox1;
		private global::Gtk.CheckButton DisplayStyle;
		private global::Gtk.Label GtkLabel7;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget libTerminus.cConfig
			global::Stetic.BinContainer.Attach (this);
			this.Name = "libTerminus.cConfig";
			// Container child libTerminus.cConfig.Gtk.Container+ContainerChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0F, 0F, 1F, 1F);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.IgnoreCase = new global::Gtk.CheckButton ();
			this.IgnoreCase.TooltipMarkup = "Die Groß- und Kleinschreibung Ihres Ausdrucks wird ignoriert.\nBeispiel: \"test\" trifft auch auf \"TEST\" zu.";
			this.IgnoreCase.CanFocus = true;
			this.IgnoreCase.Name = "IgnoreCase";
			this.IgnoreCase.Label = global::Mono.Unix.Catalog.GetString ("Groß- /Kleinschreibung ignorieren.");
			this.IgnoreCase.DrawIndicator = true;
			this.IgnoreCase.UseUnderline = true;
			this.vbox3.Add (this.IgnoreCase);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.IgnoreCase]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.ExplicitCapture = new global::Gtk.CheckButton ();
			this.ExplicitCapture.TooltipMarkup = "Die Datenquelle muss genau auf den Ausdruck übereinstimmen.";
			this.ExplicitCapture.CanFocus = true;
			this.ExplicitCapture.Name = "ExplicitCapture";
			this.ExplicitCapture.Label = global::Mono.Unix.Catalog.GetString ("Explicit Capture");
			this.ExplicitCapture.DrawIndicator = true;
			this.ExplicitCapture.UseUnderline = true;
			this.vbox3.Add (this.ExplicitCapture);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.ExplicitCapture]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.IgnorePatternWhitespace = new global::Gtk.CheckButton ();
			this.IgnorePatternWhitespace.TooltipMarkup = "Leerzeichen werden im Ausdruck/ Datenquelle ignoriert.";
			this.IgnorePatternWhitespace.CanFocus = true;
			this.IgnorePatternWhitespace.Name = "IgnorePatternWhitespace";
			this.IgnorePatternWhitespace.Label = global::Mono.Unix.Catalog.GetString ("Leerzeichen ignorieren");
			this.IgnorePatternWhitespace.DrawIndicator = true;
			this.IgnorePatternWhitespace.UseUnderline = true;
			this.vbox3.Add (this.IgnorePatternWhitespace);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.IgnorePatternWhitespace]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.SyntaxEnabled = new global::Gtk.CheckButton ();
			this.SyntaxEnabled.TooltipMarkup = "Das Programm kann Ihnen verschiedene Teile des Regex - Syntaxes farbig markieren, um Ihnen die Arbeit zu erleichtern.";
			this.SyntaxEnabled.CanFocus = true;
			this.SyntaxEnabled.Name = "SyntaxEnabled";
			this.SyntaxEnabled.Label = global::Mono.Unix.Catalog.GetString ("Syntaxhervorhebung aktivieren");
			this.SyntaxEnabled.DrawIndicator = true;
			this.SyntaxEnabled.UseUnderline = true;
			this.vbox3.Add (this.SyntaxEnabled);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.SyntaxEnabled]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.DisplayStyle = new global::Gtk.CheckButton ();
			this.DisplayStyle.TooltipMarkup = "Sie können die Beschreibungen der Elemente der Toolbar ein- oder ausblenden.";
			this.DisplayStyle.CanFocus = true;
			this.DisplayStyle.Name = "DisplayStyle";
			this.DisplayStyle.Label = global::Mono.Unix.Catalog.GetString ("Toolbar - Beschreibungen ausblenden");
			this.DisplayStyle.DrawIndicator = true;
			this.DisplayStyle.UseUnderline = true;
			this.hbox1.Add (this.DisplayStyle);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.DisplayStyle]));
			w5.Position = 0;
			this.vbox3.Add (this.hbox1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
			w6.Position = 4;
			w6.Expand = false;
			w6.Fill = false;
			this.GtkAlignment.Add (this.vbox3);
			this.frame1.Add (this.GtkAlignment);
			this.GtkLabel7 = new global::Gtk.Label ();
			this.GtkLabel7.Name = "GtkLabel7";
			this.GtkLabel7.LabelProp = global::Mono.Unix.Catalog.GetString ("Programmeinstellungen");
			this.GtkLabel7.UseMarkup = true;
			this.frame1.LabelWidget = this.GtkLabel7;
			this.Add (this.frame1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
