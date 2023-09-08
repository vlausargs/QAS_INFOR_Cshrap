//PROJECT NAME: Data
//CLASS NAME: OrdChk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class OrdChk : IOrdChk
	{
		readonly IApplicationDB appDB;
		
		public OrdChk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) OrdChkSp(
			string CurItem,
			string ParmsSite,
			int? MrpParmPreqChk,
			int? MrpParmPlanPlannedPs,
			string Infobar,
			int? IncludeCoitem = 0,
			int? IncludeJob = 0,
			int? IncludeJobitem = 0,
			int? IncludePoitem = 0,
			int? IncludePreqitem = 0,
			int? IncludeTrnitem = 0,
			int? BufferExcMesg = 0,
			Guid? ProcessId = null,
			string Whse = null,
			DateTime? Today = null)
		{
			ItemType _CurItem = CurItem;
			SiteType _ParmsSite = ParmsSite;
			ListYesNoType _MrpParmPreqChk = MrpParmPreqChk;
			ListYesNoType _MrpParmPlanPlannedPs = MrpParmPlanPlannedPs;
			InfobarType _Infobar = Infobar;
			ListYesNoType _IncludeCoitem = IncludeCoitem;
			ListYesNoType _IncludeJob = IncludeJob;
			ListYesNoType _IncludeJobitem = IncludeJobitem;
			ListYesNoType _IncludePoitem = IncludePoitem;
			ListYesNoType _IncludePreqitem = IncludePreqitem;
			ListYesNoType _IncludeTrnitem = IncludeTrnitem;
			ListYesNoType _BufferExcMesg = BufferExcMesg;
			RowPointerType _ProcessId = ProcessId;
			WhseType _Whse = Whse;
			DateType _Today = Today;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "OrdChkSp";
				
				appDB.AddCommandParameter(cmd, "CurItem", _CurItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmPreqChk", _MrpParmPreqChk, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmPlanPlannedPs", _MrpParmPlanPlannedPs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IncludeCoitem", _IncludeCoitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeJob", _IncludeJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeJobitem", _IncludeJobitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludePoitem", _IncludePoitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludePreqitem", _IncludePreqitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeTrnitem", _IncludeTrnitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BufferExcMesg", _BufferExcMesg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Today", _Today, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
