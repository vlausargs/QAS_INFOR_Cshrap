//PROJECT NAME: Data
//CLASS NAME: LogBGTaskMessage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LogBGTaskMessage : ILogBGTaskMessage
	{
		readonly IApplicationDB appDB;
		
		public LogBGTaskMessage(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? InitMsgDisplayed) LogBGTaskMessageSp(
			int? TaskID,
			string InitialMsg,
			string ErrorMsg,
			int? InitMsgDisplayed)
		{
			GenericNoType _TaskID = TaskID;
			InfobarType _InitialMsg = InitialMsg;
			InfobarType _ErrorMsg = ErrorMsg;
			FlagNyType _InitMsgDisplayed = InitMsgDisplayed;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LogBGTaskMessageSp";
				
				appDB.AddCommandParameter(cmd, "TaskID", _TaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InitialMsg", _InitialMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ErrorMsg", _ErrorMsg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InitMsgDisplayed", _InitMsgDisplayed, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InitMsgDisplayed = _InitMsgDisplayed;
				
				return (Severity, InitMsgDisplayed);
			}
		}
	}
}
