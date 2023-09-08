//PROJECT NAME: Data
//CLASS NAME: IsAna.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsAna : IIsAna
	{
		readonly IApplicationDB appDB;
		
		public IsAna(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsAnaFn(
			string pJournalId)
		{
			JournalIdType _pJournalId = pJournalId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsAna](@pJournalId)";
				
				appDB.AddCommandParameter(cmd, "pJournalId", _pJournalId, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
