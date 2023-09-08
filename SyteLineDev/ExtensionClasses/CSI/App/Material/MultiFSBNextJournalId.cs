//PROJECT NAME: Finance
//CLASS NAME: MultiFSBNextJournalId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBNextJournalId : IMultiFSBNextJournalId
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBNextJournalId(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Seq,
			string Infobar) MultiFSBNextJournalIdSp(
			string FSBName,
			string Id = "General",
			int? Increment = 1,
			int? Seq = null,
			string Infobar = null)
		{
			FSBNameType _FSBName = FSBName;
			JournalIdType _Id = Id;
			IntType _Increment = Increment;
			JournalSeqType _Seq = Seq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBNextJournalIdSp";
				
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
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
