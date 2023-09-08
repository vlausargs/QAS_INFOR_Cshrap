//PROJECT NAME: Finance
//CLASS NAME: ProcessTmpMassJournalBulk.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class ProcessTmpMassJournalBulk : IProcessTmpMassJournalBulk
	{
		readonly IApplicationDB appDB;
		
		
		public ProcessTmpMassJournalBulk(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ProcessTmpMassJournalBulkSp(Guid? ProcessId,
		int? BGTaskId)
		{
			RowPointerType _ProcessId = ProcessId;
			GenericNoType _BGTaskId = BGTaskId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProcessTmpMassJournalBulkSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGTaskId", _BGTaskId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
