//PROJECT NAME: Finance
//CLASS NAME: FinRptLineDefaultSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineDefaultSeq : IFinRptLineDefaultSeq
	{
		readonly IApplicationDB appDB;
		
		
		public FinRptLineDefaultSeq(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? FirstSeq,
		int? LastSeq,
		string Infobar) FinRptLineDefaultSeqSp(string RptId,
		int? FirstSeq,
		int? LastSeq,
		string Infobar)
		{
			RptIdType _RptId = RptId;
			FinStmtSeqType _FirstSeq = FirstSeq;
			FinStmtSeqType _LastSeq = LastSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptLineDefaultSeqSp";
				
				appDB.AddCommandParameter(cmd, "RptId", _RptId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FirstSeq", _FirstSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LastSeq", _LastSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FirstSeq = _FirstSeq;
				LastSeq = _LastSeq;
				Infobar = _Infobar;
				
				return (Severity, FirstSeq, LastSeq, Infobar);
			}
		}
	}
}
