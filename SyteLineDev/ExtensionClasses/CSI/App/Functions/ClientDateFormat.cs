//PROJECT NAME: Data
//CLASS NAME: ClientDateFormat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ClientDateFormat : IClientDateFormat
	{
		readonly IApplicationDB appDB;
		
		public ClientDateFormat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ClientDateFormatFn(
			DateTime? Date)
		{
			GenericDateType _Date = Date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ClientDateFormat](@Date)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
