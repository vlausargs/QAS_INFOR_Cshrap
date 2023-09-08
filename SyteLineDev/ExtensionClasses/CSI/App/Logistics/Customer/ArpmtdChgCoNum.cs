//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdChgCoNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtdChgCoNum : IArpmtdChgCoNum
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtdChgCoNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PArpmtdApplyCustNum,
		string PApplCustName,
		int? PFixedEuro,
		decimal? PArpmtdExchRate,
		int? PUpdateRate,
		decimal? PArpmtdForAmtApplied,
		decimal? PArpmtdForDiscAmt,
		decimal? PArpmtdDomAmtApplied,
		decimal? PArpmtdDomDiscAmt,
		string PArpmtdDiscAcct,
		string PArpmtdDiscAcctUnit1,
		string PArpmtdDiscAcctUnit2,
		string PArpmtdDiscAcctUnit3,
		string PArpmtdDiscAcctUnit4,
		string Infobar,
		int? PArpmtdDiscIsControl) ArpmtdChgCoNumSp(string PArpmtdSite,
		string PArpmtdCoNum,
		string PArpmtdInvNum,
		string PArpmtCustNum,
		string PDerCustCurrCode,
		int? PAddMode,
		int? PReApp,
		string POpenType,
		string PArpmtdType,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		decimal? PForAmtRem,
		string PArpmtdApplyCustNum,
		string PApplCustName,
		int? PFixedEuro,
		decimal? PArpmtdExchRate,
		int? PUpdateRate,
		decimal? PArpmtdForAmtApplied,
		decimal? PArpmtdForDiscAmt,
		decimal? PArpmtdDomAmtApplied,
		decimal? PArpmtdDomDiscAmt,
		string PArpmtdDiscAcct,
		string PArpmtdDiscAcctUnit1,
		string PArpmtdDiscAcctUnit2,
		string PArpmtdDiscAcctUnit3,
		string PArpmtdDiscAcctUnit4,
		string Infobar,
		int? PArpmtdDiscIsControl,
		string PArpmtBankCode = null,
		string PArpmtPaymentCurrCode = null,
		decimal? PArpmtPaymentExchRate = null)
		{
			SiteType _PArpmtdSite = PArpmtdSite;
			CoNumType _PArpmtdCoNum = PArpmtdCoNum;
			InvNumType _PArpmtdInvNum = PArpmtdInvNum;
			CustNumType _PArpmtCustNum = PArpmtCustNum;
			CurrCodeType _PDerCustCurrCode = PDerCustCurrCode;
			FlagNyType _PAddMode = PAddMode;
			FlagNyType _PReApp = PReApp;
			LongListType _POpenType = POpenType;
			StringType _PArpmtdType = PArpmtdType;
			ExchRateType _PArpmtExchRate = PArpmtExchRate;
			DateType _PArpmtRecptDate = PArpmtRecptDate;
			AmountType _PForAmtRem = PForAmtRem;
			CustNumType _PArpmtdApplyCustNum = PArpmtdApplyCustNum;
			NameType _PApplCustName = PApplCustName;
			Flag _PFixedEuro = PFixedEuro;
			ExchRateType _PArpmtdExchRate = PArpmtdExchRate;
			FlagNyType _PUpdateRate = PUpdateRate;
			AmountType _PArpmtdForAmtApplied = PArpmtdForAmtApplied;
			AmountType _PArpmtdForDiscAmt = PArpmtdForDiscAmt;
			AmountType _PArpmtdDomAmtApplied = PArpmtdDomAmtApplied;
			AmountType _PArpmtdDomDiscAmt = PArpmtdDomDiscAmt;
			AcctType _PArpmtdDiscAcct = PArpmtdDiscAcct;
			UnitCode1Type _PArpmtdDiscAcctUnit1 = PArpmtdDiscAcctUnit1;
			UnitCode2Type _PArpmtdDiscAcctUnit2 = PArpmtdDiscAcctUnit2;
			UnitCode3Type _PArpmtdDiscAcctUnit3 = PArpmtdDiscAcctUnit3;
			UnitCode4Type _PArpmtdDiscAcctUnit4 = PArpmtdDiscAcctUnit4;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PArpmtdDiscIsControl = PArpmtdDiscIsControl;
			BankCodeType _PArpmtBankCode = PArpmtBankCode;
			CurrCodeType _PArpmtPaymentCurrCode = PArpmtPaymentCurrCode;
			ExchRateType _PArpmtPaymentExchRate = PArpmtPaymentExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdChgCoNumSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtdSite", _PArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdCoNum", _PArpmtdCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdInvNum", _PArpmtdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtCustNum", _PArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDerCustCurrCode", _PDerCustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddMode", _PAddMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReApp", _PReApp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenType", _POpenType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdType", _PArpmtdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtExchRate", _PArpmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtRecptDate", _PArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmtRem", _PForAmtRem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdApplyCustNum", _PArpmtdApplyCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PApplCustName", _PApplCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFixedEuro", _PFixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdExchRate", _PArpmtdExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUpdateRate", _PUpdateRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdForAmtApplied", _PArpmtdForAmtApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdForDiscAmt", _PArpmtdForDiscAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDomAmtApplied", _PArpmtdDomAmtApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDomDiscAmt", _PArpmtdDomDiscAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDiscAcct", _PArpmtdDiscAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDiscAcctUnit1", _PArpmtdDiscAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDiscAcctUnit2", _PArpmtdDiscAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDiscAcctUnit3", _PArpmtdDiscAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDiscAcctUnit4", _PArpmtdDiscAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDiscIsControl", _PArpmtdDiscIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtBankCode", _PArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtPaymentCurrCode", _PArpmtPaymentCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtPaymentExchRate", _PArpmtPaymentExchRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PArpmtdApplyCustNum = _PArpmtdApplyCustNum;
				PApplCustName = _PApplCustName;
				PFixedEuro = _PFixedEuro;
				PArpmtdExchRate = _PArpmtdExchRate;
				PUpdateRate = _PUpdateRate;
				PArpmtdForAmtApplied = _PArpmtdForAmtApplied;
				PArpmtdForDiscAmt = _PArpmtdForDiscAmt;
				PArpmtdDomAmtApplied = _PArpmtdDomAmtApplied;
				PArpmtdDomDiscAmt = _PArpmtdDomDiscAmt;
				PArpmtdDiscAcct = _PArpmtdDiscAcct;
				PArpmtdDiscAcctUnit1 = _PArpmtdDiscAcctUnit1;
				PArpmtdDiscAcctUnit2 = _PArpmtdDiscAcctUnit2;
				PArpmtdDiscAcctUnit3 = _PArpmtdDiscAcctUnit3;
				PArpmtdDiscAcctUnit4 = _PArpmtdDiscAcctUnit4;
				Infobar = _Infobar;
				PArpmtdDiscIsControl = _PArpmtdDiscIsControl;
				
				return (Severity, PArpmtdApplyCustNum, PApplCustName, PFixedEuro, PArpmtdExchRate, PUpdateRate, PArpmtdForAmtApplied, PArpmtdForDiscAmt, PArpmtdDomAmtApplied, PArpmtdDomDiscAmt, PArpmtdDiscAcct, PArpmtdDiscAcctUnit1, PArpmtdDiscAcctUnit2, PArpmtdDiscAcctUnit3, PArpmtdDiscAcctUnit4, Infobar, PArpmtdDiscIsControl);
			}
		}
	}
}
