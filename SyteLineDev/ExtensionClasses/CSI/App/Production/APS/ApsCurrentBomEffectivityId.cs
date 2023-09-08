//PROJECT NAME: Production
//CLASS NAME: ApsCurrentBomEffectivityId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCurrentBomEffectivityId : IApsCurrentBomEffectivityId
	{
		readonly IApplicationDB appDB;
		
		public ApsCurrentBomEffectivityId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCurrentBomEffectivityIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCurrentBomEffectivityId]()";

				var Severity = appDB.ExecuteNonQuery(cmd);
				return Severity;
			}
		}
	}
}
