//PROJECT NAME: Logistics
//CLASS NAME: IValidateCOConsignValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateCOConsignValues
	{
		(int? ReturnCode, int? ConsignableOrder,
		string Infobar) ValidateCOConsignValuesSp(string CustNum,
		int? CustSeq,
		string Whse,
		int? Consignment,
		string CoNum,
		int? ConsignableOrder,
		string Infobar);
	}
}

