//PROJECT NAME: Data
//CLASS NAME: ChangeSiteAndSiteGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ChangeSiteAndSiteGroup : IChangeSiteAndSiteGroup
	{
		readonly IApplicationDB appDB;
		
		public ChangeSiteAndSiteGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChangeSiteAndSiteGroupSp(
			string SiteName,
			string NewSiteGroup = null,
			string Infobar = null)
		{
			SiteType _SiteName = SiteName;
			SiteGroupType _NewSiteGroup = NewSiteGroup;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChangeSiteAndSiteGroupSp";
				
				appDB.AddCommandParameter(cmd, "SiteName", _SiteName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSiteGroup", _NewSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
