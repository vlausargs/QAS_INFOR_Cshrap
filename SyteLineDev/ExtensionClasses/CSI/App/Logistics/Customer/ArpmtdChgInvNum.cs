//PROJECT NAME: Logistics
//CLASS NAME: ArpmtdChgInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtdChgInvNum : IArpmtdChgInvNum
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtdChgInvNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PDerTransctionCurrCode,
		string PArpmtdApplyCustNum,
		string PApplCustName,
		int? PFixedEuro,
		string PArpmtdCoNum,
		string PArpmtdDoNum,
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
		decimal? DfltTax1Val,
		decimal? DfltTax2Val,
		decimal? PArpmtdShipmentId,
		int? PArpmtdDiscIsControl,
		int? PFixedRate,
		string Infobar) ArpmtdChgInvNumSp(string PArpmtdSite,
		string PArpmtdInvNum,
		string PArpmtCustNum,
		string PBankCurrCode,
		string PDerTransctionCurrCode,
		int? PAddMode,
		int? PReApp,
		string POpenType,
		string PArpmtdType,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		decimal? PForAmtRem,
		decimal? PAllowAmt,
		string PArpmtdApplyCustNum,
		string PApplCustName,
		int? PFixedEuro,
		string PArpmtdCoNum,
		string PArpmtdDoNum,
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
		decimal? DfltTax1Val,
		decimal? DfltTax1Var,
		decimal? DfltTax2Val,
		decimal? DfltTax2Var,
		decimal? PArpmtdShipmentId,
		int? PArpmtdDiscIsControl,
		string Infobar,
		string PArpmtBankCode = null,
		string PArpmtPaymentCurrCode = null,
		decimal? PArpmtPaymentExchRate = null,
		int? PFixedRate = null)
		{
			SiteType _PArpmtdSite = PArpmtdSite;
			InvNumType _PArpmtdInvNum = PArpmtdInvNum;
			CustNumType _PArpmtCustNum = PArpmtCustNum;
			CurrCodeType _PBankCurrCode = PBankCurrCode;
			CurrCodeType _PDerTransctionCurrCode = PDerTransctionCurrCode;
			FlagNyType _PAddMode = PAddMode;
			FlagNyType _PReApp = PReApp;
			LongListType _POpenType = POpenType;
			StringType _PArpmtdType = PArpmtdType;
			ExchRateType _PArpmtExchRate = PArpmtExchRate;
			DateType _PArpmtRecptDate = PArpmtRecptDate;
			AmountType _PForAmtRem = PForAmtRem;
			AmountType _PAllowAmt = PAllowAmt;
			CustNumType _PArpmtdApplyCustNum = PArpmtdApplyCustNum;
			NameType _PApplCustName = PApplCustName;
			Flag _PFixedEuro = PFixedEuro;
			CoNumType _PArpmtdCoNum = PArpmtdCoNum;
			DoNumType _PArpmtdDoNum = PArpmtdDoNum;
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
			AmountType _DfltTax1Val = DfltTax1Val;
			AmountType _DfltTax1Var = DfltTax1Var;
			AmountType _DfltTax2Val = DfltTax2Val;
			AmountType _DfltTax2Var = DfltTax2Var;
			ShipmentIDType _PArpmtdShipmentId = PArpmtdShipmentId;
			ListYesNoType _PArpmtdDiscIsControl = PArpmtdDiscIsControl;
			InfobarType _Infobar = Infobar;
			BankCodeType _PArpmtBankCode = PArpmtBankCode;
			CurrCodeType _PArpmtPaymentCurrCode = PArpmtPaymentCurrCode;
			ExchRateType _PArpmtPaymentExchRate = PArpmtPaymentExchRate;
			FlagNyType _PFixedRate = PFixedRate;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdChgInvNumSp";
				
				appDB.AddCommandParameter(cmd, "PArpmtdSite", _PArpmtdSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdInvNum", _PArpmtdInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtCustNum", _PArpmtCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCurrCode", _PBankCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDerTransctionCurrCode", _PDerTransctionCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAddMode", _PAddMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PReApp", _PReApp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POpenType", _POpenType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdType", _PArpmtdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtExchRate", _PArpmtExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtRecptDate", _PArpmtRecptDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PForAmtRem", _PForAmtRem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAllowAmt", _PAllowAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdApplyCustNum", _PArpmtdApplyCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PApplCustName", _PApplCustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFixedEuro", _PFixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdCoNum", _PArpmtdCoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDoNum", _PArpmtdDoNum, ParameterDirection.InputOutput);
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
				appDB.AddCommandParameter(cmd, "DfltTax1Val", _DfltTax1Val, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DfltTax1Var", _DfltTax1Var, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DfltTax2Val", _DfltTax2Val, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DfltTax2Var", _DfltTax2Var, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtdShipmentId", _PArpmtdShipmentId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtdDiscIsControl", _PArpmtdDiscIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArpmtBankCode", _PArpmtBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtPaymentCurrCode", _PArpmtPaymentCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArpmtPaymentExchRate", _PArpmtPaymentExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.InputOutput);

				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDerTransctionCurrCode = _PDerTransctionCurrCode;
				PArpmtdApplyCustNum = _PArpmtdApplyCustNum;
				PApplCustName = _PApplCustName;
				PFixedEuro = _PFixedEuro;
				PArpmtdCoNum = _PArpmtdCoNum;
				PArpmtdDoNum = _PArpmtdDoNum;
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
				DfltTax1Val = _DfltTax1Val;
				DfltTax2Val = _DfltTax2Val;
				PArpmtdShipmentId = _PArpmtdShipmentId;
				PArpmtdDiscIsControl = _PArpmtdDiscIsControl;
				PFixedRate = _PFixedRate;
				Infobar = _Infobar;
				
				return (Severity, PDerTransctionCurrCode, PArpmtdApplyCustNum, PApplCustName, PFixedEuro, PArpmtdCoNum, PArpmtdDoNum, PArpmtdExchRate, PUpdateRate, PArpmtdForAmtApplied, PArpmtdForDiscAmt, PArpmtdDomAmtApplied, PArpmtdDomDiscAmt, PArpmtdDiscAcct, PArpmtdDiscAcctUnit1, PArpmtdDiscAcctUnit2, PArpmtdDiscAcctUnit3, PArpmtdDiscAcctUnit4, DfltTax1Val, DfltTax2Val, PArpmtdShipmentId, PArpmtdDiscIsControl, PFixedRate,Infobar);
			}
		}
	}
}
