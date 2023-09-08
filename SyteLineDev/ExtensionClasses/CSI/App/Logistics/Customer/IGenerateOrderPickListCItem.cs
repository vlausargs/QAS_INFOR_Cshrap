//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickListCItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickListCItem
	{
		(int? ReturnCode,
			string Infobar) GenerateOrderPickListCItemSp(
			Guid? PSessionID,
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemItem,
			decimal? PCoitemQtyOrdered,
			decimal? PCoitemQtyShipped,
			string PCoitemWhse,
			Guid? PCoitemRowPointer,
			int? PItemLotTracked,
			string PItemUM,
			string PItemlocLoc,
			Guid? PItemlocRowPointer,
			int? PListByLoc,
			string PLotLocLot,
			Guid? PLotLocRowPointer,
			string Infobar);
	}
}

