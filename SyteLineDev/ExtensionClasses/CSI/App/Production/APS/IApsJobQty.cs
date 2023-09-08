//PROJECT NAME: Production
//CLASS NAME: IApsJobQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsJobQty
	{
		decimal? ApsJobQtyFn(
			decimal? pQtyReleased,
			decimal? pQtyComplete,
			decimal? pQtyScrapped,
			decimal? pShrinkFact,
			int? pShrinkFlag,
			int? pPrecision,
			int? pSchedulerNeedsJob);
	}
}

