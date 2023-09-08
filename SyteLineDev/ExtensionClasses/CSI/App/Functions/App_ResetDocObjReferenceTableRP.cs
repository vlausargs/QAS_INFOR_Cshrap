//PROJECT NAME: Data
//CLASS NAME: App_ResetDocObjReferenceTableRP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_ResetDocObjReferenceTableRP : IApp_ResetDocObjReferenceTableRP
	{
		readonly IApplicationDB appDB;
		
		public App_ResetDocObjReferenceTableRP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) App_ResetDocObjReferenceTableRPSp(
			string SourceServer,
			string SourceDB,
			string SourceSite,
			int? AnalyzeOnly = 1,
			string Infobar = null)
		{
			StringType _SourceServer = SourceServer;
			StringType _SourceDB = SourceDB;
			SiteType _SourceSite = SourceSite;
			ListYesNoType _AnalyzeOnly = AnalyzeOnly;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "App_ResetDocObjReferenceTableRPSp";
				
				appDB.AddCommandParameter(cmd, "SourceServer", _SourceServer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceDB", _SourceDB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnalyzeOnly", _AnalyzeOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
