//PROJECT NAME: Production
//CLASS NAME: ApsGetDemandWhseForOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetDemandWhseForOrderId : IApsGetDemandWhseForOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsGetDemandWhseForOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetDemandWhseForOrderIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetDemandWhseForOrderId]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
