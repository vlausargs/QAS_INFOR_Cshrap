//PROJECT NAME: BusInterface
//CLASS NAME: ESBJournalEntryCreation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
	public class ESBJournalEntryCreation : IESBJournalEntryCreation
	{
		readonly IApplicationDB appDB;
		
		public ESBJournalEntryCreation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ESBJournalEntryCreationSp(
			decimal? BatchID)
		{
			OperationCounterType _BatchID = BatchID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ESBJournalEntryCreationSp";
				
				appDB.AddCommandParameter(cmd, "BatchID", _BatchID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
