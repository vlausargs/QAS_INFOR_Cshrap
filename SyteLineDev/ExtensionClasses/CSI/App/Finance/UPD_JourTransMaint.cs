//PROJECT NAME: Finance
//CLASS NAME: UPD_JourTransMaint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class UPD_JourTransMaint : IUPD_JourTransMaint
	{
		readonly IApplicationDB appDB;
		
		
		public UPD_JourTransMaint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UPD_JourTransMaintSp(string pJournalId,
		int? pSeq,
		DateTime? pTransDate,
		string pAcct,
		string pAcctUnit1,
		string pAcctUnit2,
		string pAcctUnit3,
		string pAcctUnit4,
		decimal? pDomAmount)
		{
			JournalIdType _pJournalId = pJournalId;
			JournalSeqType _pSeq = pSeq;
			DateType _pTransDate = pTransDate;
			AcctType _pAcct = pAcct;
			UnitCode1Type _pAcctUnit1 = pAcctUnit1;
			UnitCode2Type _pAcctUnit2 = pAcctUnit2;
			UnitCode3Type _pAcctUnit3 = pAcctUnit3;
			UnitCode4Type _pAcctUnit4 = pAcctUnit4;
			AmountType _pDomAmount = pDomAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UPD_JourTransMaintSp";
				
				appDB.AddCommandParameter(cmd, "pJournalId", _pJournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSeq", _pSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDate", _pTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcct", _pAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit1", _pAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit2", _pAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit3", _pAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit4", _pAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomAmount", _pDomAmount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
