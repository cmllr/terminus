	using System;
using Gtk;
using libTerminus;
using Mono.Unix;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;

/// <summary>
/// Main window.
/// </summary>
public partial class MainWindow: Gtk.Window
{	
	
	/// <summary>
	/// Initializes a new instance of the <see cref="MainWindow"/> class.
	/// </summary>
	/// <summary>
	/// Initializes a new instance of the <see cref="MainWindow"/> class.
	/// </summary>
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		AppendEvents ();
		notebook1.RemovePage (0);		
		cTerminus.g_isReady = true;
		cTerminus.g_programVersion = Assembly.GetExecutingAssembly ().GetName ().Version;
		this.Title = cTerminus.getTitle (notebook1, notebook1.Page);
		
	}
	/// <summary>
	/// Initializes a new instance of the <see cref="MainWindow"/> class.
	/// </summary>
	/// <param name='Filename'>
	/// Filename.
	/// </param>
	/// <summary>
	/// Initializes a new instance of the <see cref="MainWindow"/> class.
	/// </summary>
	/// <param name='Filename'>
	/// Filename.
	/// </param>
	public MainWindow (string Filename): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		AppendEvents ();
		notebook1.RemovePage (0);	
		cTerminus.g_isReady = true;
		//cTerminus.enableSyntax = true;
		cTerminus.g_programVersion = Assembly.GetExecutingAssembly ().GetName ().Version;
		this.Title = cTerminus.getTitle (notebook1, notebook1.Page);
		cTerminus.AddTabFromFile (notebook1, Filename, 0);
		cStatusLabele.Text = "Bereit.";

	}
	/// <summary>
	/// Appends the signals of the menu buttons and toolstrip icons
	/// </summary>
	void AppendEvents ()
	{
		newAction1.Activated += OnNewActionActivated;
		saveAction.Activated += OnSaveAction1Activated;
		openAction.Activated += OnOpenAction1Activated;
		saveAsAction.Activated += OnSaveAsAction1Activated;
		closeAction.Activated += OnCloseAction1Activated;
		undoAction1.Activated += OnUndoActionActivated;
		redoAction1.Activated += OnRedoActionActivated;
		copyAction.Activated += OnCopyAction1Activated;
		cutAction.Activated += OnCutAction1Activated;
		pasteAction.Activated += OnPasteAction1Activated;
		//preferencesAction1.Activated += OnExecuteActionActivated;
		selectAllAction1.Activated += OnSelectAllActionActivated;
		aboutAction1.Activated += OnAboutActionActivated;
		if (cTerminus.Configuration.HideText)
			toolbar1.ToolbarStyle = ToolbarStyle.Icons;
		mediaPlayAction.Activated += OnExecuteActionActivated;
		clearAction1.Activated += OnClearActionActivated;	
	}
	/// <summary>
	/// Raises the delete event event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='a'>
	/// A.
	/// </param>
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		checkfortabs (a);

	}
	bool checkfortabs (DeleteEventArgs a)
	{
		if (notebook1.NPages == 0) {
			cTerminus.Configuration.Save ();
			Application.Quit ();
			a.RetVal = false;

		} else {
			if (cTerminus.AskForClosing () == ResponseType.Yes) {
				cTerminus.Configuration.Save ();
				Application.Quit ();
				a.RetVal = false;
			} else {
				a.RetVal = true;
			}
		}
		return (bool)a.RetVal;
	}
	/// <summary>
	/// Raises the notebook1 switch page event.
	/// </summary>
	/// <param name='o'>
	/// O.
	/// </param>
	/// <param name='args'>
	/// Arguments.
	/// </param>
	protected void OnNotebook1SwitchPage (object o, Gtk.SwitchPageArgs args)
	{		
		//If the Engine is Ready (cTerminus is a static class), get the Title of the current tab page
		if (cTerminus.g_isReady == true) {
			this.Title = cTerminus.getTitle (notebook1, notebook1.Page);
			//cTerminus.CurrentRegexUniqueID = ((cRegex)notebook1.GetNthPage()).uniqueID;
		}
	
	}
	void check ()
	{
		try {
			if (notebook1.GetNthPage (notebook1.Page) is cRegex) {
				cTerminus.disable = false;
			} else {
				cTerminus.disable = true;

			}
		} catch {
		}
	}
	/// <summary>
	/// Raises the save action1 activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnSaveAction1Activated (object sender, System.EventArgs e)
	{
		try {
			//If the filename is alrady saved --> Save the file | If not, show the Save as Dialog.
			if (cTerminus.getFileName (notebook1, notebook1.Page) == "")
				cTerminus.Save (notebook1, notebook1.Page, cTerminus.ShowSaveDialog (null));
			else
				cTerminus.Save (notebook1, notebook1.Page, cTerminus.getFileName (notebook1, notebook1.Page));
			this.Title = cTerminus.getTitle (notebook1, notebook1.Page);
		} catch (Exception ex) {
			//If any error appears --> Log it.

			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);	
		}
	}
	/// <summary>
	/// Raises the close action1 activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnCloseAction1Activated (object sender, System.EventArgs e)
	{
		try {
			//Close the tab which is the current selection
			cTerminus.CloseTab (notebook1, notebook1.Page);
			//Change the Title.
			this.Title = cTerminus.getTitle (notebook1, notebook1.Page);
		} catch (Exception ex) {
			//if any error apears --> Log it 
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);	
		}
	}
	/// <summary>
	/// Raises the new action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnNewActionActivated (object sender, System.EventArgs e)
	{
		try {
			//add a new page
			cTerminus.AddTab (notebook1, "");
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);	
		}
	}
	/// <summary>
	/// Raises the save as action1 activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnSaveAsAction1Activated (object sender, EventArgs e)
	{
		try {
			cTerminus.Save (notebook1, notebook1.Page, cTerminus.ShowSaveDialog (null));
			this.Title = cTerminus.getTitle (notebook1, notebook1.Page);
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the open action1 activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnOpenAction1Activated (object sender, EventArgs e)
	{
		try {
			cTerminus.AddTabFromFile (notebook1);		

		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the undo action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnUndoActionActivated (object sender, System.EventArgs e)
	{
		try {
			((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).Undo ();
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the redo action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnRedoActionActivated (object sender, System.EventArgs e)
	{
		try {
			((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).Redo ();
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the execute action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnExecuteActionActivated (object sender, System.EventArgs e)
	{
		try {
			this.cStatusLabele.Text = "Arbeite..";
			//get the current Options and run the parser.
			Output.Buffer.Text = "";
			RegexOptions _optionen = RegexOptions.None;
			if (IgnoreCase.Active)
				_optionen = RegexOptions.IgnoreCase;
			if (IgnorePatternWhitespace.Active)
				_optionen = _optionen | RegexOptions.IgnorePatternWhitespace;
			if (ExplicitCapture.Active)
				_optionen = _optionen | RegexOptions.ExplicitCapture;
			libTerminus.ParsingMode mode = libTerminus.ParsingMode.All;
			if (radiobutton1.Active)
				mode = libTerminus.ParsingMode.All;
			if (radiobutton2.Active)
				mode = libTerminus.ParsingMode.OnlyRegular;
			if (radiobutton3.Active)
				mode = libTerminus.ParsingMode.OnlyGroups;
			((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).parse (ref Output, _optionen, mode);
			this.cStatusLabele.Text = "Bereit. Ausdruck vearbeitet in " + cTerminus.g_lastResultTimeSpan.TotalSeconds + " Sekunden.";
			//this.cStatusLabele.Text = cTerminus.getMemory ().ToString () + " MB";
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
			this.cStatusLabele.Text = "Bereit. Ausdruck vearbeitet in " + cTerminus.g_lastResultTimeSpan.TotalSeconds + " Sekunden.";
		}
	}
	/// <summary>
	/// Raises the clear action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnClearActionActivated (object sender, System.EventArgs e)
	{
		try {
			if (cTerminus.AskForClear () == ResponseType.Yes)
				((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).Clear ();
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the cut action1 activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnCutAction1Activated (object sender, System.EventArgs e)
	{
		try {
			((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).cut ();
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the copy action1 activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnCopyAction1Activated (object sender, System.EventArgs e)
	{
		try {
			((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).Copy ();
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the paste action1 activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnPasteAction1Activated (object sender, System.EventArgs e)
	{
		try {
			((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).Paste ();
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the about action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnAboutActionActivated (object sender, System.EventArgs e)
	{
		try {
			cTerminus.showAboutDialog (Assembly.GetExecutingAssembly ().GetName ().Version, this.GdkWindow);
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the spell check action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnSpellCheckActionActivated (object sender, System.EventArgs e)
	{
		try {
					
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);		
		}
	}
	/// <summary>
	/// Raises the close action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnCloseActionActivated (object sender, EventArgs e)
	{
		try {
			//cTerminus.CloseTab (notebook1, notebook1.Page);
			//Close the tab which is the current selection
			cTerminus.CloseTab (notebook1, notebook1.Page);
			//Change the Title.
			this.Title = cTerminus.getTitle (notebook1, notebook1.Page);
		} catch (Exception ex) {
			cLogger.Log (ex.Message, new StackTrace ().GetFrame (0).GetMethod ().Name);				
		}
	}
	/// <summary>
	/// Raises the quit action activated event.
	/// </summary>
	/// <param name='sender'>
	/// Sender.
	/// </param>
	/// <param name='e'>
	/// E.
	/// </param>
	protected void OnQuitActionActivated (object sender, EventArgs e)
	{
		if (!checkfortabs (new DeleteEventArgs ()))		
			Application.Quit ();
	}

	protected void OnSelectAllActionActivated (object sender, System.EventArgs e)
	{
		cTerminus.addLibraryTab (notebook1);
	}

	protected void OnSyntaxEnabledToggled (object sender, EventArgs e)
	{
		//cTerminus.Configuration.useSyntax = SyntaxEnabled.Active;

		//((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).MarkSyntax (ref tv);

	}


	protected void OnPreferencesActionActivated (object sender, EventArgs e)
	{
		cTerminus.addConfigTab (notebook1);
	}





	protected void OnNurTextTxtActionActivated (object sender, System.EventArgs e)
	{
		try {
			string pattern = ((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).GetExpressionBuffer ();
			string data = ((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).GetDataSourceBuffer ();
			cExport.exportToText (pattern, data, Output.Buffer.Text);
		} catch {
			
		}
	}


	protected void OnHypertextHtmlActionActivated (object sender, System.EventArgs e)
	{
		try {
			string pattern = ((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).GetExpressionBuffer ();
			string data = ((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).GetDataSourceBuffer ();
			cExport.exportToHypertext (pattern, data, Output.Buffer.Text);
		} catch {
			
		}
	}

	protected void OnKommaGetrenntCsvActionActivated (object sender, System.EventArgs e)
	{
		try {
			string pattern = ((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).GetExpressionBuffer ();
			string data = ((libTerminus.cRegex)notebook1.GetNthPage (notebook1.Page)).GetDataSourceBuffer ();
			cExport.exportToCSV (pattern, data, Output.Buffer.Text);
		} catch {
			
		}
	}
	protected void OnPreferencesAction1Activated (object sender, EventArgs e)
	{
		cTerminus.addConfigTab (notebook1);

	}
	protected void OnDialogQuestionActionActivated (object sender, EventArgs e)
	{
		MessageBox.Show (cTerminus.getBuildInfo (), cTerminus.g_programName, ButtonsType.Ok, MessageType.Info, null);
	}



	protected void OnCancelActionActivated (object sender, EventArgs e)
	{
		Process xdg = new Process ();
		xdg.StartInfo = new ProcessStartInfo (@"http://scribble.pf-control.de/Projekte/Bugtracker");
		xdg.Start ();
	}	

	protected void OnConnectActionActivated (object sender, EventArgs e)
	{
		Process xdg = new Process ();
		xdg.StartInfo = new ProcessStartInfo (@"http://scribble.pf-control.de/");
		xdg.Start ();
	}

	protected void OnSaveAsAction2Activated (object sender, EventArgs e)
	{
		cTerminus.SaveCopy(notebook1,notebook1.Page);
	}

	protected void OnSelectFontActionActivated (object sender, EventArgs e)
	{
		new cKeyBoard().Show();
	}

	protected void OnRestoreActivated (object sender, EventArgs e)
	{
		new cRestoreWizard().Show();
	}
}
