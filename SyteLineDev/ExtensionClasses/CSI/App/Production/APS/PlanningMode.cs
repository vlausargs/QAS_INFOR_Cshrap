//PROJECT NAME: Production
//CLASS NAME: PlanningMode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class PlanningMode : IPlanningMode
	{
		readonly IApplicationDB appDB;
		
		
		public PlanningMode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? PlanningModeSp(string apsmode,
		decimal? infcap)
		{
			ApsModeType _apsmode = apsmode;
			ApsDurationType _infcap = infcap;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PlanningModeSp";
				
				appDB.AddCommandParameter(cmd, "apsmode", _apsmode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "infcap", _infcap, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
