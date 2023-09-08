//PROJECT NAME: Finance
//CLASS NAME: GlJouc.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class GlJouc : IGlJouc
	{
		readonly IApplicationDB appDB;
		
		
		public GlJouc(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) GlJoucSp(DateTime? PPostDate,
		int? PLastSeq,
		string PPostLevel,
		string PJournalId,
		string Infobar,
		Guid? SessionID,
		string CalledFrom)
		{
			DateType _PPostDate = PPostDate;
			JournalSeqType _PLastSeq = PLastSeq;
			JournalCompLevelType _PPostLevel = PPostLevel;
			JournalIdType _PJournalId = PJournalId;
			InfobarType _Infobar = Infobar;
			RowPointerType _SessionID = SessionID;
			FormNameType _CalledFrom = CalledFrom;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlJoucSp";
				
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastSeq", _PLastSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostLevel", _PPostLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJournalId", _PJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
