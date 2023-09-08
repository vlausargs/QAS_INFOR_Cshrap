//PROJECT NAME: Data
//CLASS NAME: PlanningLateAlert.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PlanningLateAlert : IPlanningLateAlert
	{
		readonly IApplicationDB appDB;
		
		public PlanningLateAlert(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PlanningLateAlertFn(
			string PProjNum,
			int? PProjTaskNum,
			string Site = null)
		{
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PProjTaskNum = PProjTaskNum;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[PlanningLateAlert](@PProjNum, @PProjTaskNum, @Site)";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjTaskNum", _PProjTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
