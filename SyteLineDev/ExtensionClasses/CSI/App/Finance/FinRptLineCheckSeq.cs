//PROJECT NAME: Finance
//CLASS NAME: FinRptLineCheckSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineCheckSeq : IFinRptLineCheckSeq
	{
		readonly IApplicationDB appDB;
		
		
		public FinRptLineCheckSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) FinRptLineCheckSeqSp(string RptId,
		int? Seq,
		string Infobar)
		{
			RptIdType _RptId = RptId;
			FinStmtSeqType _Seq = Seq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptLineCheckSeqSp";
				
				appDB.AddCommandParameter(cmd, "RptId", _RptId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
