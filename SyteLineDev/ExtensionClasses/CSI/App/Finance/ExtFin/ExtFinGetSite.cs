//PROJECT NAME: Finance
//CLASS NAME: ExtFinGetSite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.ExtFin
{
	public class ExtFinGetSite : IExtFinGetSite
	{
		readonly IApplicationDB appDB;
		
		
		public ExtFinGetSite(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Site) ExtFinGetSiteSp(string Site)
		{
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ExtFinGetSiteSp";
				
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Site = _Site;
				
				return (Severity, Site);
			}
		}
	}
}
