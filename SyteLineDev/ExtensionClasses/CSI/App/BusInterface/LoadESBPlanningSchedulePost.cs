//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBPlanningSchedulePost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBPlanningSchedulePost
	{
		int LoadESBPlanningSchedulePostSp(ref string Infobar);
	}
	
	public class LoadESBPlanningSchedulePost : ILoadESBPlanningSchedulePost
	{
		readonly IApplicationDB appDB;
		
		public LoadESBPlanningSchedulePost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBPlanningSchedulePostSp(ref string Infobar)
		{
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBPlanningSchedulePostSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
