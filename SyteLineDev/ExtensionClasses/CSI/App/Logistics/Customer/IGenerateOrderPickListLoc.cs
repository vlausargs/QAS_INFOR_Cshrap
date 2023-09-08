//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickListLoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickListLoc
	{
		(int? ReturnCode,
			string PItemlocLoc,
			decimal? PItemlocQtyOnHand,
			decimal? PItemlocQtyRsvd,
			Guid? PItemlocRowPointer,
			string PLotLocLot,
			decimal? PLotLocQtyOnHand,
			decimal? PLotLocQtyRsvd,
			Guid? PLotLocRowPointer,
			Guid? PLotRowPointer,
			decimal? PRsvdInvQtyRsvd,
			Guid? PRsvdInvRowPointer,
			decimal? PRsvdInvRsvdNum,
			int? PTMoreResv,
			int? PTRsvdFlg) GenerateOrderPickListLocSp(
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemItem,
			string PCoitemWhse,
			string PItemIssueBy,
			int? PItemLotTracked,
			int? PPostMatlIssues,
			string PItemlocLoc,
			decimal? PItemlocQtyOnHand,
			decimal? PItemlocQtyRsvd,
			Guid? PItemlocRowPointer,
			string PLotLocLot,
			decimal? PLotLocQtyOnHand,
			decimal? PLotLocQtyRsvd,
			Guid? PLotLocRowPointer,
			Guid? PLotRowPointer,
			decimal? PRsvdInvQtyRsvd,
			Guid? PRsvdInvRowPointer,
			decimal? PRsvdInvRsvdNum,
			int? PTMoreResv,
			int? PTRsvdFlg);
	}
}

