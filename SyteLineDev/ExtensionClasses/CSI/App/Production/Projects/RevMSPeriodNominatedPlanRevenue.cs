//PROJECT NAME: Production
//CLASS NAME: RevMSPeriodNominatedPlanRevenue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMSPeriodNominatedPlanRevenue : IRevMSPeriodNominatedPlanRevenue
	{
		readonly IApplicationDB appDB;
		
		public RevMSPeriodNominatedPlanRevenue(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? RevMSPeriodNominatedPlanRevenueFn(
			string ProjNum,
			DateTime? CurrentPeriodStart,
			DateTime? CurrentPeriodEnd,
			int? Nominated)
		{
			ProjNumType _ProjNum = ProjNum;
			DateType _CurrentPeriodStart = CurrentPeriodStart;
			DateType _CurrentPeriodEnd = CurrentPeriodEnd;
			ListYesNoType _Nominated = Nominated;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[RevMSPeriodNominatedPlanRevenue](@ProjNum, @CurrentPeriodStart, @CurrentPeriodEnd, @Nominated)";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentPeriodStart", _CurrentPeriodStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrentPeriodEnd", _CurrentPeriodEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Nominated", _Nominated, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
