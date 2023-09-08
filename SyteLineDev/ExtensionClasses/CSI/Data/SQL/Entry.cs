using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
	public class Entry : IEntry
	{
		IApplicationDB appDB;


		public Entry(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}

		public string EntryFn(int? Entry,
		string List,
		string Delim = ",")
		{
			IntType _Entry = Entry;
			VeryLongListType _List = List;
			VeryLongListType _Delim = Delim;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Entry](@Entry, @List, @Delim)";

				appDB.AddCommandParameter(cmd, "Entry", _Entry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delim", _Delim, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
