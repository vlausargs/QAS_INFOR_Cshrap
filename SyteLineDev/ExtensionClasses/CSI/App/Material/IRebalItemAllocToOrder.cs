//PROJECT NAME: Material
//CLASS NAME: IRebalItemAllocToOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IRebalItemAllocToOrder
	{
		(int? ReturnCode, int? CoitemCount) RebalItemAllocToOrderSp(int? CoitemCount,
		string StartingItem = null,
		string EndingItem = null,
		string StartingWhse = null,
		string EndingWhse = null);
	}
}

