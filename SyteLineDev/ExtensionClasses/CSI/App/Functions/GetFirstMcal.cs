//PROJECT NAME: Data
//CLASS NAME: GetFirstMcal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetFirstMcal : IGetFirstMcal
	{
		readonly IApplicationDB appDB;
		
		public GetFirstMcal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? GetFirstMcalFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetFirstMcal]()";
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
