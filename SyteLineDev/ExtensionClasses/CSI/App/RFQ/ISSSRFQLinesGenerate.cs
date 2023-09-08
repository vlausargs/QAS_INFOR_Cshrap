//PROJECT NAME: RFQ
//CLASS NAME: ISSSRFQLinesGenerate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRFQLinesGenerate
	{
		(int? ReturnCode,
			string Infobar) SSSRFQLinesGenerateSp(
			string Method,
			int? FromGenUtils,
			string LastRFQNum,
			int? LastRFQLine,
			int? Seq = 1,
			string Item = null,
			string UM = null,
			string RefType = null,
			string RefNum = null,
			int? RefLineSuf = null,
			int? RefRelease = null,
			DateTime? DueDate = null,
			decimal? SelectedQty = null,
			decimal? BrkQtyConv1 = null,
			decimal? BrkQtyConv2 = null,
			decimal? BrkQtyConv3 = null,
			decimal? BrkQtyConv4 = null,
			decimal? BrkQtyConv5 = null,
			decimal? BrkQtyConv6 = null,
			decimal? BrkQtyConv7 = null,
			decimal? BrkQtyConv8 = null,
			decimal? BrkQtyConv9 = null,
			decimal? BrkQtyConv10 = null,
			string PSessionId = null,
			string Infobar = null,
			string Description = null,
			string Buyer = null);
	}
}

