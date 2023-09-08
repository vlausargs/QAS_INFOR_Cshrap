//PROJECT NAME: Production
//CLASS NAME: ApsParmApsMode.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsParmApsMode : IApsParmApsMode
	{
		readonly IApplicationDB appDB;
		
		public ApsParmApsMode(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ApsParmApsModeFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ApsParmApsMode]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
