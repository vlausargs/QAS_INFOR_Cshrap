//PROJECT NAME: Data
//CLASS NAME: ICalcHrs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICalcHrs
	{
		(int? ReturnCode,
			int? SetupTicks,
			int? RunTicks) CalcHrsSp(
			string pOperSched,
			decimal? PEfficiency,
			decimal? pQtyReleased,
			decimal? pQtyScrapped,
			decimal? pQtyComplete,
			decimal? pRunHrsTLbr,
			decimal? pSetupHrsT,
			decimal? pRunTicksLbr,
			decimal? pSchedTicks,
			decimal? pSetupTicks,
			string pSchedDriver,
			decimal? pRunHrsTMch,
			decimal? pRunTicksMch,
			int? SetupTicks,
			int? RunTicks);

		decimal? CalcHrsFn(
			string pType,
			string pEmpNum,
			int? pSeq);
	}
}

