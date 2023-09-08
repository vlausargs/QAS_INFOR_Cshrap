//PROJECT NAME: Data
//CLASS NAME: IRepCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepCoitem
	{
		int? RepCoitemSp(
			string ShipSite,
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string Item,
			string CustItem,
			string FeatStr,
			string Stat,
			DateTime? PromiseDate,
			string Pricecode,
			string UM,
			string Description,
			string CoOrigSite,
			decimal? QtyOrdered,
			decimal? Disc,
			decimal? Price,
			DateTime? DueDate,
			int? Reprice,
			string CustNum,
			int? CustSeq,
			DateTime? ReleaseDate,
			string Whse,
			string CommCode,
			string TransNat,
			string ProcessInd,
			string Delterm,
			decimal? SupplQtyConvFactor,
			string Origin,
			int? ConsNum,
			string TaxCode1,
			string TaxCode2,
			decimal? ExportValue,
			string EcCode,
			decimal? QtyOrderedConv,
			decimal? PriceConv,
			string CoCustNum,
			string Transport,
			string RefType,
			DateTime? ProjectedDate,
			decimal? QtyShipped,
			decimal? QtyReturned,
			decimal? QtyRsvd,
			decimal? QtyReady,
			decimal? QtyPacked,
			int? Packed,
			DateTime? ShipDate,
			decimal? QtyInvoiced,
			decimal? UnitWeight,
			string Mode,
			int? SyncReqd,
			string TransNat2,
			int? PlanOnSave,
			int? ApsMode,
			int? EdiInOrderPSp,
			string ConfigId,
			int? AllowOverCreditLimit,
			string NonInvAcct,
			string NonInvAcctUnit1,
			string NonInvAcctUnit2,
			string NonInvAcctUnit3,
			string NonInvAcctUnit4,
			string ManufacturerId,
			string ManufacturerItem,
			decimal? PrgBillTot,
			decimal? PrgBillApp,
			int? RepFromTrigger = 0,
			string UETListPairs = null,
			decimal? QtyPicked = null,
			int? InvoiceHold = 0);
	}
}

