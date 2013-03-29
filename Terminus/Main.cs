using System;
using Gtk;
using System.Reflection;
using System.Threading;

namespace Terminus
{
	/// <summary>
	/// The Program main class.
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name='args'>
		/// The command-line arguments.
		/// </param>
		public static void Main (string[] args)
		{

			//Initalize a new object of the argument parser
			libTerminus.cArgumentParser argsP = new libTerminus.cArgumentParser (args, Assembly.GetExecutingAssembly ().GetName ().Version.ToString ());
			GLib.ExceptionManager.UnhandledException += delegate(GLib.UnhandledExceptionArgs argsEx) {
				Console.WriteLine (argsEx.ExceptionObject.ToString ());
			};
			new libTerminus.cPathEnvironment ().ConfFileManagement (); 
			if (argsP.Path == "") {
				Mono.Unix.Catalog.Init ("i8n1", "./locale");
				Console.WriteLine ("Useing locale path \"{0}\"", "./locale");
			} else {
				Console.WriteLine ("Useing locale path \"{0}\"", argsP.Path + "/locale");
				Mono.Unix.Catalog.Init ("i8n1", argsP.Path + "/locale");
			}
			//if the program should be runned..
			if (argsP.AllowedToRun) {			
				Application.Init ();
				if (argsP.FileToOpen == "") {
					MainWindow win = new MainWindow ("");	
					win.Show ();
				} else {
					MainWindow win = new MainWindow (argsP.FileToOpen);
					win.Show ();			
				}
				Application.Run ();
				
			} else if (argsP.AllowedToRun == false && argsP.RunIntoShell == true) {
				new libTerminus.cShell ();
			} else
				Environment.Exit (-1);

		

		}
	}
}
