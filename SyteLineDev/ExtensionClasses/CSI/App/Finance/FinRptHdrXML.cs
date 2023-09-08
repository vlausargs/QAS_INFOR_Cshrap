//PROJECT NAME: Finance
//CLASS NAME: FinRptHdrXML.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptHdrXML : IFinRptHdrXML
	{
		readonly IApplicationDB appDB;
		
		public FinRptHdrXML(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FinRptHdrXMLSp(
			string FromReportId,
			string ToSite,
			string ToReportId,
			string Infobar)
		{
			RptIdType _FromReportId = FromReportId;
			SiteType _ToSite = ToSite;
			RptIdType _ToReportId = ToReportId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptHdrXMLSp";
				
				appDB.AddCommandParameter(cmd, "FromReportId", _FromReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToReportId", _ToReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
