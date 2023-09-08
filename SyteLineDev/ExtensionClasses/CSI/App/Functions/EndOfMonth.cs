//PROJECT NAME: Data
//CLASS NAME: EndOfMonth.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EndOfMonth : IEndOfMonth
	{
		readonly IApplicationDB appDB;
		
		public EndOfMonth(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? EndOfMonthFn(
			DateTime? Date)
		{
			DateTimeType _Date = Date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[EndOfMonth](@Date)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
