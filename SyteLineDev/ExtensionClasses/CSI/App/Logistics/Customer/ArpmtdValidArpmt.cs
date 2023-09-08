//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtdValidArpmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IArpmtdValidArpmt
	{
		(int? ReturnCode, string BankCurrCode, string PaymentCurrCode, string PayType, int? CheckNum, string CustName, string CustCurrCode, string CustBalMethod, int? CorpCust, DateTime? RecptDate, decimal? ExchRate, decimal? PaymentExchRate, decimal? ForCheckAmt, decimal? DomCheckAmt, decimal? PaymentCheckAmt, decimal? ForAmtBal, decimal? DomAmtBal, decimal? PaymentAmtBal, decimal? ForAmtRem, decimal? DomAmtRem, decimal? PaymentAmtRem, string DefaultType, int? ReApp, string OpenType, int? FixedEuro, int? ChkTransferCash, string PaymentCurrAmtFormat, string CreditMemoNum, string BankAmtFormat, string Infobar) ArpmtdValidArpmtSp(string CustNum,
		string Level,
		string Site,
		string BankCode,
		string BankCurrCode,
		string PaymentCurrCode,
		string PayType,
		int? CheckNum,
		string CustName,
		string CustCurrCode,
		string CustBalMethod,
		int? CorpCust,
		DateTime? RecptDate,
		decimal? ExchRate,
		decimal? PaymentExchRate,
		decimal? ForCheckAmt,
		decimal? DomCheckAmt,
		decimal? PaymentCheckAmt,
		decimal? ForAmtBal,
		decimal? DomAmtBal,
		decimal? PaymentAmtBal,
		decimal? ForAmtRem,
		decimal? DomAmtRem,
		decimal? PaymentAmtRem,
		string DefaultType,
		int? ReApp,
		string OpenType,
		int? FixedEuro,
		int? ChkTransferCash,
		string PaymentCurrAmtFormat,
		string CreditMemoNum,
		string BankAmtFormat = null,
		string Infobar = null);
	}
	
	public class ArpmtdValidArpmt : IArpmtdValidArpmt
	{
		readonly IApplicationDB appDB;
		
		public ArpmtdValidArpmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string BankCurrCode, string PaymentCurrCode, string PayType, int? CheckNum, string CustName, string CustCurrCode, string CustBalMethod, int? CorpCust, DateTime? RecptDate, decimal? ExchRate, decimal? PaymentExchRate, decimal? ForCheckAmt, decimal? DomCheckAmt, decimal? PaymentCheckAmt, decimal? ForAmtBal, decimal? DomAmtBal, decimal? PaymentAmtBal, decimal? ForAmtRem, decimal? DomAmtRem, decimal? PaymentAmtRem, string DefaultType, int? ReApp, string OpenType, int? FixedEuro, int? ChkTransferCash, string PaymentCurrAmtFormat, string CreditMemoNum, string BankAmtFormat, string Infobar) ArpmtdValidArpmtSp(string CustNum,
		string Level,
		string Site,
		string BankCode,
		string BankCurrCode,
		string PaymentCurrCode,
		string PayType,
		int? CheckNum,
		string CustName,
		string CustCurrCode,
		string CustBalMethod,
		int? CorpCust,
		DateTime? RecptDate,
		decimal? ExchRate,
		decimal? PaymentExchRate,
		decimal? ForCheckAmt,
		decimal? DomCheckAmt,
		decimal? PaymentCheckAmt,
		decimal? ForAmtBal,
		decimal? DomAmtBal,
		decimal? PaymentAmtBal,
		decimal? ForAmtRem,
		decimal? DomAmtRem,
		decimal? PaymentAmtRem,
		string DefaultType,
		int? ReApp,
		string OpenType,
		int? FixedEuro,
		int? ChkTransferCash,
		string PaymentCurrAmtFormat,
		string CreditMemoNum,
		string BankAmtFormat = null,
		string Infobar = null)
		{
			CustNumType _CustNum = CustNum;
			StringType _Level = Level;
			SiteType _Site = Site;
			BankCodeType _BankCode = BankCode;
			CurrCodeType _BankCurrCode = BankCurrCode;
			CurrCodeType _PaymentCurrCode = PaymentCurrCode;
			ArpmtTypeType _PayType = PayType;
			ArCheckNumType _CheckNum = CheckNum;
			NameType _CustName = CustName;
			CurrCodeType _CustCurrCode = CustCurrCode;
			StringType _CustBalMethod = CustBalMethod;
			FlagNyType _CorpCust = CorpCust;
			DateType _RecptDate = RecptDate;
			ExchRateType _ExchRate = ExchRate;
			ExchRateType _PaymentExchRate = PaymentExchRate;
			AmountType _ForCheckAmt = ForCheckAmt;
			AmountType _DomCheckAmt = DomCheckAmt;
			AmountType _PaymentCheckAmt = PaymentCheckAmt;
			AmountType _ForAmtBal = ForAmtBal;
			AmountType _DomAmtBal = DomAmtBal;
			AmountType _PaymentAmtBal = PaymentAmtBal;
			AmountType _ForAmtRem = ForAmtRem;
			AmountType _DomAmtRem = DomAmtRem;
			AmountType _PaymentAmtRem = PaymentAmtRem;
			StringType _DefaultType = DefaultType;
			FlagNyType _ReApp = ReApp;
			LongListType _OpenType = OpenType;
			FlagNyType _FixedEuro = FixedEuro;
			ListYesNoType _ChkTransferCash = ChkTransferCash;
			InputMaskType _PaymentCurrAmtFormat = PaymentCurrAmtFormat;
			InvNumType _CreditMemoNum = CreditMemoNum;
			InputMaskType _BankAmtFormat = BankAmtFormat;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtdValidArpmtSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCurrCode", _BankCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentCurrCode", _PaymentCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PayType", _PayType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CheckNum", _CheckNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustName", _CustName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustCurrCode", _CustCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustBalMethod", _CustBalMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CorpCust", _CorpCust, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RecptDate", _RecptDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentExchRate", _PaymentExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForCheckAmt", _ForCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomCheckAmt", _DomCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentCheckAmt", _PaymentCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForAmtBal", _ForAmtBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomAmtBal", _DomAmtBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentAmtBal", _PaymentAmtBal, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForAmtRem", _ForAmtRem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomAmtRem", _DomAmtRem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentAmtRem", _PaymentAmtRem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DefaultType", _DefaultType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReApp", _ReApp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OpenType", _OpenType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FixedEuro", _FixedEuro, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ChkTransferCash", _ChkTransferCash, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentCurrAmtFormat", _PaymentCurrAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreditMemoNum", _CreditMemoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BankAmtFormat", _BankAmtFormat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BankCurrCode = _BankCurrCode;
				PaymentCurrCode = _PaymentCurrCode;
				PayType = _PayType;
				CheckNum = _CheckNum;
				CustName = _CustName;
				CustCurrCode = _CustCurrCode;
				CustBalMethod = _CustBalMethod;
				CorpCust = _CorpCust;
				RecptDate = _RecptDate;
				ExchRate = _ExchRate;
				PaymentExchRate = _PaymentExchRate;
				ForCheckAmt = _ForCheckAmt;
				DomCheckAmt = _DomCheckAmt;
				PaymentCheckAmt = _PaymentCheckAmt;
				ForAmtBal = _ForAmtBal;
				DomAmtBal = _DomAmtBal;
				PaymentAmtBal = _PaymentAmtBal;
				ForAmtRem = _ForAmtRem;
				DomAmtRem = _DomAmtRem;
				PaymentAmtRem = _PaymentAmtRem;
				DefaultType = _DefaultType;
				ReApp = _ReApp;
				OpenType = _OpenType;
				FixedEuro = _FixedEuro;
				ChkTransferCash = _ChkTransferCash;
				PaymentCurrAmtFormat = _PaymentCurrAmtFormat;
				CreditMemoNum = _CreditMemoNum;
				BankAmtFormat = _BankAmtFormat;
				Infobar = _Infobar;
				
				return (Severity, BankCurrCode, PaymentCurrCode, PayType, CheckNum, CustName, CustCurrCode, CustBalMethod, CorpCust, RecptDate, ExchRate, PaymentExchRate, ForCheckAmt, DomCheckAmt, PaymentCheckAmt, ForAmtBal, DomAmtBal, PaymentAmtBal, ForAmtRem, DomAmtRem, PaymentAmtRem, DefaultType, ReApp, OpenType, FixedEuro, ChkTransferCash, PaymentCurrAmtFormat, CreditMemoNum, BankAmtFormat, Infobar);
			}
		}
	}
}
