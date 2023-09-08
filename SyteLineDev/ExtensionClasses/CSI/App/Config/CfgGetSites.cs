//PROJECT NAME: Config
//CLASS NAME: CfgGetSites.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGetSites : ICfgGetSites
	{
		readonly IApplicationDB appDB;
		
		
		public CfgGetSites(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string FromSite,
		string ToSite,
		string Infobar) CfgGetSitesSp(string RefNum,
		string FromSite,
		string ToSite,
		string Infobar)
		{
			TrnNumType _RefNum = RefNum;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgGetSitesSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				FromSite = _FromSite;
				ToSite = _ToSite;
				Infobar = _Infobar;
				
				return (Severity, FromSite, ToSite, Infobar);
			}
		}
	}
}
