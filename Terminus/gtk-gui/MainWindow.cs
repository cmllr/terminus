
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action DateiAction;
	private global::Gtk.Action newAction;
	private global::Gtk.Action openAction;
	private global::Gtk.Action saveAction;
	private global::Gtk.Action saveAsAction;
	private global::Gtk.Action closeAction;
	private global::Gtk.Action quitAction;
	private global::Gtk.Action BearbeitenAction;
	private global::Gtk.Action saveAction1;
	private global::Gtk.Action closeAction1;
	private global::Gtk.Action saveAsAction1;
	private global::Gtk.Action newAction1;
	private global::Gtk.Action openAction1;
	private global::Gtk.Action undoAction;
	private global::Gtk.Action redoAction;
	private global::Gtk.Action cutAction;
	private global::Gtk.Action copyAction;
	private global::Gtk.Action pasteAction;
	private global::Gtk.Action mediaPlayAction1;
	private global::Gtk.Action clearAction;
	private global::Gtk.Action selectAllAction1;
	private global::Gtk.Action separatorAction;
	private global::Gtk.Action undoAction1;
	private global::Gtk.Action redoAction1;
	private global::Gtk.Action cutAction1;
	private global::Gtk.Action copyAction1;
	private global::Gtk.Action pasteAction1;
	private global::Gtk.Action RegexAction;
	private global::Gtk.Action mediaPlayAction;
	private global::Gtk.Action ExtrasAction;
	private global::Gtk.Action propertiesAction;
	private global::Gtk.Action HilfeAction;
	private global::Gtk.Action cancelAction;
	private global::Gtk.Action aboutAction;
	private global::Gtk.Action preferencesAction;
	private global::Gtk.Action selectAllAction;
	private global::Gtk.Action spellCheckAction;
	private global::Gtk.Action aboutAction1;
	private global::Gtk.Action ExportAction;
	private global::Gtk.Action Action;
	private global::Gtk.Action gotoBottomAction;
	private global::Gtk.Action NurTextTxtAction;
	private global::Gtk.Action HypertextHtmlAction;
	private global::Gtk.Action KommaGetrenntCsvAction;
	private global::Gtk.Action preferencesAction1;
	private global::Gtk.Action berDieseVersionAction;
	private global::Gtk.Action dialogQuestionAction;
	private global::Gtk.Action connectAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar1;
	private global::Gtk.Toolbar toolbar1;
	private global::Gtk.Notebook notebook1;
	private global::Gtk.VBox vbox2;
	private global::Gtk.Expander expander3;
	private global::Gtk.VBox vbox3;
	private global::Gtk.CheckButton IgnoreCase;
	private global::Gtk.CheckButton ExplicitCapture;
	private global::Gtk.CheckButton IgnorePatternWhitespace;
	private global::Gtk.HBox hbox1;
	private global::Gtk.RadioButton radiobutton1;
	private global::Gtk.RadioButton radiobutton2;
	private global::Gtk.RadioButton radiobutton3;
	private global::Gtk.Label GtkLabel26;
	private global::Gtk.Expander expander1;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TextView Output;
	private global::Gtk.Label GtkLabel27;
	private global::Gtk.Label cStatusLabele;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.DateiAction = new global::Gtk.Action ("DateiAction", global::Mono.Unix.Catalog.GetString ("Datei"), null, null);
		this.DateiAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Datei");
		w1.Add (this.DateiAction, null);
		this.newAction = new global::Gtk.Action ("newAction", global::Mono.Unix.Catalog.GetString ("Neu"), null, "gtk-new");
		this.newAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Neu");
		w1.Add (this.newAction, null);
		this.openAction = new global::Gtk.Action ("openAction", global::Mono.Unix.Catalog.GetString ("Öffnen"), null, "gtk-open");
		this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Öffnen");
		w1.Add (this.openAction, null);
		this.saveAction = new global::Gtk.Action ("saveAction", global::Mono.Unix.Catalog.GetString ("Speichern"), null, "gtk-save");
		this.saveAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Speichern");
		w1.Add (this.saveAction, null);
		this.saveAsAction = new global::Gtk.Action ("saveAsAction", global::Mono.Unix.Catalog.GetString ("Speichern unter"), null, "gtk-save-as");
		this.saveAsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Speichern unter");
		w1.Add (this.saveAsAction, null);
		this.closeAction = new global::Gtk.Action ("closeAction", global::Mono.Unix.Catalog.GetString ("Schließen"), null, "gtk-close");
		this.closeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Schließen");
		w1.Add (this.closeAction, null);
		this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("Beenden"), null, "gtk-quit");
		this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Beenden");
		w1.Add (this.quitAction, null);
		this.BearbeitenAction = new global::Gtk.Action ("BearbeitenAction", global::Mono.Unix.Catalog.GetString ("Bearbeiten"), null, null);
		this.BearbeitenAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Bearbeiten");
		w1.Add (this.BearbeitenAction, null);
		this.saveAction1 = new global::Gtk.Action ("saveAction1", null, null, "gtk-save");
		w1.Add (this.saveAction1, null);
		this.closeAction1 = new global::Gtk.Action ("closeAction1", null, null, "gtk-close");
		w1.Add (this.closeAction1, null);
		this.saveAsAction1 = new global::Gtk.Action ("saveAsAction1", null, null, "gtk-save-as");
		w1.Add (this.saveAsAction1, null);
		this.newAction1 = new global::Gtk.Action ("newAction1", null, null, "gtk-new");
		w1.Add (this.newAction1, null);
		this.openAction1 = new global::Gtk.Action ("openAction1", null, null, "gtk-open");
		w1.Add (this.openAction1, null);
		this.undoAction = new global::Gtk.Action ("undoAction", null, null, "gtk-undo");
		w1.Add (this.undoAction, null);
		this.redoAction = new global::Gtk.Action ("redoAction", null, null, "gtk-redo");
		w1.Add (this.redoAction, null);
		this.cutAction = new global::Gtk.Action ("cutAction", null, null, "gtk-cut");
		w1.Add (this.cutAction, null);
		this.copyAction = new global::Gtk.Action ("copyAction", null, null, "gtk-copy");
		w1.Add (this.copyAction, null);
		this.pasteAction = new global::Gtk.Action ("pasteAction", null, null, "gtk-paste");
		w1.Add (this.pasteAction, null);
		this.mediaPlayAction1 = new global::Gtk.Action ("mediaPlayAction1", global::Mono.Unix.Catalog.GetString ("Ausführen"), null, "gtk-media-play");
		this.mediaPlayAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Ausführen");
		w1.Add (this.mediaPlayAction1, null);
		this.clearAction = new global::Gtk.Action ("clearAction", null, null, "gtk-clear");
		w1.Add (this.clearAction, null);
		this.selectAllAction1 = new global::Gtk.Action ("selectAllAction1", global::Mono.Unix.Catalog.GetString ("Bibliothek"), null, "gtk-select-all");
		this.selectAllAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Bibliothek");
		w1.Add (this.selectAllAction1, null);
		this.separatorAction = new global::Gtk.Action ("separatorAction", null, null, "gtk-separator");
		w1.Add (this.separatorAction, null);
		this.undoAction1 = new global::Gtk.Action ("undoAction1", global::Mono.Unix.Catalog.GetString ("Rückgängig"), null, "gtk-undo");
		this.undoAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Undo");
		w1.Add (this.undoAction1, null);
		this.redoAction1 = new global::Gtk.Action ("redoAction1", global::Mono.Unix.Catalog.GetString ("Wiederholen"), null, "gtk-redo");
		this.redoAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Redo");
		w1.Add (this.redoAction1, null);
		this.cutAction1 = new global::Gtk.Action ("cutAction1", global::Mono.Unix.Catalog.GetString ("Ausschneiden"), null, "gtk-cut");
		this.cutAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Cu_t");
		w1.Add (this.cutAction1, null);
		this.copyAction1 = new global::Gtk.Action ("copyAction1", global::Mono.Unix.Catalog.GetString ("Kopieren"), null, "gtk-copy");
		this.copyAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Copy");
		w1.Add (this.copyAction1, null);
		this.pasteAction1 = new global::Gtk.Action ("pasteAction1", global::Mono.Unix.Catalog.GetString ("Einfügen"), null, "gtk-paste");
		this.pasteAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Paste");
		w1.Add (this.pasteAction1, null);
		this.RegexAction = new global::Gtk.Action ("RegexAction", global::Mono.Unix.Catalog.GetString ("Regex"), null, null);
		this.RegexAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Regex");
		w1.Add (this.RegexAction, null);
		this.mediaPlayAction = new global::Gtk.Action ("mediaPlayAction", global::Mono.Unix.Catalog.GetString ("Ausführen"), null, "gtk-media-play");
		this.mediaPlayAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Execute");
		w1.Add (this.mediaPlayAction, null);
		this.ExtrasAction = new global::Gtk.Action ("ExtrasAction", global::Mono.Unix.Catalog.GetString ("Extras"), null, null);
		this.ExtrasAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Extras");
		w1.Add (this.ExtrasAction, null);
		this.propertiesAction = new global::Gtk.Action ("propertiesAction", global::Mono.Unix.Catalog.GetString ("_Properties"), null, "gtk-properties");
		this.propertiesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Properties");
		w1.Add (this.propertiesAction, null);
		this.HilfeAction = new global::Gtk.Action ("HilfeAction", global::Mono.Unix.Catalog.GetString ("Hilfe"), null, null);
		this.HilfeAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Hilfe");
		w1.Add (this.HilfeAction, null);
		this.cancelAction = new global::Gtk.Action ("cancelAction", global::Mono.Unix.Catalog.GetString ("Fehler melden"), null, "gtk-cancel");
		this.cancelAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Fehler melden");
		w1.Add (this.cancelAction, null);
		this.aboutAction = new global::Gtk.Action ("aboutAction", global::Mono.Unix.Catalog.GetString ("_About"), null, "gtk-about");
		this.aboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_About");
		w1.Add (this.aboutAction, null);
		this.preferencesAction = new global::Gtk.Action ("preferencesAction", global::Mono.Unix.Catalog.GetString ("Einstellungen"), null, "gtk-preferences");
		this.preferencesAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Properties");
		w1.Add (this.preferencesAction, null);
		this.selectAllAction = new global::Gtk.Action ("selectAllAction", global::Mono.Unix.Catalog.GetString ("Bibliothek"), null, "gtk-select-all");
		this.selectAllAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Bibliothek");
		w1.Add (this.selectAllAction, null);
		this.spellCheckAction = new global::Gtk.Action ("spellCheckAction", global::Mono.Unix.Catalog.GetString ("_Spell Check"), null, "gtk-spell-check");
		this.spellCheckAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Spell Check");
		w1.Add (this.spellCheckAction, null);
		this.aboutAction1 = new global::Gtk.Action ("aboutAction1", null, null, "gtk-about");
		w1.Add (this.aboutAction1, null);
		this.ExportAction = new global::Gtk.Action ("ExportAction", global::Mono.Unix.Catalog.GetString ("Export"), null, null);
		this.ExportAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Export");
		w1.Add (this.ExportAction, null);
		this.Action = new global::Gtk.Action ("Action", null, null, null);
		w1.Add (this.Action, null);
		this.gotoBottomAction = new global::Gtk.Action ("gotoBottomAction", global::Mono.Unix.Catalog.GetString ("Exportieren"), null, "gtk-goto-bottom");
		this.gotoBottomAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Exportieren");
		w1.Add (this.gotoBottomAction, null);
		this.NurTextTxtAction = new global::Gtk.Action ("NurTextTxtAction", global::Mono.Unix.Catalog.GetString ("Nur Text (*.txt)"), null, null);
		this.NurTextTxtAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Nur Text (*.txt)");
		w1.Add (this.NurTextTxtAction, null);
		this.HypertextHtmlAction = new global::Gtk.Action ("HypertextHtmlAction", global::Mono.Unix.Catalog.GetString ("Hypertext (*.html)"), null, null);
		this.HypertextHtmlAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Hypertext (*.html)");
		w1.Add (this.HypertextHtmlAction, null);
		this.KommaGetrenntCsvAction = new global::Gtk.Action ("KommaGetrenntCsvAction", global::Mono.Unix.Catalog.GetString ("Komma - getrennt (*.csv)"), null, null);
		this.KommaGetrenntCsvAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Komma - getrennt (*.csv)");
		w1.Add (this.KommaGetrenntCsvAction, null);
		this.preferencesAction1 = new global::Gtk.Action ("preferencesAction1", null, null, "gtk-preferences");
		w1.Add (this.preferencesAction1, null);
		this.berDieseVersionAction = new global::Gtk.Action ("berDieseVersionAction", global::Mono.Unix.Catalog.GetString ("Über diese Version"), null, null);
		this.berDieseVersionAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Über diese Version");
		w1.Add (this.berDieseVersionAction, null);
		this.dialogQuestionAction = new global::Gtk.Action ("dialogQuestionAction", global::Mono.Unix.Catalog.GetString ("Über diese Version"), null, "gtk-dialog-question");
		this.dialogQuestionAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Über diese Version");
		w1.Add (this.dialogQuestionAction, null);
		this.connectAction = new global::Gtk.Action ("connectAction", global::Mono.Unix.Catalog.GetString ("Web"), null, "gtk-connect");
		this.connectAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Web");
		w1.Add (this.connectAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.Icon = global::Gdk.Pixbuf.LoadFromResource ("Terminus.bin.Debug.Boot.Images.Programm.png");
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='DateiAction' action='DateiAction'><menuitem name='newAction' action='newAction'/><menuitem name='openAction' action='openAction'/><menuitem name='saveAction' action='saveAction'/><menuitem name='saveAsAction' action='saveAsAction'/><menuitem name='closeAction' action='closeAction'/><menuitem name='quitAction' action='quitAction'/></menu><menu name='BearbeitenAction' action='BearbeitenAction'><menuitem name='undoAction1' action='undoAction1'/><menuitem name='redoAction1' action='redoAction1'/><menuitem name='cutAction1' action='cutAction1'/><menuitem name='copyAction1' action='copyAction1'/><menuitem name='pasteAction1' action='pasteAction1'/><menuitem name='preferencesAction' action='preferencesAction'/></menu><menu name='RegexAction' action='RegexAction'><menuitem name='mediaPlayAction' action='mediaPlayAction'/><menu name='gotoBottomAction' action='gotoBottomAction'><menuitem name='NurTextTxtAction' action='NurTextTxtAction'/><menuitem name='HypertextHtmlAction' action='HypertextHtmlAction'/><menuitem name='KommaGetrenntCsvAction' action='KommaGetrenntCsvAction'/></menu></menu><menu name='ExtrasAction' action='ExtrasAction'><menuitem name='selectAllAction' action='selectAllAction'/></menu><menu name='HilfeAction' action='HilfeAction'><menuitem name='connectAction' action='connectAction'/><menuitem name='dialogQuestionAction' action='dialogQuestionAction'/><menuitem name='cancelAction' action='cancelAction'/><menuitem name='aboutAction' action='aboutAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='newAction1' action='newAction1'/><toolitem name='openAction1' action='openAction1'/><toolitem name='saveAction1' action='saveAction1'/><toolitem name='saveAsAction1' action='saveAsAction1'/><toolitem name='closeAction1' action='closeAction1'/><separator/><toolitem name='undoAction' action='undoAction'/><toolitem name='redoAction' action='redoAction'/><separator/><toolitem name='mediaPlayAction1' action='mediaPlayAction1'/><toolitem name='clearAction' action='clearAction'/><separator/><toolitem name='cutAction' action='cutAction'/><toolitem name='copyAction' action='copyAction'/><toolitem name='pasteAction' action='pasteAction'/><separator/><toolitem name='selectAllAction1' action='selectAllAction1'/><separator/><toolitem name='preferencesAction1' action='preferencesAction1'/><toolitem name='aboutAction1' action='aboutAction1'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.toolbar1.ToolbarStyle = ((global::Gtk.ToolbarStyle)(2));
		this.vbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.notebook1 = new global::Gtk.Notebook ();
		this.notebook1.CanFocus = true;
		this.notebook1.Name = "notebook1";
		this.notebook1.CurrentPage = -1;
		this.notebook1.ShowBorder = false;
		this.notebook1.Scrollable = true;
		this.vbox1.Add (this.notebook1);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.notebook1]));
		w4.Position = 2;
		// Container child vbox1.Gtk.Box+BoxChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.expander3 = new global::Gtk.Expander (null);
		this.expander3.CanFocus = true;
		this.expander3.Name = "expander3";
		this.expander3.Expanded = true;
		// Container child expander3.Gtk.Container+ContainerChild
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
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.IgnoreCase]));
		w5.Position = 0;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.ExplicitCapture = new global::Gtk.CheckButton ();
		this.ExplicitCapture.TooltipMarkup = "Die Datenquelle muss genau auf den Ausdruck übereinstimmen.";
		this.ExplicitCapture.CanFocus = true;
		this.ExplicitCapture.Name = "ExplicitCapture";
		this.ExplicitCapture.Label = global::Mono.Unix.Catalog.GetString ("Explicit Capture");
		this.ExplicitCapture.DrawIndicator = true;
		this.ExplicitCapture.UseUnderline = true;
		this.vbox3.Add (this.ExplicitCapture);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.ExplicitCapture]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.IgnorePatternWhitespace = new global::Gtk.CheckButton ();
		this.IgnorePatternWhitespace.TooltipMarkup = "Leerzeichen werden im Ausdruck/ Datenquelle ignoriert.";
		this.IgnorePatternWhitespace.CanFocus = true;
		this.IgnorePatternWhitespace.Name = "IgnorePatternWhitespace";
		this.IgnorePatternWhitespace.Label = global::Mono.Unix.Catalog.GetString ("Leerzeichen ignorieren");
		this.IgnorePatternWhitespace.DrawIndicator = true;
		this.IgnorePatternWhitespace.UseUnderline = true;
		this.vbox3.Add (this.IgnorePatternWhitespace);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.IgnorePatternWhitespace]));
		w7.Position = 2;
		w7.Expand = false;
		w7.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.radiobutton1 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Alle Ergebnisse anzeigen"));
		this.radiobutton1.TooltipMarkup = "Alle aus dem Ausdruck resultierenden Ergebnisse anzeigen";
		this.radiobutton1.CanFocus = true;
		this.radiobutton1.Name = "radiobutton1";
		this.radiobutton1.DrawIndicator = true;
		this.radiobutton1.UseUnderline = true;
		this.radiobutton1.Group = new global::GLib.SList (global::System.IntPtr.Zero);
		this.hbox1.Add (this.radiobutton1);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.radiobutton1]));
		w8.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.radiobutton2 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Nur nicht gruppierte Ergebnisse"));
		this.radiobutton2.TooltipMarkup = "Nur Ergebnisse präsentieren, die nicht in eine Gruppe eingeordnet sind.";
		this.radiobutton2.CanFocus = true;
		this.radiobutton2.Name = "radiobutton2";
		this.radiobutton2.DrawIndicator = true;
		this.radiobutton2.UseUnderline = true;
		this.radiobutton2.Group = this.radiobutton1.Group;
		this.hbox1.Add (this.radiobutton2);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.radiobutton2]));
		w9.Position = 1;
		// Container child hbox1.Gtk.Box+BoxChild
		this.radiobutton3 = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Nur Gruppen"));
		this.radiobutton3.TooltipMarkup = "Nur Ergebnisse einblenden, die aus Gruppen resultieren.";
		this.radiobutton3.CanFocus = true;
		this.radiobutton3.Name = "radiobutton3";
		this.radiobutton3.DrawIndicator = true;
		this.radiobutton3.UseUnderline = true;
		this.radiobutton3.Group = this.radiobutton1.Group;
		this.hbox1.Add (this.radiobutton3);
		global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.radiobutton3]));
		w10.Position = 2;
		this.vbox3.Add (this.hbox1);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox1]));
		w11.Position = 4;
		w11.Expand = false;
		w11.Fill = false;
		this.expander3.Add (this.vbox3);
		this.GtkLabel26 = new global::Gtk.Label ();
		this.GtkLabel26.Name = "GtkLabel26";
		this.GtkLabel26.LabelProp = global::Mono.Unix.Catalog.GetString ("Verarbeitungsoptionen");
		this.GtkLabel26.UseUnderline = true;
		this.expander3.LabelWidget = this.GtkLabel26;
		this.vbox2.Add (this.expander3);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.expander3]));
		w13.Position = 0;
		w13.Expand = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.expander1 = new global::Gtk.Expander (null);
		this.expander1.CanFocus = true;
		this.expander1.Name = "expander1";
		this.expander1.Expanded = true;
		// Container child expander1.Gtk.Container+ContainerChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.Output = new global::Gtk.TextView ();
		this.Output.HeightRequest = 111;
		this.Output.CanFocus = true;
		this.Output.Name = "Output";
		this.Output.WrapMode = ((global::Gtk.WrapMode)(3));
		this.GtkScrolledWindow.Add (this.Output);
		this.expander1.Add (this.GtkScrolledWindow);
		this.GtkLabel27 = new global::Gtk.Label ();
		this.GtkLabel27.Name = "GtkLabel27";
		this.GtkLabel27.LabelProp = global::Mono.Unix.Catalog.GetString ("Ergebnis(se)");
		this.GtkLabel27.UseUnderline = true;
		this.expander1.LabelWidget = this.GtkLabel27;
		this.vbox2.Add (this.expander1);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.expander1]));
		w16.Position = 1;
		w16.Expand = false;
		this.vbox1.Add (this.vbox2);
		global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.vbox2]));
		w17.Position = 3;
		w17.Expand = false;
		w17.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.cStatusLabele = new global::Gtk.Label ();
		this.cStatusLabele.Name = "cStatusLabele";
		this.cStatusLabele.Xalign = 0F;
		this.vbox1.Add (this.cStatusLabele);
		global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.cStatusLabele]));
		w18.Position = 4;
		w18.Expand = false;
		w18.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1296;
		this.DefaultHeight = 450;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.newAction.Activated += new global::System.EventHandler (this.OnNewActionActivated);
		this.closeAction.Activated += new global::System.EventHandler (this.OnCloseActionActivated);
		this.quitAction.Activated += new global::System.EventHandler (this.OnQuitActionActivated);
		this.saveAction1.Activated += new global::System.EventHandler (this.OnSaveAction1Activated);
		this.closeAction1.Activated += new global::System.EventHandler (this.OnCloseAction1Activated);
		this.saveAsAction1.Activated += new global::System.EventHandler (this.OnSaveAsAction1Activated);
		this.openAction1.Activated += new global::System.EventHandler (this.OnOpenAction1Activated);
		this.undoAction.Activated += new global::System.EventHandler (this.OnUndoActionActivated);
		this.redoAction.Activated += new global::System.EventHandler (this.OnRedoActionActivated);
		this.mediaPlayAction1.Activated += new global::System.EventHandler (this.OnExecuteActionActivated);
		this.clearAction.Activated += new global::System.EventHandler (this.OnClearActionActivated);
		this.cutAction1.Activated += new global::System.EventHandler (this.OnCutAction1Activated);
		this.copyAction1.Activated += new global::System.EventHandler (this.OnCopyAction1Activated);
		this.pasteAction1.Activated += new global::System.EventHandler (this.OnPasteAction1Activated);
		this.cancelAction.Activated += new global::System.EventHandler (this.OnCancelActionActivated);
		this.aboutAction.Activated += new global::System.EventHandler (this.OnAboutActionActivated);
		this.preferencesAction.Activated += new global::System.EventHandler (this.OnPreferencesActionActivated);
		this.selectAllAction.Activated += new global::System.EventHandler (this.OnSelectAllActionActivated);
		this.spellCheckAction.Activated += new global::System.EventHandler (this.OnSpellCheckActionActivated);
		this.NurTextTxtAction.Activated += new global::System.EventHandler (this.OnNurTextTxtActionActivated);
		this.HypertextHtmlAction.Activated += new global::System.EventHandler (this.OnHypertextHtmlActionActivated);
		this.KommaGetrenntCsvAction.Activated += new global::System.EventHandler (this.OnKommaGetrenntCsvActionActivated);
		this.preferencesAction1.Activated += new global::System.EventHandler (this.OnPreferencesAction1Activated);
		this.dialogQuestionAction.Activated += new global::System.EventHandler (this.OnDialogQuestionActionActivated);
		this.connectAction.Activated += new global::System.EventHandler (this.OnConnectActionActivated);
		this.notebook1.SwitchPage += new global::Gtk.SwitchPageHandler (this.OnNotebook1SwitchPage);
	}
}
