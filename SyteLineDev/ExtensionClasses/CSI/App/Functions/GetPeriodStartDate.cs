//PROJECT NAME: Data
//CLASS NAME: GetPeriodStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPeriodStartDate : IGetPeriodStartDate
	{
		readonly IApplicationDB appDB;
		
		public GetPeriodStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetPeriodStartDateFn(
			int? PPeriod)
		{
			FinPeriodType _PPeriod = PPeriod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetPeriodStartDate](@PPeriod)";
				
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
