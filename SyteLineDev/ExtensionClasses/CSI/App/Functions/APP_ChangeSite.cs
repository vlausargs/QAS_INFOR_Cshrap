//PROJECT NAME: Data
//CLASS NAME: APP_ChangeSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_ChangeSite : IAPP_ChangeSite
	{
		readonly IApplicationDB appDB;
		
		public APP_ChangeSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) APP_ChangeSiteSp(
			string POldSite,
			string PNewSite,
			string Infobar)
		{
			SiteType _POldSite = POldSite;
			SiteType _PNewSite = PNewSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_ChangeSiteSp";
				
				appDB.AddCommandParameter(cmd, "POldSite", _POldSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewSite", _PNewSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
