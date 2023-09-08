//PROJECT NAME: Data
//CLASS NAME: GlPostD.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GlPostD : IGlPostD
	{
		readonly IApplicationDB appDB;
		
		public GlPostD(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PEndTrans,
			string Infobar) GlPostDSp(
			int? PAnalyticalLedger,
			decimal? ParTrans,
			decimal? ParTransRev,
			DateTime? PDate,
			DateTime? PNextPer,
			string PAcct,
			decimal? PDomAmount,
			decimal? PForAmount,
			string PList,
			int? PDomCurrencyPlaces,
			int? ForCurrencyPlaces = 2,
			decimal? PEndTrans = null,
			Guid? JournalRowPointer = null,
			string JournalVendNum = null,
			string JournalVoucher = null,
			int? JournalCheckNum = null,
			DateTime? JournalCheckDate = null,
			string JournalFromSite = null,
			string JournalId = null,
			int? JournalVouchSeq = null,
			string JournalRefType = null,
			decimal? JournalMatlTransNum = null,
			string JournalBankCode = null,
			string JournalCurrCode = null,
			decimal? JournalExchRate = null,
			string JournalAcctUnit1 = null,
			string JournalAcctUnit2 = null,
			string JournalAcctUnit3 = null,
			string JournalAcctUnit4 = null,
			DateTime? JournalTransDate = null,
			int? JournalReverse = null,
			string JournalRef = null,
			int? JournalNoteExists = 1,
			string JournalControlPrefix = null,
			string JournalControlSite = null,
			int? JournalControlYear = null,
			int? JournalControlPeriod = null,
			decimal? JournalControlNumber = null,
			string JournalRefControlPrefix = null,
			string JournalRefControlSite = null,
			int? JournalRefControlYear = null,
			int? JournalRefControlPeriod = null,
			decimal? JournalRefControlNumber = null,
			int? RevJournalControlYear = null,
			int? RevJournalControlPeriod = null,
			decimal? RevJournalControlNumber = null,
			string Infobar = null,
			decimal? JournalProjTransNum = null,
			decimal? PJournalBatchId = null)
		{
			ListYesNoType _PAnalyticalLedger = PAnalyticalLedger;
			MatlTransNumType _ParTrans = ParTrans;
			MatlTransNumType _ParTransRev = ParTransRev;
			DateType _PDate = PDate;
			DateType _PNextPer = PNextPer;
			AcctType _PAcct = PAcct;
			AmountType _PDomAmount = PDomAmount;
			AmountType _PForAmount = PForAmount;
			LongListType _PList = PList;
			DecimalPlacesType _PDomCurrencyPlaces = PDomCurrencyPlaces;
			DecimalPlacesType _ForCurrencyPlaces = ForCurrencyPlaces;
			MatlTransNumType _PEndTrans = PEndTrans;
			RowPointerType _JournalRowPointer = JournalRowPointer;
			VendNumType _JournalVendNum = JournalVendNum;
			InvNumVoucherType _JournalVoucher = JournalVoucher;
			GlCheckNumType _JournalCheckNum = JournalCheckNum;
			DateType _JournalCheckDate = JournalCheckDate;
			SiteType _JournalFromSite = JournalFromSite;
			JournalIdType _JournalId = JournalId;
			VouchSeqType _JournalVouchSeq = JournalVouchSeq;
			AnyRefTypeType _JournalRefType = JournalRefType;
			MatlTransNumType _JournalMatlTransNum = JournalMatlTransNum;
			BankCodeType _JournalBankCode = JournalBankCode;
			CurrCodeType _JournalCurrCode = JournalCurrCode;
			ExchRateType _JournalExchRate = JournalExchRate;
			UnitCode1Type _JournalAcctUnit1 = JournalAcctUnit1;
			UnitCode2Type _JournalAcctUnit2 = JournalAcctUnit2;
			UnitCode3Type _JournalAcctUnit3 = JournalAcctUnit3;
			UnitCode4Type _JournalAcctUnit4 = JournalAcctUnit4;
			DateType _JournalTransDate = JournalTransDate;
			ListYesNoType _JournalReverse = JournalReverse;
			ReferenceType _JournalRef = JournalRef;
			ListYesNoType _JournalNoteExists = JournalNoteExists;
			JourControlPrefixType _JournalControlPrefix = JournalControlPrefix;
			SiteType _JournalControlSite = JournalControlSite;
			FiscalYearType _JournalControlYear = JournalControlYear;
			FinPeriodType _JournalControlPeriod = JournalControlPeriod;
			LastTranType _JournalControlNumber = JournalControlNumber;
			JourControlPrefixType _JournalRefControlPrefix = JournalRefControlPrefix;
			SiteType _JournalRefControlSite = JournalRefControlSite;
			FiscalYearType _JournalRefControlYear = JournalRefControlYear;
			FinPeriodType _JournalRefControlPeriod = JournalRefControlPeriod;
			LastTranType _JournalRefControlNumber = JournalRefControlNumber;
			FiscalYearType _RevJournalControlYear = RevJournalControlYear;
			FinPeriodType _RevJournalControlPeriod = RevJournalControlPeriod;
			LastTranType _RevJournalControlNumber = RevJournalControlNumber;
			InfobarType _Infobar = Infobar;
			ProjTransNumType _JournalProjTransNum = JournalProjTransNum;
			OperationCounterType _PJournalBatchId = PJournalBatchId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlPostDSp";
				
				appDB.AddCommandParameter(cmd, "PAnalyticalLedger", _PAnalyticalLedger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParTrans", _ParTrans, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParTransRev", _ParTransRev, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNextPer", _PNextPer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomAmount", _PDomAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmount", _PForAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PList", _PList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDomCurrencyPlaces", _PDomCurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForCurrencyPlaces", _ForCurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndTrans", _PEndTrans, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JournalRowPointer", _JournalRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalVendNum", _JournalVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalVoucher", _JournalVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalCheckNum", _JournalCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalCheckDate", _JournalCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalFromSite", _JournalFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalVouchSeq", _JournalVouchSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalRefType", _JournalRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalMatlTransNum", _JournalMatlTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalBankCode", _JournalBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalCurrCode", _JournalCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalExchRate", _JournalExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalAcctUnit1", _JournalAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalAcctUnit2", _JournalAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalAcctUnit3", _JournalAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalAcctUnit4", _JournalAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalTransDate", _JournalTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalReverse", _JournalReverse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalRef", _JournalRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalNoteExists", _JournalNoteExists, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalControlPrefix", _JournalControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalControlSite", _JournalControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalControlYear", _JournalControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalControlPeriod", _JournalControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalControlNumber", _JournalControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalRefControlPrefix", _JournalRefControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalRefControlSite", _JournalRefControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalRefControlYear", _JournalRefControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalRefControlPeriod", _JournalRefControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JournalRefControlNumber", _JournalRefControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevJournalControlYear", _RevJournalControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevJournalControlPeriod", _RevJournalControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RevJournalControlNumber", _RevJournalControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JournalProjTransNum", _JournalProjTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJournalBatchId", _PJournalBatchId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEndTrans = _PEndTrans;
				Infobar = _Infobar;
				
				return (Severity, PEndTrans, Infobar);
			}
		}
	}
}
