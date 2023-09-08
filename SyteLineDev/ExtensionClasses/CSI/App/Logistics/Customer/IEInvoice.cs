//PROJECT NAME: Logistics
//CLASS NAME: IEInvoice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEInvoice
	{
		(int? ReturnCode, string Infobar) EInvoiceSp(string pSite,
		string pCoNum,
		string Infobar);
	}
}

