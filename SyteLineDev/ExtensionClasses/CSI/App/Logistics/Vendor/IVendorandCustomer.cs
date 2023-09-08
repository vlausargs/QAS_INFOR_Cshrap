//PROJECT NAME: Logistics
//CLASS NAME: IVendorandCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVendorandCustomer
	{
		(ICollectionLoadResponse Data, int? ReturnCode) VendorandCustomerSp(string InputVendCustNum);
	}
}

