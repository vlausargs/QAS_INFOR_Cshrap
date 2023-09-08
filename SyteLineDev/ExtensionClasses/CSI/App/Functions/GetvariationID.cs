//PROJECT NAME: Data
//CLASS NAME: GetvariationID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetvariationID : IGetvariationID
	{
		readonly IApplicationDB appDB;
		
		public GetvariationID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public long? GetvariationIDFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetvariationID]()";
				
				var Output = appDB.ExecuteScalar<long?>(cmd);
				
				return Output;
			}
		}
	}
}
