//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQSplitQtysToPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQSplitQtysToPrice
	{
		(int? ReturnCode,
			decimal? BrkQtyConv1,
			decimal? BrkQtyConv2,
			decimal? BrkQtyConv3,
			decimal? BrkQtyConv4,
			decimal? BrkQtyConv5,
			decimal? BrkQtyConv6,
			decimal? BrkQtyConv7,
			decimal? BrkQtyConv8,
			decimal? BrkQtyConv9,
			decimal? BrkQtyConv10,
			string Infobar) SSSRFQSplitQtysToPriceSp(
			decimal? SingleQty,
			string QtysToPrice,
			decimal? BrkQtyConv1,
			decimal? BrkQtyConv2,
			decimal? BrkQtyConv3,
			decimal? BrkQtyConv4,
			decimal? BrkQtyConv5,
			decimal? BrkQtyConv6,
			decimal? BrkQtyConv7,
			decimal? BrkQtyConv8,
			decimal? BrkQtyConv9,
			decimal? BrkQtyConv10,
			string Infobar);
	}
}

