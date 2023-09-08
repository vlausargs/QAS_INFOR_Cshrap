//PROJECT NAME: Finance
//CLASS NAME: MultiFSBGlJouc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBGlJouc : IMultiFSBGlJouc
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBGlJouc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MultiFSBGlJoucSp(
			string FSBName,
			DateTime? PPostDate,
			int? PLastSeq,
			string PPostLevel,
			string PJournalId,
			string Infobar,
			Guid? SessionID)
		{
			FSBNameType _FSBName = FSBName;
			DateType _PPostDate = PPostDate;
			JournalSeqType _PLastSeq = PLastSeq;
			JournalCompLevelType _PPostLevel = PPostLevel;
			JournalIdType _PJournalId = PJournalId;
			InfobarType _Infobar = Infobar;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBGlJoucSp";
				
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastSeq", _PLastSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostLevel", _PPostLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJournalId", _PJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
