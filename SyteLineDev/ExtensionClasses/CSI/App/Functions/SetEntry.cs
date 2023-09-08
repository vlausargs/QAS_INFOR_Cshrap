//PROJECT NAME: Data
//CLASS NAME: SetEntry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SetEntry : ISetEntry
	{
		readonly IApplicationDB appDB;
		
		public SetEntry(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SetEntryFn(
			int? Entry,
			string List,
			string Item,
			string Delim = ",")
		{
			IntType _Entry = Entry;
			LongListType _List = List;
			LongListType _Item = Item;
			StringType _Delim = Delim;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SetEntry](@Entry, @List, @Item, @Delim)";
				
				appDB.AddCommandParameter(cmd, "Entry", _Entry, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delim", _Delim, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
