//PROJECT NAME: Production
//CLASS NAME: ApsCurrentRouteId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCurrentRouteId : IApsCurrentRouteId
	{
		readonly IApplicationDB appDB;
		
		public ApsCurrentRouteId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCurrentRouteIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCurrentRouteId]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
			}
        }
	}
}
