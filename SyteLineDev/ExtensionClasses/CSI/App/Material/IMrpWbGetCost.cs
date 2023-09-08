//PROJECT NAME: Material
//CLASS NAME: IMrpWbGetCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbGetCost
	{
		(int? ReturnCode, int? LeadTime,
		decimal? UnitCost,
		string Infobar) MrpWbGetCostSp(string Item,
		decimal? ReqdQty,
		string VendNum,
		string ToWhse,
		int? LeadTime,
		decimal? UnitCost,
		string Infobar = null);
	}
}

