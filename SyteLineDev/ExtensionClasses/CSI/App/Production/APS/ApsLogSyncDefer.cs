//PROJECT NAME: Production
//CLASS NAME: ApsLogSyncDefer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsLogSyncDefer : IApsLogSyncDefer
	{
		readonly IApplicationDB appDB;
		
		public ApsLogSyncDefer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ApsLogSyncDeferFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsLogSyncDefer]()";
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
