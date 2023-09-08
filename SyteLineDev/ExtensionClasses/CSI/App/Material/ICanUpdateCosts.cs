//PROJECT NAME: Material
//CLASS NAME: ICanUpdateCosts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICanUpdateCosts
	{
		(int? ReturnCode, int? PCanUpdateCosts,
		int? PCanPromptCost1,
		int? PCanPromptCost2,
		int? PDisplayUnitCosts,
		int? CanUpdateCur) CanUpdateCostsSp(string PItem,
		string PCostType,
		string PCostMethod,
		string PPMTCode,
		string PJob = "",
		int? PSuffix = null,
		int? PCanUpdateCosts = null,
		int? PCanPromptCost1 = null,
		int? PCanPromptCost2 = null,
		int? PDisplayUnitCosts = null,
		int? CanUpdateCur = null,
		string Whse = null);
	}
}

