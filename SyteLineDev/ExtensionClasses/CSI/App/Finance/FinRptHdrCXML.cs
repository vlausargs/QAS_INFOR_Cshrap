//PROJECT NAME: Finance
//CLASS NAME: FinRptHdrCXML.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptHdrCXML : IFinRptHdrCXML
	{
		readonly IApplicationDB appDB;
		
		public FinRptHdrCXML(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FinRptHdrCXMLSp(
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
				cmd.CommandText = "FinRptHdrCXMLSp";
				
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
