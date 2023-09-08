//PROJECT NAME: Finance
//CLASS NAME: FinRptLineReSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineReSeq : IFinRptLineReSeq
	{
		readonly IApplicationDB appDB;
		
		
		public FinRptLineReSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FinRptLineReSeqSp(string PRptId,
		int? PFromSeq,
		int? PToSeq,
		int? PStartSeq,
		int? PStepSize,
		string Infobar)
		{
			RptIdType _PRptId = PRptId;
			FinStmtSeqType _PFromSeq = PFromSeq;
			FinStmtSeqType _PToSeq = PToSeq;
			FinStmtSeqType _PStartSeq = PStartSeq;
			FinStmtSeqType _PStepSize = PStepSize;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptLineReSeqSp";
				
				appDB.AddCommandParameter(cmd, "PRptId", _PRptId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSeq", _PFromSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PToSeq", _PToSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartSeq", _PStartSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStepSize", _PStepSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
