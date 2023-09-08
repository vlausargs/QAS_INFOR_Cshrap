//PROJECT NAME: Production
//CLASS NAME: ApsSchedOpOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSchedOpOrderId : IApsSchedOpOrderId
	{
		readonly IApplicationDB appDB;
		
		public ApsSchedOpOrderId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsSchedOpOrderIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsSchedOpOrderId]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
