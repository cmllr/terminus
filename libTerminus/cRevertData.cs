//
//  cRevertData.cs
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
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
namespace libTerminus
{
	public class cRevertData
	{
		public string ConnectionString = "URI=file:" + new cPathEnvironment ().const_examples_directory + "/DataRestorePool.db";
		public cRevertData ()
		{
		}
		public List<String> getRestoredData (string _datestring, string _begin, string _end)
		{
			IDbConnection dbcon = null;
			List<string> _list = new List<string> ();
			try {				
				DateTime _date = DateTime.Parse (_datestring);

				dbcon = (IDbConnection)new SqliteConnection (ConnectionString);
				dbcon.Open ();
				IDbCommand dbcmd = dbcon.CreateCommand ();
				//FIxme: syntax error
				string sql = "SELECT * FROM Phrases WHERE Date = \"" + _date.ToShortDateString () + "\"";
				dbcmd.CommandText = sql;
				IDataReader reader = dbcmd.ExecuteReader ();
				while (reader.Read()) {				
					DateTime _dbdate = DateTime.Parse (reader.GetString (2));
					_dbdate = _dbdate.AddHours (double.Parse (reader.GetString (3).ToString ()));
					if (_dbdate.ToShortDateString () == _date.ToShortDateString () && _dbdate.Hour > int.Parse (_begin) - 1 && _dbdate.Hour < int.Parse (_end)) {
						_list.Add (reader.GetString (1));
					}
				}
				// clean up
				reader.Close ();
				reader = null;
				dbcmd.Dispose ();
				dbcmd = null;			
				return _list;
			} catch (Exception ex) {
				//MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return null;
			} finally {
				dbcon.Close ();
				dbcon = null;				
			}
		}
		public void setRestoredData (DateTime _date, String _phrase, string _filename = "")
		{
			IDbConnection dbcon = null;
			try {

				dbcon = (IDbConnection)new SqliteConnection (ConnectionString);
				dbcon.Open ();
				IDbCommand dbcmd = dbcon.CreateCommand ();
				string sql = string.Format ("INSERT into Phrases (Phrase,Date,Hour,Filename) VALUES('{0}','{1}','{2}','{3}')", _phrase, _date.ToShortDateString (), _date.Hour, _filename);
				dbcmd.CommandText = sql;
				dbcmd.ExecuteNonQuery ();
				dbcmd.Dispose ();
				dbcmd = null;
			} catch {

			} finally {
				dbcon.Close ();
				dbcon = null;
			}
		}
		public List<int> getDays (int _month)
		{
			IDbConnection dbcon= null;
			List<int> _list = new List<int> ();
			try {				
						
				dbcon = (IDbConnection)new SqliteConnection (ConnectionString);
				dbcon.Open ();
				IDbCommand dbcmd = dbcon.CreateCommand ();
				//FIxme: syntax error
				string sql = "SELECT * FROM Phrases";
				dbcmd.CommandText = sql;
				IDataReader reader = dbcmd.ExecuteReader ();
				while (reader.Read()) {				
					DateTime _dbdate = DateTime.Parse (reader.GetString (2));
					if (_dbdate.Month == _month)
						_list.Add (_dbdate.Day);
				}
				// clean up
				reader.Close ();
				reader = null;
				dbcmd.Dispose ();
				dbcmd = null;			
				return _list;
			} catch (Exception ex) {
				//MessageBox.Show (ex.Message, cTerminus.g_programName, ButtonsType.Close, MessageType.Error);
				return null;
			} finally {
				dbcon.Close ();
				dbcon = null;				
			}
		}
		public void Clear ()
		{
			IDbConnection dbcon= null;
			try {
				
				dbcon = (IDbConnection)new SqliteConnection (ConnectionString);
				dbcon.Open ();
				IDbCommand dbcmd = dbcon.CreateCommand ();
				string sql = string.Format ("Delete  from Phrases");
				dbcmd.CommandText = sql;
				dbcmd.ExecuteNonQuery ();
				dbcmd.Dispose ();
				dbcmd = null;
			} catch (Exception ex) {
				
			} finally {
				dbcon.Close ();
				dbcon = null;
			}
		}
	}
}

