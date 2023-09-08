//PROJECT NAME: Data
//CLASS NAME: GainLossProcessVouchersPayable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GainLossProcessVouchersPayable : IGainLossProcessVouchersPayable
	{
		readonly IApplicationDB appDB;
		
		public GainLossProcessVouchersPayable(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string rInfobar) GainLossProcessVouchersPayableSp(
			int? pRelGl,
			int? pPostTrx,
			int? pTDomInEuro,
			int? pTCustvendInEuro,
			string pVendorVendNum,
			string pVendorBankCode,
			string pVendorCurrCode,
			string pTId,
			DateTime? pTTransDate,
			string pCurrparmsCurrCode,
			string pTLossAcct = null,
			string pTLossAcctUnit1 = null,
			string pTLossAcctUnit2 = null,
			string pTLossAcctUnit3 = null,
			string pTLossAcctUnit4 = null,
			string pTGainAcct = null,
			string pTGainAcctUnit1 = null,
			string pTGainAcctUnit2 = null,
			string pTGainAcctUnit3 = null,
			string pTGainAcctUnit4 = null,
			string pTUnGainAcct = null,
			string pTUnGainAcctUnit1 = null,
			string pTUnGainAcctUnit2 = null,
			string pTUnGainAcctUnit3 = null,
			string pTUnGainAcctUnit4 = null,
			string pTUnlossAcct = null,
			string pTUnlossAcctUnit1 = null,
			string pTUnlossAcctUnit2 = null,
			string pTUnlossAcctUnit3 = null,
			string pTUnlossAcctUnit4 = null,
			string pTApoffAcct = null,
			string pTApoffAcctUnit1 = null,
			string pTApoffAcctUnit2 = null,
			string pTApoffAcctUnit3 = null,
			string pTApoffAcctUnit4 = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string rInfobar = null)
		{
			ListYesNoType _pRelGl = pRelGl;
			ListYesNoType _pPostTrx = pPostTrx;
			ListYesNoType _pTDomInEuro = pTDomInEuro;
			ListYesNoType _pTCustvendInEuro = pTCustvendInEuro;
			VendNumType _pVendorVendNum = pVendorVendNum;
			BankCodeType _pVendorBankCode = pVendorBankCode;
			CurrCodeType _pVendorCurrCode = pVendorCurrCode;
			JournalIdType _pTId = pTId;
			GenericDateType _pTTransDate = pTTransDate;
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
			AcctType _pTUnGainAcct = pTUnGainAcct;
			UnitCode1Type _pTUnGainAcctUnit1 = pTUnGainAcctUnit1;
			UnitCode2Type _pTUnGainAcctUnit2 = pTUnGainAcctUnit2;
			UnitCode3Type _pTUnGainAcctUnit3 = pTUnGainAcctUnit3;
			UnitCode4Type _pTUnGainAcctUnit4 = pTUnGainAcctUnit4;
			AcctType _pTUnlossAcct = pTUnlossAcct;
			UnitCode1Type _pTUnlossAcctUnit1 = pTUnlossAcctUnit1;
			UnitCode2Type _pTUnlossAcctUnit2 = pTUnlossAcctUnit2;
			UnitCode3Type _pTUnlossAcctUnit3 = pTUnlossAcctUnit3;
			UnitCode4Type _pTUnlossAcctUnit4 = pTUnlossAcctUnit4;
			AcctType _pTApoffAcct = pTApoffAcct;
			UnitCode1Type _pTApoffAcctUnit1 = pTApoffAcctUnit1;
			UnitCode2Type _pTApoffAcctUnit2 = pTApoffAcctUnit2;
			UnitCode3Type _pTApoffAcctUnit3 = pTApoffAcctUnit3;
			UnitCode4Type _pTApoffAcctUnit4 = pTApoffAcctUnit4;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GainLossProcessVouchersPayableSp";
				
				appDB.AddCommandParameter(cmd, "pRelGl", _pRelGl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostTrx", _pPostTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTDomInEuro", _pTDomInEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTCustvendInEuro", _pTCustvendInEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendorVendNum", _pVendorVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendorBankCode", _pVendorBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendorCurrCode", _pVendorCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTId", _pTId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTTransDate", _pTTransDate, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "pTUnGainAcct", _pTUnGainAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnGainAcctUnit1", _pTUnGainAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnGainAcctUnit2", _pTUnGainAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnGainAcctUnit3", _pTUnGainAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnGainAcctUnit4", _pTUnGainAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcct", _pTUnlossAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit1", _pTUnlossAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit2", _pTUnlossAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit3", _pTUnlossAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit4", _pTUnlossAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApoffAcct", _pTApoffAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApoffAcctUnit1", _pTApoffAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApoffAcctUnit2", _pTApoffAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApoffAcctUnit3", _pTApoffAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApoffAcctUnit4", _pTApoffAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
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
