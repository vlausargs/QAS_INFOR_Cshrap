//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_MyPurchaseOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_MyPurchaseOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Homepage_MyPurchaseOrdersSp(string Buyer = null,
			DateTime? Date = null,
			string DateType = "D",
			string TakenBy = null,
			string Salesperson = null,
			int? OnlyCo = 0,
			string ProjMgr = null,
			int? OnlyProj = 0);
	}
}

