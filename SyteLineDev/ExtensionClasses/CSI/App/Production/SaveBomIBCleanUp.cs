//PROJECT NAME: Production
//CLASS NAME: SaveBomIBCleanUp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class SaveBomIBCleanUp : ISaveBomIBCleanUp
	{
		readonly IApplicationDB appDB;
		
		
		public SaveBomIBCleanUp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SaveBomIBCleanUpSp(Guid? ProcessId)
		{
			RowPointerType _ProcessId = ProcessId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SaveBomIBCleanUpSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
