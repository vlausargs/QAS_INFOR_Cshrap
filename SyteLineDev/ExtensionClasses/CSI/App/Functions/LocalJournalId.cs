//PROJECT NAME: Data
//CLASS NAME: LocalJournalId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LocalJournalId : ILocalJournalId
	{
		readonly IApplicationDB appDB;
		
		public LocalJournalId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string LocalJournalIdFn(
			string pJournalId)
		{
			JournalIdType _pJournalId = pJournalId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[LocalJournalId](@pJournalId)";
				
				appDB.AddCommandParameter(cmd, "pJournalId", _pJournalId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
