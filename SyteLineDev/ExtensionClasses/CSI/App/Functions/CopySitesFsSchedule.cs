//PROJECT NAME: Data
//CLASS NAME: CopySitesFsSchedule.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class CopySitesFsSchedule : ICopySitesFsSchedule
	{
		readonly IApplicationDB appDB;
		
		public CopySitesFsSchedule(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CopySitesFsScheduleSp(
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
				cmd.CommandText = "CopySitesFsScheduleSp";
				
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
