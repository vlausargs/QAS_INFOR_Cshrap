//PROJECT NAME: Production
//CLASS NAME: RevMSGetCurrentPeriodStart.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMSGetCurrentPeriodStart : IRevMSGetCurrentPeriodStart
	{
		readonly IApplicationDB appDB;
		
		public RevMSGetCurrentPeriodStart(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? RevMSGetCurrentPeriodStartFn(
			DateTime? MsPlanDate,
			DateTime? MsActDate)
		{
			DateType _MsPlanDate = MsPlanDate;
			DateType _MsActDate = MsActDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[RevMSGetCurrentPeriodStart](@MsPlanDate, @MsActDate)";
				
				appDB.AddCommandParameter(cmd, "MsPlanDate", _MsPlanDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsActDate", _MsActDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
