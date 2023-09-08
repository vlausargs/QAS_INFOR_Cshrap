//PROJECT NAME: Production
//CLASS NAME: ApsInvLevelRangeTbl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsInvLevelRangeTbl : IApsInvLevelRangeTbl
	{
		readonly IApplicationDB appDB;
		
		public ApsInvLevelRangeTbl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsInvLevelRangeTblFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsInvLevelRangeTbl]()";

                var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
			}
        }
	}
}
