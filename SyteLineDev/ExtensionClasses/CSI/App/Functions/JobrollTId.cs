//PROJECT NAME: Data
//CLASS NAME: JobrollTId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JobrollTId : IJobrollTId
	{
		readonly IApplicationDB appDB;
		
		public JobrollTId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string JobrollTIdFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JobrollTId]()";
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
