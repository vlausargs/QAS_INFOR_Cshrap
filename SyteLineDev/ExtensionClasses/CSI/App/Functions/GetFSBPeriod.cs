//PROJECT NAME: Data
//CLASS NAME: GetFSBPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetFSBPeriod : IGetFSBPeriod
	{
		readonly IApplicationDB appDB;
		
		public GetFSBPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetFSBPeriodFn(
			DateTime? TransDate,
			string PeriodName)
		{
			DateTimeType _TransDate = TransDate;
			FSBPeriodNameType _PeriodName = PeriodName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetFSBPeriod](@TransDate, @PeriodName)";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PeriodName", _PeriodName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
