//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickListDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickListDetail
	{
		(int? ReturnCode,
			decimal? PRsvdInvQtyRsvd,
			Guid? PRsvdInvRowPointer,
			decimal? PRsvdInvRsvdNum,
			Guid? PItemlocRowPointer,
			Guid? PLotLocRowPointer,
			int? PTMoreResv,
			string PSLoc,
			string PSLot,
			decimal? PSQty,
			decimal? PTcQtudOnHand,
			decimal? PTcQtuRequired,
			decimal? PTcQtuRsvdQty,
			decimal? PTcQtuShort,
			string InfoBar) GenerateOrderPickListDetailSp(
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemItem,
			string PCoitemWhse,
			string PItemIssueBy,
			string PItemItem,
			int? PItemLotTracked,
			int? PItemSerialTracked,
			int? PItemTaxFreeMatl,
			string PItemlocLoc,
			decimal? PItemlocQtyOnHand,
			decimal? PItemlocQtyRsvd,
			string PLotLocLot,
			decimal? PLotLocQtyOnHand,
			decimal? PLotLocQtyRsvd,
			decimal? PRsvdInvQtyRsvd,
			Guid? PRsvdInvRowPointer,
			decimal? PRsvdInvRsvdNum,
			Guid? PSessionId,
			DateTime? PTransDate,
			int? PTRsvdFlg,
			int? PPostMatlIssues,
			Guid? PItemlocRowPointer,
			Guid? PLotLocRowPointer,
			int? PTMoreResv,
			string PSLoc,
			string PSLot,
			decimal? PSQty,
			decimal? PTcQtudOnHand,
			decimal? PTcQtuRequired,
			decimal? PTcQtuRsvdQty,
			decimal? PTcQtuShort,
			string InfoBar);
	}
}

