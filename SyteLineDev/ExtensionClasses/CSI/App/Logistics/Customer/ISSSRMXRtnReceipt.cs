//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXRtnReceipt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXRtnReceipt
	{
		(int? ReturnCode,
			decimal? MatltrackNum,
			string Infobar) SSSRMXRtnReceiptSp(
			string Whse,
			string Item,
			string Loc,
			string Lot,
			decimal? Qty,
			string RmaNum,
			int? RmaLine,
			DateTime? TransDate,
			string ReasonCode,
			string VendNum,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			int? Reverse,
			string JourRec,
			string JourRecPrefix,
			string JourRecHd,
			string InvvendMatlAcct,
			string InvvendMatlAcctUnit1,
			string InvvendMatlAcctUnit2,
			string InvvendMatlAcctUnit3,
			string InvvendMatlAcctUnit4,
			string InvvendLbrAcct,
			string InvvendLbrAcctUnit1,
			string InvvendLbrAcctUnit2,
			string InvvendLbrAcctUnit3,
			string InvvendLbrAcctUnit4,
			string InvvendFovAcct,
			string InvvendFovAcctUnit1,
			string InvvendFovAcctUnit2,
			string InvvendFovAcctUnit3,
			string InvvendFovAcctUnit4,
			string InvvendVovAcct,
			string InvvendVovAcctUnit1,
			string InvvendVovAcctUnit2,
			string InvvendVovAcctUnit3,
			string InvvendVovAcctUnit4,
			string InvvendOutAcct,
			string InvvendOutAcctUnit1,
			string InvvendOutAcctUnit2,
			string InvvendOutAcctUnit3,
			string InvvendOutAcctUnit4,
			decimal? MatltrackNum,
			string Infobar,
			int? TmpSer = 0,
			int? UpdateCGS = 0,
			string Workkey = null,
			string ProcessType = "V",
			decimal? MatlTranAmtMatlAmt = 0,
			decimal? MatltranAmtLbrAmt = 0,
			decimal? MatltranAmtFovhdAmt = 0,
			decimal? MatltranAmtVovhdAmt = 0,
			decimal? MatlTranAmtOutAmt = 0,
			Guid? RmaitemRowPointer = null);
	}
}

