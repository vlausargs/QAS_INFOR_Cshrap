//PROJECT NAME: Data
//CLASS NAME: IDistacctTransferAccountsI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDistacctTransferAccountsI
	{
		(int? ReturnCode,
			string Infobar) DistacctTransferAccountsISp(
			string DistacctWhse,
			string DistacctProductCode,
			string ItemItem,
			string ItemProductCode,
			string LocType,
			int? ItemlocFound,
			decimal? ItemMatlCost = 0,
			decimal? ItemLbrCost = 0,
			decimal? ItemFovhdCost = 0,
			decimal? ItemVovhdCost = 0,
			decimal? ItemOutCost = 0,
			int? ItemLotTracked = 0,
			string Infobar = null,
			string ItemwhseWhse = null,
			int? CostItemAtWhse = null);
	}
}

