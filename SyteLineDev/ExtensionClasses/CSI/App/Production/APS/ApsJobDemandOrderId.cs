//PROJECT NAME: Production
//CLASS NAME: ApsJobDemandOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsJobDemandOrderId : IApsJobDemandOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsJobDemandOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public void ApsJobDemandOrderIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsJobDemandOrderId]()";
				
				appDB.ExecuteScalar<string>(cmd);
			}
		}
	}
}
