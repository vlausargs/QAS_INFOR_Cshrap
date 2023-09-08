//PROJECT NAME: Data
//CLASS NAME: StartOfNextMonth.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class StartOfNextMonth : IStartOfNextMonth
	{
		readonly IApplicationDB appDB;
		
		public StartOfNextMonth(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? StartOfNextMonthFn(
			DateTime? Date)
		{
			DateTimeType _Date = Date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[StartOfNextMonth](@Date)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
