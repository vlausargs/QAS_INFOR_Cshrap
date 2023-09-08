//PROJECT NAME: Logistics
//CLASS NAME: IRmaReplUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaReplUpdate
	{
		(int? ReturnCode, string Infobar) RmaReplUpdateSp(string PRmaNum,
		int? PRmaLine,
		string PItem,
		string PItemDesc,
		string PCustItem,
		decimal? PQtyToReturnConv,
		string PItemUM,
		decimal? PUnitPriceConv,
		string PCoNum,
		int? PCoLine,
		int? PRepair,
		string PPricecode,
		string PCustNum,
		string Infobar,
		int? IncludeTaxInPrice);
	}
}

