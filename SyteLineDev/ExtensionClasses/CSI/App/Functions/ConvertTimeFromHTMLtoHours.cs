//PROJECT NAME: Data
//CLASS NAME: ConvertTimeFromHTMLtoHours.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertTimeFromHTMLtoHours : IConvertTimeFromHTMLtoHours
	{
		readonly IApplicationDB appDB;
		
		public ConvertTimeFromHTMLtoHours(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? ConvertTimeFromHTMLtoHoursFn(
			string HTMLTime)
		{
			StringType _HTMLTime = HTMLTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertTimeFromHTMLtoHours](@HTMLTime)";
				
				appDB.AddCommandParameter(cmd, "HTMLTime", _HTMLTime, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
