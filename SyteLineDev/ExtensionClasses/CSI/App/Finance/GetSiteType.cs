//PROJECT NAME: CSIFinance
//CLASS NAME: GetSiteType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IGetSiteType
	{
		(int? ReturnCode, string Site, string SiteType, byte? SiteIsEntity, string Infobar) GetSiteTypeSp(string Site = null,
		string SiteType = null,
		byte? SiteIsEntity = null,
		string Infobar = null);
	}
	
	public class GetSiteType : IGetSiteType
	{
		readonly IApplicationDB appDB;
		
		public GetSiteType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Site, string SiteType, byte? SiteIsEntity, string Infobar) GetSiteTypeSp(string Site = null,
		string SiteType = null,
		byte? SiteIsEntity = null,
		string Infobar = null)
		{
			SiteType _Site = Site;
			ListSiteEntityType _SiteType = SiteType;
			ListYesNoType _SiteIsEntity = SiteIsEntity;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSiteTypeSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteType", _SiteType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteIsEntity", _SiteIsEntity, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Site = _Site;
				SiteType = _SiteType;
				SiteIsEntity = _SiteIsEntity;
				Infobar = _Infobar;
				
				return (Severity, Site, SiteType, SiteIsEntity, Infobar);
			}
		}
	}
}
