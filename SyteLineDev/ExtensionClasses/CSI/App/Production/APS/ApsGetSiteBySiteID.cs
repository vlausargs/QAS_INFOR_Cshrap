//PROJECT NAME: Production
//CLASS NAME: ApsGetSiteBySiteID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetSiteBySiteID : IApsGetSiteBySiteID
	{
		readonly IApplicationDB appDB;
		
		public ApsGetSiteBySiteID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetSiteBySiteIDSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApsGetSiteBySiteIDSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
