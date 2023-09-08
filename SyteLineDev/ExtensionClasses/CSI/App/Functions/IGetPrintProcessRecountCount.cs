//PROJECT NAME: Data
//CLASS NAME: IGetPrintProcessRecountCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetPrintProcessRecountCount
	{
		(int? ReturnCode,
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
			int? IsExceedNotificationThreshold);
	}
}

