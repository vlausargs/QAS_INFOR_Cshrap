//PROJECT NAME: Data
//CLASS NAME: IESumCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IESumCo
	{
		(int? ReturnCode,
			decimal? CoCost,
			decimal? CoLbrCostT,
			decimal? CoMatlCostT,
			decimal? CoFovhdCostT,
			decimal? CoVovhdCostT,
			decimal? CoOutCostT,
			string Infobar) ESumCoSp(
			string CoCoNum,
			int? ConvPlaces,
			decimal? CoCost,
			decimal? CoLbrCostT,
			decimal? CoMatlCostT,
			decimal? CoFovhdCostT,
			decimal? CoVovhdCostT,
			decimal? CoOutCostT,
			string Infobar);
	}
}

