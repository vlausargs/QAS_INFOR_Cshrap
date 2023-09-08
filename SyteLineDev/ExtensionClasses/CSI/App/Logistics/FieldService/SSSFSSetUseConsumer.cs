//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSetUseConsumer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSetUseConsumer : ISSSFSSetUseConsumer
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSetUseConsumer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSetUseConsumerSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSetUseConsumerSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
