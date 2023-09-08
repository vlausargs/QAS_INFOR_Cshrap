//PROJECT NAME: Data
//CLASS NAME: IFTReqQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTReqQty
	{
		decimal? FTReqQtyFn(
			decimal? QtyReleased,
			string Units,
			decimal? MatlQty,
			int? Scrap,
			decimal? ScrapFact);
	}
}

