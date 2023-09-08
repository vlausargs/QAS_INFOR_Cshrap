//PROJECT NAME: Production
//CLASS NAME: IRSQC_SetUnitCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_SetUnitCost
	{
		(int? ReturnCode, decimal? o_unit_cost,
		string Infobar) RSQC_SetUnitCostSp(int? i_vrma,
		decimal? o_unit_cost,
		string Infobar);
	}
}

