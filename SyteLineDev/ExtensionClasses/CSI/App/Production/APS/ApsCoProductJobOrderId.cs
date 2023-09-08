//PROJECT NAME: Production
//CLASS NAME: ApsCoProductJobOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCoProductJobOrderId : IApsCoProductJobOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsCoProductJobOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCoProductJobOrderIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCoProductJobOrderId]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
            }
        }
	}
}
