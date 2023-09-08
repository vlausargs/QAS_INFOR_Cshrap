//PROJECT NAME: Data
//CLASS NAME: ClientDateFromString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ClientDateFromString : IClientDateFromString
	{
		readonly IApplicationDB appDB;
		
		public ClientDateFromString(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? ClientDateFromStringFn(
			string Date)
		{
			LongListType _Date = Date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ClientDateFromString](@Date)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
