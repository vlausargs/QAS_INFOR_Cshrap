//PROJECT NAME: Data
//CLASS NAME: GetFSBPeriodStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetFSBPeriodStartDate : IGetFSBPeriodStartDate
	{
		readonly IApplicationDB appDB;
		
		public GetFSBPeriodStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetFSBPeriodStartDateFn(
			string PeriodName,
			int? PPeriod)
		{
			FSBPeriodNameType _PeriodName = PeriodName;
			FinPeriodType _PPeriod = PPeriod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetFSBPeriodStartDate](@PeriodName, @PPeriod)";
				
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPeriod", _PPeriod, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
