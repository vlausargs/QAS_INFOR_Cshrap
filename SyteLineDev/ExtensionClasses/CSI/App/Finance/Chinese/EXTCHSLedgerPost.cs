//PROJECT NAME: Finance
//CLASS NAME: EXTCHSLedgerPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class EXTCHSLedgerPost : IEXTCHSLedgerPost
	{
		readonly IApplicationDB appDB;
		
		public EXTCHSLedgerPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EXTCHSLedgerPostSp(
			string pJournalId,
			int? pJournalSeq,
			decimal? pTransNum,
			DateTime? pTransDate,
			int? pReverse,
			Guid? pLedgerRowPointer,
			DateTime? pJournalDate,
			string Infobar = null)
		{
			JournalIdType _pJournalId = pJournalId;
			JournalSeqType _pJournalSeq = pJournalSeq;
			MatlTransNumType _pTransNum = pTransNum;
			DateType _pTransDate = pTransDate;
			ListYesNoType _pReverse = pReverse;
			RowPointerType _pLedgerRowPointer = pLedgerRowPointer;
			DateType _pJournalDate = pJournalDate;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTCHSLedgerPostSp";
				
				appDB.AddCommandParameter(cmd, "pJournalId", _pJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJournalSeq", _pJournalSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransNum", _pTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDate", _pTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pReverse", _pReverse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLedgerRowPointer", _pLedgerRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pJournalDate", _pJournalDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
