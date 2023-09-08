//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_PurchaseOrderByVendor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_PurchaseOrderByVendor
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_PurchaseOrderByVendorSp(int? Count = 5);
	}
}

