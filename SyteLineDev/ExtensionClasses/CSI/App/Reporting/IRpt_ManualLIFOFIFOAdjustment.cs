//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ManualLIFOFIFOAdjustment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ManualLIFOFIFOAdjustment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ManualLIFOFIFOAdjustmentSp(string SessionIdChar = null,
		string InvAdjAcct = null,
		string InvAdjAcctDesc = null,
		string ItemlifoItem = null,
		string ItemlifoInvAcct = null,
		string ItemlifoLbrAcct = null,
		string ItemlifoFovhdAcct = null,
		string ItemlifoVovhdAcct = null,
		string ItemlifoOutAcct = null,
		string CostMethod = null,
		decimal? DerLocQtyOnHand = null,
		decimal? DerStackValue = null,
		decimal? DerStackQty = null,
		decimal? AdjustedValue = null,
		decimal? AdjustedQuantity = null,
		string Whse = null,
		int? TaskId = null,
		string pSite = null);
	}
}

