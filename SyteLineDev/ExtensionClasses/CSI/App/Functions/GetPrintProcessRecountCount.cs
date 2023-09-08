//PROJECT NAME: Data
//CLASS NAME: GetPrintProcessRecountCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetPrintProcessRecountCount : IGetPrintProcessRecountCount
	{
		readonly IApplicationDB appDB;
		
		public GetPrintProcessRecountCount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? RecordCount,
			string PromptMsgObj,
			string PromptMsg,
			string NotificationMsg,
			int? IsExceedPromptThreshold,
			int? IsExceedNotificationThreshold) GetPrintProcessRecountCountSp(
			string FormName,
			string FormAction,
			string FilterParmsValue,
			int? RecordCount,
			string PromptMsgObj,
			string PromptMsg,
			string NotificationMsg,
			int? IsExceedPromptThreshold,
			int? IsExceedNotificationThreshold)
		{
			FormNameType _FormName = FormName;
			NameType _FormAction = FormAction;
			NameType _FilterParmsValue = FilterParmsValue;
			IntType _RecordCount = RecordCount;
			ObjectNameType _PromptMsgObj = PromptMsgObj;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _NotificationMsg = NotificationMsg;
			ListYesNoType _IsExceedPromptThreshold = IsExceedPromptThreshold;
			ListYesNoType _IsExceedNotificationThreshold = IsExceedNotificationThreshold;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPrintProcessRecountCountSp";
				
				appDB.AddCommandParameter(cmd, "FormName", _FormName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormAction", _FormAction, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterParmsValue", _FilterParmsValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordCount", _RecordCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgObj", _PromptMsgObj, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NotificationMsg", _NotificationMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsExceedPromptThreshold", _IsExceedPromptThreshold, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsExceedNotificationThreshold", _IsExceedNotificationThreshold, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RecordCount = _RecordCount;
				PromptMsgObj = _PromptMsgObj;
				PromptMsg = _PromptMsg;
				NotificationMsg = _NotificationMsg;
				IsExceedPromptThreshold = _IsExceedPromptThreshold;
				IsExceedNotificationThreshold = _IsExceedNotificationThreshold;
				
				return (Severity, RecordCount, PromptMsgObj, PromptMsg, NotificationMsg, IsExceedPromptThreshold, IsExceedNotificationThreshold);
			}
		}
	}
}
