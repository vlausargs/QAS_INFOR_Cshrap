//PROJECT NAME: Reporting
//CLASS NAME: LedgerConsolLedger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class LedgerConsolLedger : ILedgerConsolLedger
	{
		readonly IApplicationDB appDB;
		
		public LedgerConsolLedger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) LedgerConsolLedgerSp(
			decimal? pTransNum,
			string pAcct,
			DateTime? pTransDate,
			decimal? pDomAmount,
			string pRef,
			string pVendNum,
			string pVoucher,
			int? pCheckNum,
			DateTime? pCheckDate,
			string pFromSite,
			string pFromId,
			int? pVouchSeq,
			string pRefType,
			decimal? pMatlTransNum,
			decimal? pDTransNum,
			string pBankCode,
			string pAcctUnit1,
			string pAcctUnit2,
			string pAcctUnit3,
			string pAcctUnit4,
			string pCurrCode,
			decimal? pExchRate,
			string pSite,
			string ParmsSite,
			string pHierarchy,
			string pConsolidated,
			string LedgerControlPrefix,
			string LedgerControlSite,
			int? LedgerControlYear,
			int? LedgerControlPeriod,
			decimal? LedgerControlNumber,
			string LedgerRefControlPrefix,
			string LedgerRefControlSite,
			int? LedgerRefControlYear,
			int? LedgerRefControlPeriod,
			decimal? LedgerRefControlNumber,
			string Infobar,
			decimal? pJournalBatchId,
			decimal? pForAmount,
			decimal? pLedgerProjTransNum,
			int? pLedgerCancellation,
			Guid? SessionID)
		{
			MatlTransNumType _pTransNum = pTransNum;
			AcctType _pAcct = pAcct;
			DateType _pTransDate = pTransDate;
			AmountType _pDomAmount = pDomAmount;
			ReferenceType _pRef = pRef;
			VendNumType _pVendNum = pVendNum;
			InvNumVoucherType _pVoucher = pVoucher;
			GlCheckNumType _pCheckNum = pCheckNum;
			DateType _pCheckDate = pCheckDate;
			SiteType _pFromSite = pFromSite;
			JournalIdType _pFromId = pFromId;
			VouchSeqType _pVouchSeq = pVouchSeq;
			AnyRefTypeType _pRefType = pRefType;
			MatlTransNumType _pMatlTransNum = pMatlTransNum;
			MatlTransNumType _pDTransNum = pDTransNum;
			BankCodeType _pBankCode = pBankCode;
			UnitCode1Type _pAcctUnit1 = pAcctUnit1;
			UnitCode2Type _pAcctUnit2 = pAcctUnit2;
			UnitCode3Type _pAcctUnit3 = pAcctUnit3;
			UnitCode4Type _pAcctUnit4 = pAcctUnit4;
			CurrCodeType _pCurrCode = pCurrCode;
			ExchRateType _pExchRate = pExchRate;
			SiteType _pSite = pSite;
			SiteType _ParmsSite = ParmsSite;
			HierarchyType _pHierarchy = pHierarchy;
			LedgerConsolidatedType _pConsolidated = pConsolidated;
			JourControlPrefixType _LedgerControlPrefix = LedgerControlPrefix;
			SiteType _LedgerControlSite = LedgerControlSite;
			FiscalYearType _LedgerControlYear = LedgerControlYear;
			FinPeriodType _LedgerControlPeriod = LedgerControlPeriod;
			LastTranType _LedgerControlNumber = LedgerControlNumber;
			JourControlPrefixType _LedgerRefControlPrefix = LedgerRefControlPrefix;
			SiteType _LedgerRefControlSite = LedgerRefControlSite;
			FiscalYearType _LedgerRefControlYear = LedgerRefControlYear;
			FinPeriodType _LedgerRefControlPeriod = LedgerRefControlPeriod;
			LastTranType _LedgerRefControlNumber = LedgerRefControlNumber;
			InfobarType _Infobar = Infobar;
			OperationCounterType _pJournalBatchId = pJournalBatchId;
			AmountType _pForAmount = pForAmount;
			ProjTransNumType _pLedgerProjTransNum = pLedgerProjTransNum;
			ListYesNoType _pLedgerCancellation = pLedgerCancellation;
			RowPointerType _SessionID = SessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LedgerConsolLedgerSp";
				
				appDB.AddCommandParameter(cmd, "pTransNum", _pTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcct", _pAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDate", _pTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomAmount", _pDomAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRef", _pRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVoucher", _pVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckNum", _pCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckDate", _pCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromSite", _pFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromId", _pFromId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVouchSeq", _pVouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRefType", _pRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pMatlTransNum", _pMatlTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDTransNum", _pDTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit1", _pAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit2", _pAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit3", _pAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit4", _pAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrCode", _pCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pExchRate", _pExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pHierarchy", _pHierarchy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConsolidated", _pConsolidated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerControlPrefix", _LedgerControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerControlSite", _LedgerControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerControlYear", _LedgerControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerControlPeriod", _LedgerControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerControlNumber", _LedgerControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerRefControlPrefix", _LedgerRefControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerRefControlSite", _LedgerRefControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerRefControlYear", _LedgerRefControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerRefControlPeriod", _LedgerRefControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LedgerRefControlNumber", _LedgerRefControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pJournalBatchId", _pJournalBatchId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForAmount", _pForAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLedgerProjTransNum", _pLedgerProjTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pLedgerCancellation", _pLedgerCancellation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
