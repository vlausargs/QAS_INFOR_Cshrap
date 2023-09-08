//PROJECT NAME: Production
//CLASS NAME: ApsCurrentRouteEffectivityId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCurrentRouteEffectivityId : IApsCurrentRouteEffectivityId
	{
		readonly IApplicationDB appDB;
		
		public ApsCurrentRouteEffectivityId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCurrentRouteEffectivityIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCurrentRouteEffectivityId]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
            }
        }
	}
}
