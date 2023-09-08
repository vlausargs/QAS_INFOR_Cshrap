//PROJECT NAME: Data
//CLASS NAME: GetFSBPeriodEndDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetFSBPeriodEndDate : IGetFSBPeriodEndDate
	{
		readonly IApplicationDB appDB;
		
		public GetFSBPeriodEndDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetFSBPeriodEndDateFn(
			string PeriodName,
			int? PPeriod)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			FinPeriodType _PPeriod = PPeriod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetFSBPeriodEndDate](@PeriodName, @PPeriod)";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
