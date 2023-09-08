//PROJECT NAME: Material
//CLASS NAME: MrpExplode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpExplode : IMrpExplode
	{
		readonly IApplicationDB appDB;
		
		public MrpExplode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MrpExplodeSp(
			string ItemItem,
			string ItemJob,
			int? ItemPassReq,
			int? ItemLeadTime,
			decimal? ItemVarLead,
			int? ItemPlanFlag,
			decimal? HrsPerDay,
			int? MrpParmScrapFlag,
			int? MrpParmUseSchedTimesInPlanning,
			int? MrpParmPlanPlannedPs,
			int? ApsParmPlanMaterialsAtOperStart,
			Guid? ProcessId,
			string UserMrpPlanningType,
			string Infobar,
			int? MrpParmPlanStoppedJob,
			int? DebugLevel,
			int? ItemElapsedTime,
			int? BgTaskID)
		{
			ItemType _ItemItem = ItemItem;
			JobType _ItemJob = ItemJob;
			ListYesNoType _ItemPassReq = ItemPassReq;
			LeadTimeType _ItemLeadTime = ItemLeadTime;
			VarLeadTimeType _ItemVarLead = ItemVarLead;
			ListYesNoType _ItemPlanFlag = ItemPlanFlag;
			GenericDecimalType _HrsPerDay = HrsPerDay;
			ListYesNoType _MrpParmScrapFlag = MrpParmScrapFlag;
			ListYesNoType _MrpParmUseSchedTimesInPlanning = MrpParmUseSchedTimesInPlanning;
			ListYesNoType _MrpParmPlanPlannedPs = MrpParmPlanPlannedPs;
			ListYesNoType _ApsParmPlanMaterialsAtOperStart = ApsParmPlanMaterialsAtOperStart;
			RowPointerType _ProcessId = ProcessId;
			ListRegenerationNetChangeType _UserMrpPlanningType = UserMrpPlanningType;
			InfobarType _Infobar = Infobar;
			FlagNyType _MrpParmPlanStoppedJob = MrpParmPlanStoppedJob;
			IntType _DebugLevel = DebugLevel;
			IntType _ItemElapsedTime = ItemElapsedTime;
			GenericNoType _BgTaskID = BgTaskID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpExplodeSp";
				
				appDB.AddCommandParameter(cmd, "ItemItem", _ItemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemJob", _ItemJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPassReq", _ItemPassReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemLeadTime", _ItemLeadTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemVarLead", _ItemVarLead, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemPlanFlag", _ItemPlanFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrsPerDay", _HrsPerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmScrapFlag", _MrpParmScrapFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmUseSchedTimesInPlanning", _MrpParmUseSchedTimesInPlanning, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmPlanPlannedPs", _MrpParmPlanPlannedPs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsParmPlanMaterialsAtOperStart", _ApsParmPlanMaterialsAtOperStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserMrpPlanningType", _UserMrpPlanningType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MrpParmPlanStoppedJob", _MrpParmPlanStoppedJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DebugLevel", _DebugLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemElapsedTime", _ItemElapsedTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BgTaskID", _BgTaskID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
