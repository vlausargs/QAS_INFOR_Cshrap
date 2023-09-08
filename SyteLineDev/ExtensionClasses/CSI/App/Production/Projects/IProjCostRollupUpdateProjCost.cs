//PROJECT NAME: Production
//CLASS NAME: IProjCostRollupUpdateProjCost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjCostRollupUpdateProjCost
	{
		(int? ReturnCode,
			string Infobar) ProjCostRollupUpdateProjCostSp(
			int? ProjtaskTaskNum,
			string CostCode,
			int? ProjmatlSeq,
			string CostCodeType,
			int? Year,
			int? Period,
			decimal? Amount,
			int? CurrencyPlaces,
			string ProjType,
			string Infobar);
	}
}

