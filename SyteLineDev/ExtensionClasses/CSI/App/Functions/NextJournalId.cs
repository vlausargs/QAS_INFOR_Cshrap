//PROJECT NAME: Data
//CLASS NAME: NextJournalId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextJournalId : INextJournalId
	{
		readonly IApplicationDB appDB;
		
		public NextJournalId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Seq,
			string Infobar) NextJournalIdSp(
			string Id,
			int? Increment = 1,
			int? Seq = null,
			string Infobar = null)
		{
			JournalIdType _Id = Id;
			IntType _Increment = Increment;
			JournalSeqType _Seq = Seq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextJournalIdSp";
				
				appDB.AddCommandParameter(cmd, "Id", _Id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Increment", _Increment, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Seq = _Seq;
				Infobar = _Infobar;
				
				return (Severity, Seq, Infobar);
			}
		}
	}
}
