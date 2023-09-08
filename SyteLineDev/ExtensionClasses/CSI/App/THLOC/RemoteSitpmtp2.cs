//PROJECT NAME: THLOC
//CLASS NAME: RemoteSitpmtp2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.THLOC
{
	public class RemoteSitpmtp2 : IRemoteSitpmtp2
	{
		readonly IApplicationDB appDB;
		
		
		public RemoteSitpmtp2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? RemoteSitpmtp2Sp(int? pTtVchpckVoucher,
		string pTtVchpckAptrxpType,
		string pTtVchpckDiscAcct,
		string pTtVchpckDiscAcctUnit1,
		string pTtVchpckDiscAcctUnit2,
		string pTtVchpckDiscAcctUnit3,
		string pTtVchpckDiscAcctUnit4,
		DateTime? pAppmtCheckDate,
		int? pAppmtCheckNum,
		string pAppmtBankCode,
		string pToVendNum,
		decimal? pTLoss,
		string pFromParmsSite,
		decimal? pDomesticAmtPaid,
		decimal? pDomesticAmtDisc,
		decimal? pForeignAmtPaid,
		decimal? pForeignAmtDisc,
		string pTAppmtRef,
		decimal? pVendorExchangeRate,
		string pBankHdrCurrCode,
		decimal? ptdombal,
		decimal? ptforbal,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber)
		{
			VoucherType _pTtVchpckVoucher = pTtVchpckVoucher;
			AptrxpTypeType _pTtVchpckAptrxpType = pTtVchpckAptrxpType;
			AcctType _pTtVchpckDiscAcct = pTtVchpckDiscAcct;
			UnitCode1Type _pTtVchpckDiscAcctUnit1 = pTtVchpckDiscAcctUnit1;
			UnitCode2Type _pTtVchpckDiscAcctUnit2 = pTtVchpckDiscAcctUnit2;
			UnitCode3Type _pTtVchpckDiscAcctUnit3 = pTtVchpckDiscAcctUnit3;
			UnitCode4Type _pTtVchpckDiscAcctUnit4 = pTtVchpckDiscAcctUnit4;
			DateType _pAppmtCheckDate = pAppmtCheckDate;
			ApCheckNumType _pAppmtCheckNum = pAppmtCheckNum;
			BankCodeType _pAppmtBankCode = pAppmtBankCode;
			VendNumType _pToVendNum = pToVendNum;
			GenericDecimalType _pTLoss = pTLoss;
			SiteType _pFromParmsSite = pFromParmsSite;
			GenericDecimalType _pDomesticAmtPaid = pDomesticAmtPaid;
			GenericDecimalType _pDomesticAmtDisc = pDomesticAmtDisc;
			GenericDecimalType _pForeignAmtPaid = pForeignAmtPaid;
			GenericDecimalType _pForeignAmtDisc = pForeignAmtDisc;
			ReferenceType _pTAppmtRef = pTAppmtRef;
			GenericDecimalType _pVendorExchangeRate = pVendorExchangeRate;
			CurrCodeType _pBankHdrCurrCode = pBankHdrCurrCode;
			GenericDecimalType _ptdombal = ptdombal;
			GenericDecimalType _ptforbal = ptforbal;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoteSitpmtp2Sp";
				
				appDB.AddCommandParameter(cmd, "pTtVchpckVoucher", _pTtVchpckVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTtVchpckAptrxpType", _pTtVchpckAptrxpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTtVchpckDiscAcct", _pTtVchpckDiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTtVchpckDiscAcctUnit1", _pTtVchpckDiscAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTtVchpckDiscAcctUnit2", _pTtVchpckDiscAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTtVchpckDiscAcctUnit3", _pTtVchpckDiscAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTtVchpckDiscAcctUnit4", _pTtVchpckDiscAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAppmtCheckDate", _pAppmtCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAppmtCheckNum", _pAppmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pAppmtBankCode", _pAppmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pToVendNum", _pToVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLoss", _pTLoss, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFromParmsSite", _pFromParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomesticAmtPaid", _pDomesticAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pDomesticAmtDisc", _pDomesticAmtDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForeignAmtPaid", _pForeignAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pForeignAmtDisc", _pForeignAmtDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTAppmtRef", _pTAppmtRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVendorExchangeRate", _pVendorExchangeRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankHdrCurrCode", _pBankHdrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ptdombal", _ptdombal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ptforbal", _ptforbal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
