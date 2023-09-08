//PROJECT NAME: Data
//CLASS NAME: ISyncCoFromPo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISyncCoFromPo
	{
		(int? ReturnCode,
			string Infobar) SyncCoFromPoSp(
			string SourceSite,
			string DemandingSite,
			string DemandingPO,
			int? UpdateHeader = 0,
			int? DeleteLine = 0,
			int? InsertLine = null,
			int? BlanketLine = 0,
			DateTime? PoOrderDate = null,
			int? PoItemsPoLine = null,
			int? PoItemsPoRelease = null,
			string PoItemsDescription = null,
			string PoItemDropShipNum = null,
			int? PoItemDropSeq = null,
			DateTime? PoItemsDueDate = null,
			string PoItems = null,
			decimal? PoItemsPlanCost = null,
			decimal? PoItemsPlanCostConv = null,
			decimal? PoItemsQtyOrderedConv = null,
			string PoItemsStat = null,
			string PoItemsTransNat = null,
			string PoItemsTransNat2 = null,
			string PoItemsUM = null,
			string PoItemsWhse = null,
			DateTime? PoBlnEffDate = null,
			DateTime? PoBlnExpDate = null,
			string PoBlnVendItem = null,
			string PoHeaderDropShipNum = null,
			int? PoHeaderDropSeq = null,
			string PoItemShipAddr = null,
			string Infobar = null);
	}
}

