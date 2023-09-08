//PROJECT NAME: Data
//CLASS NAME: IInventoryConstoCustOrderLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInventoryConstoCustOrderLine
	{
		(int? ReturnCode,
			Guid? RowPointer,
			string Infobar) InventoryConstoCustOrderLineSp(
			string pCoNum,
			int? pCoLine,
			string pStat,
			string pItem,
			decimal? pQtyOrderedConv,
			string pUM,
			string CoCustNum,
			int? CoCustSeq,
			string CoShipFromSite = null,
			decimal? ItemPriceConv = null,
			decimal? ItemPrice = null,
			DateTime? ColProjectedDate = null,
			DateTime? ColDueDate = null,
			DateTime? ColPromiseDate = null,
			Guid? RowPointer = null,
			string Infobar = null);
	}
}

