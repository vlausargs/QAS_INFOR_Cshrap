//PROJECT NAME: Data
//CLASS NAME: GainLossProcessVouchers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GainLossProcessVouchers : IGainLossProcessVouchers
	{
		readonly IApplicationDB appDB;
		
		public GainLossProcessVouchers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string rInfobar) GainLossProcessVouchersSp(
			int? pRelGl,
			int? pPostTrx,
			int? pDomInEuro,
			int? pCustVendInEuro,
			string pVendorVendNum,
			string pVendorBankCode,
			string pVendorCurrCode,
			string pTId,
			DateTime? pTransactionDate,
			string pCurrparmsCurrCode,
			string pTLossAcct,
			string pTLossAcctUnit1 = null,
			string pTLossAcctUnit2 = null,
			string pTLossAcctUnit3 = null,
			string pTLossAcctUnit4 = null,
			string pTGainAcct = null,
			string pTGainAcctUnit1 = null,
			string pTGainAcctUnit2 = null,
			string pTGainAcctUnit3 = null,
			string pTGainAcctUnit4 = null,
			string pTUngainAcct = null,
			string pTUngainAcctUnit1 = null,
			string pTUngainAcctUnit2 = null,
			string pTUngainAcctUnit3 = null,
			string pTUngainAcctUnit4 = null,
			string pTUnlossAcct = null,
			string pTUnlossAcctUnit1 = null,
			string pTUnlossAcctUnit2 = null,
			string pTUnlossAcctUnit3 = null,
			string pTUnlossAcctUnit4 = null,
			string pTVchoffAcct = null,
			string pTVchoffAcctUnit1 = null,
			string pTVchoffAcctUnit2 = null,
			string pTVchoffAcctUnit3 = null,
			string pTVchoffAcctUnit4 = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string pAcct = null,
			string pAcctUnit1 = null,
			string pAcctUnit2 = null,
			string pAcctUnit3 = null,
			string pAcctUnit4 = null,
			string rInfobar = null)
		{
			ListYesNoType _pRelGl = pRelGl;
			ListYesNoType _pPostTrx = pPostTrx;
			ListYesNoType _pDomInEuro = pDomInEuro;
			ListYesNoType _pCustVendInEuro = pCustVendInEuro;
			VendNumType _pVendorVendNum = pVendorVendNum;
			BankCodeType _pVendorBankCode = pVendorBankCode;
			CurrCodeType _pVendorCurrCode = pVendorCurrCode;
			JournalIdType _pTId = pTId;
			DateType _pTransactionDate = pTransactionDate;
			CurrCodeType _pCurrparmsCurrCode = pCurrparmsCurrCode;
			AcctType _pTLossAcct = pTLossAcct;
			UnitCode1Type _pTLossAcctUnit1 = pTLossAcctUnit1;
			UnitCode2Type _pTLossAcctUnit2 = pTLossAcctUnit2;
			UnitCode3Type _pTLossAcctUnit3 = pTLossAcctUnit3;
			UnitCode4Type _pTLossAcctUnit4 = pTLossAcctUnit4;
			AcctType _pTGainAcct = pTGainAcct;
			UnitCode1Type _pTGainAcctUnit1 = pTGainAcctUnit1;
			UnitCode2Type _pTGainAcctUnit2 = pTGainAcctUnit2;
			UnitCode3Type _pTGainAcctUnit3 = pTGainAcctUnit3;
			UnitCode4Type _pTGainAcctUnit4 = pTGainAcctUnit4;
			AcctType _pTUngainAcct = pTUngainAcct;
			UnitCode1Type _pTUngainAcctUnit1 = pTUngainAcctUnit1;
			UnitCode2Type _pTUngainAcctUnit2 = pTUngainAcctUnit2;
			UnitCode3Type _pTUngainAcctUnit3 = pTUngainAcctUnit3;
			UnitCode4Type _pTUngainAcctUnit4 = pTUngainAcctUnit4;
			AcctType _pTUnlossAcct = pTUnlossAcct;
			UnitCode1Type _pTUnlossAcctUnit1 = pTUnlossAcctUnit1;
			UnitCode2Type _pTUnlossAcctUnit2 = pTUnlossAcctUnit2;
			UnitCode3Type _pTUnlossAcctUnit3 = pTUnlossAcctUnit3;
			UnitCode4Type _pTUnlossAcctUnit4 = pTUnlossAcctUnit4;
			AcctType _pTVchoffAcct = pTVchoffAcct;
			UnitCode1Type _pTVchoffAcctUnit1 = pTVchoffAcctUnit1;
			UnitCode2Type _pTVchoffAcctUnit2 = pTVchoffAcctUnit2;
			UnitCode3Type _pTVchoffAcctUnit3 = pTVchoffAcctUnit3;
			UnitCode4Type _pTVchoffAcctUnit4 = pTVchoffAcctUnit4;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			AcctType _pAcct = pAcct;
			UnitCode1Type _pAcctUnit1 = pAcctUnit1;
			UnitCode2Type _pAcctUnit2 = pAcctUnit2;
			UnitCode3Type _pAcctUnit3 = pAcctUnit3;
			UnitCode4Type _pAcctUnit4 = pAcctUnit4;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GainLossProcessVouchersSp";
				
				appDB.AddCommandParameter(cmd, "pRelGl", _pRelGl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostTrx", _pPostTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomInEuro", _pDomInEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCustVendInEuro", _pCustVendInEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendorVendNum", _pVendorVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendorBankCode", _pVendorBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendorCurrCode", _pVendorCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTId", _pTId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransactionDate", _pTransactionDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrparmsCurrCode", _pCurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcct", _pTLossAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcctUnit1", _pTLossAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcctUnit2", _pTLossAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcctUnit3", _pTLossAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcctUnit4", _pTLossAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcct", _pTGainAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcctUnit1", _pTGainAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcctUnit2", _pTGainAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcctUnit3", _pTGainAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcctUnit4", _pTGainAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcct", _pTUngainAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcctUnit1", _pTUngainAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcctUnit2", _pTUngainAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcctUnit3", _pTUngainAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcctUnit4", _pTUngainAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcct", _pTUnlossAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit1", _pTUnlossAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit2", _pTUnlossAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit3", _pTUnlossAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit4", _pTUnlossAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcct", _pTVchoffAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcctUnit1", _pTVchoffAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcctUnit2", _pTVchoffAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcctUnit3", _pTVchoffAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcctUnit4", _pTVchoffAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pAcct", _pAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit1", _pAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit2", _pAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit3", _pAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAcctUnit4", _pAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ControlPrefix = _ControlPrefix;
				ControlSite = _ControlSite;
				ControlYear = _ControlYear;
				ControlPeriod = _ControlPeriod;
				ControlNumber = _ControlNumber;
				rInfobar = _rInfobar;
				
				return (Severity, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, rInfobar);
			}
		}
	}
}
