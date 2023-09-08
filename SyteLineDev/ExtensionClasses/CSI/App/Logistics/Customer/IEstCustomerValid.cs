//PROJECT NAME: Logistics
//CLASS NAME: IEstCustomerValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEstCustomerValid
	{
		(int? ReturnCode, int? CustSeq,
		string Contact,
		string Phone,
		string Slsman,
		string CustType,
		string TermsCode,
		string Pricecode,
		string TaxCode1,
		string TaxCode2,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		int? UseExchRate,
		int? ShipEarly,
		int? ShipPartial,
		string ShipCode,
		string BillToAddress,
		string ShipToAddress,
		string PCur0AmtFormat,
		string Infobar) EstCustomerValidSp(string CustNum,
		int? CustSeq,
		string Contact,
		string Phone,
		string Slsman,
		string CustType,
		string TermsCode,
		string Pricecode,
		string TaxCode1,
		string TaxCode2,
		string CurrCode,
		decimal? ExchRate,
		int? CurrRateIsFixed,
		int? UseExchRate,
		int? ShipEarly,
		int? ShipPartial,
		string ShipCode,
		string BillToAddress,
		string ShipToAddress,
		string PCur0AmtFormat,
		string Infobar);
	}
}

