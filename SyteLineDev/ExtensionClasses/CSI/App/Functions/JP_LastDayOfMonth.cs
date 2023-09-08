//PROJECT NAME: Data
//CLASS NAME: JP_LastDayOfMonth.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JP_LastDayOfMonth : IJP_LastDayOfMonth
	{
		readonly IApplicationDB appDB;
		
		public JP_LastDayOfMonth(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? JP_LastDayOfMonthFn(
			int? Year,
			int? Month)
		{
			IntType _Year = Year;
			IntType _Month = Month;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JP_LastDayOfMonth](@Year, @Month)";
				
				appDB.AddCommandParameter(cmd, "Year", _Year, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Month", _Month, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
