//PROJECT NAME: Finance
//CLASS NAME: GlrptlNextSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GlrptlNextSeq : IGlrptlNextSeq
	{
		readonly IApplicationDB appDB;
		
		
		public GlrptlNextSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? NextSeq,
		string PromptMsg,
		string Infobar) GlrptlNextSeqSp(string RptId,
		int? CurSeq,
		int? NextSeq,
		string PromptMsg,
		string Infobar)
		{
			RptIdType _RptId = RptId;
			FinStmtSeqType _CurSeq = CurSeq;
			FinStmtSeqType _NextSeq = NextSeq;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlrptlNextSeqSp";
				
				appDB.AddCommandParameter(cmd, "RptId", _RptId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurSeq", _CurSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextSeq", _NextSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextSeq = _NextSeq;
				PromptMsg = _PromptMsg;
				Infobar = _Infobar;
				
				return (Severity, NextSeq, PromptMsg, Infobar);
			}
		}
	}
}
