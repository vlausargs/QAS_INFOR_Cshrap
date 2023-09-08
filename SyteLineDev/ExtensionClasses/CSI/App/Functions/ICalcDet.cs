//PROJECT NAME: Data
//CLASS NAME: ICalcDet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcDet
	{
		(int? ReturnCode,
			decimal? PLbrCost,
			decimal? PMatlCost,
			decimal? PFovhdCost,
			decimal? PVovhdCost,
			decimal? POutCost,
			string Infobar) CalcDetSp(
			Guid? JobRecid,
			decimal? PLbrCost,
			decimal? PMatlCost,
			decimal? PFovhdCost,
			decimal? PVovhdCost,
			decimal? POutCost,
			string Infobar,
			decimal? BreakQty = 1M,
			int? UseVendorPrice = 0);
	}
}

