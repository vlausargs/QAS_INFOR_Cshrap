//PROJECT NAME: Production
//CLASS NAME: IPmfPnCalcNoJobs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfPnCalcNoJobs
	{
		(int? ReturnCode,
			string InfoBar,
			decimal? TotalQty,
			int? NoJobs,
			decimal? FirstJobSize,
			decimal? LastJobSize) PmfPnCalcNoJobsSp(
			string InfoBar = null,
			decimal? TotalQty = null,
			decimal? MinSize = null,
			decimal? MaxSize = null,
			decimal? SizeMultiple = 0,
			int? NoJobs = null,
			decimal? FirstJobSize = null,
			decimal? LastJobSize = null);
	}
}

