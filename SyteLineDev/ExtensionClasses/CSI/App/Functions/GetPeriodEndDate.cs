//PROJECT NAME: Data
//CLASS NAME: GetPeriodEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPeriodEndDate : IGetPeriodEndDate
	{
		readonly IApplicationDB appDB;
		
		public GetPeriodEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetPeriodEndDateFn(
			int? PPeriod)
		{
			FinPeriodType _PPeriod = PPeriod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetPeriodEndDate](@PPeriod)";
				
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
