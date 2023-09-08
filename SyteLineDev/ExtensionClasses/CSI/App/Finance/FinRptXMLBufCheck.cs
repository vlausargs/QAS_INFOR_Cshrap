//PROJECT NAME: Finance
//CLASS NAME: FinRptXMLBufCheck.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptXMLBufCheck : IFinRptXMLBufCheck
	{
		readonly IApplicationDB appDB;
		
		public FinRptXMLBufCheck(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) FinRptXMLBufCheckSp(
			Guid? ProcessID,
			string ReportId,
			string Infobar)
		{
			RowPointer _ProcessID = ProcessID;
			RptIdType _ReportId = ReportId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptXMLBufCheckSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportId", _ReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
