//PROJECT NAME: Admin
//CLASS NAME: PurgeJournal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface IPurgeJournal
	{
		(int? ReturnCode, string Infobar) PurgeJournalSp(string pJournalId,
		DateTime? pCutoffDate,
		short? CutoffDateOffset = null,
		decimal? UserId = null,
		string Infobar = null);
	}
	
	public class PurgeJournal : IPurgeJournal
	{
		IApplicationDB appDB;
		
		public PurgeJournal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PurgeJournalSp(string pJournalId,
		DateTime? pCutoffDate,
		short? CutoffDateOffset = null,
		decimal? UserId = null,
		string Infobar = null)
		{
			JournalIdType _pJournalId = pJournalId;
			DateType _pCutoffDate = pCutoffDate;
			DateOffsetType _CutoffDateOffset = CutoffDateOffset;
			TokenType _UserId = UserId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeJournalSp";
				
				appDB.AddCommandParameter(cmd, "pJournalId", _pJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCutoffDate", _pCutoffDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CutoffDateOffset", _CutoffDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
