//PROJECT NAME: Production
//CLASS NAME: ApsCurrentBomId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsCurrentBomId : IApsCurrentBomId
	{
		readonly IApplicationDB appDB;
		
		public ApsCurrentBomId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsCurrentBomIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsCurrentBomId]()";
				
				var Output = appDB.ExecuteNonQuery(cmd);
				
				return Output;
			}
		}
	}
}
