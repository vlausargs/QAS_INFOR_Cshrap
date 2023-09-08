//PROJECT NAME: Logistics
//CLASS NAME: IGenerateOrderPickListCo14haD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGenerateOrderPickListCo14haD
	{
		(int? ReturnCode,
			string Infobar) GenerateOrderPickListCo14haDSp(
			int? PBarLoc,
			int? PPostMatlIssues,
			int? PPrintBc,
			string PPrItemCi,
			int? PPrPlanItemMatl,
			int? PPrSerialNumbers,
			string PTtCoitem_Pickwarn,
			int? PCoitemCoLine,
			string PCoitemCoNum,
			int? PCoitemCoRelease,
			string PCoitemCustItem,
			DateTime? PCoitemDueDate,
			string PCoitemFeatStr,
			string PCoItemItem,
			DateTime? PCoitemPickDate,
			decimal? PCoitemQtyOrdered,
			Guid? PCoitemRowPointer,
			string PDescription,
			int? PCoitemNoteExistsFlag,
			string PManufacturerId,
			string PManufacturerItem,
			DateTime? PCoOrderDate,
			Guid? PCoRowPointer,
			string PInvparmsFbomBlank,
			string PInvparmsFeatTempl,
			int? PCoparmsPickwarnCo,
			string PItemFeatTempl,
			string PItemJob,
			int? PItemLotTracked,
			int? PItemPlanFlag,
			Guid? PItemRowPointer,
			int? PItemSerialTracked,
			int? PItemSuffix,
			string PItemUM,
			Guid? PSessionId,
			string PSWorkkey,
			string PSLoc,
			string PSLot,
			decimal? PTcQtudOnHand1,
			decimal? PTcQtuRequired1,
			decimal? PTcQtuRsvdQty1,
			decimal? PTcQtuShort1,
			decimal? PTcQtuSQty1,
			Guid? PItemlocRowPointer,
			Guid? PLotLocRowPointer,
			int? PFirstLoc,
			string Infobar);
	}
}

