//PROJECT NAME: Production
//CLASS NAME: RevMSGetCurrentPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMSGetCurrentPeriod : IRevMSGetCurrentPeriod
	{
		readonly IApplicationDB appDB;
		
		public RevMSGetCurrentPeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RevMSGetCurrentPeriodFn(
			DateTime? MsPlanDate,
			DateTime? MsActDate)
		{
			DateType _MsPlanDate = MsPlanDate;
			DateType _MsActDate = MsActDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[RevMSGetCurrentPeriod](@MsPlanDate, @MsActDate)";
				
				appDB.AddCommandParameter(cmd, "MsPlanDate", _MsPlanDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsActDate", _MsActDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
