//PROJECT NAME: Production
//CLASS NAME: GetSysParPermPlanMode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetSysParPermPlanMode : IGetSysParPermPlanMode
	{
		readonly IApplicationDB appDB;
		
		
		public GetSysParPermPlanMode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ApsParmApsmode,
		int? CanAdd,
		int? CanUpdate,
		int? CanDelete,
		string PlanMode,
		string Parm_DefWhse,
		string Infobar) GetSysParPermPlanModeSp(string ApsParmApsmode,
		int? CanAdd,
		int? CanUpdate,
		int? CanDelete,
		string PlanMode,
		string Parm_DefWhse,
		string Infobar)
		{
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			ListYesNoType _CanAdd = CanAdd;
			ListYesNoType _CanUpdate = CanUpdate;
			ListYesNoType _CanDelete = CanDelete;
			StringType _PlanMode = PlanMode;
			WhseType _Parm_DefWhse = Parm_DefWhse;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSysParPermPlanModeSp";
				
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAdd", _CanAdd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanUpdate", _CanUpdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDelete", _CanDelete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PlanMode", _PlanMode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Parm_DefWhse", _Parm_DefWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ApsParmApsmode = _ApsParmApsmode;
				CanAdd = _CanAdd;
				CanUpdate = _CanUpdate;
				CanDelete = _CanDelete;
				PlanMode = _PlanMode;
				Parm_DefWhse = _Parm_DefWhse;
				Infobar = _Infobar;
				
				return (Severity, ApsParmApsmode, CanAdd, CanUpdate, CanDelete, PlanMode, Parm_DefWhse, Infobar);
			}
		}
	}
}
