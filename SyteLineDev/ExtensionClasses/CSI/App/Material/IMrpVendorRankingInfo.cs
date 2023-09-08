//PROJECT NAME: Material
//CLASS NAME: IMrpVendorRankingInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpVendorRankingInfo
	{
		(int? ReturnCode,
			string VendNum,
			int? LeadTime,
			decimal? UnitCost,
			string Infobar) MrpVendorRankingInfoSp(
			string Item,
			decimal? ReqdQty,
			int? Rank,
			string SourceRuleVendNum,
			string VendNum,
			int? LeadTime,
			decimal? UnitCost,
			string Infobar);
	}
}

