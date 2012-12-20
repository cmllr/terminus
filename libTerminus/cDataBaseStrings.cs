//
//  cDataBaseStrings.cs
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

namespace libTerminus
{
	public static class cDataBaseStrings
	{
		public static string g_Pool_ConnectionString = "URI=file:" + new cPathEnvironment ().const_examples_directory + new cPathEnvironment ().const_path_separator + "Library.db";
		public static string g_Pool_get = "SELECT Title,Phrase,Description " + "FROM phrases";
		public static string g_Pool_delete = "Delete " + " FROM phrases WHERE Title = \"{0}\"";
	}
}

