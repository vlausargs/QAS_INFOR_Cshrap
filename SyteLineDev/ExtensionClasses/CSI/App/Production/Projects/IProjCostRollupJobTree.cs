//PROJECT NAME: Production
//CLASS NAME: IProjCostRollupJobTree.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjCostRollupJobTree
	{
		(int? ReturnCode,
			decimal? AccumMatlCost,
			decimal? AccumLbrCost,
			decimal? AccumFovhdCost,
			decimal? AccumVovhdCost,
			decimal? AccumOutCost,
			string Infobar) ProjCostRollupJobTreeSp(
			string PJobType,
			string PJob,
			int? PSuffix,
			string PItem,
			decimal? PQty,
			int? ProjtaskTaskNum,
			string ProjmatlCostCode,
			int? ProjmatlSeq,
			int? CurrencyPlaces,
			int? MrpParmScrapFlag,
			int? Level,
			string ProjType,
			decimal? AccumMatlCost,
			decimal? AccumLbrCost,
			decimal? AccumFovhdCost,
			decimal? AccumVovhdCost,
			decimal? AccumOutCost,
			string Infobar);
	}
}

