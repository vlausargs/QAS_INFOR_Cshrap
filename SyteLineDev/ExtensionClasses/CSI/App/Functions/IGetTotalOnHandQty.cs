//PROJECT NAME: Data
//CLASS NAME: IGetTotalOnHandQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetTotalOnHandQty
	{
		(int? ReturnCode,
			decimal? TotOnHdQty,
			decimal? TotResvCO) GetTotalOnHandQtySp(
			string SiteGroup,
			string Item,
			decimal? TotOnHdQty,
			decimal? TotResvCO);
	}
}

