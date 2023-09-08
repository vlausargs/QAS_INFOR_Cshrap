//PROJECT NAME: Data
//CLASS NAME: ILogBGTaskMessage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ILogBGTaskMessage
	{
		(int? ReturnCode,
			int? InitMsgDisplayed) LogBGTaskMessageSp(
			int? TaskID,
			string InitialMsg,
			string ErrorMsg,
			int? InitMsgDisplayed);
	}
}

