
using System;

namespace libTerminus
{
	/// <summary>
	/// Contains the paths for the different platforms.
	/// </summary>
	public  class cPathEnvironment
	{
		/// <summary>
		/// Gets or sets the const_path_separator.
		/// </summary>
		/// <value>
		/// The const_path_separator.
		/// </value>
		public string const_path_separator { get; set; }
		/// <summary>
		/// Gets or sets the const_preferences_file.
		/// </summary>
		/// <value>
		/// The const_preferences_file.
		/// </value>
		public string const_preferences_file{ get; set; } 
		/// <summary>
		/// Gets or sets the const_data_dir.
		/// </summary>
		/// <value>
		/// The const_data_dir.
		/// </value>
		public string const_data_dir{ get; set; } 
		/// <summary>
		/// Gets or sets the const_program_image.
		/// </summary>
		/// <value>
		/// The const_program_image.
		/// </value>
		public  string const_program_image{ get; set; } 
		/// <summary>
		/// Gets or sets the const_program_license.
		/// </summary>
		/// <value>
		/// The const_program_license.
		/// </value>
		public string const_program_license{ get; set; } 
		/// <summary>
		/// Gets or sets the const_examples_directory.
		/// </summary>
		/// <value>
		/// The const_examples_directory.
		/// </value>
		public string const_examples_directory { get; set; }
		public string const_start_path { get; set; }
		public string const_settings_path { get; set; }
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cPathEnvironment"/> class.
		/// </summary>
		public cPathEnvironment ()
		{
			if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX) {

				const_path_separator = @"/";
				const_preferences_file = Environment.CurrentDirectory + const_path_separator + "Boot" + const_path_separator + "Boot.conf"; // @"/etc/terminus/Boot.conf";
				const_data_dir = Environment.CurrentDirectory + const_path_separator; //@"/usr/share/terminus/";
				const_program_image = Environment.CurrentDirectory + const_path_separator + @"Boot/Images/Programm.png"; //const_data_dir + @"Boot/Images/Programm.png";
				const_program_license = Environment.CurrentDirectory + const_path_separator + @"Boot/Texts/License";
				const_examples_directory = Environment.CurrentDirectory + const_path_separator + @"Boot/Library";
				const_start_path = Environment.GetEnvironmentVariable ("HOME");
				const_settings_path = Environment.CurrentDirectory + const_path_separator + @"Boot/Config/Program.cfg";
			} else {
				const_path_separator = @"\";
				const_preferences_file = getWinPath () + @"\Boot.conf";
				const_data_dir = getWinPath () + @"\";
				const_program_image = getWinPath () + @"\Boot\Images\Programm.png";
				const_program_license = getWinPath () + @"\Boot\Texts\License";
				const_examples_directory = getWinPath () + @"\Boot\Library";
				const_start_path = Environment.ExpandEnvironmentVariables ("%HOMEDRIVE%%HOMEPATH%");
				const_settings_path = getWinPath () + @"\Boot\Config\Program.cfg";
			}

		}
		/// <summary>
		/// Gets the window path.
		/// </summary>
		/// <returns>
		/// The windows path.
		/// </returns>
		public string getWinPath ()
		{
			return System.Reflection.Assembly.GetExecutingAssembly ().Location.Replace ("Path.dll", "");
		}

	}
}

