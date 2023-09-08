//PROJECT NAME: Finance
//CLASS NAME: FinRptXMLBufCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptXMLBufCopy : IFinRptXMLBufCopy
	{
		readonly IApplicationDB appDB;
		
		public FinRptXMLBufCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FinRptXMLBufCopySp(
			Guid? ProcessID,
			string ReportId,
			string FromSite,
			string Infobar)
		{
			RowPointer _ProcessID = ProcessID;
			RptIdType _ReportId = ReportId;
			SiteType _FromSite = FromSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptXMLBufCopySp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportId", _ReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
