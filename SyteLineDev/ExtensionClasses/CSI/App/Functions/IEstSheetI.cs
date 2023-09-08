//PROJECT NAME: Data
//CLASS NAME: IEstSheetI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEstSheetI
	{
		(int? ReturnCode,
			decimal? LCost1,
			decimal? LCost2,
			decimal? LCost3,
			decimal? LCost4,
			decimal? LCost5,
			decimal? LCost6,
			decimal? LCost7,
			decimal? LCost8,
			decimal? UCost1,
			decimal? UCost2,
			decimal? UCost3,
			decimal? UCost4,
			decimal? UCost5,
			decimal? UCost6,
			decimal? UCost7,
			decimal? UCost8,
			string Infobar) EstSheetISp(
			Guid? PJobRowid,
			decimal? LCost1,
			decimal? LCost2,
			decimal? LCost3,
			decimal? LCost4,
			decimal? LCost5,
			decimal? LCost6,
			decimal? LCost7,
			decimal? LCost8,
			decimal? UCost1,
			decimal? UCost2,
			decimal? UCost3,
			decimal? UCost4,
			decimal? UCost5,
			decimal? UCost6,
			decimal? UCost7,
			decimal? UCost8,
			string Infobar,
			decimal? BreakQty = 1M,
			int? UseVendorPrice = 0);
	}
}

