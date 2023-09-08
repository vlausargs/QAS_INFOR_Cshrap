//PROJECT NAME: Data
//CLASS NAME: App_UserAndGroupCopyDBDataClean.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_UserAndGroupCopyDBDataClean : IApp_UserAndGroupCopyDBDataClean
	{
		readonly IApplicationDB appDB;
		
		public App_UserAndGroupCopyDBDataClean(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) App_UserAndGroupCopyDBDataCleanSp(
			string SourceServer,
			string SourceDB,
			string SourceSite,
			int? UsersAreShared,
			string Infobar)
		{
			OSLocationType _SourceServer = SourceServer;
			OSLocationType _SourceDB = SourceDB;
			SiteType _SourceSite = SourceSite;
			ListYesNoType _UsersAreShared = UsersAreShared;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "App_UserAndGroupCopyDBDataCleanSp";
				
				appDB.AddCommandParameter(cmd, "SourceServer", _SourceServer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceDB", _SourceDB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceSite", _SourceSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsersAreShared", _UsersAreShared, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
