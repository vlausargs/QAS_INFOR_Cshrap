//PROJECT NAME: Data
//CLASS NAME: APP_PostCopySiteReferenceDataCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_PostCopySiteReferenceDataCleanup : IAPP_PostCopySiteReferenceDataCleanup
	{
		readonly IApplicationDB appDB;
		
		public APP_PostCopySiteReferenceDataCleanup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) APP_PostCopySiteReferenceDataCleanupSp(
			string SourceServer,
			string SourceDB,
			string SourceSite,
			int? AnalyzeOnly,
			string Infobar)
		{
			OSLocationType _SourceServer = SourceServer;
			OSLocationType _SourceDB = SourceDB;
			SiteType _SourceSite = SourceSite;
			ListYesNoType _AnalyzeOnly = AnalyzeOnly;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_PostCopySiteReferenceDataCleanupSp";
				
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
