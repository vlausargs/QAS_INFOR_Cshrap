//PROJECT NAME: Data
//CLASS NAME: IRepCoBln.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IRepCoBln
	{
		(int? ReturnCode,
			string Infobar) RepCoBlnSp(
			string CoNum,
			int? CoLine,
			string Item,
			string CustItem,
			string FeatStr,
			decimal? BlanketQty,
			DateTime? EffDate,
			DateTime? ExpDate,
			decimal? ContPrice,
			string Stat,
			DateTime? PromiseDate,
			string Pricecode,
			string UM,
			decimal? BlanketQtyConv,
			decimal? ContPriceConv,
			string ShipSite,
			string Description,
			string ConfigId,
			string NonInvAcct,
			string NonInvAcctUnit1,
			string NonInvAcctUnit2,
			string NonInvAcctUnit3,
			string NonInvAcctUnit4,
			decimal? CostConv,
			string OrigSite,
			string ManufacturerId,
			string ManufacturerItem,
			string Infobar,
			int? RepFromTrigger = 0,
			string UETListPairs = null);
	}
}

