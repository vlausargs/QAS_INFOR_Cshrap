//PROJECT NAME: Logistics
//CLASS NAME: GetSiteGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetSiteGroup : IGetSiteGroup
	{
		readonly IApplicationDB appDB;
		
		
		public GetSiteGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string SiteGroup) GetSiteGroupSp(string SiteGroup)
		{
			SiteGroupType _SiteGroup = SiteGroup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetSiteGroupSp";
				
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SiteGroup = _SiteGroup;
				
				return (Severity, SiteGroup);
			}
		}
	}
}
