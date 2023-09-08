//PROJECT NAME: Data
//CLASS NAME: IESumCoh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IESumCoh
	{
		(int? ReturnCode,
			decimal? CohCost,
			decimal? CohLbrCostT,
			decimal? CohMatlCostT,
			decimal? CohFovhdCostT,
			decimal? CohVovhdCostT,
			decimal? CohOutCostT,
			string Infobar) ESumCohSp(
			string CohCoNum,
			int? ConvPlaces,
			decimal? CohCost,
			decimal? CohLbrCostT,
			decimal? CohMatlCostT,
			decimal? CohFovhdCostT,
			decimal? CohVovhdCostT,
			decimal? CohOutCostT,
			string Infobar);
	}
}

