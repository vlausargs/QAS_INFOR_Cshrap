//PROJECT NAME: CSIProjects
//CLASS NAME: GetPlanningMode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IGetPlanningMode
	{
		int GetPlanningModeSp(ref string PlanMode,
		                      ref string Infobar);
	}
	
	public class GetPlanningMode : IGetPlanningMode
	{
		readonly IApplicationDB appDB;
		
		public GetPlanningMode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetPlanningModeSp(ref string PlanMode,
		                             ref string Infobar)
		{
			StringType _PlanMode = PlanMode;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPlanningModeSp";
				
				appDB.AddCommandParameter(cmd, "PlanMode", _PlanMode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PlanMode = _PlanMode;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
