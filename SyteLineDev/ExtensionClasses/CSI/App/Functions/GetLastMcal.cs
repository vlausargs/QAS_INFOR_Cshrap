//PROJECT NAME: Data
//CLASS NAME: GetLastMcal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetLastMcal : IGetLastMcal
	{
		readonly IApplicationDB appDB;
		
		public GetLastMcal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetLastMcalFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetLastMcal]()";
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
