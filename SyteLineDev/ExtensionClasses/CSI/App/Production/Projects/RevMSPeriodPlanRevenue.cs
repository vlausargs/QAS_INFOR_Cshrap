//PROJECT NAME: Production
//CLASS NAME: RevMSPeriodPlanRevenue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMSPeriodPlanRevenue : IRevMSPeriodPlanRevenue
	{
		readonly IApplicationDB appDB;
		
		public RevMSPeriodPlanRevenue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? RevMSPeriodPlanRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd)
		{
			ProjNumType _ProjNum = ProjNum;
			DateType _CurrentPeriodStart = CurrentPeriodStart;
			DateType _CurrentPeriodEnd = CurrentPeriodEnd;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[RevMSPeriodPlanRevenue](@ProjNum, @CurrentPeriodStart, @CurrentPeriodEnd)";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentPeriodStart", _CurrentPeriodStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentPeriodEnd", _CurrentPeriodEnd, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
