//
//  Enums.cs
//
//  Author:
//       christoph <fury@gtkforum.php-friends.de>
//
//  Copyright (c) 2013 christoph
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

namespace libTerminus
{
	/// <summary>
	/// Parsing mode.
	/// </summary>
	public enum ParsingMode
	{
		All,
		OnlyGroups,
		OnlyRegular,
	}
	/// <summary>
	/// Log method.
	/// </summary>
	public enum LogMethod
	{
		File,
		Logs,
		DataBase,
	}
	/// <summary>
	/// Log level.
	/// </summary>
	public enum LogLevel
	{
		Critical,
		Warning,
	}
	/// <summary>
	/// Export type.
	/// </summary>
	public enum ExportType
	{
		Text,
		CSV,
		HTML,
	}
}