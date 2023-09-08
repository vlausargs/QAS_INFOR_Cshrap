//PROJECT NAME: Logistics
//CLASS NAME: IArinvCustomerInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArinvCustomerInfo
	{
		(int? ReturnCode, DateTime? DueDate,
		string CustType,
		string TermsCode,
		string PayType,
		string TaxCode1,
		string TaxCode2,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		int? UseExchRate,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Infobar,
		int? IsControl) ArinvCustomerInfoSp(string CustNum,
		string ArinvType,
		DateTime? InvoiceDate,
		DateTime? DueDate,
		string CustType,
		string TermsCode,
		string PayType,
		string TaxCode1,
		string TaxCode2,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		int? UseExchRate,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string Infobar,
		string App_To_Inv_Num,
		int? IsControl);
	}
}

