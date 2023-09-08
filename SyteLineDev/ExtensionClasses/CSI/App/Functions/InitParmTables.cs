//PROJECT NAME: Data
//CLASS NAME: InitParmTables.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InitParmTables : IInitParmTables
	{
		readonly IApplicationDB appDB;
		
		public InitParmTables(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) InitParmTablesSp(
			string Site,
			string SiteGroup = null,
			string TimeZone = null,
			string Infobar = null,
			string SiteType = null)
		{
			SiteType _Site = Site;
			SiteGroupType _SiteGroup = SiteGroup;
			TimeZoneType _TimeZone = TimeZone;
			InfobarType _Infobar = Infobar;
			ListSiteEntityType _SiteType = SiteType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InitParmTablesSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeZone", _TimeZone, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SiteType", _SiteType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
