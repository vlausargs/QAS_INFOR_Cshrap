//PROJECT NAME: Data
//CLASS NAME: ICalcHr1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcHr1
	{
		int? CalcHr1Sp(
			decimal? pSchedTicks,
			string pOperSched,
			decimal? pQtyComplete,
			decimal? pRunHrsTLbr,
			decimal? pSetupTicks,
			decimal? pEfficiency,
			decimal? pSetupHrsT,
			string pSchedDriver,
			decimal? pRunHrsTMch);
	}
}

