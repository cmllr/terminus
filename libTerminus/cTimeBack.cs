using System;
using System.Collections.Generic;
namespace libTerminus
{
	/// <summary>
	/// The time back machine should save accidently removed phrases
	/// </summary>
	public class cTimeBack
	{
		/// <summary>
		/// The save interval.
		/// </summary>
		public int SaveInterval = 5;
		/// <summary>
		/// The done intetervals.
		/// </summary>
		public int DoneIntetervals = 0;
		/// <summary>
		/// The _data.
		/// </summary>
		Dictionary<DateTime,String[]> _data = new Dictionary<DateTime,string[]>();
		/// <summary>
		/// Initializes a new instance of the <see cref="libTerminus.cTimeBack"/> class.
		/// </summary>
		public cTimeBack ()
		{
			
		}
		/// <summary>
		/// Add the specified _date and _st.
		/// </summary>
		/// <param name='_date'>
		/// _date.
		/// </param>
		/// <param name='_st'>
		/// _st.
		/// </param>
		public void add(DateTime _date, string[] _st)
		{
			try{
		
				if (_data.ContainsKey(_date) == false)
				{
					if (_date.Subtract(getLastKey()).TotalMilliseconds > 100){
						this._data.Add(_date,_st);
						DoneIntetervals++;}
					if (DoneIntetervals == SaveInterval){
							//save();
					}
				}
				//MessageBox.Show(_date.ToString(),"fa",Gtk.ButtonsType.Cancel,Gtk.MessageType.Error,null);
			}
			catch (Exception Ex){
				Console.Write("Fehler: " + Ex.Message);
			}
		}
		/// <summary>
		/// Gets the last key.
		/// </summary>
		/// <returns>
		/// The last key.
		/// </returns>
		public DateTime getLastKey()
		{
			DateTime _last;
			foreach (KeyValuePair<DateTime,string[]> kvp in this._data)
			{
				_last = kvp.Key;
			}
			return _last;
		}
		/// <summary>
		/// Revert the specified _date.
		/// </summary>
		/// <param name='_date'>
		/// _date.
		/// </param>
		public string[] revert(DateTime _date)
		{
			if (this._data.ContainsKey(_date))
			{
				return _data[_date];
			}
			else
			{
				return null;
			}
		}
		/// <summary>
		/// Contains the specified _content.
		/// </summary>
		/// <param name='_content'>
		/// If set to <c>true</c> _content.
		/// </param>
		public bool Contains(string _content)
		{
			foreach (DateTime _k in _data.Keys)
			{
				if (_content.Contains(_k.ToString()))
				    return true;
			}
			return false;
		}
		/// <summary>
		/// Save this instance.
		/// </summary>
		public void save()
		{
			string _cache = new cPathEnvironment().const_data_dir + ".terminus" + cTerminus.CurrentRegexUniqueID + "cache";
			
				string _newcontent ="";
				foreach(KeyValuePair<DateTime,string[]> nvp in this._data)
				{
					_newcontent += nvp.Key + ";;;;;" + nvp.Value[0] + ";;;;;" + nvp.Value[1] + "\n";
				}
				System.IO.File.AppendAllText(_cache,_newcontent);
				DoneIntetervals = 0;
			
		}
	}
}

