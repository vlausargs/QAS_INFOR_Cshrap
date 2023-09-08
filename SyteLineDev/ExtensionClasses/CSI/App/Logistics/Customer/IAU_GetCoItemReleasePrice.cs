//PROJECT NAME: Logistics
//CLASS NAME: IAU_GetCoItemReleasePrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IAU_GetCoItemReleasePrice
	{
		(int? ReturnCode,
			decimal? PriceConv,
			string Infobar) AU_GetCoItemReleasePriceSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			decimal? PriceConv,
			string Infobar);
	}
}

