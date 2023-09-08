//PROJECT NAME: Logistics
//CLASS NAME: IAppmtValidateOpenPayment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtValidateOpenPayment
	{
		(int? ReturnCode, int? POpenPay,
		decimal? PForCheckAmt,
		decimal? PDomCheckAmt,
		decimal? PExchRate,
		DateTime? PCheckDate,
		string PRef,
		string Infobar,
		string PForCurr) AppmtValidateOpenPaymentSp(string PVendNum,
		int? PCheckNum,
		int? POpenPay,
		decimal? PForCheckAmt,
		decimal? PDomCheckAmt,
		decimal? PExchRate,
		DateTime? PCheckDate,
		string PRef,
		string Infobar,
		string PBankCode,
		string PPayType,
		string PForCurr = null);
	}
}

