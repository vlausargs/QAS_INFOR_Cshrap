//PROJECT NAME: Logistics
//CLASS NAME: ICoCustSeqValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoCustSeqValid
	{
		(int? ReturnCode, string ShipToAddress,
		string Whse,
		string ShipCode,
		int? ShipPartial,
		int? ShipEarly,
		string Slsman,
		string TaxCode1,
		string TaxCode2,
		string ShipToContact,
		string ShipToPhone,
		string Infobar,
		int? ShipHold) CoCustSeqValidSp(string CustNum,
		int? CustSeq,
		string ShipToAddress,
		string Whse,
		string ShipCode,
		int? ShipPartial,
		int? ShipEarly,
		string Slsman,
		string TaxCode1,
		string TaxCode2,
		string ShipToContact,
		string ShipToPhone,
		string Infobar,
		int? ShipHold);
	}
}

