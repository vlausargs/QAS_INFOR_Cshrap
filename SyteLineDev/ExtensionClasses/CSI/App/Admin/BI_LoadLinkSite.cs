//PROJECT NAME: CSIAdmin
//CLASS NAME: BI_LoadLinkSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface IBI_LoadLinkSite
	{
		(int? ReturnCode, string ServerName, string DatabaseName, string SiteName, string SiteCurrCode) BI_LoadLinkSiteSp(string Site = null,
		string ServerName = null,
		string DatabaseName = null,
		string SiteName = null,
		string SiteCurrCode = null);
	}
	
	public class BI_LoadLinkSite : IBI_LoadLinkSite
	{
		IApplicationDB appDB;
		
		public BI_LoadLinkSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ServerName, string DatabaseName, string SiteName, string SiteCurrCode) BI_LoadLinkSiteSp(string Site = null,
		string ServerName = null,
		string DatabaseName = null,
		string SiteName = null,
		string SiteCurrCode = null)
		{
			SiteType _Site = Site;
			OSLocationType _ServerName = ServerName;
			StringType _DatabaseName = DatabaseName;
			DescriptionType _SiteName = SiteName;
			CurrCodeType _SiteCurrCode = SiteCurrCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BI_LoadLinkSiteSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServerName", _ServerName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DatabaseName", _DatabaseName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteName", _SiteName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteCurrCode", _SiteCurrCode, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ServerName = _ServerName;
				DatabaseName = _DatabaseName;
				SiteName = _SiteName;
				SiteCurrCode = _SiteCurrCode;
				
				return (Severity, ServerName, DatabaseName, SiteName, SiteCurrCode);
			}
		}
	}
}
