//PROJECT NAME: Logistics
//CLASS NAME: IAU_RepricePoitemorBlanketLines.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAU_RepricePoitemorBlanketLines
	{
		int? AU_RepricePoitemorBlanketLinesSp(int? LineorBlanketLine,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		decimal? NewPrice);
	}
}

