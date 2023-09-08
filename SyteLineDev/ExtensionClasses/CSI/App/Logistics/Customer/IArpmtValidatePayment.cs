//PROJECT NAME: Logistics
//CLASS NAME: IArpmtValidatePayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArpmtValidatePayment
	{
		(int? ReturnCode, string PBankCode,
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
		decimal? PaymentExchRate = null);
	}
}

