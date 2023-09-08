//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGanttValidateEditOperation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public interface IApsGanttValidateEditOperation
	{
		(int? ReturnCode, string PromptMsg, string PromptButtons) ApsGanttValidateEditOperationSp(short? AltNum = 0,
		int? Plan0Sched1 = null,
		string JSID = null,
		int? JobTag = null,
		int? SeqNum = null,
		string FromResource = null,
		DateTime? FromStartDate = null,
		DateTime? FromEndDate = null,
		string ToResource = null,
		DateTime? ToStartDate = null,
		DateTime? ToEndDate = null,
		string PromptMsg = null,
		string PromptButtons = null);
	}
	
	public class ApsGanttValidateEditOperation : IApsGanttValidateEditOperation
	{
		readonly IApplicationDB appDB;
		
		public ApsGanttValidateEditOperation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PromptMsg, string PromptButtons) ApsGanttValidateEditOperationSp(short? AltNum = 0,
		int? Plan0Sched1 = null,
		string JSID = null,
		int? JobTag = null,
		int? SeqNum = null,
		string FromResource = null,
		DateTime? FromStartDate = null,
		DateTime? FromEndDate = null,
		string ToResource = null,
		DateTime? ToStartDate = null,
		DateTime? ToEndDate = null,
		string PromptMsg = null,
		string PromptButtons = null)
		{
			ApsAltNoType _AltNum = AltNum;
			IntType _Plan0Sched1 = Plan0Sched1;
			ApsJobstepType _JSID = JSID;
			ApsOperationTagType _JobTag = JobTag;
			ApsIntType _SeqNum = SeqNum;
			ApsResourceType _FromResource = FromResource;
			GenericDateType _FromStartDate = FromStartDate;
			GenericDateType _FromEndDate = FromEndDate;
			ApsResourceType _ToResource = ToResource;
			GenericDateType _ToStartDate = ToStartDate;
			GenericDateType _ToEndDate = ToEndDate;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGanttValidateEditOperationSp";
				
				appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Plan0Sched1", _Plan0Sched1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JSID", _JSID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobTag", _JobTag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SeqNum", _SeqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromResource", _FromResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromStartDate", _FromStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromEndDate", _FromEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToResource", _ToResource, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToStartDate", _ToStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToEndDate", _ToEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				
				return (Severity, PromptMsg, PromptButtons);
			}
		}
	}
}
