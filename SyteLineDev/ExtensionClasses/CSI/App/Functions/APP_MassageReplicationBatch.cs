//PROJECT NAME: Data
//CLASS NAME: APP_MassageReplicationBatch.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class APP_MassageReplicationBatch : IAPP_MassageReplicationBatch
	{
		readonly IApplicationDB appDB;
		
		public APP_MassageReplicationBatch(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? APP_MassageReplicationBatchSp(
			Guid? ProcessingPtr)
		{
			RowPointerType _ProcessingPtr = ProcessingPtr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "APP_MassageReplicationBatchSp";
				
				appDB.AddCommandParameter(cmd, "ProcessingPtr", _ProcessingPtr, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
