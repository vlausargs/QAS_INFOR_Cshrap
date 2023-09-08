//PROJECT NAME: Data
//CLASS NAME: IJobChildQtyI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobChildQtyI
	{
		decimal? JobChildQtyIFn(
			decimal? QtyReleased,
			string Units,
			decimal? MatlQty,
			int? FromExtScrap,
			decimal? JbmExtScrap,
			int? IsItemScrap,
			decimal? ShrinkFact);

		(int? ReturnCode,
			decimal? QtyReleased,
			string Infobar) JobChildqtyISp(
			decimal? QtyReleased,
			string Units,
			decimal? MatlQty,
			int? FromExtScrap,
			decimal? JbmExtScrap,
			int? IsItemScrap,
			decimal? ShrinkFact,
			string Infobar);
	}
}

