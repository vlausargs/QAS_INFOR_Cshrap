//PROJECT NAME: Finance
//CLASS NAME: TTJournalPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalPost : ITTJournalPost
	{
		readonly IApplicationDB appDB;
		
		
		public TTJournalPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Message,
		string Infobar) TTJournalPostSp(int? PCompressJournals,
		string PCompressionLevel,
		int? PDeleteJournals,
		DateTime? PReversingDate,
		int? PSingleDateForTnx,
		DateTime? PSingleDateToUse,
		DateTime? PPostThroughDate,
		string PJournalId,
		int? PLastSeq,
		Guid? SessionID,
		int? POverrideWarning,
		string Message,
		decimal? PJournalBatchId,
		string Infobar,
		string FSBName = null)
		{
			ListYesNoType _PCompressJournals = PCompressJournals;
			JournalCompLevelType _PCompressionLevel = PCompressionLevel;
			ListYesNoType _PDeleteJournals = PDeleteJournals;
			DateType _PReversingDate = PReversingDate;
			ListYesNoType _PSingleDateForTnx = PSingleDateForTnx;
			DateType _PSingleDateToUse = PSingleDateToUse;
			DateType _PPostThroughDate = PPostThroughDate;
			JournalIdType _PJournalId = PJournalId;
			JournalSeqType _PLastSeq = PLastSeq;
			RowPointerType _SessionID = SessionID;
			ListYesNoType _POverrideWarning = POverrideWarning;
			LongListType _Message = Message;
			OperationCounterType _PJournalBatchId = PJournalBatchId;
			LongListType _Infobar = Infobar;
			FSBNameType _FSBName = FSBName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TTJournalPostSp";
				
				appDB.AddCommandParameter(cmd, "PCompressJournals", _PCompressJournals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCompressionLevel", _PCompressionLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDeleteJournals", _PDeleteJournals, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReversingDate", _PReversingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSingleDateForTnx", _PSingleDateForTnx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSingleDateToUse", _PSingleDateToUse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostThroughDate", _PPostThroughDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJournalId", _PJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastSeq", _PLastSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POverrideWarning", _POverrideWarning, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Message", _Message, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PJournalBatchId", _PJournalBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Message = _Message;
				Infobar = _Infobar;
				
				return (Severity, Message, Infobar);
			}
		}
	}
}
