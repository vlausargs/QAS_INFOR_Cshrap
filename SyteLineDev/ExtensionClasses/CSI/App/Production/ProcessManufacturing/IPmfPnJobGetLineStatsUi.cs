//PROJECT NAME: Production
//CLASS NAME: IPmfPnJobGetLineStatsUi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnJobGetLineStatsUi
	{
		(int? ReturnCode,
			string InfoBar,
			decimal? MatlPctComplete,
			decimal? ProdPctComplete) PmfPnJobGetLineStatsUiSp(
			string InfoBar = null,
			Guid? PnRp = null,
			Guid? JobRp = null,
			decimal? MatlPctComplete = null,
			decimal? ProdPctComplete = null);
	}
}

