//PROJECT NAME: Production
//CLASS NAME: ApsGetDemandID2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGetDemandID2 : IApsGetDemandID2
	{
		readonly IApplicationDB appDB;
		
		public ApsGetDemandID2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsGetDemandID2Fn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsGetDemandID2]()";
				
				var Severity =appDB.ExecuteNonQuery(cmd);

				return Severity;
			}
		}
	}
}
