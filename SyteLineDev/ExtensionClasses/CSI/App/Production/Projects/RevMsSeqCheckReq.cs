//PROJECT NAME: Production
//CLASS NAME: RevMsSeqCheckReq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class RevMsSeqCheckReq : IRevMsSeqCheckReq
	{
		readonly IApplicationDB appDB;
		
		
		public RevMsSeqCheckReq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string MsgPrompt,
		string MsgButtons,
		string Infobar) RevMsSeqCheckReqSp(string PProjNum,
		string PMsNum,
		int? PTaskNum,
		string MsgPrompt,
		string MsgButtons,
		string Infobar)
		{
			ProjNumType _PProjNum = PProjNum;
			ProjMsNumType _PMsNum = PMsNum;
			TaskNumType _PTaskNum = PTaskNum;
			InfobarType _MsgPrompt = MsgPrompt;
			InfobarType _MsgButtons = MsgButtons;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RevMsSeqCheckReqSp";
				
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMsNum", _PMsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MsgPrompt", _MsgPrompt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MsgButtons", _MsgButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MsgPrompt = _MsgPrompt;
				MsgButtons = _MsgButtons;
				Infobar = _Infobar;
				
				return (Severity, MsgPrompt, MsgButtons, Infobar);
			}
		}
	}
}
