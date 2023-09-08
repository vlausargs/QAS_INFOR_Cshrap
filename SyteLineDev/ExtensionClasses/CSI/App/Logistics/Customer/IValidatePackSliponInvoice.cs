//PROJECT NAME: Logistics
//CLASS NAME: IValidatePackSliponInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidatePackSliponInvoice
	{
		(int? ReturnCode, string Infobar) ValidatePackSliponInvoiceSp(string CustNum,
		int? PrintPackInv,
		string Infobar,
		string PSite = null);
	}
}

