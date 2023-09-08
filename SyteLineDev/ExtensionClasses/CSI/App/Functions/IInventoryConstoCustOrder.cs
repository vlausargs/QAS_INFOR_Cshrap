//PROJECT NAME: Data
//CLASS NAME: IInventoryConstoCustOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInventoryConstoCustOrder
	{
		(int? ReturnCode,
			Guid? RowPointer,
			string Infobar) InventoryConstoCustOrderSp(
			string pOrderType,
			string pStat,
			string CoCustNum,
			int? CoCustSeq,
			DateTime? pOrderDate,
			string pWhse,
			int? pCoConsignment = 0,
			Guid? RowPointer = null,
			string Infobar = null);
	}
}

