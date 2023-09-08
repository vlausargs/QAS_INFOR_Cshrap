//PROJECT NAME: Data
//CLASS NAME: ChangeReportsToGetInitInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeReportsToGetInitInfo : IChangeReportsToGetInitInfo
	{
		readonly IApplicationDB appDB;
		
		public ChangeReportsToGetInitInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ReportToSite,
			DateTime? CutoffDate,
			int? Recover,
			string Infobar) ChangeReportsToGetInitInfoSp(
			string ReportToSite,
			DateTime? CutoffDate,
			int? Recover,
			string Infobar)
		{
			SiteType _ReportToSite = ReportToSite;
			Date4Type _CutoffDate = CutoffDate;
			Flag _Recover = Recover;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeReportsToGetInitInfoSp";
				
				appDB.AddCommandParameter(cmd, "ReportToSite", _ReportToSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CutoffDate", _CutoffDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Recover", _Recover, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReportToSite = _ReportToSite;
				CutoffDate = _CutoffDate;
				Recover = _Recover;
				Infobar = _Infobar;
				
				return (Severity, ReportToSite, CutoffDate, Recover, Infobar);
			}
		}
	}
}
