//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_MyCustomerOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_MyCustomerOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_MyCustomerOrdersSp(string TakenBy,
			DateTime? Date,
			string DateType = "D",
			string Salesperson = null,
			string ProjMgr = null,
			int? OnlyProj = 0);
	}
}

