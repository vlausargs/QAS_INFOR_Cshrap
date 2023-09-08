//PROJECT NAME: Finance
//CLASS NAME: EXTCHSGlComp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSGlComp : IEXTCHSGlComp
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSGlComp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTCHSGlCompSp(
			DateTime? PPostDate,
			int? PLastSeq,
			string PPostLevel,
			string PJournalId,
			string Infobar)
		{
			DateType _PPostDate = PPostDate;
			JournalSeqType _PLastSeq = PLastSeq;
			JournalCompLevelType _PPostLevel = PPostLevel;
			JournalIdType _PJournalId = PJournalId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSGlCompSp";
				
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PLastSeq", _PLastSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostLevel", _PPostLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJournalId", _PJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
