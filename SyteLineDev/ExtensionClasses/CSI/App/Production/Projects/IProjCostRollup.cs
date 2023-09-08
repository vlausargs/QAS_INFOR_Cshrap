//PROJECT NAME: Production
//CLASS NAME: IProjCostRollup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjCostRollup
	{
		(int? ReturnCode, string Infobar) ProjCostRollupSp(string FromProjNum,
		string ToProjNum,
		string ProjStatList,
		string CostCodeOrMileStone,
		int? CalcRevenue,
		string Infobar,
		int? TaskNum = null,
		int? Seq = null);
	}
}

