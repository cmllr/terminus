//  cLogger.cs Logs anything
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
using System.Threading;
namespace libTerminus
{
	/// <summary>
	/// The logger class
	/// </summary>
	public static class cLogger
	{
		public static LogLevel g_CurrentLogLevel = LogLevel.Exception;
		/// <summary>
		/// The log level header.
		/// </summary>
		/// <summary>
		/// Log the specified LogData.
		/// </summary>
		/// <param name='_logdata'>
		/// Log data.
		/// </param>
		/// <summary>
		/// Log the specified LogData and MethodName.
		/// </summary>
		/// <param name='_logdata'>
		/// Log data.
		/// </param>
		/// <param name='_methodName'>
		/// Method name.
		/// </param>
		public static void Log (string _logdata, string _methodName)
		{
			Console.WriteLine ("\"{0}\" in \"{1}\"", _logdata, _methodName);
		}
	}
}