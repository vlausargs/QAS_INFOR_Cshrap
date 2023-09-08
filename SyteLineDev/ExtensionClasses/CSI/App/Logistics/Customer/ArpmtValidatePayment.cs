//PROJECT NAME: Logistics
//CLASS NAME: ArpmtValidatePayment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtValidatePayment : IArpmtValidatePayment
	{
		readonly IApplicationDB appDB;
		
		
		public ArpmtValidatePayment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PBankCode,
		DateTime? PReceiptDate,
		string PPayCurrCode,
		string POpenType,
		string POpenCode,
		int? POpenDraft,
		decimal? PCheckAmt,
		decimal? PExchRate,
		DateTime? PDueDate,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
		decimal? PaymentCheckAmt,
		decimal? PaymentExchRate) ArpmtValidatePaymentSp(string PCustNum,
		int? PCheckNum,
		string PType,
		string PBankCode,
		DateTime? PReceiptDate,
		string PPayCurrCode,
		string POpenType,
		string POpenCode,
		int? POpenDraft,
		decimal? PCheckAmt,
		decimal? PExchRate,
		DateTime? PDueDate,
		string Infobar,
		string PromptMsg,
		string PromptButtons,
		string CreditMemoNum,
		decimal? PaymentCheckAmt = null,
		decimal? PaymentExchRate = null)
		{
			CustNumType _PCustNum = PCustNum;
			ArCheckNumType _PCheckNum = PCheckNum;
			ArpmtTypeType _PType = PType;
			BankCodeType _PBankCode = PBankCode;
			DateType _PReceiptDate = PReceiptDate;
			CurrCodeType _PPayCurrCode = PPayCurrCode;
			LongListType _POpenType = POpenType;
			LongListType _POpenCode = POpenCode;
			FlagNyType _POpenDraft = POpenDraft;
			AmountType _PCheckAmt = PCheckAmt;
			ExchRateType _PExchRate = PExchRate;
			DateType _PDueDate = PDueDate;
			InfobarType _Infobar = Infobar;
			InfobarType _PromptMsg = PromptMsg;
			InfobarType _PromptButtons = PromptButtons;
			InvNumType _CreditMemoNum = CreditMemoNum;
			AmountType _PaymentCheckAmt = PaymentCheckAmt;
			ExchRateType _PaymentExchRate = PaymentExchRate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ArpmtValidatePaymentSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PReceiptDate", _PReceiptDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PPayCurrCode", _PPayCurrCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POpenType", _POpenType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POpenCode", _POpenCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POpenDraft", _POpenDraft, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCheckAmt", _PCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CreditMemoNum", _CreditMemoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaymentCheckAmt", _PaymentCheckAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PaymentExchRate", _PaymentExchRate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PBankCode = _PBankCode;
				PReceiptDate = _PReceiptDate;
				PPayCurrCode = _PPayCurrCode;
				POpenType = _POpenType;
				POpenCode = _POpenCode;
				POpenDraft = _POpenDraft;
				PCheckAmt = _PCheckAmt;
				PExchRate = _PExchRate;
				PDueDate = _PDueDate;
				Infobar = _Infobar;
				PromptMsg = _PromptMsg;
				PromptButtons = _PromptButtons;
				PaymentCheckAmt = _PaymentCheckAmt;
				PaymentExchRate = _PaymentExchRate;
				
				return (Severity, PBankCode, PReceiptDate, PPayCurrCode, POpenType, POpenCode, POpenDraft, PCheckAmt, PExchRate, PDueDate, Infobar, PromptMsg, PromptButtons, PaymentCheckAmt, PaymentExchRate);
			}
		}
	}
}
