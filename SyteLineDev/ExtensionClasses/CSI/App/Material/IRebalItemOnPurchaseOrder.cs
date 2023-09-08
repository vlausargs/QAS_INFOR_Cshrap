//PROJECT NAME: Material
//CLASS NAME: IRebalItemOnPurchaseOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRebalItemOnPurchaseOrder
	{
		(int? ReturnCode, string Infobar) RebalItemOnPurchaseOrderSp(string Infobar,
		string StartingItem = null,
		string EndingItem = null,
		string StartingWhse = null,
		string EndingWhse = null);
	}
}

