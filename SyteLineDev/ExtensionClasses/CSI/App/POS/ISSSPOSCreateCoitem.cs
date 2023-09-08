//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCreateCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCreateCoitem
	{
		(int? ReturnCode,
			string Infobar) SSSPOSCreateCoitemSp(
			string TCoNum,
			string POSNum,
			string POSMCustNum,
			int? POSMMatlTransNum,
			Guid? PosmMatlRowPointer,
			string POSMMatlItem,
			string POSMMatlItemDescription,
			string POSMMatlUM,
			string POSMMatlWhse,
			decimal? POSMMatlDisc,
			decimal? POSMMatlQtyOrdered,
			decimal? POSMMatlQtyOrderedConv,
			decimal? POSMMatlPrice,
			decimal? POSMMatlPriceConv,
			string POSMMatlTaxCode1,
			string POSMMatlTaxCode2,
			string Infobar);
	}
}

