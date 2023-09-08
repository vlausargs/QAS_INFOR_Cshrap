//PROJECT NAME: Data
//CLASS NAME: IsWeekend.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsWeekend : IIsWeekend
	{
		readonly IApplicationDB appDB;
		
		public IsWeekend(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsWeekendFn(
			DateTime? Date)
		{
			DateType _Date = Date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsWeekend](@Date)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
