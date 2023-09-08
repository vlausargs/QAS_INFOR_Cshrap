//PROJECT NAME: Data
//CLASS NAME: App_GetListNonMultiSiteTabsCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_GetListNonMultiSiteTabsCopy : IApp_GetListNonMultiSiteTabsCopy
	{
		readonly IApplicationDB appDB;
		
		public App_GetListNonMultiSiteTabsCopy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) App_GetListNonMultiSiteTabsCopySp(
			string SourceServer,
			string SourceDB,
			string Infobar)
		{
			OSLocationType _SourceServer = SourceServer;
			OSLocationType _SourceDB = SourceDB;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "App_GetListNonMultiSiteTabsCopySp";
				
				appDB.AddCommandParameter(cmd, "SourceServer", _SourceServer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SourceDB", _SourceDB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
