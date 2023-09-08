//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ItemDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ItemDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemDetailSp(string MaterialStatus = "AOS",
			string Source = "PMT",
			string MaterialType = "MTFO",
			string ABCCode = "ABC",
			int? Stocked = 0,
			int? NotStocked = 0,
			int? DisplayStockroomLocations = 0,
			int? DisplayVendorsfortheItems = 0,
			int? DisplayCustomersforItems = 0,
			int? PrintZeroQtyOnHandItems = 0,
			int? PrintCost = 0,
			int? PrintPrice = 0,
			int? DisplayHeader = 0,
			string WarehouseStarting = null,
			string WarehouseEnding = null,
			string ItemStarting = null,
			string ItemEnding = null,
			string ProductCodeStarting = null,
			string ProductCodeEnding = null,
			string ComplianceProgramId = null,
			string ComplianceStatus = null,
			string pSite = null);
	}
}

