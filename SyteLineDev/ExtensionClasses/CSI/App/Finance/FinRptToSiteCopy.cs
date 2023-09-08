//PROJECT NAME: Finance
//CLASS NAME: FinRptToSiteCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptToSiteCopy : IFinRptToSiteCopy
	{
		readonly IApplicationDB appDB;
		
		public FinRptToSiteCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? RecordCnt,
			string Infobar) FinRptToSiteCopySp(
			string FromReportId,
			int? StartSeq,
			int? EndSeq,
			string ToSite,
			string ToReportId,
			int? RunMode,
			int? RecordCnt,
			string Infobar)
		{
			RptIdType _FromReportId = FromReportId;
			FinStmtSeqType _StartSeq = StartSeq;
			FinStmtSeqType _EndSeq = EndSeq;
			SiteType _ToSite = ToSite;
			RptIdType _ToReportId = ToReportId;
			ListYesNoType _RunMode = RunMode;
			IntType _RecordCnt = RecordCnt;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptToSiteCopySp";
				
				appDB.AddCommandParameter(cmd, "FromReportId", _FromReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSeq", _StartSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSeq", _EndSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToReportId", _ToReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RunMode", _RunMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordCnt", _RecordCnt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RecordCnt = _RecordCnt;
				Infobar = _Infobar;
				
				return (Severity, RecordCnt, Infobar);
			}
		}
	}
}
