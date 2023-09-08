//PROJECT NAME: Logistics
//CLASS NAME: ICustomerCreditCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerCreditCheck
	{
		(int? ReturnCode, int? pCreditLimitExceeded,
		decimal? pCreditLimit,
		decimal? pCreditLimitBalance,
		string pCurrencyCode,
		int? pOnCreditHold,
		string pCreditHoldReason,
		int? pLCRRequired,
		string Infobar) CustomerCreditCheckSp(string pSite,
		string pCustNum,
		decimal? pAmount,
		int? pCreditLimitExceeded,
		decimal? pCreditLimit,
		decimal? pCreditLimitBalance,
		string pCurrencyCode,
		int? pOnCreditHold,
		string pCreditHoldReason,
		int? pLCRRequired,
		string Infobar);
	}
}

