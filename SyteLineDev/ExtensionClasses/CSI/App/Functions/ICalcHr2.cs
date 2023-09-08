//PROJECT NAME: Data
//CLASS NAME: ICalcHr2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcHr2
	{
		int? CalcHr2Sp(
			decimal? PSchedTicks,
			string POperSched,
			decimal? PQtyReleased,
			decimal? PQtyComplete,
			decimal? PQtyScrapped,
			decimal? PRunTicksLbr,
			decimal? PEfficiency,
			decimal? PRunHrsTLbr,
			decimal? PSetupHrsT,
			string PSchedDriver,
			decimal? PRunHrsTMch,
			decimal? PRunTicksMch);
	}
}

