//PROJECT NAME: Production
//CLASS NAME: ApsDemandId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsDemandId : IApsDemandId
	{
		readonly IApplicationDB appDB;
		
		public ApsDemandId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsDemandIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsDemandId]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
            }
        }
	}
}
