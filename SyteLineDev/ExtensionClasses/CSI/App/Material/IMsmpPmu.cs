//PROJECT NAME: Material
//CLASS NAME: IMsmpPmu.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMsmpPmu
	{
		(int? ReturnCode,
			decimal? ProfitMarkup,
			string Infobar) MsmpPmuSp(
			string Item,
			DateTime? EffDate,
			string Pricecode,
			decimal? QtyMoved,
			decimal? TotalCost,
			decimal? TotalOrderedQty,
			decimal? ProfitMarkup,
			string Infobar,
			string FromSite = null,
			string ToSite = null,
			decimal? TransferExchRate = null);
	}
}

