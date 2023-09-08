//PROJECT NAME: Logistics
//CLASS NAME: SSSFSConsumerCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConsumerCreate : ISSSFSConsumerCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSConsumerCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSConsumerCreateSp()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSConsumerCreateSp";
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
