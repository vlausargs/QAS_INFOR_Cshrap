//PROJECT NAME: Finance
//CLASS NAME: FinRptLinSXML.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLinSXML : IFinRptLinSXML
	{
		readonly IApplicationDB appDB;
		
		public FinRptLinSXML(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FinRptLinSXMLSp(
			string FromReportId,
			int? StartSeq,
			int? EndSeq,
			int? Delayed,
			string ToSite,
			string ToReportId,
			string FromSitePrefix,
			string Infobar)
		{
			RptIdType _FromReportId = FromReportId;
			FinStmtSeqType _StartSeq = StartSeq;
			FinStmtSeqType _EndSeq = EndSeq;
			ListYesNoType _Delayed = Delayed;
			SiteType _ToSite = ToSite;
			RptIdType _ToReportId = ToReportId;
			OSLocationType _FromSitePrefix = FromSitePrefix;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptLinSXMLSp";
				
				appDB.AddCommandParameter(cmd, "FromReportId", _FromReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartSeq", _StartSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSeq", _EndSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delayed", _Delayed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToReportId", _ToReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSitePrefix", _FromSitePrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
