//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdChgArpmtdType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtdChgArpmtdType : IArpmtdChgArpmtdType
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtdChgArpmtdType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PArpmtdInvNum,
		decimal? PArpmtdExchRate,
		int? PUpdateRate,
		string PArpmtdDepositAcct,
		string PArpmtdDepositAcctUnit1,
		string PArpmtdDepositAcctUnit2,
		string PArpmtdDepositAcctUnit3,
		string PArpmtdDepositAcctUnit4,
		decimal? PArpmtdForAmtApplied,
		decimal? PArpmtdDomAmtApplied,
		string Infobar,
		int? PArpmtdDepositIsControl) ArpmtdChgArpmtdTypeSp(string PArpmtCustNum,
		int? PArpmtCheckNum,
		string PArpmtCreditMemoNum,
		string PArpmtdType,
		string PArpmtBankCode,
		string PArpmtdSite,
		int? PAddMode,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		string PCustCurrCode,
		int? PReApp,
		string POpenType,
		decimal? PDerPayAmtRem,
		decimal? PDerForAmtRem,
		decimal? PDerDomAmtRem,
		string PArpmtdInvNum,
		decimal? PArpmtdExchRate,
		int? PUpdateRate,
		string PArpmtdDepositAcct,
		string PArpmtdDepositAcctUnit1,
		string PArpmtdDepositAcctUnit2,
		string PArpmtdDepositAcctUnit3,
		string PArpmtdDepositAcctUnit4,
		decimal? PArpmtdForAmtApplied,
		decimal? PArpmtdDomAmtApplied,
		string Infobar,
		int? PArpmtdDepositIsControl,
		string PArpmtPaymentCurrCode = null,
		decimal? PArpmtPaymentExchRate = null)
		{
			CustNumType _PArpmtCustNum = PArpmtCustNum;
			ArCheckNumType _PArpmtCheckNum = PArpmtCheckNum;
			InvNumType _PArpmtCreditMemoNum = PArpmtCreditMemoNum;
			StringType _PArpmtdType = PArpmtdType;
			BankCodeType _PArpmtBankCode = PArpmtBankCode;
			SiteType _PArpmtdSite = PArpmtdSite;
			ListYesNoType _PAddMode = PAddMode;
			ExchRateType _PArpmtExchRate = PArpmtExchRate;
			DateType _PArpmtRecptDate = PArpmtRecptDate;
			CurrCodeType _PCustCurrCode = PCustCurrCode;
			ListYesNoType _PReApp = PReApp;
			LongListType _POpenType = POpenType;
			AmountType _PDerPayAmtRem = PDerPayAmtRem;
			AmountType _PDerForAmtRem = PDerForAmtRem;
			AmountType _PDerDomAmtRem = PDerDomAmtRem;
			InvNumType _PArpmtdInvNum = PArpmtdInvNum;
			ExchRateType _PArpmtdExchRate = PArpmtdExchRate;
			ListYesNoType _PUpdateRate = PUpdateRate;
			AcctType _PArpmtdDepositAcct = PArpmtdDepositAcct;
			UnitCode1Type _PArpmtdDepositAcctUnit1 = PArpmtdDepositAcctUnit1;
			UnitCode2Type _PArpmtdDepositAcctUnit2 = PArpmtdDepositAcctUnit2;
			UnitCode3Type _PArpmtdDepositAcctUnit3 = PArpmtdDepositAcctUnit3;
			UnitCode4Type _PArpmtdDepositAcctUnit4 = PArpmtdDepositAcctUnit4;
			AmountType _PArpmtdForAmtApplied = PArpmtdForAmtApplied;
			AmountType _PArpmtdDomAmtApplied = PArpmtdDomAmtApplied;
			InfobarType _Infobar = Infobar;
			ListYesNoType _PArpmtdDepositIsControl = PArpmtdDepositIsControl;
			CurrCodeType _PArpmtPaymentCurrCode = PArpmtPaymentCurrCode;
			ExchRateType _PArpmtPaymentExchRate = PArpmtPaymentExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdChgArpmtdTypeSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtCustNum", _PArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtCheckNum", _PArpmtCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtCreditMemoNum", _PArpmtCreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdType", _PArpmtdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtBankCode", _PArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdSite", _PArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddMode", _PAddMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtExchRate", _PArpmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtRecptDate", _PArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustCurrCode", _PCustCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReApp", _PReApp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenType", _POpenType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDerPayAmtRem", _PDerPayAmtRem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDerForAmtRem", _PDerForAmtRem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDerDomAmtRem", _PDerDomAmtRem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdInvNum", _PArpmtdInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdExchRate", _PArpmtdExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUpdateRate", _PUpdateRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDepositAcct", _PArpmtdDepositAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDepositAcctUnit1", _PArpmtdDepositAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDepositAcctUnit2", _PArpmtdDepositAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDepositAcctUnit3", _PArpmtdDepositAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDepositAcctUnit4", _PArpmtdDepositAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdForAmtApplied", _PArpmtdForAmtApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDomAmtApplied", _PArpmtdDomAmtApplied, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDepositIsControl", _PArpmtdDepositIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtPaymentCurrCode", _PArpmtPaymentCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtPaymentExchRate", _PArpmtPaymentExchRate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PArpmtdInvNum = _PArpmtdInvNum;
				PArpmtdExchRate = _PArpmtdExchRate;
				PUpdateRate = _PUpdateRate;
				PArpmtdDepositAcct = _PArpmtdDepositAcct;
				PArpmtdDepositAcctUnit1 = _PArpmtdDepositAcctUnit1;
				PArpmtdDepositAcctUnit2 = _PArpmtdDepositAcctUnit2;
				PArpmtdDepositAcctUnit3 = _PArpmtdDepositAcctUnit3;
				PArpmtdDepositAcctUnit4 = _PArpmtdDepositAcctUnit4;
				PArpmtdForAmtApplied = _PArpmtdForAmtApplied;
				PArpmtdDomAmtApplied = _PArpmtdDomAmtApplied;
				Infobar = _Infobar;
				PArpmtdDepositIsControl = _PArpmtdDepositIsControl;
				
				return (Severity, PArpmtdInvNum, PArpmtdExchRate, PUpdateRate, PArpmtdDepositAcct, PArpmtdDepositAcctUnit1, PArpmtdDepositAcctUnit2, PArpmtdDepositAcctUnit3, PArpmtdDepositAcctUnit4, PArpmtdForAmtApplied, PArpmtdDomAmtApplied, Infobar, PArpmtdDepositIsControl);
			}
		}
	}
}
